using BusinessSystemDBEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BusinessSystem
{
    public partial class FrmRequisition : SonForm
    {
        public FrmRequisition()
        {
            InitializeComponent();                
        }

        BusinessDataBaseEntities dbContext;

        private void altoButton1_Click(object sender, EventArgs e)
        {

            dbContext = new BusinessDataBaseEntities();

            try
            {
                var q = new RequisitionChild
                {                   
                    ProductName = textBox1.Text,
                    UnitPrice = decimal.Parse(textBox2.Text),
                    Quantity = decimal.Parse(textBox3.Text),
                    Discount = decimal.Parse(textBox4.Text),
                    Note = textBox5.Text
                };

                dbContext.RequisitionChilds.Add(q);
                dbContext.SaveChanges();

                MessageBox.Show("XXXX");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
