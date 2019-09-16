using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace BusinessSystem
{
    public class RoundButton : Button
    {
        private Color buttonColor;
        private LinearGradientBrush edgeBrush;
        private Blend edgeBlend;
        private Color edgeColor1;
        private Color edgeColor2;

        protected override void OnPaint(PaintEventArgs e)
        {
            buttonColor = this.BackColor;
            edgeColor1 = ControlPaint.Light(buttonColor);
            edgeColor2 = ControlPaint.Dark(buttonColor);

            var g = e.Graphics;
            var buttonRect = this.ClientRectangle;
            FillBackground(g, buttonRect);
            DrawEdges(g, ref buttonRect);
        }

        protected void FillBackground(Graphics g, Rectangle rect)
        {
            var bgRect = rect;
            bgRect.Inflate(1, 1);
            var bgBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
            bgBrush.Color = Parent.BackColor;
            g.FillRectangle(bgBrush, bgRect);
            bgBrush.Dispose();
        }

        protected virtual void DrawEdges(Graphics g, ref Rectangle edgeRect)
        {
            var lgbRect = edgeRect;
            lgbRect.Inflate(1, 1);
            edgeBrush = new LinearGradientBrush(lgbRect, edgeColor1, edgeColor2, 5);

            edgeBlend = new Blend();
            edgeBlend.Positions = new float[] { 0.0f, .2f, .4f, .6f, .8f, 1.0f };
            edgeBlend.Factors = new float[] { .0f, .0f, .2f, .4f, 1f, 1f };
            edgeBrush.Blend = edgeBlend;
            FillShape(g, edgeBrush, edgeRect);
        }


        protected virtual void FillShape(Graphics g, Object brush, Rectangle rect)
        {
            if (brush.GetType().ToString() == "System.Drawing.Drawing2D.LinearGradientBrush")
            {
                g.FillEllipse((LinearGradientBrush)brush, rect);
            }
            else if (brush.GetType().ToString() == "System.Drawing.Drawing2D.PathGradientBrush")
            {
                g.FillEllipse((PathGradientBrush)brush, rect);
            }
        }
    }
}
