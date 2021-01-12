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
            storage = new Storage(100);
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            G = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        private void unselectedAll()
        {
            for (int i = 0; i < storage.getsize(); i++)
            {
                if (storage.circle[i] != null)
                    storage.circle[i].select = false;
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
                        CCircle current = storage.circle[i];
                        if(storage.circle[i].CSelect(e.X, e.Y))
                        {
                            if(!ctrlPress)
                            {
                                unselectedAll();
                            }
                            current.select = (current.select ? false : true);
                            this.Invalidate();
                            return;
                        }
                    }
                }
                unselectedAll();
                CCircle newCircle = new CCircle(e.X, e.Y);
                storage.addCCircle(newCircle);
                this.Invalidate();
            }
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                ctrlPress = true;
            if(e.KeyCode == Keys.Delete)
            {
                for(int i = 0; i < storage.getsize(); i++)
                {
                    if(storage.circle[i] != null && storage.circle[i].select)
                    {
                        storage.deleteCCircle(i);
                    }
                }
                this.Invalidate();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrlPress = false;
        }
    }
}

