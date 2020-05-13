using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0331_Suplier_Products
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Products' 資料表。您可以視需要進行移動或移除。
            this.productsTableAdapter.Fill(this.northwindDataSet.Products);
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Suppliers' 資料表。您可以視需要進行移動或移除。
            this.suppliersTableAdapter.Fill(this.northwindDataSet.Suppliers);

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = config.Sections["connectionStrings"];
            section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            config.Save();

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = config.Sections["connectionStrings"];
            section.SectionInformation.UnprotectSection();
            config.Save();
        }
    }
}
