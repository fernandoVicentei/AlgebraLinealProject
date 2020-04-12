using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace ALGEBRA_LINEAL
{
    public partial class DETERMINANTE : Form
    {
        static int num = 50;
        static int nume = 50;
        static double aux = 50;
        static double auxi = 50;
        static double[,] MASO = new double[num, num];
        static double[,] MA = new double[num, num];     
        
        public DETERMINANTE()
        {
            InitializeComponent();
        }
        private void label3_Click(object sender, EventArgs e)
        {           
        }
       
        static void IngreColum(ref int n1)
        {
            n1 = Convert.ToInt32(Interaction.InputBox("--- INGRESAR DATOS --", "INGRESAR NRO. DE COLUMNAS ", "", 50, 50));

        }
        static void IngreFila(ref int n1)
        {
            n1 = Convert.ToInt32(Interaction.InputBox("--- INGRESAR DATOS --", "INGRESAR NRO. DE FILAS ", "", 50, 50));

        }
        static void MostrMatr(ref double[,] M1, int num1, int num2, ref DataGridView p)
        {
            p.ColumnCount = num2;
            p.RowCount = num1;
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < num2; j++)
                {

                    p.Rows[i].Cells[j].Value = M1[i, j];
                }

            }
        }
        static void CargaMat(int num1, int num2, ref double[,] MA1)
        {
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    MA1[i, j] = Convert.ToInt32(Interaction.InputBox("INGRESAR ELEMTOS", "Ingresar datos en la posicion M[" + i + "," + j + "]", "", 50, 50));
                }
            }
        }
        static double SumaR(double a1, double b1)
        {
            return a1 + b1;
        }
        static double Resta(double a1, double b1)
        {
            return a1 - b1;
        }
        static double Multiplicar(double a1, double b1)
        {
            return a1 * b1;
        }      
        static double ObteniendoElprimerValor(ref double[,] MA1,int num1,int nume1)
        {
            double c = nume1 - 2;
            double a = 1;
            double b = 1;
            int e = 0;
            int g = 1;
            double d= 1;
            for (int i = 0; i < num1;i++)
            {
                for (int j = 0; j< nume1;j++)
                {
                   
                    if (i == j)
                    {
                        a = Multiplicar(MA1[i, j], a);
                        c = c + c;
                    }
                    else if(j==c)
                    {
                        b = Multiplicar(MA1[i, j], b);
                        c = 0;
                       
                    }
                    else 
                    {
                        d = Multiplicar(MA1[i, j], d);
                        c = e + c;
                    }
                }
                e = g--;
            }
            c = SumaR(SumaR(a, b), d);
            return c;
        }
        static double DterdeDosValores(ref double[,] MA1,int num1,int nume1)
        {
            double v = 1;
            double s = 1;
            for (int i = 0; i < num1;i++)
            {
                for (int j=0;j<nume1;j++)
                {
                    if (i == j)
                    {
                        v = Multiplicar(MA1[i, j], v);
                    }
                    else
                    {
                        s = Multiplicar(MA1[i, j], s);
                    }
                }
            }
            s = Resta(v, s);
            return s;
        }
        static double ConseguiregundValor(ref double[,] MA1,int num1,int nume1)
        {
            double a = nume1 - 1;
            double b = 1;
            double c = 1;
            double y = 1;
            double e = 1;
            double d = 1;
            double g = 2;
            for (int i = 0; i <num1;i++)
            {
                for (int j = 0; j < nume1; j++)
                {
                    if (j == a)
                    {
                        c = Multiplicar(MA1[i, j], c);
                        a--;
                    }
                    else if(j==b)
                    {
                        d = Multiplicar(MA1[i, j], d);
                        b = 0;
                       
                    }
                    else
                    {
                        y = Multiplicar(MA1[i, j], y);
                        b = e;
                    }
                }
                e = g;
            }
            a = 0;
            a = SumaR(SumaR(c, d), y);
            return a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IngreFila(ref num);
            IngreColum(ref nume);
            CargaMat(num, nume, ref MA);
            if (num == nume)
            {
                if (num == 2)
                {
                   aux= DterdeDosValores(ref MA, num, nume);
                    txtmatriz.Text = aux.ToString();
                    MostrMatr(ref MA, num, nume, ref MATRIZA);
                }
                else
                {
                   aux= ConseguiregundValor(ref MA, num, nume);
                    auxi = ObteniendoElprimerValor(ref MA, num, nume);
                    aux = Resta(auxi, aux);
                    txtmatriz.Text = aux.ToString();
                    MostrMatr(ref MA, num, nume, ref MATRIZA);
                }
            }
            else
            {
                MessageBox.Show("LO   SENTIMOS... LAS DIMENSIONES DE FILA Y  COLUMNA DEBEN SER IGUALES, VUELVA A INTENTARLO -->>>");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
