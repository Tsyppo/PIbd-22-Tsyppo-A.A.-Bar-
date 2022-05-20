namespace AbstractBarView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.коктейлиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMessages = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CocktailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CocktailComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartWorksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCreateBackUp = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonCreateOrder = new System.Windows.Forms.Button();
            this.ButtonIssuedOrder = new System.Windows.Forms.Button();
            this.ButtonRef = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.StartWorksToolStripMenuItem,
            this.toolStripMenuItemCreateBackUp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1422, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.коктейлиToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.исполнителиToolStripMenuItem,
            this.toolStripMenuItemMessages});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // коктейлиToolStripMenuItem
            // 
            this.коктейлиToolStripMenuItem.Name = "коктейлиToolStripMenuItem";
            this.коктейлиToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.коктейлиToolStripMenuItem.Text = "Коктейли";
            this.коктейлиToolStripMenuItem.Click += new System.EventHandler(this.коктейлиToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            // 
            // toolStripMenuItemMessages
            // 
            this.toolStripMenuItemMessages.Name = "toolStripMenuItemMessages";
            this.toolStripMenuItemMessages.Size = new System.Drawing.Size(185, 26);
            this.toolStripMenuItemMessages.Text = "Письма";
            this.toolStripMenuItemMessages.Click += new System.EventHandler(this.toolStripMenuItemMessages_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CocktailsToolStripMenuItem,
            this.CocktailComponentsToolStripMenuItem,
            this.OrdersToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // CocktailsToolStripMenuItem
            // 
            this.CocktailsToolStripMenuItem.Name = "CocktailsToolStripMenuItem";
            this.CocktailsToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.CocktailsToolStripMenuItem.Text = "Список коктейлей";
            this.CocktailsToolStripMenuItem.Click += new System.EventHandler(this.ComponentsToolStripMenuItem_Click);
            // 
            // CocktailComponentsToolStripMenuItem
            // 
            this.CocktailComponentsToolStripMenuItem.Name = "CocktailComponentsToolStripMenuItem";
            this.CocktailComponentsToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.CocktailComponentsToolStripMenuItem.Text = "Коктейли по компонентам";
            this.CocktailComponentsToolStripMenuItem.Click += new System.EventHandler(this.ComponentCocktailsToolStripMenuItem_Click);
            // 
            // OrdersToolStripMenuItem
            // 
            this.OrdersToolStripMenuItem.Name = "OrdersToolStripMenuItem";
            this.OrdersToolStripMenuItem.Size = new System.Drawing.Size(279, 26);
            this.OrdersToolStripMenuItem.Text = "Список заказов";
            this.OrdersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // StartWorksToolStripMenuItem
            // 
            this.StartWorksToolStripMenuItem.Name = "StartWorksToolStripMenuItem";
            this.StartWorksToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.StartWorksToolStripMenuItem.Text = "Запуск работ";
            this.StartWorksToolStripMenuItem.Click += new System.EventHandler(this.StartWorksToolStripMenuItem_Click);
            // 
            // toolStripMenuItemCreateBackUp
            // 
            this.toolStripMenuItemCreateBackUp.Name = "toolStripMenuItemCreateBackUp";
            this.toolStripMenuItemCreateBackUp.Size = new System.Drawing.Size(123, 24);
            this.toolStripMenuItemCreateBackUp.Text = "Создать бекап";
            this.toolStripMenuItemCreateBackUp.Click += new System.EventHandler(this.toolStripMenuItemCreateBackUp_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1184, 409);
            this.dataGridView.TabIndex = 1;
            // 
            // ButtonCreateOrder
            // 
            this.ButtonCreateOrder.Location = new System.Drawing.Point(1190, 46);
            this.ButtonCreateOrder.Name = "ButtonCreateOrder";
            this.ButtonCreateOrder.Size = new System.Drawing.Size(220, 29);
            this.ButtonCreateOrder.TabIndex = 2;
            this.ButtonCreateOrder.Text = "Создать заказ";
            this.ButtonCreateOrder.UseVisualStyleBackColor = true;
            this.ButtonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // ButtonIssuedOrder
            // 
            this.ButtonIssuedOrder.Location = new System.Drawing.Point(1190, 106);
            this.ButtonIssuedOrder.Name = "ButtonIssuedOrder";
            this.ButtonIssuedOrder.Size = new System.Drawing.Size(220, 29);
            this.ButtonIssuedOrder.TabIndex = 5;
            this.ButtonIssuedOrder.Text = "Заказ выдан";
            this.ButtonIssuedOrder.UseVisualStyleBackColor = true;
            this.ButtonIssuedOrder.Click += new System.EventHandler(this.ButtonIssuedOrder_Click);
            // 
            // ButtonRef
            // 
            this.ButtonRef.Location = new System.Drawing.Point(1190, 170);
            this.ButtonRef.Name = "ButtonRef";
            this.ButtonRef.Size = new System.Drawing.Size(220, 29);
            this.ButtonRef.TabIndex = 6;
            this.ButtonRef.Text = "Обновить список";
            this.ButtonRef.UseVisualStyleBackColor = true;
            this.ButtonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 440);
            this.Controls.Add(this.ButtonRef);
            this.Controls.Add(this.ButtonIssuedOrder);
            this.Controls.Add(this.ButtonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Абстрактный бар";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem коктейлиToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonCreateOrder;
        private System.Windows.Forms.Button ButtonIssuedOrder;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CocktailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CocktailComponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartWorksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMessages;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreateBackUp;
    }
}