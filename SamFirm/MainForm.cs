﻿using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace SamFirm
{
    public class MainForm : Form
    {
        //필드
        private string destinationfile;
        private Command.Firmware FW;
        public bool PauseDownload { get; set; }

        //컨트롤
        #region 컨트롤
        private CheckBox binary_checkbox;
        private CheckBox checkbox_auto;
        private CheckBox checkbox_autodecrypt;
        private CheckBox checkbox_crc;
        private CheckBox checkbox_manual;
        private Label csc_lbl;
        private TextBox csc_textbox;
        private Button decrypt_button;
        private Button download_button;
        private Label file_lbl;
        private TextBox file_textbox;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        internal Label lbl_speed;
        internal RichTextBox log_textbox;
        private Label model_lbl;
        private TextBox model_textbox;
        private Label pda_lbl;
        private TextBox pda_textbox;
        private Label phone_lbl;
        private TextBox phone_textbox;
        private ProgressBar progressBar;
        private Label region_lbl;
        private TextBox region_textbox;
        private SaveFileDialog saveFileDialog1;
        private Label size_lbl;
        private TextBox size_textbox;
        private Button update_button;
        private Label version_lbl;
        private TextBox version_textbox;
        #endregion

        //기본 생성자
        public MainForm()
        {
            this.InitializeComponent();
        }

        //컴포넌트 초기화 메소드
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.model_textbox = new System.Windows.Forms.TextBox();
            this.model_lbl = new System.Windows.Forms.Label();
            this.download_button = new System.Windows.Forms.Button();
            this.log_textbox = new System.Windows.Forms.RichTextBox();
            this.region_lbl = new System.Windows.Forms.Label();
            this.region_textbox = new System.Windows.Forms.TextBox();
            this.pda_lbl = new System.Windows.Forms.Label();
            this.pda_textbox = new System.Windows.Forms.TextBox();
            this.csc_lbl = new System.Windows.Forms.Label();
            this.csc_textbox = new System.Windows.Forms.TextBox();
            this.update_button = new System.Windows.Forms.Button();
            this.phone_lbl = new System.Windows.Forms.Label();
            this.phone_textbox = new System.Windows.Forms.TextBox();
            this.file_lbl = new System.Windows.Forms.Label();
            this.file_textbox = new System.Windows.Forms.TextBox();
            this.version_lbl = new System.Windows.Forms.Label();
            this.version_textbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkbox_manual = new System.Windows.Forms.CheckBox();
            this.checkbox_auto = new System.Windows.Forms.CheckBox();
            this.binary_checkbox = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.decrypt_button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_speed = new System.Windows.Forms.Label();
            this.checkbox_autodecrypt = new System.Windows.Forms.CheckBox();
            this.checkbox_crc = new System.Windows.Forms.CheckBox();
            this.size_textbox = new System.Windows.Forms.TextBox();
            this.size_lbl = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // model_textbox
            // 
            this.model_textbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.model_textbox.Location = new System.Drawing.Point(113, 25);
            this.model_textbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.model_textbox.Name = "model_textbox";
            this.model_textbox.Size = new System.Drawing.Size(197, 27);
            this.model_textbox.TabIndex = 0;
            // 
            // model_lbl
            // 
            this.model_lbl.AutoSize = true;
            this.model_lbl.Location = new System.Drawing.Point(11, 29);
            this.model_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.model_lbl.Name = "model_lbl";
            this.model_lbl.Size = new System.Drawing.Size(53, 20);
            this.model_lbl.TabIndex = 1;
            this.model_lbl.Text = "Model";
            // 
            // download_button
            // 
            this.download_button.Location = new System.Drawing.Point(99, 135);
            this.download_button.Margin = new System.Windows.Forms.Padding(0);
            this.download_button.Name = "download_button";
            this.download_button.Size = new System.Drawing.Size(125, 27);
            this.download_button.TabIndex = 13;
            this.download_button.Text = "Download";
            this.download_button.UseVisualStyleBackColor = true;
            this.download_button.Click += new System.EventHandler(this.Download_button_Click);
            // 
            // log_textbox
            // 
            this.log_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log_textbox.Location = new System.Drawing.Point(13, 269);
            this.log_textbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.log_textbox.Name = "log_textbox";
            this.log_textbox.ReadOnly = true;
            this.log_textbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.log_textbox.Size = new System.Drawing.Size(851, 257);
            this.log_textbox.TabIndex = 3;
            this.log_textbox.TabStop = false;
            this.log_textbox.Text = "";
            // 
            // region_lbl
            // 
            this.region_lbl.AutoSize = true;
            this.region_lbl.Location = new System.Drawing.Point(11, 59);
            this.region_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.region_lbl.Name = "region_lbl";
            this.region_lbl.Size = new System.Drawing.Size(57, 20);
            this.region_lbl.TabIndex = 5;
            this.region_lbl.Text = "Region";
            // 
            // region_textbox
            // 
            this.region_textbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.region_textbox.Location = new System.Drawing.Point(113, 55);
            this.region_textbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.region_textbox.Name = "region_textbox";
            this.region_textbox.Size = new System.Drawing.Size(197, 27);
            this.region_textbox.TabIndex = 1;
            // 
            // pda_lbl
            // 
            this.pda_lbl.AutoSize = true;
            this.pda_lbl.Location = new System.Drawing.Point(13, 17);
            this.pda_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pda_lbl.Name = "pda_lbl";
            this.pda_lbl.Size = new System.Drawing.Size(39, 20);
            this.pda_lbl.TabIndex = 7;
            this.pda_lbl.Text = "PDA";
            // 
            // pda_textbox
            // 
            this.pda_textbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.pda_textbox.Location = new System.Drawing.Point(105, 14);
            this.pda_textbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pda_textbox.Name = "pda_textbox";
            this.pda_textbox.Size = new System.Drawing.Size(197, 27);
            this.pda_textbox.TabIndex = 4;
            // 
            // csc_lbl
            // 
            this.csc_lbl.AutoSize = true;
            this.csc_lbl.Location = new System.Drawing.Point(13, 47);
            this.csc_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.csc_lbl.Name = "csc_lbl";
            this.csc_lbl.Size = new System.Drawing.Size(37, 20);
            this.csc_lbl.TabIndex = 9;
            this.csc_lbl.Text = "CSC";
            // 
            // csc_textbox
            // 
            this.csc_textbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.csc_textbox.Location = new System.Drawing.Point(105, 44);
            this.csc_textbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.csc_textbox.Name = "csc_textbox";
            this.csc_textbox.Size = new System.Drawing.Size(197, 27);
            this.csc_textbox.TabIndex = 5;
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(188, 215);
            this.update_button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(124, 27);
            this.update_button.TabIndex = 10;
            this.update_button.Text = "Check Update";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.Update_button_Click);
            // 
            // phone_lbl
            // 
            this.phone_lbl.AutoSize = true;
            this.phone_lbl.Location = new System.Drawing.Point(13, 77);
            this.phone_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phone_lbl.Name = "phone_lbl";
            this.phone_lbl.Size = new System.Drawing.Size(53, 20);
            this.phone_lbl.TabIndex = 12;
            this.phone_lbl.Text = "Phone";
            // 
            // phone_textbox
            // 
            this.phone_textbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.phone_textbox.Location = new System.Drawing.Point(105, 74);
            this.phone_textbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.phone_textbox.Name = "phone_textbox";
            this.phone_textbox.Size = new System.Drawing.Size(197, 27);
            this.phone_textbox.TabIndex = 6;
            // 
            // file_lbl
            // 
            this.file_lbl.AutoSize = true;
            this.file_lbl.Location = new System.Drawing.Point(8, 29);
            this.file_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.file_lbl.Name = "file_lbl";
            this.file_lbl.Size = new System.Drawing.Size(32, 20);
            this.file_lbl.TabIndex = 13;
            this.file_lbl.Text = "File";
            // 
            // file_textbox
            // 
            this.file_textbox.Location = new System.Drawing.Point(100, 21);
            this.file_textbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.file_textbox.Name = "file_textbox";
            this.file_textbox.ReadOnly = true;
            this.file_textbox.Size = new System.Drawing.Size(385, 27);
            this.file_textbox.TabIndex = 20;
            this.file_textbox.TabStop = false;
            // 
            // version_lbl
            // 
            this.version_lbl.AutoSize = true;
            this.version_lbl.Location = new System.Drawing.Point(8, 59);
            this.version_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.version_lbl.Name = "version_lbl";
            this.version_lbl.Size = new System.Drawing.Size(60, 20);
            this.version_lbl.TabIndex = 15;
            this.version_lbl.Text = "Version";
            // 
            // version_textbox
            // 
            this.version_textbox.Location = new System.Drawing.Point(100, 51);
            this.version_textbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.version_textbox.Name = "version_textbox";
            this.version_textbox.ReadOnly = true;
            this.version_textbox.Size = new System.Drawing.Size(385, 27);
            this.version_textbox.TabIndex = 30;
            this.version_textbox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.checkbox_manual);
            this.groupBox1.Controls.Add(this.checkbox_auto);
            this.groupBox1.Controls.Add(this.binary_checkbox);
            this.groupBox1.Controls.Add(this.model_textbox);
            this.groupBox1.Controls.Add(this.model_lbl);
            this.groupBox1.Controls.Add(this.update_button);
            this.groupBox1.Controls.Add(this.region_textbox);
            this.groupBox1.Controls.Add(this.region_lbl);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(349, 248);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Firmware Info";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.phone_textbox);
            this.groupBox3.Controls.Add(this.csc_lbl);
            this.groupBox3.Controls.Add(this.csc_textbox);
            this.groupBox3.Controls.Add(this.pda_lbl);
            this.groupBox3.Controls.Add(this.pda_textbox);
            this.groupBox3.Controls.Add(this.phone_lbl);
            this.groupBox3.Location = new System.Drawing.Point(8, 107);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(333, 107);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // checkbox_manual
            // 
            this.checkbox_manual.AutoSize = true;
            this.checkbox_manual.Location = new System.Drawing.Point(172, 87);
            this.checkbox_manual.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkbox_manual.Name = "checkbox_manual";
            this.checkbox_manual.Size = new System.Drawing.Size(83, 24);
            this.checkbox_manual.TabIndex = 3;
            this.checkbox_manual.Text = "Manual";
            this.checkbox_manual.UseVisualStyleBackColor = true;
            this.checkbox_manual.CheckedChanged += new System.EventHandler(this.Checkbox_manual_CheckedChanged);
            // 
            // checkbox_auto
            // 
            this.checkbox_auto.AutoSize = true;
            this.checkbox_auto.Location = new System.Drawing.Point(15, 87);
            this.checkbox_auto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkbox_auto.Name = "checkbox_auto";
            this.checkbox_auto.Size = new System.Drawing.Size(64, 24);
            this.checkbox_auto.TabIndex = 2;
            this.checkbox_auto.Text = "Auto";
            this.checkbox_auto.UseVisualStyleBackColor = true;
            this.checkbox_auto.CheckedChanged += new System.EventHandler(this.Checkbox_auto_CheckedChanged);
            // 
            // binary_checkbox
            // 
            this.binary_checkbox.AutoSize = true;
            this.binary_checkbox.Location = new System.Drawing.Point(15, 220);
            this.binary_checkbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.binary_checkbox.Name = "binary_checkbox";
            this.binary_checkbox.Size = new System.Drawing.Size(124, 24);
            this.binary_checkbox.TabIndex = 7;
            this.binary_checkbox.Text = "Binary Nature";
            this.binary_checkbox.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(100, 168);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(387, 27);
            this.progressBar.TabIndex = 18;
            // 
            // decrypt_button
            // 
            this.decrypt_button.Enabled = false;
            this.decrypt_button.Location = new System.Drawing.Point(251, 135);
            this.decrypt_button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.decrypt_button.Name = "decrypt_button";
            this.decrypt_button.Size = new System.Drawing.Size(169, 27);
            this.decrypt_button.TabIndex = 14;
            this.decrypt_button.Text = "Decrypt";
            this.decrypt_button.UseVisualStyleBackColor = true;
            this.decrypt_button.Click += new System.EventHandler(this.Decrypt_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbl_speed);
            this.groupBox2.Controls.Add(this.checkbox_autodecrypt);
            this.groupBox2.Controls.Add(this.checkbox_crc);
            this.groupBox2.Controls.Add(this.size_textbox);
            this.groupBox2.Controls.Add(this.size_lbl);
            this.groupBox2.Controls.Add(this.progressBar);
            this.groupBox2.Controls.Add(this.decrypt_button);
            this.groupBox2.Controls.Add(this.download_button);
            this.groupBox2.Controls.Add(this.file_lbl);
            this.groupBox2.Controls.Add(this.file_textbox);
            this.groupBox2.Controls.Add(this.version_textbox);
            this.groupBox2.Controls.Add(this.version_lbl);
            this.groupBox2.Location = new System.Drawing.Point(370, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(495, 248);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Download";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 203);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Speed";
            // 
            // lbl_speed
            // 
            this.lbl_speed.AutoSize = true;
            this.lbl_speed.Location = new System.Drawing.Point(96, 203);
            this.lbl_speed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_speed.Name = "lbl_speed";
            this.lbl_speed.Size = new System.Drawing.Size(46, 20);
            this.lbl_speed.TabIndex = 24;
            this.lbl_speed.Text = "0kB/s";
            // 
            // checkbox_autodecrypt
            // 
            this.checkbox_autodecrypt.AutoSize = true;
            this.checkbox_autodecrypt.Checked = true;
            this.checkbox_autodecrypt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_autodecrypt.Location = new System.Drawing.Point(252, 111);
            this.checkbox_autodecrypt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkbox_autodecrypt.Name = "checkbox_autodecrypt";
            this.checkbox_autodecrypt.Size = new System.Drawing.Size(179, 24);
            this.checkbox_autodecrypt.TabIndex = 12;
            this.checkbox_autodecrypt.Text = "Decrypt automatically";
            this.checkbox_autodecrypt.UseVisualStyleBackColor = true;
            // 
            // checkbox_crc
            // 
            this.checkbox_crc.AutoSize = true;
            this.checkbox_crc.Checked = true;
            this.checkbox_crc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_crc.Location = new System.Drawing.Point(100, 111);
            this.checkbox_crc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkbox_crc.Name = "checkbox_crc";
            this.checkbox_crc.Size = new System.Drawing.Size(123, 24);
            this.checkbox_crc.TabIndex = 11;
            this.checkbox_crc.Text = "Check CRC32";
            this.checkbox_crc.UseVisualStyleBackColor = true;
            // 
            // size_textbox
            // 
            this.size_textbox.Location = new System.Drawing.Point(100, 81);
            this.size_textbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.size_textbox.Name = "size_textbox";
            this.size_textbox.ReadOnly = true;
            this.size_textbox.Size = new System.Drawing.Size(385, 27);
            this.size_textbox.TabIndex = 40;
            this.size_textbox.TabStop = false;
            // 
            // size_lbl
            // 
            this.size_lbl.AutoSize = true;
            this.size_lbl.Location = new System.Drawing.Point(8, 87);
            this.size_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.size_lbl.Name = "size_lbl";
            this.size_lbl.Size = new System.Drawing.Size(36, 20);
            this.size_lbl.TabIndex = 20;
            this.size_lbl.Text = "Size";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.update_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(878, 538);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.log_textbox);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SamFirm Continued";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Close);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        //폼을 로드했을 때 호출하는 메소드
        private void MainForm_Load(object sender, EventArgs e)
        {
            Logger.Form = this;
            Web.Form = this;
            Decrypt.Form = this;

            //각 컨트롤에 설정파일에서 불러온 값을 적용한다.
            this.model_textbox.Text = Settings.ReadSetting("Model");
            this.region_textbox.Text = Settings.ReadSetting("Region");
            this.pda_textbox.Text = Settings.ReadSetting("PDAVer");
            this.csc_textbox.Text = Settings.ReadSetting("CSCVer");
            this.phone_textbox.Text = Settings.ReadSetting("PHONEVer");
            if (Settings.ReadSetting("AutoInfo").ToLower() == "true")
            {
                this.checkbox_auto.Checked = true;
            }
            else
            {
                this.checkbox_manual.Checked = true;
            }
            if (Settings.ReadSetting("BinaryNature").ToLower() == "true")
            {
                this.binary_checkbox.Checked = true;
            }
            if (Settings.ReadSetting("CheckCRC").ToLower() == "false")
            {
                this.checkbox_crc.Checked = false;
            }
            if (Settings.ReadSetting("AutoDecrypt").ToLower() == "false")
            {
                this.checkbox_autodecrypt.Checked = false;
            }
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            Logger.WriteLine("SamFirm v" + versionInfo.FileVersion);
            ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => true;
        }

        //폼을 닫았을 때 호출하는 메소드
        private void MainForm_Close(object sender, EventArgs e)
        {
            Settings.SetSetting("Model", this.model_textbox.Text.ToUpper());
            Settings.SetSetting("Region", this.region_textbox.Text.ToUpper());
            Settings.SetSetting("PDAVer", this.pda_textbox.Text);
            Settings.SetSetting("CSCVer", this.csc_textbox.Text);
            Settings.SetSetting("PHONEVer", this.phone_textbox.Text);
            Settings.SetSetting("AutoInfo", this.checkbox_auto.Checked.ToString());
            Settings.SetSetting("BinaryNature", this.binary_checkbox.Checked.ToString());
            Settings.SetSetting("CheckCRC", this.checkbox_crc.Checked.ToString());
            Settings.SetSetting("AutoDecrypt", this.checkbox_autodecrypt.Checked.ToString());
            this.PauseDownload = true;
            Thread.Sleep(100);
            Imports.FreeModule();
            Logger.SaveLog();
        }

        //컨트롤 활성화/비활성화 설정 메소드
        private void ControlsEnabled(bool Enabled)
        {
            this.update_button.Invoke(new Action(() => this.update_button.Enabled = Enabled));
            this.download_button.Invoke(new Action(() => this.download_button.Enabled = Enabled));
            this.binary_checkbox.Invoke(new Action(() => this.binary_checkbox.Enabled = Enabled));
            this.model_textbox.Invoke(new Action(() => this.model_textbox.Enabled = Enabled));
            this.region_textbox.Invoke(new Action(() => this.region_textbox.Enabled = Enabled));
            this.checkbox_auto.Invoke(new Action(() => this.checkbox_auto.Enabled = Enabled));
            this.checkbox_manual.Invoke(new Action(() => this.checkbox_manual.Enabled = Enabled));
            this.checkbox_manual.Invoke(new Action(delegate {
                if (this.checkbox_manual.Checked)
                {
                    this.pda_textbox.Enabled = Enabled;
                    this.csc_textbox.Enabled = Enabled;
                    this.phone_textbox.Enabled = Enabled;
                }
            }));
            this.checkbox_autodecrypt.Invoke(new Action(() => this.checkbox_autodecrypt.Enabled = Enabled));
            this.checkbox_crc.Invoke(new Action(() => this.checkbox_crc.Enabled = Enabled));
        }

        //Auto 체크박스의 체크상태가 변경되면 실행하는 메소드
        private void Checkbox_auto_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkbox_manual.Checked && !this.checkbox_auto.Checked)
            {
                this.checkbox_auto.Checked = true;
            }
            else
            {
                this.checkbox_manual.Checked = !this.checkbox_auto.Checked;
                this.pda_textbox.Enabled = !this.checkbox_auto.Checked;
                this.csc_textbox.Enabled = !this.checkbox_auto.Checked;
                this.phone_textbox.Enabled = !this.checkbox_auto.Checked;
            }
        }

        //Manual 체크박스의 체크상태가 변경되면 실행하는 메소드
        private void Checkbox_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkbox_auto.Checked && !this.checkbox_manual.Checked)
            {
                this.checkbox_manual.Checked = true;
            }
            else
            {
                this.checkbox_auto.Checked = !this.checkbox_manual.Checked;
                this.pda_textbox.Enabled = this.checkbox_manual.Checked;
                this.csc_textbox.Enabled = this.checkbox_manual.Checked;
                this.phone_textbox.Enabled = this.checkbox_manual.Checked;
            }
        }

        //Decrypt 버튼 클릭시 실행하는 메소드
        private void Decrypt_button_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(this.destinationfile))
            {
                Logger.WriteLine("Error Decrypt_button_Click(): File " + this.destinationfile + " does not exist");
            }
            else
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += delegate {
                    Thread.Sleep(100);
                    Logger.WriteLine("\nDecrypting firmware...");
                    this.ControlsEnabled(false);
                    this.decrypt_button.Invoke(new Action(() => this.decrypt_button.Enabled = false));
                    if (this.destinationfile.EndsWith(".enc2"))
                    {
                        Decrypt.SetDecryptKey(this.FW.Region, this.FW.Model, this.FW.Version);
                    }
                    else if (this.destinationfile.EndsWith(".enc4"))
                    {
                        if (this.FW.BinaryNature == 1)
                        {
                            Decrypt.SetDecryptKey(this.FW.Version, this.FW.LogicValueFactory);
                        }
                        else
                        {
                            Decrypt.SetDecryptKey(this.FW.Version, this.FW.LogicValueHome);
                        }
                    }
                    if (Decrypt.DecryptFile(this.destinationfile, Path.Combine(Path.GetDirectoryName(this.destinationfile), Path.GetFileNameWithoutExtension(this.destinationfile)), true) == 0)
                    {
                        System.IO.File.Delete(this.destinationfile);
                    }
                    Logger.WriteLine("Decryption finished");
                    this.ControlsEnabled(true);
                };
                worker.RunWorkerAsync();
            }
        }

        //Download 버튼 클릭시 실행하는 메소드
        private void Download_button_Click(object sender, EventArgs e)
        {
            //다운로드를 일시정지한다.
            if (this.download_button.Text == "Pause")
            {
                Utility.TaskBarProgressState(true);
                this.PauseDownload = true;
                Utility.ReconnectDownload = false;
                this.download_button.Text = "Download";
                return;
            }

            //예외 처리
            if ((e.GetType() == typeof(DownloadEventArgs)) && ((DownloadEventArgs)e).isReconnect)
            {
                if (this.download_button.Text == "Pause" || !Utility.ReconnectDownload)
                {
                    return;
                }
            }
            if (this.PauseDownload)
            {
                Logger.WriteLine("Download thread is still running. Please wait.");
                return;
            }
            else if (string.IsNullOrEmpty(this.file_textbox.Text))
            {
                Logger.WriteLine("No file to download. Please check for update first.");
                return;
            }

            //다운로드 작업
            if ((e.GetType() != typeof(DownloadEventArgs)) || !((DownloadEventArgs)e).isReconnect)
            {
                //.zip + .enc4
                string extension = Path.GetExtension(Path.GetFileNameWithoutExtension(FW.Filename)) + Path.GetExtension(FW.Filename);
                this.saveFileDialog1.OverwritePrompt = false;
                this.saveFileDialog1.FileName = this.FW.Filename.Replace(extension, "");
                this.saveFileDialog1.Filter = "Firmware|*" + extension;
                if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    Logger.WriteLine("Download aborted.");
                    return;
                }
                if (!this.saveFileDialog1.FileName.EndsWith(extension))
                {
                    this.saveFileDialog1.FileName = this.saveFileDialog1.FileName + extension;
                }
                else
                {
                    this.saveFileDialog1.FileName = this.saveFileDialog1.FileName.Replace(extension + extension, extension);
                }
                Logger.WriteLine("Filename: " + this.saveFileDialog1.FileName);

                this.destinationfile = this.saveFileDialog1.FileName;
                if (System.IO.File.Exists(this.destinationfile))
                {
                    switch (new AppendDialogBox().ShowDialog())
                    {
                        case DialogResult.Yes:
                            break;

                        case DialogResult.No:
                            System.IO.File.Delete(this.destinationfile);
                            break;

                        case DialogResult.Cancel:
                            Logger.WriteLine("Download aborted.");
                            return;

                        default:
                            Logger.WriteLine("Error: Wrong DialogResult");
                            return;
                    }
                }
            }
            Utility.TaskBarProgressState(false);
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate (object o, DoWorkEventArgs _e) {
                try
                {
                    this.ControlsEnabled(false);
                    Utility.ReconnectDownload = false;
                    MethodInvoker invoker1 = delegate
                    {
                        this.download_button.Enabled = true;
                        this.download_button.Text = "Pause";
                    };
                    this.download_button.Invoke(invoker1);
                    if (this.FW.Filename == this.destinationfile)
                    {
                        Logger.WriteLine("Download " + this.FW.Filename);
                    }
                    else
                    {
                        Logger.WriteLine("Download " + this.FW.Filename + " to " + this.destinationfile);
                    }
                    Command.Download(this.FW.Path, this.FW.Filename, this.FW.Version, this.FW.Region, this.FW.Model_Type, this.destinationfile, this.FW.Size, true);
                    if (this.PauseDownload)
                    {
                        Logger.WriteLine("Download paused.");
                        this.PauseDownload = false;
                        if (Utility.ReconnectDownload)
                        {
                            Logger.WriteLine("Reconnecting...");
                            Utility.Reconnect(new Action<object, EventArgs>(this.Download_button_Click));
                        }
                    }
                    else
                    {
                        Logger.WriteLine("Download finished.");
                        if (this.checkbox_crc.Checked)
                        {
                            if (this.FW.CRC == null)
                            {
                                Logger.WriteLine("Error: Unable to check CRC. Value not set by Samsung");
                            }
                            else
                            {
                                Logger.WriteLine("\nChecking CRC32...");
                                if (!Utility.CRCCheck(this.destinationfile, this.FW.CRC))
                                {
                                    Logger.WriteLine("Error: CRC does not match. Please redownload the file.");
                                    System.IO.File.Delete(this.destinationfile);
                                    goto Label_01C9;
                                }
                                Logger.WriteLine("CRC matched.");
                            }
                        }
                        decrypt_button.Invoke(new Action(() => decrypt_button.Enabled = true));
                        if (this.checkbox_autodecrypt.Checked)
                        {
                            this.Decrypt_button_Click(o, null);
                        }
                    }
                Label_01C9:
                    if (!Utility.ReconnectDownload)
                    {
                        this.ControlsEnabled(true);
                    }
                    this.download_button.Invoke(new Action(() => this.download_button.Text = "Download"));
                }
                catch (Exception exception)
                {
                    Logger.WriteLine("Error Download_button_Click(): " + exception);
                }
            };
            worker.RunWorkerAsync();
        }

        //Update 버튼 클릭시 실행하는 메소드
        private void Update_button_Click(object sender, EventArgs e)
        {
            //예외 처리
            if (string.IsNullOrEmpty(model_textbox.Text))
            {
                Logger.WriteLine("Error: Please specify a model");
                return;
            }
            else if (string.IsNullOrEmpty(region_textbox.Text))
            {
                Logger.WriteLine("Error: Please specify a region");
                return;
            }
            else if (checkbox_manual.Checked && (string.IsNullOrEmpty(pda_textbox.Text) || string.IsNullOrEmpty(csc_textbox.Text) || string.IsNullOrEmpty(phone_textbox.Text)))
            {
                Logger.WriteLine("Error: Please specify PDA, CSC and Phone version or use Auto Method");
                return;
            }

            //백그라운드 작업 등록
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate {
                MethodInvoker invoker1 = null;
                MethodInvoker invoker2 = null;
                MethodInvoker invoker3 = null;
                MethodInvoker invoker4 = null;
                MethodInvoker invoker5 = null;
                MethodInvoker invoker6 = null;
                try
                {
                    this.SetProgressBar(0);
                    this.ControlsEnabled(false);
                    Utility.ReconnectDownload = false;

                    //Auto에 체크되어 있으면 UpdateCheckAuto() 메소드 실행
                    if (this.checkbox_auto.Checked)
                    {
                        this.FW = SamFirm.Command.UpdateCheckAuto(this.model_textbox.Text, this.region_textbox.Text, this.binary_checkbox.Checked);
                    }
                    else
                    {
                        this.FW = SamFirm.Command.UpdateCheck(this.model_textbox.Text, this.region_textbox.Text, this.pda_textbox.Text, this.csc_textbox.Text, this.phone_textbox.Text, this.pda_textbox.Text, this.binary_checkbox.Checked, false);
                    }

                    //FW 구조체의 Filename멤버가 비어있지 않으면 FW의 멤버를 출력하고,
                    //비어있으면 빈 글자를 출력한다.
                    if (!string.IsNullOrEmpty(this.FW.Filename))
                    {
                        invoker1 = () => this.file_textbox.Text = FW.Filename;
                        this.file_textbox.Invoke(invoker1);

                        invoker2 = () => this.version_textbox.Text = FW.Version;
                        this.version_textbox.Invoke(invoker2);

                        invoker3 = () => this.size_textbox.Text = (long.Parse(FW.Size) / 1024L / 1024L) + " MB";
                        this.size_textbox.Invoke(invoker3);
                    }
                    else
                    {
                        invoker4 = () => this.file_textbox.Text = string.Empty;
                        this.file_textbox.Invoke(invoker4);

                        invoker5 = () => this.version_textbox.Text = string.Empty;
                        this.version_textbox.Invoke(invoker5);

                        invoker6 = () => this.size_textbox.Text = string.Empty;
                        this.size_textbox.Invoke(invoker6);
                    }

                    //출력을 완료하면 컨트롤을 활성화한다.
                    this.ControlsEnabled(true);
                }
                catch (Exception exception)
                {
                    Logger.WriteLine(exception.Message);
                    Logger.WriteLine(exception.ToString());
                }
            };

            //백그라운드 작업 실행
            worker.RunWorkerAsync();
        }

        //작업 진행바를 설정하는 메소드
        public void SetProgressBar(int progress)
        {
            MethodInvoker invoker1 = delegate
            {
                if (progress > 100)
                {
                    this.progressBar.Value = 100;
                }
                else
                {
                    this.progressBar.Value = progress;
                }
                TaskbarManager.Instance.SetProgressValue(progress, 100);
            };
            this.progressBar.Invoke(invoker1);
        }

        public class DownloadEventArgs : EventArgs
        {
            internal bool isReconnect;
        }
    }
}