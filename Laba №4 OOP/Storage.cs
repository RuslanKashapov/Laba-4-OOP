using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba__4_OOP
{
    public class Storage
    {
        public int count;
        public int size;
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

        public CCircle getCCircle(int i)
        {
            return circle[i];
        }

        public void increaseSize(int newsize)
        {
            CCircle[] NewCCircle = new CCircle[size + newsize];
            for (int i = 0; i < size + newsize; i++)
                NewCCircle[i] = null;

            for (int i = 0; i < size; i++)
                if (circle[i] != null)
                    NewCCircle[i] = circle[i];
            circle = NewCCircle;
            size += newsize;
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
