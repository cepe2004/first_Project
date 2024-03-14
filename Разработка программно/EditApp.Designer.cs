namespace Разработка_программного_модуля_для_учета_заявок_на_ремонт_оборудования
{
    partial class EditApp
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
            this.CbStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TbDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbWorker = new System.Windows.Forms.ComboBox();
            this.BtAdd = new System.Windows.Forms.Button();
            this.CbApp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.назадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbStatus
            // 
            this.CbStatus.FormattingEnabled = true;
            this.CbStatus.Location = new System.Drawing.Point(251, 61);
            this.CbStatus.Name = "CbStatus";
            this.CbStatus.Size = new System.Drawing.Size(411, 21);
            this.CbStatus.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(36, 61);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(72, 24);
            this.label8.TabIndex = 17;
            this.label8.Text = "Статус";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(36, 115);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(100, 24);
            this.label6.TabIndex = 20;
            this.label6.Text = "Описание";
            // 
            // TbDescription
            // 
            this.TbDescription.BackColor = System.Drawing.SystemColors.Window;
            this.TbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbDescription.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TbDescription.Location = new System.Drawing.Point(251, 116);
            this.TbDescription.Multiline = true;
            this.TbDescription.Name = "TbDescription";
            this.TbDescription.Size = new System.Drawing.Size(411, 117);
            this.TbDescription.TabIndex = 19;
            this.TbDescription.TextChanged += new System.EventHandler(this.TbDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(36, 268);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(185, 48);
            this.label1.TabIndex = 21;
            this.label1.Text = "Ответственный за \r\nвыполнение";
            // 
            // CbWorker
            // 
            this.CbWorker.FormattingEnabled = true;
            this.CbWorker.Location = new System.Drawing.Point(251, 273);
            this.CbWorker.Name = "CbWorker";
            this.CbWorker.Size = new System.Drawing.Size(411, 21);
            this.CbWorker.TabIndex = 22;
            // 
            // BtAdd
            // 
            this.BtAdd.BackColor = System.Drawing.SystemColors.Control;
            this.BtAdd.CausesValidation = false;
            this.BtAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtAdd.Location = new System.Drawing.Point(301, 371);
            this.BtAdd.Name = "BtAdd";
            this.BtAdd.Size = new System.Drawing.Size(151, 40);
            this.BtAdd.TabIndex = 23;
            this.BtAdd.Text = "Подтвердить";
            this.BtAdd.UseVisualStyleBackColor = false;
            this.BtAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // CbApp
            // 
            this.CbApp.CausesValidation = false;
            this.CbApp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CbApp.FormattingEnabled = true;
            this.CbApp.Location = new System.Drawing.Point(251, 28);
            this.CbApp.Name = "CbApp";
            this.CbApp.Size = new System.Drawing.Size(411, 21);
            this.CbApp.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(36, 28);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Заявка";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.назадToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 26);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // назадToolStripMenuItem
            // 
            this.назадToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.назадToolStripMenuItem.Name = "назадToolStripMenuItem";
            this.назадToolStripMenuItem.Size = new System.Drawing.Size(64, 22);
            this.назадToolStripMenuItem.Text = "Назад";
            // 
            // EditApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.CbApp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtAdd);
            this.Controls.Add(this.CbWorker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TbDescription);
            this.Controls.Add(this.CbStatus);
            this.Controls.Add(this.label8);
            this.Name = "EditApp";
            this.Text = "EditApp";
            this.Load += new System.EventHandler(this.EditApp_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TbDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbWorker;
        private System.Windows.Forms.Button BtAdd;
        private System.Windows.Forms.ComboBox CbApp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem назадToolStripMenuItem;
    }
}