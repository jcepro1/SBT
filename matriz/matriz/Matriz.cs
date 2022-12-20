using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matriz
{
    class Matriz
    {
        const int MAXF = 100;
        const int MAXC = 100;
        private int[,] x;
        private int f, c;


        public Matriz()
        {
            x = new int[MAXF, MAXC];
            f = 0; c = 0;
        }

        public void cargar(int nf, int nc, int a, int b)
        {
            f = nf; c = nc;
            int f1, c1;
            Random r = new Random();
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    x[f1, c1] = r.Next(a, b);
                }
            }
        }
        public string descargar()
        {
            string s = "";
            int f1, c1;
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    s = s + x[f1, c1] + "\x09";
                }
                s = s + "\x0d" + "\x0a";
            }
            return s;
        }
      
       
         int frecuenciaFil(int f1, int ele)
         {
             int fr = 0;
             for (int c1 = 1; c1 <= c; c1++)
             {
                 if (x[f1, c1] == ele)
                 {
                     fr++;
                 }
             }
             return fr;
         }
         public void pregunta1()
         {
             int may = 0;
             int elemay=0;
            for (int f1 = 1; f1 <= f; f1++)
            {
                may = 0;
                for (int c1 = 1; c1 <= c; c1++)
                 {
                    int ele = x[f1, c1];
                    int fr=frecuenciaFil(f1,ele);
                    if (fr > may)
                    {
                        may = fr;
                        elemay = ele;
                    }
                 }
                x[f1, c+1] = elemay;
                x[f1, c+2] = may;
             }
             c = c + 2;
         }
         void cargarcol(int ele)
         {
             c++;
             x[1, c] = ele;
         }
         void ordenarCol()
         {
             for (int c1 = 1; c1 <= c-1; c1++)
             {
                 for (int c2 = c1+1; c2 <= c; c2++)
                 {
                     if (x[1, c1] > x[1, c2])
                     {
                         int aux = x[1, c1];
                         x[1, c1] = x[1, c2];
                         x[1, c2] = aux;
                     }
                 }
             }
         }
         public void pregunta2(int fi, int ff, int ci, int cf)
         {
            Matriz mpares = new Matriz();
            Matriz mimpares = new Matriz();

            for (int c1 = ci; c1<=cf; c1++)
             {
                for (int f1 = ff; f1 >= fi; f1--)
                 {
                     int ele = x[f1, c1];
                     if (ele % 2 == 0)
                     {
                         mpares.cargarcol(ele);
                     }
                     else
                     {
                         mimpares.cargarcol(ele);
                     }
                 }
             }

            mpares.ordenarCol();
            mimpares.ordenarCol();
            int i1 = 1;
            int i2 = 1;
            for (int c1 = ci; c1 <= cf; c1++)
            {
                for (int f1 = ff; f1 >= fi; f1--)
                {
                    if (i1 <= mpares.c)
                    {
                        x[f1, c1] = mpares.x[1, i1];
                        i1++;
                    }
                    else
                    {
                        x[f1, c1] = mimpares.x[1, i2];
                        i2++;
                    }
                }
            }
         }



    }
}
