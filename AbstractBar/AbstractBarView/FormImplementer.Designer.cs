﻿namespace AbstractBarView
{
    partial class FormImplementer
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
            this.labelFIO = new System.Windows.Forms.Label();
            this.labelWorkingTime = new System.Windows.Forms.Label();
            this.labelPauseTime = new System.Windows.Forms.Label();
            this.textBoxImplementerFIO = new System.Windows.Forms.TextBox();
            this.textBoxWorkingTime = new System.Windows.Forms.TextBox();
            this.textBoxPauseTime = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(12, 16);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(138, 20);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "ФИО Исполнителя";
            // 
            // labelWorkingTime
            // 
            this.labelWorkingTime.AutoSize = true;
            this.labelWorkingTime.Location = new System.Drawing.Point(12, 60);
            this.labelWorkingTime.Name = "labelWorkingTime";
            this.labelWorkingTime.Size = new System.Drawing.Size(110, 20);
            this.labelWorkingTime.TabIndex = 1;
            this.labelWorkingTime.Text = "Время работы";
            // 
            // labelPauseTime
            // 
            this.labelPauseTime.AutoSize = true;
            this.labelPauseTime.Location = new System.Drawing.Point(15, 100);
            this.labelPauseTime.Name = "labelPauseTime";
            this.labelPauseTime.Size = new System.Drawing.Size(107, 20);
            this.labelPauseTime.TabIndex = 2;
            this.labelPauseTime.Text = "Время отдыха";
            // 
            // textBoxImplementerFIO
            // 
            this.textBoxImplementerFIO.Location = new System.Drawing.Point(157, 13);
            this.textBoxImplementerFIO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxImplementerFIO.Name = "textBoxImplementerFIO";
            this.textBoxImplementerFIO.Size = new System.Drawing.Size(245, 27);
            this.textBoxImplementerFIO.TabIndex = 3;
            // 
            // textBoxWorkingTime
            // 
            this.textBoxWorkingTime.Location = new System.Drawing.Point(157, 57);
            this.textBoxWorkingTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxWorkingTime.Name = "textBoxWorkingTime";
            this.textBoxWorkingTime.Size = new System.Drawing.Size(245, 27);
            this.textBoxWorkingTime.TabIndex = 4;
            // 
            // textBoxPauseTime
            // 
            this.textBoxPauseTime.Location = new System.Drawing.Point(157, 97);
            this.textBoxPauseTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPauseTime.Name = "textBoxPauseTime";
            this.textBoxPauseTime.Size = new System.Drawing.Size(245, 27);
            this.textBoxPauseTime.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(197, 153);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(101, 31);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(304, 153);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 31);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 200);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxPauseTime);
            this.Controls.Add(this.textBoxWorkingTime);
            this.Controls.Add(this.textBoxImplementerFIO);
            this.Controls.Add(this.labelPauseTime);
            this.Controls.Add(this.labelWorkingTime);
            this.Controls.Add(this.labelFIO);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormImplementer";
            this.Text = "Исполнитель";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label labelWorkingTime;
        private System.Windows.Forms.Label labelPauseTime;
        private System.Windows.Forms.TextBox textBoxImplementerFIO;
        private System.Windows.Forms.TextBox textBoxWorkingTime;
        private System.Windows.Forms.TextBox textBoxPauseTime;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}