using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
            using(FolderBrowserDialog fbd = new FolderBrowserDialog() {Description = "Select Your Path."})
            {
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    string extn;
                    txtPath.Text = fbd.SelectedPath;
                    foreach(string item in System.IO.Directory.GetFiles(fbd.SelectedPath))
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
            if(listView.FocusedItem != null)
            {
                System.Diagnostics.Process.Start(listFiles[listView.FocusedItem.Index]);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Process of Duplicate file scanning takes place here
            total_groups = 0; //initialize total groups before scan 
            total_duplicates = 0; //Total duplicate photos
            int cnt = 0;    //index for listViewScanned 
            List<bool> visited = new List<bool>(); //saves the info already grouped photos
            visited.Clear(); //remove garbage value
           for(int i=0;i<listFiles.Count;i++)  //initialize it with true values meaning not grouped is true
            {
                visited.Add(false);
            }
            listViewScanned.Items.Clear();  //Clear garbage value if any
            progressBar.Minimum = 0;        //initialize progresbar minimum value
            progressBar.Maximum = listFiles.Count;    //initialize progress bar maximum value
            progressBar.Value =  0;                  //starting value of progress bar
            for (int i = 0; i < listFiles.Count; i++)     
            {
                progressBar.Value = i;         //updating  progressbar value with progress in task
                if (visited[i] == false)  //checking if already visited 
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(listFiles[i]);
                    for (int j = 0 ; j < listFiles.Count; j++)
                    {
                        System.IO.FileInfo fi2 = new System.IO.FileInfo(listFiles[j]);
                        if (fi.Length == fi2.Length && fi.Extension == fi2.Extension)
                        {
                            
                           if (!visited[i])
                            {
                               
                                imageListScanned.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(listFiles[i]));
                                listViewScanned.Items.Add(fi.Name, cnt);
                                visited[i] = true;
                                total_groups += 1;   //updating groups
                                cnt += 1;  //updating index of listViewScanned.Items
                            }
                          
                            if (!visited[j])
                            {
                                
                                imageListScanned.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(listFiles[j]));
                                listViewScanned.Items.Add(fi2.Name,cnt);
                                listViewScanned.Items[cnt].Checked = true;
                                visited[j] = true;
                                cnt += 1;  //updating index of listViewScanned.Items
                            }
                        }
                    }
                }
                progressBar.Value += 1;
                textBoxGroup.Text = Convert.ToString(total_groups); //Displaying total groups identified
                total_duplicates = listFiles.Count - total_groups; //Calculate total duplicate photos
                textBoxDuplicate.Text = Convert.ToString(total_duplicates); //Display Total Duplicate photos
                if (total_groups == listFiles.Count)
                {
                    textBoxStatus.Text = "No duplicates found!";
                }
                else
                {
                    textBoxStatus.Text = "Duplicates found!";
                }
            }
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
            //operation = false;
        }
    }
}
