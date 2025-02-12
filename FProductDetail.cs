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
    public partial class FProductDetail : Form
    {
        private readonly OleDbDataAdapter daBrands;
        private readonly DataSet dsBrands;
        private readonly OleDbDataAdapter daMeasureUnits;
        private readonly DataSet dsMeasureUnits;

        readonly string BrandsListQuery = "SELECT " + // запрос списка брендов
            " * "+
            " FROM brand"+
            ";";
        readonly string MeasureUnitsListQuery =  // запрос списка единиц измерения
            "SELECT * FROM measure_units;";
        public FProductDetail()
        {
            InitializeComponent();
            using (OleDbConnection conn = new OleDbConnection(MyNeedsFunction.connectionString()))
            {
                daBrands = new OleDbDataAdapter(BrandsListQuery, conn);
                dsBrands = new DataSet();
                daBrands.Fill(dsBrands, "brands");
                cbBrands.DataSource = dsBrands.Tables["brands"];
                cbBrands.DisplayMember = "title";
                cbBrands.ValueMember = "id";

                daMeasureUnits = new OleDbDataAdapter(MeasureUnitsListQuery, conn);
                dsMeasureUnits = new DataSet();
                daMeasureUnits.Fill(dsMeasureUnits, "m_units");
                cbMeasureUnits.DataSource = dsMeasureUnits.Tables["m_units"];
                cbMeasureUnits.DisplayMember = "title";
                cbMeasureUnits.ValueMember = "id";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
