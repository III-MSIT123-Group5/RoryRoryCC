<<<<<<< HEAD
﻿using BusinessSystem.ReportTimeSystem;
=======
﻿using BusinessSystem.companycars;
>>>>>>> parent of 98ed476... 2019.09.16(ChenWei)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessSystem
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD

            //Application.Run(new MainForm());
            //Application.Run(new BulletinBoard_2());
            //Application.Run(new CompanyCarForm());


            //Application.Run(new FormAdd ());
            Application.Run(new CreateEmployeeForm());
=======
            Application.Run(new MainForm());




>>>>>>> parent of 98ed476... 2019.09.16(ChenWei)

        }
    }
}
