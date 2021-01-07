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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int k = 5;
        static int index = 0;
        int ctrl = 0;
        Storage storage = new Storage(k);
        int indexin = 0;

        class Circle
        {
            public int x, y;//координаты круга
            public int rad = 25;
            public Color color = Color.Lime;
            public bool draw = true;

            public Circle()
            {
                x = 0;
                y = 0;
            }

            public Circle(int x, int y)
            {
                this.x = x-rad;
                this.y = y-rad;
            }

            ~Circle()
            {

            }
        }

        private void paint_circle(Color name, ref Storage stg, int index)
        {
            Pen pen = new Pen(name, 3);
            if(!storage.check_empty(index))
            {
                if(storage.objects[index].draw == true)
                {
                    PaintBox.CreateGraphics().DrawEllipse(
                        pen, stg.objects[index].x,
                        stg.objects[index].y,
                        stg.objects[index].rad * 2,
                        stg.objects[index].rad * 2);
                        stg.objects[index].color = name;)
                }
            }
        }

        private void remove_selection_circle(ref Storage stg)
        {
            for (int i = 0; i < k; i++)
            {
                if(!storage.check_empty(i))
                {
                    paint_circle(Color.Lime, ref storage, i);
                }
            }          
        }

        private void remove_selected(ref Storage stg)
        {
            for(int i = 0; i < k; ++i)
            {
                if(!storage.check_empty(i))
                {
                   if(storage.objects[i].color == Color.Red)
                    {
                        storage.delete_object(i);
                    }
                }
            }
        }

        private int check_circle(ref Storage stg, int size, int x, int y)
        {
            if(stg.occupied(size) != 0)
            {
                
            }
        }

        class Storage
        {
            public Circle[] objects;
            int j = 0;

            public Storage(int count)
            {
                objects = new Circle[count];
                for (int i = 0; i < count; ++i)
                    objects[i] = null;
            }

            public void init(int count)
            {
                objects = new Circle[count];
                for (int i = 0; i < count; ++i)
                    objects[i] = null;
            }

            public void AddObject(int ind, ref Circle object1, int count, ref int indexin)
            {
                if(ind < count)
                {
                    objects[ind] = object1;
                    j++;
                }
            }

            public void delete_object(int ind)
            {
                objects[ind] = null;
                index--;
            }

            public bool check_empty(int index)
            {
                if (objects[index] == null)
                    return true;
                else return false;
            }

            public int occupied(int size)
            {
                int count_occupied = 0;
                for (int i = 0; i < size; ++i)
                    if (!check_empty(i))
                        ++count_occupied;
                return count_occupied;
            }

            public void increase(ref int size)
            {
                int newsize = size * 2;
                Storage storage1 = new Storage(newsize);
                for (int i = 0; i < size; ++i)
                    storage1.objects[i] = objects[i];
                for(int i = size; i < newsize -1; ++i)
                {
                    storage1.objects[i] = objects[i];
                }
                size = newsize;
                init(newsize);
                for (int i = 0; i < newsize; ++i)
                    objects[i] = storage1.objects[i];
            }
            ~Storage()
            {

            }
        }

        private void PaintBox_MouseClick(object sender, MouseEventArgs e)
        {
            Circle krug = new Circle(e.X, e.Y);
            if (index == k)
                storage.increase(ref k);
            int c = 
        }
    }

}
