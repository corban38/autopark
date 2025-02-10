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
    public partial class fProviders : Form
    {
        OleDbConnection con;
        OleDbDataAdapter daProviders;        
        DataSet DS;
        
        // флаг успешного изменения БД
        bool dataChanged = false;
        DialogResult dResult = DialogResult.Cancel;
        public fProviders()
        {
            con = new OleDbConnection(MyNeedsFunction.connectionString());
            con.Open();
            
            InitializeComponent();
        }

        void AddItem()
        {
            // создаем новую строку поставщиков
            DataRow row = DS.Tables["providers"].NewRow();

            // добавляем новую строку в таблицу поставщиков
            DS.Tables["providers"].Rows.Add(row);
            if (!dataChanged)
            {
                dataChanged = true;
            }
        }
        private void RemoveItem() {
            foreach (DataGridViewRow row in dgvList.SelectedRows)
            {
                dgvList.Rows.Remove(row);
                if (!dataChanged)
                {
                    dataChanged = true;
                }
            }
            
        }
        private void SaveChanges()
        {
            OleDbCommandBuilder _ = new OleDbCommandBuilder(daProviders);
            daProviders.Update(DS.Tables["providers"]);
            DS.AcceptChanges();
            GetProvidersList();
            dResult = DialogResult.OK;
            dataChanged = false;
        }

        void GetProvidersList()
        {
            string listQuery = "SELECT " + // запрос списка поставщиков
                " id" +
                ", title" +
                ", phone" +
                ", description" +
                " FROM providers" +
                ";";
            daProviders = new OleDbDataAdapter(listQuery, con);
            DS = new DataSet();
            daProviders.Fill(DS, "providers");
            dgvList.DataSource = DS.Tables["providers"];
            // настройка столбцов в сетке
            foreach (DataGridViewColumn column in dgvList.Columns)
            {
                switch (column.Name)
                {
                    case "title":
                        column.HeaderText = "Поставщик";
                        column.Width = 150;
                        break;
                    case "description":
                        column.HeaderText = "Комментарий";
                        break;
                    case "phone":
                        column.HeaderText = "Телефон";
                        column.Width = 120;
                        break;                    
                    case "id":
                        column.Visible = false;
                        break;
                }
            }
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            dgvList.CurrentCell = cell;
                            break;
                        }
                    }
                    break;
                }
            }


        }

        private void fProviders_Load(object sender, EventArgs e)
        {
            GetProvidersList();
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
                case Keys.F4: AddItem();
                    break;                
                case Keys.F8: RemoveItem();
                    break;
                case Keys.Delete: RemoveItem();
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
                dResult = MessageBox.Show(
                    "Вы хотите сохранить изменения?", "Сохранение",
                    MessageBoxButtons.YesNoCancel);
                switch (dResult)
                {
                    case DialogResult.Yes:
                        SaveChanges();
                        break;
                    case DialogResult.No:
                        break;
                    default: e.Cancel = true;
                        break;
                }
            }
            // закрываем соединение с БД
            con.Close();
            // и возвращаем флаг изменения БД в качестве результата
            DialogResult = DialogResult.OK;
        }
    }
}
