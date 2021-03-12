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
        Graphics G;
        Storage storage;
        Bitmap bitmap;
        bool ctrlPress = false;

        public Form1()
        {
            InitializeComponent();
            storage = new Storage(150);
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            G = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        private void unselect()
        {
            for (int i = 0; i < storage.getsize(); i++)
            {
                if (storage.circle[i] != null)
                    storage.circle[i].select = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
                ctrlPress = true;
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < storage.getsize(); i++)
                {
                    if (storage.circle[i] != null && storage.circle[i].select == true)
                    {
                        storage.deleteCCircle(i);
                    }
                }
                this.Invalidate();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                for(int i = 0; i < storage.getsize(); i++)
                {
                    if(storage.circle[i] != null)
                    {
                        if (storage.circle[i].CConnect(e.X, e.Y) == true)
                        {
                            if (ctrlPress == false)
                            {
                                unselect();
                            }
                            if (storage.circle[i].select == false)
                            {
                                storage.circle[i].select = true;
                            }
                            else
                            {
                                storage.circle[i].select = false;
                            }         
                            this.Invalidate();
                            return;
                        }
                    }
                }
                unselect();
                storage.addCCircle(new CCircle(e.X, e.Y));
                this.Invalidate();
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrlPress = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            G.Clear(Color.White);
            for(int i = 0; i < storage.getsize(); i++)
            {
                if (storage.circle[i] != null)
                    storage.circle[i].DrawCircle(G);
            }
            pictureBox1.Image = bitmap;
        }   
    }
}

