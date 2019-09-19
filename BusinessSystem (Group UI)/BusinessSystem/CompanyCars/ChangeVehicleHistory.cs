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

namespace BusinessSystem.CompanyCars
{
    public partial class ChangeVehicleHistory : SonForm
    {


        //
        //全域變數
        //
        BusinessDataBaseEntities dbContext = new BusinessDataBaseEntities();
        //
        //
        //
        public ChangeVehicleHistory()
        {
            InitializeComponent();

            var q = from p in this.dbContext.CompanyVehicleHistories
                    where p.employeeID == 
            
        }
    }
}
