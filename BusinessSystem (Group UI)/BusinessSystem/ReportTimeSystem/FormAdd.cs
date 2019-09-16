using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessSystemDBEntityModel;



namespace BusinessSystem.ReportTimeSystem
{
    public partial class FormAdd : SonForm
    {
        BusinessSystemDBEntityModel.BusinessDataBaseEntities dbcontext = new BusinessDataBaseEntities();
        public FormAdd()
        {
            InitializeComponent();
            var q = from reptime in dbcontext.ReportTimeSystems
                    join eve in dbcontext.Events
                    on reptime.EventID equals eve.EventID
                    select eve.EventName;
            comboBox1.DataSource = q.ToList();
        }

        private void clsAltoButton1_Click(object sender, EventArgs e)
        {
            string strconn = ConfigurationManager.ConnectionStrings["BusinessSystem"].ConnectionString;
            string stradd = "AddReport";
            SqlConnection conn = new SqlConnection(strconn);
            SqlCommand cmd = new SqlCommand(stradd, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter pReturnValue = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            pReturnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(pReturnValue);

            SqlParameter pApplyDateTime = new SqlParameter("@ApplyDateTime", SqlDbType.DateTime);
            pApplyDateTime.Direction = ParameterDirection.Input;
            pApplyDateTime.Value = DateTime.Now;
            cmd.Parameters.Add(pApplyDateTime);

            SqlParameter pEventHours = new SqlParameter("@EventHours", SqlDbType.Float);
            pEventHours.Direction = ParameterDirection.Input;
            pEventHours.Value = float.Parse(comboBox2.Text);
            cmd.Parameters.Add(pEventHours);

            SqlParameter pEventID = new SqlParameter("@EventID", SqlDbType.Int);
            pEventID.Direction = ParameterDirection.Input;
            pEventID.Value = comboBox1.SelectedIndex;
            cmd.Parameters.Add(pEventID);




            SqlParameter pemployeeID = new SqlParameter("@employeeID", SqlDbType.Int);
            pemployeeID.Direction = ParameterDirection.Input;
            pemployeeID.Value = DateTime.Now;
            cmd.Parameters.Add(pemployeeID);

            SqlParameter pNote = new SqlParameter("@departmentID", SqlDbType.NVarChar, 100);
            pNote.Direction = ParameterDirection.Input;
            pNote.Value = richTextBox1.Text;
            cmd.Parameters.Add(pNote);


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
