using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace autopark
{
    public partial class fProviders : Form
    {
        private OleDbDataAdapter daProviders;
        private readonly DataSet DS;

        readonly string listQuery = "SELECT " + // запрос списка поставщиков
                " id" +
                ", title" +
                ", phone" +
                ", description" +
                ", is_deleted" +
                " FROM providers" +
                //" WHERE is_deleted = FALSE"+
                ";";
        // флаг успешного изменения БД
        bool dataChanged = false;
        
        public fProviders()
        {
            InitializeComponent();
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            using (OleDbConnection conn = new OleDbConnection(MyNeedsFunction.connectionString()))
            {
                daProviders = new OleDbDataAdapter(listQuery, conn);
                DS = new DataSet();
                daProviders.Fill(DS, "providers");
                dgvList.DataSource = DS.Tables["providers"];
            }

            // настройка столбцов в сетке
            foreach (DataGridViewColumn column in dgvList.Columns)
            {
                switch (column.Name)
                {
                    case "title":
                        column.HeaderText = "Поставщик";
                        break;
                    case "description":
                        column.HeaderText = "Комментарий";
                        break;
                    case "phone":
                        column.HeaderText = "Телефон";                       
                        break;
                    case "is_deleted":
                        column.Visible = false;
                        break;
                    case "id":
                        column.Visible = false;
                        break;
                }
            }
        }

        void AddItem()
        {
            using(ProviderDetail providerDetail = new ProviderDetail())
            {
                providerDetail.StartPosition = FormStartPosition.CenterParent;
                if (providerDetail.ShowDialog() == DialogResult.OK)
                {
                    // создаем новую строку поставщиков
                    DataRow row = DS.Tables["providers"].NewRow();
                    row["title"] = providerDetail.tbTitle.Text;
                    row["phone"] = providerDetail.tbPhone.Text;
                    row["description"] = providerDetail.tbDescription.Text;
                    row["is_deleted"] = false;
                    // добавляем новую строку в таблицу поставщиков
                    DS.Tables["providers"].Rows.Add(row);
                    //DS.AcceptChanges();
                    dataChanged = true;

                }
            }            
        }
        void EditItem()
        {
            int i = dgvList.CurrentRow.Index;
            DataRow[] curr_rows = DS.Tables["providers"].Select();

            if (curr_rows.Length < 1) {
                MessageBox.Show("Нет строк в наборе");
                return;
            }
            DataRow row = curr_rows[i];
            
            using (ProviderDetail providerDetail = new ProviderDetail())
            {
                providerDetail.StartPosition = FormStartPosition.CenterParent;
                providerDetail.tbTitle.Text = row["title"].ToString();
                providerDetail.tbPhone.Text = row["phone"].ToString();
                providerDetail.tbDescription.Text = row["description"].ToString();

                if (providerDetail.ShowDialog() == DialogResult.OK)
                {
                    // заполняем строку поставщиков новыми данными
                    row["title"] = providerDetail.tbTitle.Text;
                    row["phone"] = providerDetail.tbPhone.Text;
                    row["description"] = providerDetail.tbDescription.Text;

                    dataChanged = true;

                }
            }
        }
        private void RemoveItem() {
            DataRow[] curr_rows = DS.Tables["providers"].Select();
            foreach (DataGridViewRow row in dgvList.SelectedRows)
            {
                int i = row.Index;
                DataRow current_row = curr_rows[i];
                current_row["is_deleted"] = true;
                dataChanged = true;                
            }            
        }
        private void SaveChanges()
        {   
            using (OleDbConnection conn = new OleDbConnection(MyNeedsFunction.connectionString()))
            {
                conn.Open();

                daProviders = new OleDbDataAdapter(listQuery, conn);
                OleDbCommandBuilder _ = new OleDbCommandBuilder(daProviders);

                daProviders.Update(DS.Tables["providers"]);
                DS.AcceptChanges();
            }
            dataChanged = false;
        }
        private void SetColumnsWidth(DataGridView dgv)
        {
            // настройка столбцов в сетке
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                switch (column.Name)
                {
                    case "title":
                        column.Width = 150;
                        break;                    
                    case "phone":                        
                        column.Width = 80;
                        break;                    
                }
            }
        }
        private void fProviders_Load(object sender, EventArgs e)
        {
            SetColumnsWidth(dgvList);
        }

        private void btnAddProvider_Click(object sender, EventArgs e)
        {
            AddItem();            
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
           SaveChanges();          
        }

        private void dgvList_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    AddItem();
                    break;
                case Keys.F4:
                    EditItem();
                    break;
                case Keys.F8:
                    RemoveItem();
                    break;
                case Keys.Delete:
                    RemoveItem();
                    break;
                case Keys.Insert:
                    AddItem();
                    break;
            }
            
        }

        private void fProviders_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataChanged)
            {
                // изменения не сохранены.... 
                DialogResult dResult = MessageBox.Show(
                    "Вы хотите сохранить изменения?", "Изменения не сохранены!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (dResult == DialogResult.Yes)
                {
                    SaveChanges();
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void btnChangeItem_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        private void dgvList_Paint(object sender, PaintEventArgs e)
        {
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if ((bool)row.Cells["is_deleted"].Value)
                {
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                    using (Font font = new Font(
                        dgvList.DefaultCellStyle.Font, FontStyle.Italic | FontStyle.Strikeout))
                    {
                        row.DefaultCellStyle.Font = font;
                    }
                    
                }
            }
        }
    }
}
