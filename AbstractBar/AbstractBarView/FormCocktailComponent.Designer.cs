namespace AbstractBarView
{
    partial class FormCocktailComponent
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
            this.labelComponent = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.Location = new System.Drawing.Point(12, 9);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(91, 20);
            this.labelComponent.TabIndex = 0;
            this.labelComponent.Text = "Компонент:";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(12, 46);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(93, 20);
            this.labelQuantity.TabIndex = 1;
            this.labelQuantity.Text = "Количество:";
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(121, 6);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(280, 28);
            this.comboBoxComponent.TabIndex = 2;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(121, 43);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(280, 27);
            this.textBoxCount.TabIndex = 3;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(207, 89);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(94, 29);
            this.ButtonSave.TabIndex = 4;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(307, 89);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(94, 29);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormCocktailComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 123);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelComponent);
            this.Name = "FormCocktailComponent";
            this.Text = "Компонент коктейля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelComponent;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
    }
}