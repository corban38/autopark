namespace autopark
{
    partial class fProviders
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
            this.panTop = new System.Windows.Forms.Panel();
            this.btnChangeItem = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnAddProvider = new System.Windows.Forms.Button();
            this.panList = new System.Windows.Forms.Panel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.panTop.SuspendLayout();
            this.panList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.btnChangeItem);
            this.panTop.Controls.Add(this.btnSaveChanges);
            this.panTop.Controls.Add(this.btnAddProvider);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(800, 36);
            this.panTop.TabIndex = 0;
            // 
            // btnChangeItem
            // 
            this.btnChangeItem.Location = new System.Drawing.Point(294, 7);
            this.btnChangeItem.Name = "btnChangeItem";
            this.btnChangeItem.Size = new System.Drawing.Size(75, 23);
            this.btnChangeItem.TabIndex = 2;
            this.btnChangeItem.Text = "Изменить";
            this.btnChangeItem.UseVisualStyleBackColor = true;
            this.btnChangeItem.Click += new System.EventHandler(this.btnChangeItem_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(93, 7);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(75, 23);
            this.btnSaveChanges.TabIndex = 1;
            this.btnSaveChanges.Text = "Сохранить";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnAddProvider
            // 
            this.btnAddProvider.Location = new System.Drawing.Point(12, 7);
            this.btnAddProvider.Name = "btnAddProvider";
            this.btnAddProvider.Size = new System.Drawing.Size(75, 23);
            this.btnAddProvider.TabIndex = 0;
            this.btnAddProvider.Text = "Добавить";
            this.btnAddProvider.UseVisualStyleBackColor = true;
            this.btnAddProvider.Click += new System.EventHandler(this.btnAddProvider_Click);
            // 
            // panList
            // 
            this.panList.Controls.Add(this.dgvList);
            this.panList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panList.Location = new System.Drawing.Point(0, 36);
            this.panList.Name = "panList";
            this.panList.Size = new System.Drawing.Size(800, 414);
            this.panList.TabIndex = 1;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Name = "dgvList";
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(800, 414);
            this.dgvList.TabIndex = 0;
            this.dgvList.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvList_Paint);
            this.dgvList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvList_KeyUp);
            // 
            // fProviders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panList);
            this.Controls.Add(this.panTop);
            this.Name = "fProviders";
            this.Text = "Поставщики";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fProviders_FormClosing);
            this.Load += new System.EventHandler(this.fProviders_Load);
            this.panTop.ResumeLayout(false);
            this.panList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Panel panList;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnAddProvider;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnChangeItem;
    }
}