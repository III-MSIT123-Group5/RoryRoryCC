﻿using BusinessSystem.companycars;
using BusinessSystem.CompanyCars;
using BusinessSystem.EmployeeSystem;
using BusinessSystem.Requisition;
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
            //Application.Run(new LoginForm());
            Application.Run(new FrmRequisition1());
            Application.Run(new FrmRequisition2());
        }
    }
}
