using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autopark
{
    public partial class FProducts : Form
    {
        private OleDbDataAdapter daProducts;
        private readonly DataSet DS;
        // запрос списка брендов
        private OleDbDataAdapter daBrands;
        private readonly DataSet dsBrands;
        readonly string BrandListQuery = "SELECT id AS br_id, title AS br_title FROM brand;";
        // запрос списка единиц измерения
        private OleDbDataAdapter daMeasureUnits;
        private readonly DataSet dsMeasureUnits;
        readonly string MeasureUnitsListQuery = "SELECT id, short FROM measure_units;";

        readonly string listQuery = "SELECT " + // запрос списка поставщиков
                " * " +                
                " FROM products" +
                //" LEFT JOIN brand ON products.brand_id = brand.id)"+
                //" LEFT JOIN measure_units ON products.mu_id = measure_units.id" +
                ";";
        
        // флаг успешного изменения БД
        bool dataChanged = false;
        public FProducts()
        {
            InitializeComponent();
            DGVList.AllowUserToAddRows = false;
            DGVList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVList.ReadOnly = true;
            using (OleDbConnection conn = new OleDbConnection(MyNeedsFunction.connectionString()))
            {
                daProducts = new OleDbDataAdapter(listQuery, conn);
                DS = new DataSet();
                daProducts.Fill(DS, "prods");
                DGVList.DataSource = DS.Tables["prods"];
                
                daBrands = new OleDbDataAdapter(BrandListQuery, conn);
                dsBrands = new DataSet();
                daBrands.Fill(dsBrands, "brands");

                DataGridViewComboBoxColumn dgvComboBoxColumn = new DataGridViewComboBoxColumn();
                dgvComboBoxColumn.DataSource = dsBrands.Tables["brands"];
                dgvComboBoxColumn.DisplayMember = "br_title";
                dgvComboBoxColumn.ValueMember = "br_id";
                dgvComboBoxColumn.Name = "brand_name";
                dgvComboBoxColumn.HeaderText = "Производитель";
                dgvComboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

                daMeasureUnits = new OleDbDataAdapter(MeasureUnitsListQuery, conn);
                dsMeasureUnits = new DataSet();
                daMeasureUnits.Fill(dsMeasureUnits, "mu");

                DataGridViewComboBoxColumn MesureUnitsColumn = new DataGridViewComboBoxColumn();
                MesureUnitsColumn.DataSource = dsMeasureUnits.Tables["mu"];
                MesureUnitsColumn.DisplayMember = "short";
                MesureUnitsColumn.ValueMember = "id";
                MesureUnitsColumn.Name = "unit_name";
                MesureUnitsColumn.HeaderText = "Ед.изм.";
                MesureUnitsColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

                DGVList.Columns.Add(MesureUnitsColumn);
                DGVList.Columns.Add(dgvComboBoxColumn);
            }
        }
        private void AdjustColumnOrder()
        {
            foreach (DataGridViewColumn column in DGVList.Columns)
            {
                switch (column.Name) {
                    case "title":
                        column.DisplayIndex = 0;
                        break;
                    case "count":
                        column.DisplayIndex = 1;
                        break;
                    case "unit_name":
                        column.DisplayIndex = 2;
                        break;
                    case "brand_name":
                        column.DisplayIndex = 3;
                        break;
                    case "description":
                        column.DisplayIndex = 4;
                        column.HeaderText = "Примечания";
                        break;
                    default: column.Visible = false; break;
                }
            }
            
        }
        void AddItem()
        {
            using (FProductDetail detail = new FProductDetail())
            {
                
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    //; 
                }
            }
        }
        private void EditItem()
        {
            using (FProductDetail detail = new FProductDetail())
            {
                detail.tbTitle.Text = DGVList.CurrentRow.Cells["title"].Value.ToString();
                detail.tbCount.Text = DGVList.CurrentRow.Cells["count"].Value.ToString();
                detail.cbBrands.SelectedValue = DGVList.CurrentRow.Cells["brand_id"].Value;
                detail.cbMeasureUnits.SelectedValue = DGVList.CurrentRow.Cells["mu_id"].Value;
                detail.tbProductDescription.Text = DGVList.CurrentRow.Cells["description"].Value.ToString(); 
                if (detail.ShowDialog() == DialogResult.OK)
                {
                    DGVList.CurrentRow.Cells["count"].Value = detail.tbCount.Text;
                    DGVList.CurrentRow.Cells["description"].Value = detail.tbProductDescription.Text;
                    DGVList.CurrentRow.Cells["brand_id"].Value = detail.cbBrands.SelectedValue;
                    DGVList.CurrentRow.Cells["mu_id"].Value = detail.cbMeasureUnits.SelectedValue;
                }
            }
        }
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void BtnEditItem_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        private void DGVList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGVList.Rows[e.RowIndex].Cells["brand_name"].Value =
                DGVList.Rows[e.RowIndex].Cells["brand_id"].Value;
            DGVList.Rows[e.RowIndex].Cells["unit_name"].Value =
                DGVList.Rows[e.RowIndex].Cells["mu_id"].Value;
        }

        private void FProducts_Load(object sender, EventArgs e)
        {
            AdjustColumnOrder();
            foreach (DataGridViewRow row in DGVList.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            DGVList.CurrentCell = cell;
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
