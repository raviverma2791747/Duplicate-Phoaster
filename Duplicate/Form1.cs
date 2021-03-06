﻿using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using About;

namespace Duplicate
{
    public partial class Form : System.Windows.Forms.Form
    {
        List<string> listFiles = new List<string>(); //Stores complete list of files to be scanned 
        //Total photos =  Total duplicate photos + Total groups
        int total_groups = 0; //Counts total groups of duplicate and single  photos
        int total_duplicates = 0; //Total duplicate photos;

        public Form()
        {
            InitializeComponent();
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            listFiles.Clear();              //clear garbage value
            listView.Items.Clear();
            total_groups = 0;
            textBoxStatus.Text = "Loading Files";
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select Your Path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string extn;
                    txtPath.Text = fbd.SelectedPath;
                    foreach (string item in Directory.GetFiles(fbd.SelectedPath))
                    {
                        extn = Path.GetExtension(item);
                        if (extn == ".PNG" || extn == ".JPEG" || extn == ".JPG" || extn == ".BMP" || extn == ".ICO" || extn == ".GIF")
                        {
                            imageList.Images.Add(Icon.ExtractAssociatedIcon(item));
                            FileInfo fi = new FileInfo(item);
                            listFiles.Add(fi.FullName);
                            listView.Items.Add(fi.Name, imageList.Images.Count - 1);
                        }
                    }
                    textTotalFiles.Text = Convert.ToString(imageList.Images.Count);
                }
            }
            btnStart.Enabled = true;
            btnOpen.Enabled = false;
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If user clicks the image in the program it opens the image
            if (listView.FocusedItem != null)
            {
                System.Diagnostics.Process.Start(listFiles[listView.FocusedItem.Index]);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (listFiles.Count == 0)
            {
                textBoxStatus.Text = "No files to Scan";
                btnStart.Enabled = false;
                btnOpen.Enabled = true;
            }
            else
            {
                listViewScanned.Items.Clear();  //Clear garbage value if any
                progressBar.Minimum = 0;        //initialize progresbar minimum value
                progressBar.Maximum = listFiles.Count;    //initialize progress bar maximum value
                progressBar.Value = 0;                  //starting value of progress bar
                progressBar.ForeColor = Color.Blue;
                backgroundWorkerScan.RunWorkerAsync();
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
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
            backgroundWorkerScan.CancelAsync();
            btnDelete.Enabled = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnOpen.Enabled = true;
        }

        private void backgroundWorkerScan_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Process of Duplicate file scanning takes place here
            //string currStatus;
            System.Windows.Forms.ListView scan = new System.Windows.Forms.ListView
            {
                CheckBoxes = true
            };
            total_groups = 0; //initialize total groups before scan 
            total_duplicates = 0; //Total duplicate photos
            int scan_index = 0;    //index for listViewScanned 
            List<bool> visited = new List<bool>(); //saves the info already grouped photos
            visited.Clear(); //remove garbage value
            //DateTime startTime = DateTime.Now;// Intial time when scan started
            //DateTime currentTime = DateTime.Now; // current time during scan
            for (int i = 0; i < listFiles.Count; i++)  //initialize it with true values meaning not grouped is true
            {
                visited.Add(false);
            }
            FileInfo fi; //= new FileInfo();
            FileInfo fi2; //= new FileInfo();
            ShellFile shellFile; //= ShellFile.FromFilePath(listFiles[i]);
            Bitmap shellThumb;//= shellFile.Thumbnail.ExtraLargeBitmap;
            for (int i = 0; i < listFiles.Count; i++)
            {
                if (backgroundWorkerScan.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                backgroundWorkerScan.ReportProgress(i);
                //progressBar.Value = i;         //updating  progressbar value with progress in task
                //currentTime = DateTime.Now;
                //textBoxStatus.Text = Convert.ToString((currentTime.Minute - startTime.Minute )/(i+1)* (listFiles.Count - i));
                if (visited[i] == false)  //checking if already visited 
                {
                    fi = new FileInfo(listFiles[i]);
                    for (int j = 0; j < listFiles.Count; j++)
                    {
                         fi2 = new FileInfo(listFiles[j]);
                        if (fi.Length == fi2.Length && fi.Extension == fi2.Extension)
                        {

                            if (!visited[i])
                            {
                                shellFile = ShellFile.FromFilePath(listFiles[i]);
                                shellThumb = shellFile.Thumbnail.ExtraLargeBitmap;
                                imageListScanned.Images.Add(shellThumb);
                                scan.Items.Add(fi.Name, scan_index);
                                visited[i] = true;
                                total_groups += 1;   //updating groups
                                scan_index += 1;  //updating index of listViewScanned.Items
                            }

                            if (!visited[j])
                            {
                                shellFile = ShellFile.FromFilePath(listFiles[j]);
                                shellThumb = shellFile.Thumbnail.ExtraLargeBitmap;
                                imageListScanned.Images.Add(shellThumb);
                                scan.Items.Add(fi2.Name, scan_index);
                                scan.Items[scan_index].Checked = true;
                                visited[j] = true;
                                scan_index += 1;  //updating index of listViewScanned.Items
                            }
                        }
                    }
                }
                // textBoxGroup.Text = Convert.ToString(total_groups); //Displaying total groups identified
                textBoxGroup.Invoke((Action)(() => textBoxGroup.Text = Convert.ToString(total_groups)));
                total_duplicates = listFiles.Count - total_groups; //Calculate total duplicate photos
                // textBoxDuplicate.Text = Convert.ToString(total_duplicates); //Display Total Duplicate photos
                textBoxDuplicate.Invoke((Action)(() => textBoxDuplicate.Text = Convert.ToString(total_duplicates)));
            }
            e.Result = scan;
            if (total_groups == listFiles.Count)
            {
                textBoxStatus.Invoke((Action)(() => textBoxStatus.Text = "No duplicates found!"));
            }
            else
            {
                textBoxStatus.Invoke((Action)(() => textBoxStatus.Text = "Duplicates found!"));
            }
        }

        private void backgroundWorkerScan_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            textBoxStatus.Text = Convert.ToString(progressBar.Value) + " files scanned";
        }

        private void backgroundWorkerScan_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == false)
            {
                progressBar.Value += 1;
                ListView result = (ListView)e.Result;
                for (int i = 0; i < listFiles.Count; i++)
                {
                    listViewScanned.Items.Add((ListViewItem)result.Items[i].Clone());
                }
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnDelete.Enabled = true;
                btnOpen.Enabled = true;
                // MessageBox.Show("Done!");
            }
            else
            {
                progressBar.Value = listFiles.Count;
                // MessageBox.Show("Scan Successfully Cancelled!");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        
    }
}