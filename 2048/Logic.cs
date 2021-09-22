using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2048
{
    
    public class Logic
    {
        public Random r = new Random();
        public int[,] mezok = new int[4, 4];
        public int kettes_db = 0;
        public bool ujmezo = false;
        public bool vesztett = false;
        public bool nyert = false;
        public Pontok pontok = new Pontok();
        public int legnagyobb;

        public void PalyaGeneralas()
        {
            int sor;
            int oszlop;

            for (int i = 0; i < 2; i++)
            {
                sor = r.Next(4);
                oszlop = r.Next(4);
                while (mezok[sor, oszlop] == 2)
                {
                    sor = r.Next(4);
                    oszlop = r.Next(4);
                }
                mezok[sor, oszlop] = 2;
            }
        }
        public void Lepes(string irany)
        {
            switch (irany)
            {
                case "le":
                    key_down();
                    key_down();
                    for (int i = 3; i > 0; i--)
                    {
                        for (int j = 3; j >= 0; j--)
                        {

                            if (mezok[i, j] == mezok[i - 1, j])
                            {
                                if (mezok[i, j] != 0)
                                {
                                    ujmezo = true;
                                }
                                mezok[i, j] = mezok[i - 1, j] * 2;
                                if (mezok[i, j] == 4096)
                                {
                                    nyert = true;
                                    break;
                                }
                                UjSzam(i, j);
                                mezok[i - 1, j] = 0;
                                if (mezok[i, j] > legnagyobb)
                                {
                                    legnagyobb = mezok[i, j];
                                }


                            }
                        }

                    }
                    key_down();
                    key_down();
                    key_down();
                    if (ujmezo == true)
                    {
                        UjMezo();
                    }
                 
                    vesztes();
                    break;

                case "jobb":
                    key_right();
                    key_right();
                    for (int i = 3; i >= 0; i--)
                    {
                        for (int j = 3; j > 0; j--)
                        {

                            if (mezok[i, j] == mezok[i, j - 1])
                            {
                                if (mezok[i, j] != 0)
                                {
                                    ujmezo = true;
                                }
                                mezok[i, j] = mezok[i, j - 1] * 2;
                                if (mezok[i, j] == 4096)
                                {
                                    nyert = true;
                                    break;
                                }
                                UjSzam(i, j);
                                mezok[i, j - 1] = 0;
                                if (mezok[i, j] > legnagyobb)
                                {
                                    legnagyobb = mezok[i, j];
                                }

                            }
                        }

                    }
                    key_right();
                    key_right();
                    key_right();
                    if (ujmezo == true)
                    {
                        UjMezo();
                    }
                    vesztes();
                    break;

                case "fel":
                    key_up();
                    key_up();
                    for (int i = 0; i < 3; i++)
                    {

                        for (int j = 0; j < 4; j++)
                        {
                            if (mezok[i, j] == mezok[i + 1, j])
                            {
                                if (mezok[i, j] != 0)
                                {
                                    ujmezo = true;
                                }
                                mezok[i, j] = mezok[i + 1, j] * 2;
                                if (mezok[i, j] == 4096)
                                {
                                    nyert = true;
                                
                                    break;
                                }
                                UjSzam(i, j);
                                mezok[i + 1, j] = 0;
                                if (mezok[i, j] > legnagyobb)
                                {
                                    legnagyobb = mezok[i, j];
                                }

                            }
                        }
                    }
                    key_up();
                    key_up();
                    key_up();
                    if (ujmezo == true)
                    {
                        UjMezo();
                    }
                    
                    vesztes();
                    break;
                case "bal":
                    key_left();
                    key_left();
                    for (int i = 0; i < 4; i++)
                    {

                        for (int j = 0; j < 3; j++)
                        {
                            if (mezok[i, j] == mezok[i, j + 1])
                            {
                                if (mezok[i, j] != 0)
                                {
                                    ujmezo = true;
                                }
                                mezok[i, j] = mezok[i, j + 1] * 2;
                                if (mezok[i, j] == 4096)
                                {
                                    nyert = true;
                                    
                                    break;
                                }


                                UjSzam(i, j);
                                mezok[i, j + 1] = 0;
                                if (mezok[i, j] > legnagyobb)
                                {
                                    legnagyobb = mezok[i, j];
                                }
                            }

                        }
                    }
                    key_left();
                    key_left();
                    key_left();
                    if (ujmezo == true)
                    {
                        UjMezo();
                    }
                    vesztes();
                    break;
            }
        }
        public void key_down()
        {
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 4; j++)
                {

                    if (mezok[i, j] != 0 && mezok[i + 1, j] == 0)
                    {
                        mezok[i + 1, j] = mezok[i, j];
                        mezok[i, j] = 0;
                        ujmezo = true;
                    }
                }
            }

        }
        public void key_right()
        {
            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 3; j++)
                {


                    if (mezok[i, j] != 0 && mezok[i, j + 1] == 0)
                    {
                        mezok[i, j + 1] = mezok[i, j];
                        mezok[i, j] = 0;
                        ujmezo = true;

                    }
                }
            }

        }
        public void key_up()
        {

            for (int i = 3; i > 0; i--)
            {
                for (int j = 3; j >= 0; j--)
                {

                    if (mezok[i, j] != 0 && mezok[i - 1, j] == 0)
                    {
                        mezok[i - 1, j] = mezok[i, j];
                        mezok[i, j] = 0;
                        ujmezo = true;
                    }

                }

            }

        }
        public void key_left()
        {
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j > 0; j--)
                {
                    if (mezok[i, j] != 0 && mezok[i, j - 1] == 0)
                    {
                        mezok[i, j - 1] = mezok[i, j];
                        mezok[i, j] = 0;
                        ujmezo = true;
                    }
                }

            }

        }
        public void vesztes()
        {
            int azonos = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i - 1 >= 0)
                    {
                        if (mezok[i - 1, j] == mezok[i, j] || mezok[i - 1, j] == 0)
                        {
                            azonos++;
                        }
                    }
                    if (j + 1 < 4)
                    {
                        if (mezok[i, j + 1] == mezok[i, j] || mezok[i, j + 1] == 0)
                        {
                            azonos++;
                        }
                    }
                    if (i + 1 < 4)
                    {
                        if (mezok[i + 1, j] == mezok[i, j] || mezok[i + 1, j] == 0)
                        {
                            azonos++;
                        }
                    }
                    if (j - 1 >= 0)
                    {
                        if (mezok[i, j - 1] == mezok[i, j] || mezok[i, j - 1] == mezok[i, j])
                        {
                            azonos++;
                        }
                    }

                }
            }
            if (azonos == 0)
            {
                vesztett = true;
            }

        }
        public void UjMezo()
        {
            kettes();
            ujmezo = false;

            int sor;
            int oszlop;

            sor = r.Next(4);
            oszlop = r.Next(4);
            while (mezok[sor, oszlop] != 0)
            {
                sor = r.Next(4);
                oszlop = r.Next(4);
            }
            if (legnagyobb < 128 || kettes_db % 2 != 0)
            {
                mezok[sor, oszlop] = 2;
            }
            else
            {
                mezok[sor, oszlop] = 4;
            }

           
        }
            private void kettes()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (mezok[i, j] == 2)
                    {
                        kettes_db++;
                    }
                }
            }
        }

        public void UjSzam(int i, int j)
        {
            
            int ertek_tabla;
            ertek_tabla = mezok[i, j];
            pontok.PontszamNovelese(ertek_tabla);
          
        }
        public void UjraKezdes()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mezok[i, j] = 0;
                    
                }
            }
           
            pontok.pontszam = 0;
            vesztett = false;
            nyert = false;
            legnagyobb = 0;
        }

    }
}
