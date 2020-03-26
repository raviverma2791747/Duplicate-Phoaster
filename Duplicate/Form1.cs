using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;


namespace Duplicate
{
    public partial class Form : System.Windows.Forms.Form
    {
        List<string> listFiles = new List<string>();
        //Total photos =  Total duplicate photos + Total groups
        int total_groups = 0; //Counts total groups of duplicate and single  photos
        int total_duplicates = 0; //Total duplicate photos;
                                  // bool operation = true; // state of operation

        public Form()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            listFiles.Clear();
            listView.Items.Clear();
            total_groups = 0;
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select Your Path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string extn;
                    txtPath.Text = fbd.SelectedPath;
                    foreach (string item in System.IO.Directory.GetFiles(fbd.SelectedPath))
                    {
                        extn = Path.GetExtension(item);
                        if (extn == ".PNG" || extn == ".JPEG" || extn == ".JPG" || extn == ".BMP")
                        {
                            imageList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
                            System.IO.FileInfo fi = new System.IO.FileInfo(item);
                            listFiles.Add(fi.FullName);
                            listView.Items.Add(fi.Name, imageList.Images.Count - 1);
                        }
                    }
                    textTotalFiles.Text = Convert.ToString(imageList.Images.Count);
                }
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.FocusedItem != null)
            {
                System.Diagnostics.Process.Start(listFiles[listView.FocusedItem.Index]);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            listViewScanned.Items.Clear();  //Clear garbage value if any
            progressBar.Minimum = 0;        //initialize progresbar minimum value
            progressBar.Maximum = listFiles.Count;    //initialize progress bar maximum value
            progressBar.Value = 0;                  //starting value of progress bar
            backgroundWorkerStatus.RunWorkerAsync();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            progressBar.Minimum = 0;        //initialize progresbar minimum value
            progressBar.Maximum = listFiles.Count;    //initialize progress bar maximum value
            progressBar.Value = 0;   //starting value of progress bar
            if (total_groups < listFiles.Count)
            {
                for (int i = 0; i < listFiles.Count; i++)
                {
                    progressBar.Value = i;
                    string path = Path.Combine(txtPath.Text, listViewScanned.Items[i].Text);
                    if (listViewScanned.Items[i].Checked == true)
                    {
                        File.Delete(path);
                    }
                }
                progressBar.Value += 1;
                textBoxStatus.Text = "Done!";
            }
            else
            {
                progressBar.Value = listFiles.Count;
                textBoxStatus.Text = "Nothing To Do!";
            }
        }

        private void linkLabelPrj_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/raviverma2791747/Duplicate-Phoaster");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            backgroundWorkerStatus.CancelAsync();
        }

        private void backgroundWorkerStatus_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Process of Duplicate file scanning takes place here
            //string currStatus;
            System.Windows.Forms.ListView scan = new System.Windows.Forms.ListView();
            scan.CheckBoxes = true;
            ImageList scanImage = new ImageList();
            scan.LargeImageList = scanImage;
            total_groups = 0; //initialize total groups before scan 
            total_duplicates = 0; //Total duplicate photos
            int cnt = 0;    //index for listViewScanned 
            List<bool> visited = new List<bool>(); //saves the info already grouped photos
            visited.Clear(); //remove garbage value
            //DateTime startTime = DateTime.Now;// Intial time when scan started
            //DateTime currentTime = DateTime.Now; // current time during scan
            for (int i = 0; i < listFiles.Count; i++)  //initialize it with true values meaning not grouped is true
            {
                visited.Add(false);
            }
            for (int i = 0; i < listFiles.Count; i++)
            {
                if (backgroundWorkerStatus.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                backgroundWorkerStatus.ReportProgress(i);
                //progressBar.Value = i;         //updating  progressbar value with progress in task
                //currentTime = DateTime.Now;
                //textBoxStatus.Text = Convert.ToString((currentTime.Minute - startTime.Minute )/(i+1)* (listFiles.Count - i));
                if (visited[i] == false)  //checking if already visited 
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(listFiles[i]);
                    for (int j = 0; j < listFiles.Count; j++)
                    {
                        System.IO.FileInfo fi2 = new System.IO.FileInfo(listFiles[j]);
                        if (fi.Length == fi2.Length && fi.Extension == fi2.Extension)
                        {

                            if (!visited[i])
                            {
                                ShellFile shellFile = ShellFile.FromFilePath(listFiles[i]);
                                Bitmap shellThumb = shellFile.Thumbnail.ExtraLargeBitmap;
                                imageListScanned.Images.Add(shellThumb);
                                scan.Items.Add(fi.Name, cnt);
                                visited[i] = true;
                                total_groups += 1;   //updating groups
                                cnt += 1;  //updating index of listViewScanned.Items
                            }

                            if (!visited[j])
                            {

                                imageListScanned.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(listFiles[j]));
                                scan.Items.Add(fi2.Name, cnt);
                                scan.Items[cnt].Checked = true;
                                visited[j] = true;
                                cnt += 1;  //updating index of listViewScanned.Items
                            }
                        }
                    }
                }
                e.Result = scan;
                // textBoxGroup.Text = Convert.ToString(total_groups); //Displaying total groups identified
                textBoxGroup.Invoke((Action)(() => textBoxGroup.Text = Convert.ToString(total_groups)));
                total_duplicates = listFiles.Count - total_groups; //Calculate total duplicate photos
                // textBoxDuplicate.Text = Convert.ToString(total_duplicates); //Display Total Duplicate photos
                textBoxDuplicate.Invoke((Action)(() => textBoxDuplicate.Text = Convert.ToString(total_duplicates)));
                if (total_groups == listFiles.Count)
                {
                    textBoxStatus.Invoke((Action)(() => textBoxStatus.Text = "No duplicates found!"));
                }
                else
                {
                    textBoxStatus.Invoke((Action)(() => textBoxStatus.Text = "Duplicates found!"));
                }
            }
        }

        private void backgroundWorkerStatus_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            textBoxStatus.Text = Convert.ToString(progressBar.Value) + " files scanned";


        }

        private void backgroundWorkerStatus_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled == false)
            {
                progressBar.Value += 1;
                System.Windows.Forms.ListView result = (System.Windows.Forms.ListView)e.Result;
                for (int i = 0; i < listFiles.Count; i++)
                {
                    listViewScanned.Items.Add((ListViewItem)result.Items[i].Clone());
                }
                MessageBox.Show("Done!");
            }
            else
            {
                progressBar.Value = listFiles.Count;
                MessageBox.Show("Scan Successfully Cancelled!");
            }
        }
    }
}
