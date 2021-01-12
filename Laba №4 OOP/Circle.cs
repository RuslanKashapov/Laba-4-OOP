using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba__4_OOP
{
    public class CCircle
    {
        public int x = 0;
        public int y = 0;
        public static int radius = 20;
        public bool select = false;
        Pen greenPen;
        Pen redPen;

        public CCircle(int x, int y)
        {
            greenPen = new Pen(Color.Green);
            greenPen.Width = 3;
            redPen = new Pen(Color.Red);
            redPen.Width = 3;
            this.x = x;
            this.y = y;
        }

        public bool CSelect(int x, int y)
        {
            if (Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2) <= radius * radius)
                return true;
            else
                return false;
        }
        public void DrawCircle(Graphics G)
        {
            G.DrawEllipse(select ? redPen : greenPen, (x - radius), (y - radius), 2 * radius, 2 * radius);
        }
    }
}
