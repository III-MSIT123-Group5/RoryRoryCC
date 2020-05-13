using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0331_CustomerOrders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.customersTableAdapter.Connection.StateChange += Connection_StateChange;
            this.customersTableAdapter.Connection.InfoMessage += Connection_InfoMessage;

            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Orders' 資料表。您可以視需要進行移動或移除。
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Customers' 資料表。您可以視需要進行移動或移除。
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        private void Connection_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {
           
        }

        private void Connection_StateChange(object sender, StateChangeEventArgs e)
        {
           switch (e.CurrentState)
            {
                case ConnectionState.Closed:
                    slbConnectionState.Text = "連線關閉";
                    slbConnectionState.Image = new Bitmap("unlink.png");
                    break;
                case ConnectionState.Open:
                    slbConnectionState.Text = "連線開啟";
                    slbConnectionState.Image = new Bitmap("link.png");
                    break;
            }
        }

        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            if (northwindDataSet.HasChanges())
            {
                // this.tableAdapterManager.UpdateAll(this.northwindDataSet);
                NorthwindDataSet dsChanged = (NorthwindDataSet)northwindDataSet.GetChanges(DataRowState.Modified);
                if(MessageBox.Show($"確定更新{dsChanged.Customers.Rows.Count}筆資料?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("儲存成功!", "", MessageBoxButtons.OK);
                    this.customersTableAdapter.Update(this.northwindDataSet);
                    dsChanged.AcceptChanges();
                }              
            }
            else
            {
                MessageBox.Show("沒有資料需被更新!", "", MessageBoxButtons.OK);
            }
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定刪除?","刪除",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                customersBindingSource.RemoveCurrent();
            }
        }

        private void ordersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ordersDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (ordersDataGridView.CurrentCell.ColumnIndex < 0) return;
            Control parentCTL = e.Control.Parent;
            DateTimePicker dtPicker = new DateTimePicker();
            switch (ordersDataGridView.CurrentCell.ColumnIndex)
            {
                case 3:
                  
                    dtPicker.Name = "odTP";
                    dtPicker.Size = ordersDataGridView.CurrentCell.Size;
                    dtPicker.CustomFormat = "yyyy/MM/dd";


                    dtPicker.Format = DateTimePickerFormat.Custom;
                    dtPicker.Location = new Point(e.Control.Location.X - e.Control.Margin.Left < 0 ? 0 : e.Control.Location.X - e.Control.Margin.Left, e.Control.Location.Y - e.Control.Margin.Top < 0 ? 0 : e.Control.Location.Y - e.Control.Margin.Top);

                    break;
            }

            
      

          
                if (e.Control.Text != "")
                {
                    dtPicker.Value = DateTime.ParseExact(e.Control.Text, dtPicker.CustomFormat, null);
                }
                e.Control.Visible = false;

                foreach (Control tmpCTL in parentCTL.Controls)
                {
                    if (tmpCTL.Name == dtPicker.Name) parentCTL.Controls.Remove(tmpCTL);
                }
                parentCTL.Controls.Add(dtPicker);

                //dtPicker.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
            }
            
        }
    }

