using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba__4_OOP
{
    public class Storage
    {
        protected int count;
        protected int size;
        public CCircle[] circle;

        public Storage(int size)
        {
            this.size = size;
            count = 0;
            circle = new CCircle[size];
            for (int i = 0; i < size; i++)
            {
                circle[i] = null;
            }
        }

        public void addCCircle(CCircle t)
        {
            for (int i = 0; i < size; i++)
            {
                if (circle[i] == null)
                {
                    circle[i] = t;
                    count++;
                    break;
                }
            }

        }
        public void deleteCCircle(int i)
        {
            if (circle[i] != null)
            {
                circle[i] = null;
                count--;
            }
        }
        public int getsize()
        {
            return size;
        }
    }
}
