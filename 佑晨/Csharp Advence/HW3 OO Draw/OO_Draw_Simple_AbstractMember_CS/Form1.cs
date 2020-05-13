using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace OO_Draw_Simple_AbstractMember_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum DrawType
        {

            Line,

            Rectangle,

            Elipse ,
        }
        DrawType DrawShape;
        Color DrawColor = Color.Purple;
        Shape sp;
        CPoint StartPt;
        CPoint EndPt;
        ArrayList col = new ArrayList();


        private void ToolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (ToolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    DrawShape = DrawType.Line;
                    break;
                case 1:
                    DrawShape = DrawType.Rectangle;
                    break;
                case 2:
                    DrawShape = DrawType.Elipse;
                    break;
            }
        }

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            StartPt.X = e.X;
            StartPt.Y = e.Y;
        }

        private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            EndPt.X = e.X;
            EndPt.Y = e.Y;
            switch (DrawShape)
            {
                case DrawType.Line:
                    sp = new Line(StartPt, EndPt, DrawColor);
                    break;
                case DrawType.Rectangle:
                    sp = new Square(StartPt, EndPt, DrawColor);
                    break;
                case DrawType.Elipse:
                    sp = new Elipse(StartPt, EndPt, DrawColor);
                    break;
            }
            sp.Draw(this.CreateGraphics());
            col.Add(sp);
        }

        #region Serialization
        private void Button1_Click(object sender, System.EventArgs e)
        {
            ColorDialog Colordialog1 = new ColorDialog();
            if ((Colordialog1.ShowDialog() == DialogResult.OK))
            {
                DrawColor = Colordialog1.Color;
            }
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            System.Runtime.Serialization.Formatters.Soap.SoapFormatter b = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
            System.IO.FileStream f = new System.IO.FileStream("aaa.xml", System.IO.FileMode.Create);
            b.Serialize(f, col);
            f.Close();
        }

        private void Button3_Click(object sender, System.EventArgs e) {
        
        Graphics g = this.CreateGraphics();
        foreach (Shape x in col) {
            x.Draw(g);
        }
    }

        private void Button4_Click(object sender, System.EventArgs e) {
        System.Runtime.Serialization.Formatters.Soap.SoapFormatter b = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
        System.IO.FileStream f = new System.IO.FileStream("aaa.xml", FileMode.Open);
        col = ((ArrayList)(b.Deserialize(f)));
  
        Graphics g = this.CreateGraphics();
        foreach ( Shape x in col) {
            x.Draw(g);
        }
        f.Close();
    }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Button3_Click(sender, e);
        }

        private void Button5_Click(object sender, System.EventArgs e)
        {
            // col = Nothing
            this.CreateGraphics().Clear(this.BackColor);
        }


        #endregion

       
    }
}