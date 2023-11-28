using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public interface DrawingSkills
    {
        public void DrawTriangle(Point a, Point b, Point c);
        public void DrawSquare(Point leftUpperAngle, Point rightBottomAngle);
        public void DrawCircle(Point center, int radius);
        public void DrawLine(Point a, Point b);
    }
    public class DrawingTool
    {
        Graphics g { get; set; }
        Color lineColor { get; set; }
        Color figureColor { get; set; }
        [AllowNull]
        Pen pen { get; set; }
        [AllowNull]
        Brush brush { get; set; }
    }
    public class Artist : DrawingTool, DrawingSkills
    {
        Graphics g { get; set; }
        Color lineColor { get; set; }
        Color figureColor { get; set; }
        [AllowNull]
        Pen pen { get; set; }
        [AllowNull]
        Brush brush { get; set; }
        public Artist(Graphics g)
        {
            this.g = g;
        }
        public Artist(Graphics g, Color lineColor, Color figureColor)
        {
            this.g = g;


            if (!lineColor.IsEmpty)
            {
                this.lineColor = lineColor;
                pen = new Pen(lineColor);
            }
            if (!figureColor.IsEmpty)
            {
                this.figureColor = figureColor;
                brush = new SolidBrush(figureColor);
            }
        }
        public void setLineColor(Color color)
        {
            lineColor = color;
            if (pen == null)
                pen = new(lineColor);
            else
                pen.Color = lineColor;
        }
        public void setFigureColor(Color color)
        {
            figureColor = color;
            if(brush == null)
                brush = new SolidBrush(lineColor);
            else
                brush = new SolidBrush(figureColor);
        }
        public void DrawTriangle(Point a, Point b, Point c)
        {
            if (!figureColor.IsEmpty)
                g.FillPolygon(brush, new Point[] { a, b, c });
            if (!lineColor.IsEmpty)
            {
                g.DrawLine(pen, a, b);
                g.DrawLine(pen, b, c);
                g.DrawLine(pen, c, a);
            }
        }
        public void DrawSquare(Point leftUpperAngle, Point rightBottomAngle)
        {
            if (!figureColor.IsEmpty)
                g.FillRectangle(brush, new Rectangle(leftUpperAngle, new Size(Math.Abs(rightBottomAngle.X - leftUpperAngle.X), Math.Abs(rightBottomAngle.Y - leftUpperAngle.Y))));
            if (!lineColor.IsEmpty)
                g.DrawRectangle(pen, new Rectangle(leftUpperAngle, new Size(Math.Abs(rightBottomAngle.X - leftUpperAngle.X), Math.Abs(rightBottomAngle.Y - leftUpperAngle.Y))));
        }
        public void DrawSquare(Point leftUpperAngle, int sQuareSideSize)
        {
            if (!figureColor.IsEmpty)
                g.FillRectangle(brush, new Rectangle(leftUpperAngle.X, leftUpperAngle.Y, sQuareSideSize, sQuareSideSize));
            if (!lineColor.IsEmpty)
                g.DrawRectangle(pen, new Rectangle(leftUpperAngle.X, leftUpperAngle.Y, sQuareSideSize, sQuareSideSize));
        }
        public void DrawCircle(Point center, int radius)
        {
            if (!figureColor.IsEmpty)
                g.FillEllipse(brush, center.X, center.Y, radius, radius);
            if (!lineColor.IsEmpty)
                g.DrawEllipse(pen, center.X, center.Y, radius, radius);
        }
        public void DrawLine(Point a, Point b)
        {
            if (!lineColor.IsEmpty)
                g.DrawLine(pen, a, b);
        }
    }
}
