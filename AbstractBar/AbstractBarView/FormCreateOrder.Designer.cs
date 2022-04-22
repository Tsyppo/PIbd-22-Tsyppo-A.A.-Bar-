namespace AbstractBarView
{
    partial class FormCreateOrder
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
            this.labelCocktail = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.comboBoxCocktail = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.labelClient = new System.Windows.Forms.Label();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelCocktail
            // 
            this.labelCocktail.AutoSize = true;
            this.labelCocktail.Location = new System.Drawing.Point(24, 55);
            this.labelCocktail.Name = "labelCocktail";
            this.labelCocktail.Size = new System.Drawing.Size(76, 20);
            this.labelCocktail.TabIndex = 0;
            this.labelCocktail.Text = "Коктейль:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(24, 91);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(93, 20);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество:";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(24, 125);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(58, 20);
            this.labelSum.TabIndex = 2;
            this.labelSum.Text = "Сумма:";
            // 
            // comboBoxCocktail
            // 
            this.comboBoxCocktail.FormattingEnabled = true;
            this.comboBoxCocktail.Location = new System.Drawing.Point(140, 52);
            this.comboBoxCocktail.Name = "comboBoxCocktail";
            this.comboBoxCocktail.Size = new System.Drawing.Size(233, 28);
            this.comboBoxCocktail.TabIndex = 3;
            this.comboBoxCocktail.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCocktail_SelectedIndexChanged);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(140, 91);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(233, 27);
            this.textBoxCount.TabIndex = 4;
            this.textBoxCount.TextChanged += new System.EventHandler(this.TextBoxCount_TextChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSum.Location = new System.Drawing.Point(140, 125);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(233, 27);
            this.textBoxSum.TabIndex = 5;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(159, 176);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(94, 29);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(279, 176);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(94, 29);
            this.ButtonCancel.TabIndex = 7;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(24, 22);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(61, 20);
            this.labelClient.TabIndex = 8;
            this.labelClient.Text = "Клиент:";
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(140, 14);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(233, 28);
            this.comboBoxClient.TabIndex = 9;
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 217);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxCocktail);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelCocktail);
            this.Name = "FormCreateOrder";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCocktail;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.ComboBox comboBoxCocktail;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.ComboBox comboBoxClient;
    }
}