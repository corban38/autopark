namespace autopark
{
    partial class FCars
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
            this.pFooter = new System.Windows.Forms.Panel();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.pBrandList = new System.Windows.Forms.Panel();
            this.gbBrands = new System.Windows.Forms.GroupBox();
            this.dgvBrandList = new System.Windows.Forms.DataGridView();
            this.pBrandButtons = new System.Windows.Forms.Panel();
            this.btnSaveChangeBrand = new System.Windows.Forms.Button();
            this.btnDeleteBrand = new System.Windows.Forms.Button();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pModelList = new System.Windows.Forms.Panel();
            this.gbModels = new System.Windows.Forms.GroupBox();
            this.dgvModelList = new System.Windows.Forms.DataGridView();
            this.pModelButtons = new System.Windows.Forms.Panel();
            this.btnSaveChangeModel = new System.Windows.Forms.Button();
            this.btnDeleteModel = new System.Windows.Forms.Button();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.pFooter.SuspendLayout();
            this.pBrandList.SuspendLayout();
            this.gbBrands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrandList)).BeginInit();
            this.pBrandButtons.SuspendLayout();
            this.pModelList.SuspendLayout();
            this.gbModels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelList)).BeginInit();
            this.pModelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pFooter
            // 
            this.pFooter.Controls.Add(this.btnCloseForm);
            this.pFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pFooter.Location = new System.Drawing.Point(0, 280);
            this.pFooter.Name = "pFooter";
            this.pFooter.Size = new System.Drawing.Size(703, 45);
            this.pFooter.TabIndex = 1;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(616, 10);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(75, 23);
            this.btnCloseForm.TabIndex = 0;
            this.btnCloseForm.Text = "Закрыть";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // pBrandList
            // 
            this.pBrandList.Controls.Add(this.gbBrands);
            this.pBrandList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pBrandList.Location = new System.Drawing.Point(0, 0);
            this.pBrandList.MinimumSize = new System.Drawing.Size(350, 0);
            this.pBrandList.Name = "pBrandList";
            this.pBrandList.Size = new System.Drawing.Size(350, 280);
            this.pBrandList.TabIndex = 2;
            // 
            // gbBrands
            // 
            this.gbBrands.Controls.Add(this.dgvBrandList);
            this.gbBrands.Controls.Add(this.pBrandButtons);
            this.gbBrands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBrands.Location = new System.Drawing.Point(0, 0);
            this.gbBrands.Name = "gbBrands";
            this.gbBrands.Size = new System.Drawing.Size(350, 280);
            this.gbBrands.TabIndex = 1;
            this.gbBrands.TabStop = false;
            this.gbBrands.Text = "Марка автомобиля";
            // 
            // dgvBrandList
            // 
            this.dgvBrandList.AllowUserToAddRows = false;
            this.dgvBrandList.AllowUserToDeleteRows = false;
            this.dgvBrandList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBrandList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBrandList.Location = new System.Drawing.Point(3, 47);
            this.dgvBrandList.Name = "dgvBrandList";
            this.dgvBrandList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBrandList.Size = new System.Drawing.Size(344, 230);
            this.dgvBrandList.TabIndex = 0;
            // 
            // pBrandButtons
            // 
            this.pBrandButtons.Controls.Add(this.btnSaveChangeBrand);
            this.pBrandButtons.Controls.Add(this.btnDeleteBrand);
            this.pBrandButtons.Controls.Add(this.btnAddBrand);
            this.pBrandButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBrandButtons.Location = new System.Drawing.Point(3, 16);
            this.pBrandButtons.Name = "pBrandButtons";
            this.pBrandButtons.Size = new System.Drawing.Size(344, 31);
            this.pBrandButtons.TabIndex = 0;
            // 
            // btnSaveChangeBrand
            // 
            this.btnSaveChangeBrand.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaveChangeBrand.Location = new System.Drawing.Point(210, 0);
            this.btnSaveChangeBrand.Name = "btnSaveChangeBrand";
            this.btnSaveChangeBrand.Size = new System.Drawing.Size(130, 31);
            this.btnSaveChangeBrand.TabIndex = 2;
            this.btnSaveChangeBrand.Text = "Сохранить изменения";
            this.btnSaveChangeBrand.UseVisualStyleBackColor = true;
            this.btnSaveChangeBrand.Click += new System.EventHandler(this.btnSaveChangeBrand_Click);
            // 
            // btnDeleteBrand
            // 
            this.btnDeleteBrand.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteBrand.Location = new System.Drawing.Point(105, 0);
            this.btnDeleteBrand.Name = "btnDeleteBrand";
            this.btnDeleteBrand.Size = new System.Drawing.Size(105, 31);
            this.btnDeleteBrand.TabIndex = 1;
            this.btnDeleteBrand.Text = "Удалить запись";
            this.btnDeleteBrand.UseVisualStyleBackColor = true;
            this.btnDeleteBrand.Click += new System.EventHandler(this.btnDeleteBrand_Click);
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddBrand.Location = new System.Drawing.Point(0, 0);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(105, 31);
            this.btnAddBrand.TabIndex = 0;
            this.btnAddBrand.Text = "Добавить запись";
            this.btnAddBrand.UseVisualStyleBackColor = true;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(350, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 280);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // pModelList
            // 
            this.pModelList.Controls.Add(this.gbModels);
            this.pModelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pModelList.Location = new System.Drawing.Point(353, 0);
            this.pModelList.MinimumSize = new System.Drawing.Size(350, 0);
            this.pModelList.Name = "pModelList";
            this.pModelList.Size = new System.Drawing.Size(350, 280);
            this.pModelList.TabIndex = 4;
            // 
            // gbModels
            // 
            this.gbModels.Controls.Add(this.dgvModelList);
            this.gbModels.Controls.Add(this.pModelButtons);
            this.gbModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbModels.Location = new System.Drawing.Point(0, 0);
            this.gbModels.Name = "gbModels";
            this.gbModels.Size = new System.Drawing.Size(350, 280);
            this.gbModels.TabIndex = 2;
            this.gbModels.TabStop = false;
            this.gbModels.Text = "Модель";
            // 
            // dgvModelList
            // 
            this.dgvModelList.AllowUserToAddRows = false;
            this.dgvModelList.AllowUserToDeleteRows = false;
            this.dgvModelList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModelList.Location = new System.Drawing.Point(3, 47);
            this.dgvModelList.Name = "dgvModelList";
            this.dgvModelList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModelList.Size = new System.Drawing.Size(344, 230);
            this.dgvModelList.TabIndex = 0;
            this.dgvModelList.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvModelList_RowValidated);
            // 
            // pModelButtons
            // 
            this.pModelButtons.Controls.Add(this.btnSaveChangeModel);
            this.pModelButtons.Controls.Add(this.btnDeleteModel);
            this.pModelButtons.Controls.Add(this.btnAddModel);
            this.pModelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pModelButtons.Location = new System.Drawing.Point(3, 16);
            this.pModelButtons.Name = "pModelButtons";
            this.pModelButtons.Size = new System.Drawing.Size(344, 31);
            this.pModelButtons.TabIndex = 1;
            // 
            // btnSaveChangeModel
            // 
            this.btnSaveChangeModel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaveChangeModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveChangeModel.Location = new System.Drawing.Point(210, 0);
            this.btnSaveChangeModel.Name = "btnSaveChangeModel";
            this.btnSaveChangeModel.Size = new System.Drawing.Size(130, 31);
            this.btnSaveChangeModel.TabIndex = 0;
            this.btnSaveChangeModel.Text = "Сохранить изменения";
            this.btnSaveChangeModel.UseVisualStyleBackColor = true;
            this.btnSaveChangeModel.Click += new System.EventHandler(this.btnSaveChangeModel_Click);
            // 
            // btnDeleteModel
            // 
            this.btnDeleteModel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteModel.Location = new System.Drawing.Point(105, 0);
            this.btnDeleteModel.Name = "btnDeleteModel";
            this.btnDeleteModel.Size = new System.Drawing.Size(105, 31);
            this.btnDeleteModel.TabIndex = 1;
            this.btnDeleteModel.Text = "Удалить запись";
            this.btnDeleteModel.UseVisualStyleBackColor = true;
            this.btnDeleteModel.Click += new System.EventHandler(this.btnDeleteModel_Click);
            // 
            // btnAddModel
            // 
            this.btnAddModel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddModel.Location = new System.Drawing.Point(0, 0);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(105, 31);
            this.btnAddModel.TabIndex = 2;
            this.btnAddModel.Text = "Добавить запись";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // FCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 325);
            this.Controls.Add(this.pModelList);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pBrandList);
            this.Controls.Add(this.pFooter);
            this.Name = "FCars";
            this.Text = "Справочник по моделям автомобилей";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FCars_FormClosing);
            this.Load += new System.EventHandler(this.FCars_Load);
            this.pFooter.ResumeLayout(false);
            this.pBrandList.ResumeLayout(false);
            this.gbBrands.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrandList)).EndInit();
            this.pBrandButtons.ResumeLayout(false);
            this.pModelList.ResumeLayout(false);
            this.gbModels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelList)).EndInit();
            this.pModelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pFooter;
        private System.Windows.Forms.Panel pBrandList;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pModelList;
        private System.Windows.Forms.DataGridView dgvBrandList;
        private System.Windows.Forms.DataGridView dgvModelList;
        private System.Windows.Forms.Panel pModelButtons;
        private System.Windows.Forms.Button btnSaveChangeModel;
        private System.Windows.Forms.Button btnDeleteModel;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.GroupBox gbBrands;
        private System.Windows.Forms.Panel pBrandButtons;
        private System.Windows.Forms.GroupBox gbModels;
        private System.Windows.Forms.Button btnDeleteBrand;
        private System.Windows.Forms.Button btnAddBrand;
        private System.Windows.Forms.Button btnSaveChangeBrand;
        private System.Windows.Forms.Button btnCloseForm;
    }
}