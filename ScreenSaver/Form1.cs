using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class frmScrSvr : Form
    {

        List<Image> bigimages = new List<Image>();//Fotoğraflarımızı listeledik.
        List<britpic> britpics = new List<britpic>();//Ekran koruyucumuz içindeki fotoğrafların özelliklerini listeledik.
        Random rnd = new Random();


       public class britpic
        {
            public int Picnum;
            public float X;
            public float Y;
            public float Speed;

        }


        public frmScrSvr()
        {
            InitializeComponent();
        }

        private void frmScrSvr_KeyDown(object sender, KeyEventArgs e)
        {
            Close();//Klavyeden herhangi bir tuşa bastığımızda ekran koruyucuyu sonlandırabiliriz.
        }

        private void frmScrSvr_Load(object sender, EventArgs e)
        {
            string[] images = System.IO.Directory.GetFiles("pics"); //Fotoğraflarımızın dosya uzantılarını dizi içine attık.

            foreach (string item in images)
            {
                bigimages.Add(new Bitmap(item));
            }

            for (int i = 0; i < 2000; i++)
            {
                britpic bp = new britpic();
                bp.Picnum = i % bigimages.Count;
                bp.X = rnd.Next(0, Width);
                bp.Y = rnd.Next(0, Height);

                britpics.Add(bp);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void frmScrSvr_Paint(object sender, PaintEventArgs e)
        {
            foreach (britpic item in britpics)
            {
                e.Graphics.DrawImage(bigimages[item.Picnum], item.X, item.Y);
                item.X -= 2;

                if (item.X<-250)
                {
                    item.X = Width + rnd.Next(20, 100);
                }
            }
        }
    }
}
