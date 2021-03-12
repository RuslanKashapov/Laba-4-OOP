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
        protected int x = 0;
        protected int y = 0;
        protected static int radius = 25;
        public bool select = true;
        Pen greenPen;
        Pen redPen;

        public CCircle(int x, int y)
        {
            greenPen = new Pen(Color.Green, 3);
            redPen = new Pen(Color.Red, 3);
            this.x = x;
            this.y = y;
        }

        public bool CConnect(int x, int y)
        {  
            if (Math.Pow(this.x - x, 2) + Math.Pow(this.y - y, 2) <= Math.Pow(radius, 2))
                return true;
            else
                return false;
        }
        public void DrawCircle(Graphics G)
        {
            if(this.select == true)
            {
                G.DrawEllipse(redPen, (x - radius), (y - radius), 2 * radius, 2 * radius);
            }
            else
            {
                G.DrawEllipse(greenPen, (x - radius), (y - radius), 2 * radius, 2 * radius);
            }
        }
    }
}
