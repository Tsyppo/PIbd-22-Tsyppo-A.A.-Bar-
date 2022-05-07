namespace AbstractBarView
{
    partial class FormReportTotalOrders
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
            this.panel = new System.Windows.Forms.Panel();
            this.buttonToPDF = new System.Windows.Forms.Button();
            this.buttonMake = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.buttonToPDF);
            this.panel.Controls.Add(this.buttonMake);
            this.panel.Location = new System.Drawing.Point(14, 16);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(887, 48);
            this.panel.TabIndex = 0;
            // 
            // buttonToPDF
            // 
            this.buttonToPDF.Location = new System.Drawing.Point(135, 4);
            this.buttonToPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonToPDF.Name = "buttonToPDF";
            this.buttonToPDF.Size = new System.Drawing.Size(125, 40);
            this.buttonToPDF.TabIndex = 1;
            this.buttonToPDF.Text = "В Pdf";
            this.buttonToPDF.UseVisualStyleBackColor = true;
            this.buttonToPDF.Click += new System.EventHandler(this.buttonToPDF_Click);
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(3, 4);
            this.buttonMake.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(125, 40);
            this.buttonMake.TabIndex = 0;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // FormReportTotalOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormReportTotalOrders";
            this.Text = "Заказы";
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonToPDF;
        private System.Windows.Forms.Button buttonMake;
    }
}