using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2048
{
    public class Pontok
    {
        public int pontszam;
        public int[] pont;
        public int record;
        public void PontszamNovelese(int pontszam)
        {


            this.pontszam += pontszam;
            if (record < this.pontszam)
            {
                record = this.pontszam;
               
                StreamWriter ki = new StreamWriter("record.txt");
                ki.Write(record);
                ki.Close();
            }
      
           
        }

        public void RecordBeolvasas()
        {
            StreamReader be = new StreamReader("record.txt");
            record = Convert.ToInt32(be.ReadLine());
            be.Close();

        }
    }
}
