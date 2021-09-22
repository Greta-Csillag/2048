using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2048
{

    public partial class Form1 : Form
    {
        public PictureBox[] kepek;
        public PictureBox[,] tabla;
        public Random r = new Random();
        public int[] kep_tag = new int[11];
        public Logic logic;
        public Lepes lepes;
        public int min = 0;
        public Form1()
        {

            Random r = new Random();
            InitializeComponent();
            RemoveCursorNavigation(Controls);
            kepbeolvasas();
            logic = new Logic();
            lepes = new Lepes();
            kezdes();

        }

        public void kepbeolvasas()
        {
            kepek = new PictureBox[11];
            for (int i = 0; i < 11; i++)
            {
                kepek[i] = new PictureBox();
            }
            Bitmap ures = new Bitmap("0.png");
            kepek[0].Image = (Image)ures;
            kepek[0].Tag = 0;
            int a = 2;
            for (int i = 1; i < 11; i++)
            {
                Bitmap kep = new Bitmap($"{a}.png");
                kepek[i].Image = (Image)kep;
                kepek[i].Image = (Image)kep;
                kepek[i].Tag = a;
                a = a * 2;
            }
        }
        public void kezdes()
        {
            logic.PalyaGeneralas();

            logic.pontok.RecordBeolvasas();


            

            tabla = new PictureBox[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tabla[i, j] = new PictureBox();
                    tabla[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    tabla[i, j].Left = 100 + j * 100;
                    tabla[i, j].Top = 100 + i * 100;
                    tabla[i, j].Width = 100;
                    tabla[i, j].Height = 100;
                    
                    this.Controls.Add(tabla[i, j]);
                }
            }
            PalyaFrissites();

            lepes.Kimentes(logic.mezok);
            lepes.lepesszam--;
            PontszamFrissites();
           
        }
        
        private void mozgas(object sender, PreviewKeyDownEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.Down:
                    logic.Lepes("le");
                    break;

                case Keys.Right:
                    logic.Lepes("jobb");
                    break;

                case Keys.Up:
                    logic.Lepes("fel");
                    break;

                case Keys.Left:
                    logic.Lepes("bal");
                    break;
            }
            
            PalyaFrissites();
            if (logic.vesztett == true)
            {
                vege();
            }
            if (logic.nyert == true)
            {
                vege();
            }
            lepes.Kimentes(logic.mezok);
            PontszamFrissites();
        }

        private void PontszamFrissites()
        {
            label3.Text = ($"rekord: {logic.pontok.record}");
            label1.Text = ($"Pontszám: {logic.pontok.pontszam}");
        }

        public void vege()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tabla[i, j].Visible = false;
                }
            }
            if (logic.vesztett == true)
            {
                label2.Text = ("Vesztettél!");
                label2.Visible = true;
                button1.Visible = true;
                button2.Visible = false;
            }
            else if (logic.nyert == true)
            {
                label2.Text = "Lusta voltam és nincs több szám. Gratulálok, nyertél!";
                label2.Visible = true;
                button1.Visible = true;
            }

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            
                this.Controls.Clear();
                lepes.lepesszam = 0;
                logic.UjraKezdes();
                InitializeComponent();
                RemoveCursorNavigation(Controls);
                kepbeolvasas();
                logic = new Logic();
                lepes = new Lepes();
                button2.Visible = false;
                kezdes();
                button2.Visible = true;

                for (int i = 0; i < 10000; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        lepes.vissza[i, j] = 0;
                    }
                }
            min = 0;

            
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (lepes.lepesszam>2)
            {
                
                lepes.MezoTorles(logic.mezok);
                PalyaFrissites();
            }
            
            
        }

        public void PalyaFrissites()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int ertek_tabla;
                    int ertek_kep;
                    ertek_tabla = logic.mezok[i, j];
                    for (int k = 0; k < 11; k++)
                    {
                        ertek_kep = Convert.ToInt32(kepek[k].Tag);
                        if (ertek_kep == ertek_tabla)
                        {
                            tabla[i, j].Image = kepek[k].Image;
                        }
                    }
                }
            }
        }

        private void RemoveCursorNavigation(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                ctrl.PreviewKeyDown += new PreviewKeyDownEventHandler(mozgas);
                RemoveCursorNavigation(ctrl.Controls);
            }
        }

        
    }
}
