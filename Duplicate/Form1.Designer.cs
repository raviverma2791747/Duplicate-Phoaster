namespace Duplicate
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewScanned = new System.Windows.Forms.ListView();
            this.imageListScanned = new System.Windows.Forms.ImageList(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelDuplicate = new System.Windows.Forms.Label();
            this.textBoxDuplicate = new System.Windows.Forms.TextBox();
            this.labelStartStop = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.textBoxGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkLabelPrj = new System.Windows.Forms.LinkLabel();
            this.labelPrj = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorkerScan = new System.ComponentModel.BackgroundWorker();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.textTotalFiles = new System.Windows.Forms.TextBox();
            this.totalFiles = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewScanned);
            this.groupBox2.Location = new System.Drawing.Point(325, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 409);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Processed Files";
            // 
            // listViewScanned
            // 
            this.listViewScanned.AllowColumnReorder = true;
            this.listViewScanned.CheckBoxes = true;
            this.listViewScanned.GridLines = true;
            this.listViewScanned.HideSelection = false;
            this.listViewScanned.LargeImageList = this.imageListScanned;
            this.listViewScanned.Location = new System.Drawing.Point(6, 19);
            this.listViewScanned.Name = "listViewScanned";
            this.listViewScanned.Size = new System.Drawing.Size(528, 384);
            this.listViewScanned.TabIndex = 0;
            this.listViewScanned.UseCompatibleStateImageBehavior = false;
            // 
            // imageListScanned
            // 
            this.imageListScanned.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListScanned.ImageSize = new System.Drawing.Size(64, 64);
            this.imageListScanned.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 445);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(853, 23);
            this.progressBar.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelDuplicate);
            this.groupBox3.Controls.Add(this.textBoxDuplicate);
            this.groupBox3.Controls.Add(this.labelStartStop);
            this.groupBox3.Controls.Add(this.btnStop);
            this.groupBox3.Controls.Add(this.textBoxStatus);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.textBoxGroup);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Location = new System.Drawing.Point(12, 309);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 126);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Actions";
            // 
            // labelDuplicate
            // 
            this.labelDuplicate.AutoSize = true;
            this.labelDuplicate.Location = new System.Drawing.Point(121, 59);
            this.labelDuplicate.Name = "labelDuplicate";
            this.labelDuplicate.Size = new System.Drawing.Size(121, 13);
            this.labelDuplicate.TabIndex = 9;
            this.labelDuplicate.Text = "Total Duplicate Photos :";
            // 
            // textBoxDuplicate
            // 
            this.textBoxDuplicate.Location = new System.Drawing.Point(248, 56);
            this.textBoxDuplicate.Name = "textBoxDuplicate";
            this.textBoxDuplicate.ReadOnly = true;
            this.textBoxDuplicate.Size = new System.Drawing.Size(33, 20);
            this.textBoxDuplicate.TabIndex = 8;
            this.textBoxDuplicate.Text = "0";
            this.textBoxDuplicate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelStartStop
            // 
            this.labelStartStop.AutoSize = true;
            this.labelStartStop.Location = new System.Drawing.Point(6, 25);
            this.labelStartStop.Name = "labelStartStop";
            this.labelStartStop.Size = new System.Drawing.Size(122, 13);
            this.labelStartStop.TabIndex = 7;
            this.labelStartStop.Text = "Scan Duplicate Photos :";
            // 
            // btnStop
            // 
            this.btnStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStop.Location = new System.Drawing.Point(180, 19);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(51, 24);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(58, 90);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(116, 20);
            this.textBoxStatus.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status :";
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDelete.Location = new System.Drawing.Point(180, 87);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Remove Duplicates";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // textBoxGroup
            // 
            this.textBoxGroup.Location = new System.Drawing.Point(84, 56);
            this.textBoxGroup.Name = "textBoxGroup";
            this.textBoxGroup.ReadOnly = true;
            this.textBoxGroup.Size = new System.Drawing.Size(32, 20);
            this.textBoxGroup.TabIndex = 2;
            this.textBoxGroup.Text = "0";
            this.textBoxGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Groups :";
            // 
            // btnStart
            // 
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStart.Location = new System.Drawing.Point(128, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(46, 25);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(15, 10);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(66, 13);
            this.labelVersion.TabIndex = 4;
            this.labelVersion.Text = "Version : 1.5";
            // 
            // linkLabelPrj
            // 
            this.linkLabelPrj.AutoSize = true;
            this.linkLabelPrj.Location = new System.Drawing.Point(582, 9);
            this.linkLabelPrj.Name = "linkLabelPrj";
            this.linkLabelPrj.Size = new System.Drawing.Size(283, 13);
            this.linkLabelPrj.TabIndex = 5;
            this.linkLabelPrj.TabStop = true;
            this.linkLabelPrj.Text = "https://github.com/raviverma2791747/Duplicate-Phoaster";
            this.linkLabelPrj.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPrj_LinkClicked);
            // 
            // labelPrj
            // 
            this.labelPrj.AutoSize = true;
            this.labelPrj.Location = new System.Drawing.Point(501, 9);
            this.labelPrj.Name = "labelPrj";
            this.labelPrj.Size = new System.Drawing.Size(75, 13);
            this.labelPrj.TabIndex = 6;
            this.labelPrj.Text = "Source Code :";
            // 
            // btnOpen
            // 
            this.btnOpen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpen.Location = new System.Drawing.Point(6, 19);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // listView
            // 
            this.listView.HideSelection = false;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(6, 48);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(290, 173);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.textTotalFiles);
            this.groupBox1.Controls.Add(this.totalFiles);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.listView);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 277);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            // 
            // backgroundWorkerScan
            // 
            this.backgroundWorkerScan.WorkerReportsProgress = true;
            this.backgroundWorkerScan.WorkerSupportsCancellation = true;
            this.backgroundWorkerScan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerScan_DoWork);
            this.backgroundWorkerScan.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerScan_ProgressChanged);
            this.backgroundWorkerScan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerScan_RunWorkerCompleted);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(87, 22);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(209, 20);
            this.txtPath.TabIndex = 2;
            // 
            // textTotalFiles
            // 
            this.textTotalFiles.Location = new System.Drawing.Point(84, 238);
            this.textTotalFiles.Name = "textTotalFiles";
            this.textTotalFiles.ReadOnly = true;
            this.textTotalFiles.Size = new System.Drawing.Size(33, 20);
            this.textTotalFiles.TabIndex = 4;
            this.textTotalFiles.Text = "0";
            this.textTotalFiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalFiles
            // 
            this.totalFiles.AutoSize = true;
            this.totalFiles.Location = new System.Drawing.Point(17, 241);
            this.totalFiles.Name = "totalFiles";
            this.totalFiles.Size = new System.Drawing.Size(61, 13);
            this.totalFiles.TabIndex = 3;
            this.totalFiles.Text = "Total Files :";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(869, 472);
            this.Controls.Add(this.labelPrj);
            this.Controls.Add(this.linkLabelPrj);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "Duplicate Phoaster";
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewScanned;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ImageList imageListScanned;
        private System.Windows.Forms.TextBox textBoxGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.LinkLabel linkLabelPrj;
        private System.Windows.Forms.Label labelPrj;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label labelStartStop;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDuplicate;
        private System.Windows.Forms.TextBox textBoxDuplicate;
        private System.ComponentModel.BackgroundWorker backgroundWorkerScan;
        private System.Windows.Forms.TextBox textTotalFiles;
        private System.Windows.Forms.Label totalFiles;
        private System.Windows.Forms.TextBox txtPath;
    }
}

