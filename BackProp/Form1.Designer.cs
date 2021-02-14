﻿namespace BackProp
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendBtn = new System.Windows.Forms.Button();
            this.saveWeightsDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.GhostWhite;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.createNNToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(899, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.loadToolStripMenuItem.Text = "Load Bot";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.saveToolStripMenuItem.Text = "Save Bot";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // createNNToolStripMenuItem
            // 
            this.createNNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createBotToolStripMenuItem,
            this.teachBotToolStripMenuItem});
            this.createNNToolStripMenuItem.Name = "createNNToolStripMenuItem";
            this.createNNToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.createNNToolStripMenuItem.Text = "Create";
            // 
            // createBotToolStripMenuItem
            // 
            this.createBotToolStripMenuItem.Name = "createBotToolStripMenuItem";
            this.createBotToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.createBotToolStripMenuItem.Text = "Create Bot";
            this.createBotToolStripMenuItem.Click += new System.EventHandler(this.createBotToolStripMenuItem_Click);
            // 
            // teachBotToolStripMenuItem
            // 
            this.teachBotToolStripMenuItem.Name = "teachBotToolStripMenuItem";
            this.teachBotToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.teachBotToolStripMenuItem.Text = "Teach Bot";
            this.teachBotToolStripMenuItem.Click += new System.EventHandler(this.teachBotToolStripMenuItem_Click);
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(729, 447);
            this.sendBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(120, 36);
            this.sendBtn.TabIndex = 3;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // saveWeightsDialog
            // 
            this.saveWeightsDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveWeightsDialog_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // messageBox
            // 
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.Location = new System.Drawing.Point(215, 423);
            this.messageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(492, 86);
            this.messageBox.TabIndex = 10;
            this.messageBox.Text = "";
            // 
            // chatBox
            // 
            this.chatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatBox.Location = new System.Drawing.Point(215, 69);
            this.chatBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chatBox.Size = new System.Drawing.Size(633, 320);
            this.chatBox.TabIndex = 11;
            this.chatBox.Text = "";
            this.chatBox.TextChanged += new System.EventHandler(this.chatBox_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::BackProp.Properties.Resources.J_A_M_E_S_;
            this.pictureBox1.Location = new System.Drawing.Point(33, 85);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 168);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(899, 567);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "J.A.M.E.S. - Your SIMPLE Customer Service Chatbot";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createNNToolStripMenuItem;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.SaveFileDialog saveWeightsDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teachBotToolStripMenuItem;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

