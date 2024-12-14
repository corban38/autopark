using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace autopark
{
    public partial class Form1 : Form
    {
        string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=autopark.mdb";
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
       // DataSet dsMaintenances = new DataSet();
        public Form1()
        {
            // con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=autopark.mdb");
            // con.Open();            
            InitializeComponent();
            
            
        }
        void FillExpenseItemsInComboBox()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                DataSet cbDS = new DataSet();
                OleDbDataAdapter cbDaExpenseItems =
                    new OleDbDataAdapter("SELECT * FROM expense_item", conn);
                cbDaExpenseItems.Fill(cbDS, "expense_item");
                cbExpenseItems.DataSource = new BindingSource(cbDS, "expense_item");
                cbExpenseItems.DisplayMember = "ei_title";
                cbExpenseItems.ValueMember = "ei_id";
                conn.Close();
            }
        }
        void FillTypesOfCarRepairWorkInComboBox()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                DataSet cbDS = new DataSet();
                OleDbDataAdapter cbDaTCRW = 
                    new OleDbDataAdapter("SELECT * FROM types_of_car_repair_work", conn);
                cbDaTCRW.Fill(cbDS, "types_of_car_repair_work");
                cbTypesOfCarRepairWork.DataSource = new BindingSource(cbDS, "types_of_car_repair_work");               
                cbTypesOfCarRepairWork.DisplayMember = "tcrw_title";
                cbTypesOfCarRepairWork.ValueMember = "tcrw_id";
                conn.Close();
            }
        }
        void FillCarsBrandModelInComboBoxes()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                DataSet cbDS = new DataSet();
                OleDbDataAdapter cbDaBrand = new OleDbDataAdapter("SELECT * FROM car_brand", conn);
                OleDbDataAdapter cbDaModel = new OleDbDataAdapter("SELECT * FROM car_model", conn);
                cbDaBrand.Fill(cbDS, "car_brand");
                cbDaModel.Fill(cbDS, "car_model");
                cbDS.Relations.Add(new DataRelation(
                            "Brand_Model", 
                            cbDS.Tables["car_brand"].Columns["cb_id"],
                            cbDS.Tables["car_model"].Columns["cm_brand_id"]
                            )
                        );

                cbCarBrand.DataSource = new BindingSource(cbDS, "car_brand");
                cbCarBrand.DisplayMember = "cb_title";
                cbCarModel.DataSource =
                    new BindingSource((BindingSource)cbCarBrand.DataSource, "Brand_Model");
                cbCarModel.ValueMember = "cm_id";
                cbCarModel.DisplayMember = "cm_title";
                conn.Close();
            }
        }
        void GetMaintenances(string car_id)
        {
            string sQuery = "SELECT " + // запрос списка ТО по автомобилю
                " maintenance.m_id AS m_id, " +
                " types_of_car_repair_work.tcrw_title AS tcrw_title, " +
                " maintenance.m_mileage AS m_mileage, " +
                " maintenance.m_date AS m_date, " +
                " maintenance_status.ms_status AS ms_status, " +
                " maintenance.m_ms_id AS ms_id, " +
                " maintenance.m_tcrw_id AS tcrw_id, " +
                " maintenance.m_car_id AS car_id, " +
                " maintenance.m_description AS m_description " +
                " FROM (maintenance " +
                " INNER JOIN types_of_car_repair_work " +                
                " ON types_of_car_repair_work.tcrw_id = maintenance.m_tcrw_id) " +
                
                " INNER JOIN maintenance_status " +
                " ON maintenance_status.ms_id = maintenance.m_ms_id " +
                " WHERE maintenance.m_car_id = " + car_id +
                " ;";
            string sQueryExpenses = "SELECT "
                + " expenses.exp_id AS id, "
                + " expense_item.ei_title AS expense_name, "
                + " expenses.exp_amount AS amount, "
                + " expenses.exp_cmnt_id AS cmnt_id, "
                + " expenses.exp_ei_id AS ei_id, "                
                + " expenses.exp_description AS exp_description "
                + " FROM expenses "
                + " INNER JOIN expense_item ON expenses.exp_ei_id = expense_item.ei_id"
                + " WHERE expenses.exp_car_id = " + car_id
                + " ;";
            string sqExpenses = new MyNeedsFunction().GetQueryStringExpenses(car_id);
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbDataAdapter daMaintenances = new OleDbDataAdapter(sQuery, conn);
                OleDbDataAdapter daMaintenanceExpenses = new OleDbDataAdapter(sqExpenses, conn);
                DataSet dsMaintenances = new DataSet();
                daMaintenances.Fill(dsMaintenances, "maintenances");
                daMaintenanceExpenses.Fill(dsMaintenances, "expenses");
                // устанавливаем связь между таблицами ТО и расходами
                dsMaintenances.Relations.Add(
                    new DataRelation(
                        "maintenances_expenses", 
                        dsMaintenances.Tables["maintenances"].Columns["m_id"],
                        dsMaintenances.Tables["expenses"].Columns["cmnt_id"]
                        )
                    );
                // заполняем сетки производителей и моделей
                dgvMaintenanceList.DataSource = new BindingSource(dsMaintenances, "maintenances");
                dgvMaintenanceExpensesList.DataSource =
                    new BindingSource((BindingSource)dgvMaintenanceList.DataSource, "maintenances_expenses");

                
            }

            // настройка столбцов в сетке список ТО
            foreach (DataGridViewColumn column in dgvMaintenanceList.Columns)
            {
                switch (column.Name)
                {
                    case "tcrw_title":
                        column.HeaderText = "Наименование";
                        column.Width = 150;
                        column.Visible = true;
                        break;
                    case "m_description":
                        column.HeaderText = "Комментарий";
                        column.Visible = true;
                        break;
                    case "m_mileage":
                        column.HeaderText = "Пробег";
                        column.Width = 120;
                        column.Visible = true;
                        break;
                    case "ms_status":
                        column.HeaderText = "Статус";
                        column.Width = 120;
                        column.Visible = true;
                        break;
                    case "m_date":
                        column.HeaderText = "Дата";
                        column.Width = 100;
                        column.Visible = true;
                        break;
                    default:
                        column.Visible = false;
                        break;
                    

                }
            }
            foreach (DataGridViewRow row in dgvMaintenanceList.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            dgvMaintenanceList.CurrentCell = cell;
                            break;
                        }
                    }
                    break;
                }
            }
            // настройка столбцов в сетке список расходов на ТО
            foreach (DataGridViewColumn column in dgvMaintenanceExpensesList.Columns)
            {
                switch (column.Name)
                {
                    case "expense_name":
                        column.HeaderText = "Наименование";
                        column.Width = 150;
                        column.Visible = true;
                        break;
                    case "exp_description":
                        column.HeaderText = "Комментарий";
                        column.Visible = true;
                        break;
                    case "amount":
                        column.HeaderText = "Сумма";
                        column.Width = 120;
                        column.Visible = true;
                        break;                    
                    default:
                        column.Visible = false;
                        break;


                }
            }
            foreach (DataGridViewRow row in dgvMaintenanceExpensesList.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            dgvMaintenanceExpensesList.CurrentCell = cell;
                            break;
                        }
                    }
                    break;
                }
            }
        }
        void GetCarsList()
        {
            string sQuery = "SELECT " + // запрос списка автомобилей в парке
                " car.c_id AS id, " +
                " car_brand.cb_title & ' ' & car_model.cm_title  AS fullName, " +
                " car.c_current_mileage AS current_mileage, " +
                " car.c_year_of_manufacture AS year_of_manufacture, " +
                " car.c_description AS description " +
                " FROM car " +                
                " INNER JOIN " +
                " (" +
                " SELECT * FROM car_model " +
                " INNER JOIN car_brand ON car_model.cm_brand_id = car_brand.cb_id " +
                ") AS car_model ON car.c_model_id = car_model.cm_id " +                
                " ;";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbDataAdapter daCars = new OleDbDataAdapter(sQuery, conn);
                DataSet dsCars = new DataSet();
                daCars.Fill(dsCars, "car");
                dgvCarsList.DataSource = dsCars.Tables["car"];
            }

            // настройка столбцов в сетке
            foreach (DataGridViewColumn column in dgvCarsList.Columns) {
                switch (column.Name)
                {
                    case "fullName":
                        column.HeaderText = "Автомобиль";
                        column.Width = 150;
                        break;
                    case "description":
                        column.HeaderText = "Комментарий";
                        break;
                    case "current_mileage":
                        column.HeaderText = "Текущий пробег";
                        column.Width = 120;
                        break;
                    case "year_of_manufacture":
                        column.HeaderText = "Год выпуска";
                        column.Width = 100;
                        break;
                    case "id":
                        column.Visible = false;
                        break;                    
                }  
            }
            foreach (DataGridViewRow row in dgvCarsList.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            dgvCarsList.CurrentCell = cell;
                            break;
                        }
                    }                    
                    break;
                }
            }

            
        }

        void GetStatusList()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                DataSet cbDS = new DataSet();
                OleDbDataAdapter cbDaStatus =
                    new OleDbDataAdapter("SELECT * FROM maintenance_status", conn);
                cbDaStatus.Fill(cbDS, "maintenance_status");
                cbStatusTO.DataSource = new BindingSource(cbDS, "maintenance_status");
                cbStatusTO.DisplayMember = "ms_status";
                cbStatusTO.ValueMember = "ms_id";
                conn.Close();
            }
            
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FCars fCars = new FCars())
            {
                if (fCars.ShowDialog() == DialogResult.OK)
                {
                    FillCarsBrandModelInComboBoxes();
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetCarsList();
            FillCarsBrandModelInComboBoxes();
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            pCarGridBtns.Visible = true;
            if (cbCarModel.SelectedIndex == -1) 
            {
                MessageBox.Show("Справочник моделей автомобиля пуст!\r\n" +
                    "Для продолжения работы программы, " +
                    "корректно заполните справочник автомобилей.");
                return; 
            }
            DateTime date1 = new DateTime(2000, 1, 1);
            string _mileage =
                (mtbCurrentMileage.Text != "") ? mtbCurrentMileage.Text : "0";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                cmd = new OleDbCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO car " +
                    "(c_model_id, c_current_mileage, c_year_of_manufacture, c_description) " +
                    "VALUES (" +
                    cbCarModel.SelectedValue.ToString() + ", " +
                    _mileage + ", '" +
                    dtYearOfManufacture.Text +
                    "', '')";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            
            GetCarsList();
            pAppendCarInPark.Visible = false;
        }

        private void btnAddCarCancel_Click(object sender, EventArgs e)
        {
            pCarGridBtns.Visible = true;
            pAppendCarInPark.Visible = false;
        }

        private void btnInsertNewCarInPark_Click(object sender, EventArgs e)
        {
            pCarGridBtns.Visible = false;
            pAppendCarInPark.Visible = true;
        }

        private void bntSaveNewCurrentMileage_Click(object sender, EventArgs e)
        {
            string _mileage =
                (mtbNewCurrentMileage.Text != "") ? mtbNewCurrentMileage.Text : "0";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand uCmd = new OleDbCommand();
                uCmd.CommandType = System.Data.CommandType.Text;
                uCmd.CommandText = "UPDATE car " +
                    " SET c_current_mileage = " + _mileage +
                    " WHERE c_id = " + dgvCarsList.CurrentRow.Cells["id"].Value.ToString() +
                    ";";
                uCmd.Connection = conn;
                uCmd.ExecuteNonQuery();
            }

            GetCarsList();

            pCarGridBtns.Visible = true;
            pCurrentMileageChange.Visible = false;
        }

        private void bntCancelNewCurrentMileage_Click(object sender, EventArgs e)
        {
            pCarGridBtns.Visible = true;
            pCurrentMileageChange.Visible = false;
        }

        private void btnChangeCurrentMileage_Click(object sender, EventArgs e)
        {
            try
            {
                lblCarName.Text = dgvCarsList.CurrentRow.Cells["fullname"].Value.ToString();
            }
            catch 
            {
                MessageBox.Show("Не выбран автомобиль для изменения пробега!");
                return; 
            }



            pCarGridBtns.Visible = false;
            pCurrentMileageChange.Visible = true;
            
        }

        private void btnChangeDescription_Click(object sender, EventArgs e)
        {
            try
            {
                lblCarNameChDescr.Text = dgvCarsList.CurrentRow.Cells["fullname"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Не выбран автомобиль для изменения пробега!");
                return;
            }

            tbDescription.Text = dgvCarsList.CurrentRow.Cells["description"].Value.ToString();
            pCarGridBtns.Visible = false;            
            pChangeDescription.Visible = true;
        }

        private void btnCancelChangeDescription_Click(object sender, EventArgs e)
        {
            pChangeDescription.Visible = false;
            pCarGridBtns.Visible = true;            
        }

        private void btnSaveChangeDescription_Click(object sender, EventArgs e)
        {
            pChangeDescription.Visible = false;
            pCarGridBtns.Visible = true;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand uCmd = new OleDbCommand();
                uCmd.CommandType = System.Data.CommandType.Text;
                uCmd.CommandText = "UPDATE car " +
                    " SET c_description = '" + tbDescription.Text + "'" +
                    " WHERE c_id = " + dgvCarsList.CurrentRow.Cells["id"].Value.ToString() +
                    ";";
                uCmd.Connection = conn;
                uCmd.ExecuteNonQuery();
            }

            GetCarsList();
        }

        private void dgvCarsList_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCarsList.Rows)
            {
                if (row == dgvCarsList.CurrentRow)
                {
                    gbCarsTO.Text = "Информация по обслуживанию автомобиля "
                                    + row.Cells["fullname"].Value.ToString();
                    GetMaintenances(row.Cells["id"].Value.ToString());
                    break;
                }
            }
        }

        private void btnAppendTO_Click(object sender, EventArgs e)
        {
            FillTypesOfCarRepairWorkInComboBox();
            GetStatusList();
            pAppendRecordForTO.Tag = null;
            pBtnsForCarTO.Visible = false;
            pAppendRecordForTO.Visible = true;
        }

        private void btnCancelNewTO_Click(object sender, EventArgs e)
        {
            pBtnsForCarTO.Visible = true;
            pAppendRecordForTO.Visible = false;
        }

        private void btnSaveNewTO_Click(object sender, EventArgs e)
        {
            string _mileage =
                (mtbMileageTCRW.Text != "") ? mtbMileageTCRW.Text : "0";
            if (_mileage == "0")
            {
                MessageBox.Show("Некорректное значение пробега!");
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand iCmd = new OleDbCommand();
                iCmd.CommandType = System.Data.CommandType.Text;
                if (pAppendRecordForTO.Tag == null) 
                {
                    iCmd.CommandText = "INSERT INTO maintenance " +
                    " (m_tcrw_id, m_mileage, m_date, m_car_id, m_ms_id, m_description) "
                    + " VALUES("
                    + cbTypesOfCarRepairWork.SelectedValue.ToString() + ", "
                    + _mileage + ", "
                    + (DateTime.TryParse(mtbDateTO.Text, out DateTime _dt) ? "'" + mtbDateTO.Text + "', " : "Null, ")
                    + dgvCarsList.CurrentRow.Cells["id"].Value.ToString() + ", "
                    + cbStatusTO.SelectedValue.ToString() + ", "
                    + "'" + tbDescriptionTO.Text + "'"
                    + ") "
                    + ";";
                }
                else
                {
                    iCmd.CommandText = "UPDATE maintenance "
                        + "SET "
                    + " m_tcrw_id = " + cbTypesOfCarRepairWork.SelectedValue.ToString()
                    + ", m_mileage = " + _mileage
                    + ", m_date = "
                    + (DateTime.TryParse(mtbDateTO.Text, out DateTime _dt) ? "'" + mtbDateTO.Text + "'" : "Null")
                    + ", m_ms_id = " + cbStatusTO.SelectedValue.ToString()
                    + ", m_description = '" + tbDescriptionTO.Text + "'"
                    + " WHERE m_id = " + pAppendRecordForTO.Tag.ToString()
                    + ";";
                }

                iCmd.Connection = conn;
                iCmd.ExecuteNonQuery();
            }
            pBtnsForCarTO.Visible = true;
            pAppendRecordForTO.Visible = false;
            GetMaintenances(dgvCarsList.CurrentRow.Cells["id"].Value.ToString());
        }

        private void btnUpdateTO_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                pAppendRecordForTO.Tag = dgvMaintenanceList.CurrentRow.Cells["m_id"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Не выбрана запись об обслуживании для изменения!");
                return;
            }
            FillTypesOfCarRepairWorkInComboBox();
            GetStatusList();
            cbStatusTO.SelectedValue = dgvMaintenanceList.CurrentRow.Cells["ms_id"].Value;
            cbTypesOfCarRepairWork.SelectedValue = dgvMaintenanceList.CurrentRow.Cells["tcrw_id"].Value;
            mtbMileageTCRW.Text = dgvMaintenanceList.CurrentRow.Cells["m_mileage"].Value.ToString();
            if (dgvMaintenanceList.CurrentRow.Cells["m_date"].Value != null)
            {
                mtbDateTO.Text = dgvMaintenanceList.CurrentRow.Cells["m_date"].Value.ToString();
            }
            tbDescriptionTO.Text = dgvMaintenanceList.CurrentRow.Cells["m_description"].Value.ToString();
            pBtnsForCarTO.Visible = false;
            pAppendRecordForTO.Visible = true;
            GetMaintenances(dgvCarsList.CurrentRow.Cells["id"].Value.ToString());
        }

        private void btnAppendExpense_Click(object sender, EventArgs e)
        {
            FillExpenseItemsInComboBox();
            tbAmount.Text = "0,00";
            tbExpenseDescription.Text = "";
            pDetailExpense.Tag = null;
            pBtnsForExpensesTO.Visible = false;
            pDetailExpense.Visible = true;
            //GetMaintenances(dgvCarsList.CurrentRow.Cells["id"].Value.ToString());
        }

        private void btnCancelChangeExpense_Click(object sender, EventArgs e)
        {
            pBtnsForExpensesTO.Visible = true;
            pDetailExpense.Visible = false;
        }

        private void btnSaveExpense_Click(object sender, EventArgs e)
        {
            if (dgvMaintenanceList.CurrentRow == null) 
            {
                pBtnsForExpensesTO.Visible = true;
                pDetailExpense.Visible = false;
                return; 
            }
            if (!float.TryParse(tbAmount.Text, out float fAmount))
            {
                MessageBox.Show("Неверный формат суммы!");
                return;
            }
            int _idxRow = dgvMaintenanceList.CurrentRow.Index;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.CommandType = System.Data.CommandType.Text;
                if (pDetailExpense.Tag == null)
                {
                    Cmd.CommandText = "INSERT INTO expenses " +
                    " (exp_amount, exp_cmnt_id, exp_ei_id, exp_car_id, exp_description) "
                    + " VALUES('"
                    + String.Format("{0:f2}", fAmount) + "', "
                    + dgvMaintenanceList.CurrentRow.Cells["m_id"].Value.ToString() + ", "
                    + cbExpenseItems.SelectedValue.ToString() + ", "
                    + dgvMaintenanceList.CurrentRow.Cells["car_id"].Value.ToString() + ", "
                    + "'" + tbExpenseDescription.Text + "'"
                    + ") "
                    + ";";
                }
                else
                {
                    Cmd.CommandText = "UPDATE expenses "
                        + "SET "
                    + " exp_amount = '" + tbAmount.Text + "'"
                    + ", exp_ei_id = " + cbExpenseItems.SelectedValue.ToString()                    
                    + ", exp_description = '" + tbExpenseDescription.Text + "'"
                    + " WHERE exp_id = " + pDetailExpense.Tag.ToString()
                    + ";";
                }

                Cmd.Connection = conn;
                Cmd.ExecuteNonQuery();
            }

            pBtnsForExpensesTO.Visible = true;
            pDetailExpense.Visible = false;
            GetMaintenances(dgvCarsList.CurrentRow.Cells["id"].Value.ToString());
            dgvMaintenanceList.CurrentCell = dgvMaintenanceList.Rows[_idxRow].Cells["tcrw_title"];
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender.GetType() != typeof(System.Windows.Forms.TextBox))
                throw new ArgumentException("sender");

            System.Windows.Forms.TextBox control = (System.Windows.Forms.TextBox)sender;

            if (e.KeyChar == '.' || e.KeyChar == '-')
                e.KeyChar = ',';

            if (!char.IsDigit(e.KeyChar)                            
                      && e.KeyChar != ','
                      && e.KeyChar != '\b'//backspace
                )
                e.Handled = true;

            

            if (e.KeyChar == ',')
            {
                if (control.SelectionStart == 0)
                    e.Handled = true;

                foreach (char c in control.Text)
                    if (c == ',')
                        e.Handled = true;
            }
        }

        private void btnUpdateExpense_Click(object sender, EventArgs e)
        {
            FillExpenseItemsInComboBox();
            cbExpenseItems.SelectedValue = dgvMaintenanceExpensesList.CurrentRow.Cells["ei_id"].Value;
            tbAmount.Text = dgvMaintenanceExpensesList.CurrentRow.Cells["amount"].Value.ToString();
            tbExpenseDescription.Text = 
                dgvMaintenanceExpensesList.CurrentRow.Cells["exp_description"].Value.ToString();
            pDetailExpense.Tag = dgvMaintenanceExpensesList.CurrentRow.Cells["id"].Value.ToString();
            pBtnsForExpensesTO.Visible = false;
            pDetailExpense.Visible = true;
        }

        private void btnDeleteExpense_Click(object sender, EventArgs e)
        {            
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string sqDelString = "DELETE * FROM expenses WHERE exp_id = ";
                conn.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.CommandType = System.Data.CommandType.Text;
                
                Cmd.Connection = conn;
                foreach (DataGridViewRow row in dgvMaintenanceExpensesList.SelectedRows)
                {
                    Cmd.CommandText = sqDelString + row.Cells["id"].Value.ToString();
                    Cmd.ExecuteNonQuery();
                    dgvMaintenanceExpensesList.Rows.Remove(row);
                }
            }
        }

        private void btnDeleteTO_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                string sqDelString = "DELETE * FROM maintenance " +                   
                    "WHERE m_id = ";
                conn.Open();
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.CommandType = System.Data.CommandType.Text;
                Cmd.Connection = conn;
                foreach (DataGridViewRow row in dgvMaintenanceList.SelectedRows)
                {
                    Cmd.CommandText = sqDelString + row.Cells["m_id"].Value.ToString();
                    Cmd.ExecuteNonQuery();
                    dgvMaintenanceList.Rows.Remove(row);
                }
            }
        }

        private void ItemsExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // запуск новой формы
            using (FCars fCars = new FCars())
            {
                if (fCars.ShowDialog() == DialogResult.OK)
                {
                    FillCarsBrandModelInComboBoxes();
                }

            }
        }
    }
}
