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
    public partial class FCars : Form
    {
        OleDbConnection con;
        OleDbDataAdapter daBrand;
        OleDbDataAdapter daModel;
        OleDbCommand cmd;
        DataSet dsBrand;
        DataSet dsModel;
        DataSet DS;
        // флаг успешного изменения БД
        DialogResult dResult = DialogResult.Cancel;
        public FCars()
        {
            // устанавливаем соединение с БД
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=autopark.mdb");
            con.Open();            
            // инициализация формы
            InitializeComponent();
            
        }

        private void FCars_Load(object sender, EventArgs e)
        {
            // заполняем сетку из БД
            GetCarsList();
        }

        void GetCarsList() {
            DS = new DataSet();
            // адаптер таблицы производителей
            daBrand = new OleDbDataAdapter("SELECT * FROM car_brand", con);
            // записываем таблицу производителей в DataSet
            daBrand.Fill(DS, "car_brand");
            // адаптер таблицы моделей
            daModel = new OleDbDataAdapter("SELECT * FROM car_model", con);
            // записываем таблицу моделей в DataSet
            daModel.Fill(DS, "car_model");
            // устанавливаем связь между таблицами производителей и моделями
            DS.Relations.Add(new DataRelation("Brand_Model", DS.Tables["car_brand"].Columns["cb_id"], 
                DS.Tables["car_model"].Columns["cm_brand_id"]));
            // заполняем сетки производителей и моделей
            dgvBrandList.DataSource = new BindingSource(DS, "car_brand");            
            dgvModelList.DataSource = 
                new BindingSource((BindingSource)dgvBrandList.DataSource, "Brand_Model");
            // настройка столбцов в сетках
            dgvBrandList.ColumnHeadersVisible = false;
            dgvModelList.ColumnHeadersVisible = false;
            dgvBrandList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvModelList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in dgvBrandList.Columns)
            {                
                column.Visible = column.Name == "cb_title";
            }
            foreach (DataGridViewColumn column in dgvModelList.Columns)
            {
                column.Visible = column.Name == "cm_title";
            }

            foreach (DataGridViewRow row in dgvBrandList.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            dgvBrandList.CurrentCell = cell;
                            break;
                        }
                    }
                    break;
                }
            }
            foreach (DataGridViewRow row in dgvModelList.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            dgvModelList.CurrentCell = cell;
                            break;
                        }
                    }
                    break;
                }
            }
        }


        

        private void FCars_FormClosing(object sender, FormClosingEventArgs e)
        {
            // закрываем соединение с БД
            con.Close();
            // и возвращаем флаг изменения БД в качестве результата
            DialogResult = dResult;
        }

        private void DgvModelList_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnSaveChangeModel_Click(object sender, EventArgs e)
        {
            // создаем объект OleDbCommandBuilder
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(daModel);
            // сохраняем изменения в базе
            daModel.Update(DS.Tables["car_model"]);
            DS.AcceptChanges();
            // обновляем данные в сетке
            GetCarsList();
            // устанавливаем флаг успешного изменения БД
            dResult = DialogResult.OK;
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            // создаем новую строку моделей
            DataRow row = DS.Tables["car_model"].NewRow();             
            // вставляем ID текущего производителя
            row["cm_brand_id"] = dgvBrandList.CurrentRow.Cells["cb_id"].Value;
            // добавляем новую строку в таблицу моделей
            DS.Tables["car_model"].Rows.Add(row);
        }

        private void btnDeleteModel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvModelList.SelectedRows)
            {
                dgvModelList.Rows.Remove(row);
            }
            // создаем объект OleDbCommandBuilder
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(daModel);
            // сохраняем изменения в базе
            daModel.Update(DS.Tables["car_model"]);
            DS.AcceptChanges();
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            // создаем новую строку производителей
            DataRow row = DS.Tables["car_brand"].NewRow();
            // добавляем новую строку в таблицу производителей
            DS.Tables["car_brand"].Rows.Add(row);
        }

        private void btnDeleteBrand_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(                 
                "При удалении производителя все модели этого производителя будут удалены!\n\r" +
                "Удаляем?",
                "Вы действительно хотите удалить запись?",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("Вы отказались удалять!");
                return;
            }
            foreach (DataGridViewRow row in dgvBrandList.SelectedRows)
            {
                dgvBrandList.Rows.Remove(row);
            }
            // создаем объект OleDbCommandBuilder            
            OleDbCommandBuilder cbBrand = new OleDbCommandBuilder(daBrand);
            OleDbCommandBuilder cbModel = new OleDbCommandBuilder(daModel);
            // сохраняем изменения в базе
            daBrand.Update(DS.Tables["car_brand"]);
            daModel.Update(DS.Tables["car_model"]);
            DS.AcceptChanges();
        }

        private void btnSaveChangeBrand_Click(object sender, EventArgs e)
        {
            // создаем объект OleDbCommandBuilder            
            OleDbCommandBuilder cbBrand = new OleDbCommandBuilder(daBrand);
            OleDbCommandBuilder cbModel = new OleDbCommandBuilder(daModel);
            // сохраняем изменения в базе
            daBrand.Update(DS.Tables["car_brand"]);
            daModel.Update(DS.Tables["car_model"]);
            DS.AcceptChanges();
            // обновляем данные в сетке
            GetCarsList();
            // устанавливаем флаг успешного изменения БД
            dResult = DialogResult.OK;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            DialogResult = dResult;
        }
    }
}
