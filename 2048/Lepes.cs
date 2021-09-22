using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2048
{
    public class Lepes
    {
        public int lepesszam = 0;
        public int[,] vissza = new int[10000, 16];

        
        public void Kimentes (int[, ] mezok)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    vissza[lepesszam, i+j*4] = mezok[i,j];
                }
            }
            
           
            lepesszam++;
        }
        
        public void MezoTorles(int[,] mezok)
        {

            for (int i = 0; i < 16; i++)
            {
                vissza[lepesszam, i] = 0;
            }
            lepesszam--;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    mezok[i , j] = vissza[lepesszam-1,i + j * 4];
                }
            }


        }

        
    }
}
