namespace labelling
{
    partial class Labelling
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBoxCategory = new System.Windows.Forms.ComboBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.cmbBoxShowLen = new System.Windows.Forms.ComboBox();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.txtBoxInfo = new System.Windows.Forms.TextBox();
            this.chkListBoxAttribute = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxScrapPath = new System.Windows.Forms.TextBox();
            this.btn_scrap_path = new System.Windows.Forms.Button();
            this.tabCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose Item:";
            // 
            // cmbBoxCategory
            // 
            this.cmbBoxCategory.FormattingEnabled = true;
            this.cmbBoxCategory.Location = new System.Drawing.Point(117, 33);
            this.cmbBoxCategory.Name = "cmbBoxCategory";
            this.cmbBoxCategory.Size = new System.Drawing.Size(91, 21);
            this.cmbBoxCategory.TabIndex = 4;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(199, 340);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(293, 340);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // cmbBoxShowLen
            // 
            this.cmbBoxShowLen.FormattingEnabled = true;
            this.cmbBoxShowLen.Location = new System.Drawing.Point(414, 342);
            this.cmbBoxShowLen.Name = "cmbBoxShowLen";
            this.cmbBoxShowLen.Size = new System.Drawing.Size(42, 21);
            this.cmbBoxShowLen.TabIndex = 9;
            this.cmbBoxShowLen.SelectedIndexChanged += new System.EventHandler(this.cmbBoxShowLen_SelectedIndexChanged);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPage1);
            this.tabCtrl.Controls.Add(this.tabPage2);
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Multiline = true;
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(1216, 692);
            this.tabCtrl.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.txtBoxInfo);
            this.tabPage1.Controls.Add(this.chkListBoxAttribute);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.listView);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtBoxPath);
            this.tabPage1.Controls.Add(this.btnOpen);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.cmbBoxCategory);
            this.tabPage1.Controls.Add(this.cmbBoxShowLen);
            this.tabPage1.Controls.Add(this.btnPrev);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1208, 666);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MainPage";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Information:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(768, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 653);
            this.panel1.TabIndex = 46;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(434, 650);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // txtBoxInfo
            // 
            this.txtBoxInfo.Enabled = false;
            this.txtBoxInfo.Location = new System.Drawing.Point(19, 381);
            this.txtBoxInfo.Multiline = true;
            this.txtBoxInfo.Name = "txtBoxInfo";
            this.txtBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxInfo.Size = new System.Drawing.Size(740, 89);
            this.txtBoxInfo.TabIndex = 45;
            // 
            // chkListBoxAttribute
            // 
            this.chkListBoxAttribute.ColumnWidth = 150;
            this.chkListBoxAttribute.FormattingEnabled = true;
            this.chkListBoxAttribute.Location = new System.Drawing.Point(19, 505);
            this.chkListBoxAttribute.MultiColumn = true;
            this.chkListBoxAttribute.Name = "chkListBoxAttribute";
            this.chkListBoxAttribute.Size = new System.Drawing.Size(740, 154);
            this.chkListBoxAttribute.TabIndex = 44;
            this.chkListBoxAttribute.SelectedIndexChanged += new System.EventHandler(this.chkListBoxAttribute_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(684, 476);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView.AllowDrop = true;
            this.listView.Location = new System.Drawing.Point(19, 88);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(740, 250);
            this.listView.TabIndex = 42;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Tile;
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Items";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Material Path:";
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Enabled = false;
            this.txtBoxPath.Location = new System.Drawing.Point(117, 7);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.Size = new System.Drawing.Size(450, 20);
            this.txtBoxPath.TabIndex = 13;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(566, 6);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(30, 23);
            this.btnOpen.TabIndex = 12;
            this.btnOpen.Text = "...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Attributes:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Choose Category:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtBoxScrapPath);
            this.tabPage2.Controls.Add(this.btn_scrap_path);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1204, 707);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SubPage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "validate the scraped result";
            // 
            // txtBoxScrapPath
            // 
            this.txtBoxScrapPath.Location = new System.Drawing.Point(97, 76);
            this.txtBoxScrapPath.Name = "txtBoxScrapPath";
            this.txtBoxScrapPath.Size = new System.Drawing.Size(469, 20);
            this.txtBoxScrapPath.TabIndex = 1;
            // 
            // btn_scrap_path
            // 
            this.btn_scrap_path.Location = new System.Drawing.Point(38, 74);
            this.btn_scrap_path.Name = "btn_scrap_path";
            this.btn_scrap_path.Size = new System.Drawing.Size(53, 23);
            this.btn_scrap_path.TabIndex = 0;
            this.btn_scrap_path.Text = "open";
            this.btn_scrap_path.UseVisualStyleBackColor = true;
            // 
            // Labelling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 693);
            this.Controls.Add(this.tabCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Labelling";
            this.Text = "Labelling";
            this.tabCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBoxCategory;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox cmbBoxShowLen;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckedListBox chkListBoxAttribute;
        private System.Windows.Forms.TextBox txtBoxInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxScrapPath;
        private System.Windows.Forms.Button btn_scrap_path;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label7;
    }
}