namespace autopark
{
    partial class FProducts
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
            this.PanTopButtons = new System.Windows.Forms.Panel();
            this.BtnEditItem = new System.Windows.Forms.Button();
            this.BtnAddItem = new System.Windows.Forms.Button();
            this.PanGridList = new System.Windows.Forms.Panel();
            this.DGVList = new System.Windows.Forms.DataGridView();
            this.PanTopButtons.SuspendLayout();
            this.PanGridList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVList)).BeginInit();
            this.SuspendLayout();
            // 
            // PanTopButtons
            // 
            this.PanTopButtons.Controls.Add(this.BtnEditItem);
            this.PanTopButtons.Controls.Add(this.BtnAddItem);
            this.PanTopButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanTopButtons.Location = new System.Drawing.Point(0, 0);
            this.PanTopButtons.Name = "PanTopButtons";
            this.PanTopButtons.Size = new System.Drawing.Size(800, 30);
            this.PanTopButtons.TabIndex = 0;
            // 
            // BtnEditItem
            // 
            this.BtnEditItem.Location = new System.Drawing.Point(93, 4);
            this.BtnEditItem.Name = "BtnEditItem";
            this.BtnEditItem.Size = new System.Drawing.Size(75, 23);
            this.BtnEditItem.TabIndex = 1;
            this.BtnEditItem.Text = "Изменить";
            this.BtnEditItem.UseVisualStyleBackColor = true;
            this.BtnEditItem.Click += new System.EventHandler(this.BtnEditItem_Click);
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.Location = new System.Drawing.Point(12, 4);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(75, 23);
            this.BtnAddItem.TabIndex = 0;
            this.BtnAddItem.Text = "Добавить";
            this.BtnAddItem.UseVisualStyleBackColor = true;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // PanGridList
            // 
            this.PanGridList.Controls.Add(this.DGVList);
            this.PanGridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanGridList.Location = new System.Drawing.Point(0, 30);
            this.PanGridList.Name = "PanGridList";
            this.PanGridList.Size = new System.Drawing.Size(800, 420);
            this.PanGridList.TabIndex = 1;
            // 
            // DGVList
            // 
            this.DGVList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVList.Location = new System.Drawing.Point(0, 0);
            this.DGVList.Name = "DGVList";
            this.DGVList.Size = new System.Drawing.Size(800, 420);
            this.DGVList.TabIndex = 0;
            this.DGVList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVList_CellFormatting);
            // 
            // FProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanGridList);
            this.Controls.Add(this.PanTopButtons);
            this.Name = "FProducts";
            this.Text = "Товары/Услуги";
            this.Load += new System.EventHandler(this.FProducts_Load);
            this.PanTopButtons.ResumeLayout(false);
            this.PanGridList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanTopButtons;
        private System.Windows.Forms.Panel PanGridList;
        private System.Windows.Forms.DataGridView DGVList;
        private System.Windows.Forms.Button BtnAddItem;
        private System.Windows.Forms.Button BtnEditItem;
    }
}