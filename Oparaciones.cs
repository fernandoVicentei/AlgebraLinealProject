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
    public partial class Oparaciones : Form
    {
        static int num = 50;
        static int nums = 50;
        static int nume = 50;
        static int[] V1 = new int[num];
        static int[] Vc1 = new int[num];
        static int[] VcT = new int[num];

        static int[,] M = new int[num, nums];
        static int[,] Mat = new int[num, nums];
        static int[,] MatZ = new int[num, nums];
        static string OP = "";

      
        public Oparaciones()
        {
            InitializeComponent();
        }
        static void IngreColum(ref int n1)
        {
            n1 = Convert.ToInt32(Interaction.InputBox("--- INGRESAR DATOS --", "INGRESAR NRO. DE COLUMNAS ", "", 50, 50));
        }
        static void IngreFila(ref int n1)
        {
            n1 = Convert.ToInt32(Interaction.InputBox("--- INGRESAR DATOS --", "INGRESAR NRO. DE FILAS ", "", 50, 50));
        }
        static void MostrMatr(ref int[,] M1, int num1, int num2, ref DataGridView p)
        {
            p.ColumnCount = num2;
            p.RowCount = num1;
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    // pl.Items.Add("[" + M1[i, j] + "]");
                    p.Rows[i].Cells[j].Value = M1[i, j];
                }
                Console.WriteLine();
            }
        }       
        static void SumarMatrices(ref int[,] M1,ref int[,] Mat1,ref int[,] MatZ1,int num1,int nume1)
        {
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < nume1; j++)
                {
                    MatZ1[i, j] = Sumar(M1[i, j], Mat1[i, j]);
                }               
            }
        }
        static void RestaMatrices(ref int[,] M1, ref int[,] Mat1, ref int[,] MatZ1, int num1, int nume1)
        {
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < nume1; j++)
                {
                    MatZ1[i, j] = Restar(M1[i, j], Mat1[i, j]);
                }
            }
        }
        static void CargaMat(int num1, int num2, ref int[,] M1)
        {
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < num2; j++)
                {                    
                    M1[i, j] = Convert.ToInt32(Interaction.InputBox("--> Ingresar Elementos <--", "Ingresar el elemento en la Posicion[" + i + ", " + j + "]-- > ", "", 60, 60));
                }
            }
        }
        static void Cmbio2(ref int[,] M1, ref int[] VEC1, int numeS, int nume1, int num, int ccont)
        {

            for (int i = 0; i < nume1; i++)
            {

                for (int iK = 0; iK < numeS; iK++)
                {

                    if (iK == num)
                    {
                        VEC1[i] = M1[i, iK];
                    }
                }
            }
        }
        static void Cmbio(ref int[,] M1, ref int[] VEC1, int numeS, int nume1, int num)
        {
            for (int i = 0; i < numeS; i++)
            {
                for (int iK = 0; iK < nume1; iK++)
                {
                    if (i == num)
                    {
                        VEC1[iK] = M1[i, iK];
                    }
                }
            }
        }
        static void Multip(ref int[,] M1, ref int[] V1, ref int[] VEC1, int num1, int nume1, int ccont, int help, int ñ)
        {
            int aux = 0;

            for (int i = 0; i < ccont; i++)
            {
                V1[i] = Multiplicar(V1[i], VEC1[i]);
            }
            for (int p = 0; p < ccont; p++)
            {
                aux = Sumar(V1[p], aux);
            }
            for (int l = help; l < num1; l++)
            {
                for (int j = ñ; j < num1; j++)
                {
                    M1[l, j] = aux;
                }
            }
        }
        static void MultiplicarMA(ref int[] V1, ref int[] VEC1, ref int[,] M1, ref int[,] Mat1, ref int[,] MatZ1, int num1, int nume1, int nums1, int ccont1)
        {
            VEC1 = new int[ccont1];
            V1 = new int[ccont1];
            int aux = nume1 - 1;
            int auxi = 0;
            int help = 0;
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < nume1; j++)
                {
                    Cmbio(ref M1, ref VEC1, num1, ccont1, i);

                    Cmbio2(ref Mat1, ref V1, num1, ccont1, j, i);
                    Multip(ref MatZ1, ref V1, ref VEC1, num1, nume1, ccont1, i, j);
                }
            }
        }
        static int Sumar(int a,int b)
        {
            return a + b;
        }
        static int Restar(int a,int b)
        {
            return a - b;
        }
        static int Multiplicar(int a,int b)
        {
            return a * b;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            int ccont = 0;
            if (OP == "SUMA")
            {
                num = 0;
                ccont = 0;
                IngreFila(ref num);
                IngreColum(ref nume);
                IngreFila(ref nums);
                IngreColum(ref ccont);
                if (num ==nums&&nume==ccont)
                {
                    CargaMat(num, nume, ref M);
                    CargaMat(num, nume, ref Mat);
                    SumarMatrices(ref M, ref Mat, ref MatZ, num, nume);
                    MostrMatr(ref M, num, nume, ref MATRIZI);
                    MostrMatr(ref Mat, num, nume, ref MATRIZII);
                    MostrMatr(ref MatZ, num, nume, ref MATRIZIII);
                }
                else
                {
                    MessageBox.Show("LO SENTIMOS.. LA OPERACION  NO PUEDE SER REALIZADA POR QUE LAS DIMENSIONES  NO SON IGUALES, VUELVA A INTENTARLO");
                }
               
            }
            else if (OP == "RESTA")
            {
                num = 0;
                ccont = 0;
                IngreFila(ref num);
                IngreColum(ref nume);
                IngreFila(ref nums);
                IngreColum(ref ccont);
                if (num==nums&&nume==ccont)
                {
                    CargaMat(num, nume, ref M);
                    CargaMat(num, nume, ref Mat);
                    RestaMatrices(ref M, ref Mat, ref MatZ, num, nume);
                    MostrMatr(ref M, num, nume, ref MATRIZI);
                    MostrMatr(ref Mat, num, nume, ref MATRIZII);
                    MostrMatr(ref MatZ, num, nume, ref MATRIZIII);
                }
                else
                {
                    MessageBox.Show("LO SENTIMOS... LA OPERACION NO PUEDE SER REALIZADA POR QUE LAS DIMENSIONES NO SON IGUALES, VUELVA A INTENTARLO");
                }

            }
            else if (OP == "MULTIPLICACION")
            {
                ccont = 0;
                num = 0;
                ccont = 0;
                IngreFila(ref num);
                IngreColum(ref nume);
                IngreFila(ref ccont);
                IngreColum(ref nums);
                if (nume == ccont)
                {
                    CargaMat(num, nume, ref M);
                    CargaMat(ccont, nums, ref Mat);
                    MultiplicarMA(ref V1, ref Vc1, ref M, ref Mat, ref MatZ, nums, num, nume, ccont);
                    MostrMatr(ref M, num, nume, ref MATRIZI);
                    MostrMatr(ref Mat, ccont, nums, ref MATRIZII);
                    MostrMatr(ref MatZ, num, nums, ref MATRIZIII);
                }
                else
                {
                    MessageBox.Show("LO SENTIMOS... LA OPERACION NO PUEDE SER REALIZADA POR QUE LAS DIMENSIONES SON DIFERENTES");
                }
               

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                OP = "SUMA";
            }
            else if(this.radioButton2.Checked==true)
            {
                OP = "RESTA";
            }
            else if(this.radioButton3.Checked==true)
            {
                OP = "MULTIPLICACION";
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button1.BackColor = Color.DarkRed;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
