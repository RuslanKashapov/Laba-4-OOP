using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba__4_OOP
{

    class Storage
    {
        public Circle[] objects;
        int j;


        public Storage(int size)
        {
            objects = new Circle[size];
            int j = 0;
            for (int i = 0; i < size; ++i)
            {
                objects[i] = null;
            }
        }

        public void init(int size)//выделение места в хранилище
        {
            objects = new Circle[size];
            for (int i = 0; i < size; ++i)
            {
                objects[i] = null;
            }
        }

        public void AddObject(ref Circle object1, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (objects[i] == null)
                {
                    objects[i] = object1;
                    j++;
                }
            }
        }

        void delObject(int i)
        {
            if (objects[i] != null)
            {
                objects[i] = null;
                j--;
            }

        }

    }
}
