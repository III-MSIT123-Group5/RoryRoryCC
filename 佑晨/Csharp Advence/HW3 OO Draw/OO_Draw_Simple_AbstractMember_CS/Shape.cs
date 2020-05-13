using System;
using System.Drawing;

[Serializable]
public struct CPoint
{
   public int X;
    public int Y;


    public CPoint(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

}

[Serializable]
public abstract class Shape
{
    public abstract void Draw(Graphics g);

    protected CPoint StartPtr;
    protected CPoint EndPtr;
    protected System.Drawing.Color Color;

    public   void Test()
    {
        //.........
    }
}


[Serializable()]
public class Line : Shape
{

    public Line(CPoint x, CPoint y, Color DrawColor)
    {
        StartPtr = x;
        EndPtr = y;
        Color = DrawColor;
    }

    public override void Draw(Graphics g)
    {
        Pen p = new Pen(this.Color);
        g.DrawLine(p, StartPtr.X, StartPtr.Y, EndPtr.X, EndPtr.Y);
    }
}


[Serializable]
public class Square : Shape
{

   public Square(CPoint x, CPoint y, Color DrawColor)
    {
        StartPtr = x;
        EndPtr = y;
        Color = DrawColor;
    }

    public override void Draw(System.Drawing.Graphics g)
    {
        Pen p = new Pen(this.Color);
        g.DrawRectangle(p, StartPtr.X, StartPtr.Y, (EndPtr.X - this.StartPtr.X), (this.EndPtr.Y - this.StartPtr.Y));
    }
}

public class Elipse : Shape
{

    public Elipse(CPoint StarPoint, CPoint EndPoint,Color DrawColor)
    {
        StartPtr = StarPoint;
        EndPtr = EndPoint;
        Color = DrawColor;
       
    }


    public override void Draw(Graphics g)
    {
        Pen p = new Pen(this.Color);
        g.DrawEllipse(p, StartPtr.X, StartPtr.Y, (this.EndPtr.X - this.StartPtr.X), (this.EndPtr.Y - this.StartPtr.Y));
    }
}

