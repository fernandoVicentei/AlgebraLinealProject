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
    public partial class INVERSA : Form
    {
        static int num = 50;
        static int nume = 50;
        static int col = 0;
        static int esce = 0;
        static int ayu = 0;
        static double nu = 0;
        static double nur = 0;
        static string nuc = "";
        static int[,] MT = new int[num, nume];
        static double[,] MASO = new double[num, num];
        static double[,] MA = new double[num, num];
        static string[,] Mle = new string[num, nume];
        static string[,] Mlt = new string[num, nume];
        static int[] VEC = new int[num];
        static int[] VE = new int[num];
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
                                       
                    p.Rows[i].Cells[j].Value = M1[i, j];
                }
               
            }
        }
        public INVERSA()
        {
            InitializeComponent();
        }
        static bool Esbarradiagonal(string nuc1)
        {
            if (nuc1.Equals("-"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void CargaMat(int num1, int num2, ref string[,]Mlt1)
        {
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                 Mlt1[i, j] = Convert.ToString(Interaction.InputBox("INGRESAR ELEMTOS", "Ingresar datos en la posicion M[" + i + "," + j + "]", "", 50, 50));
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
        static bool Esespacio(string subpa)
        {
            if (subpa.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool Nega(int num1)
        {
            if (num1 < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool Neutro(double num1)
        {
            if (num1 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool EsUno(int num1)
        {
            if (num1 == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static double Dividir(double VAR, double nume1)
        {
            return (VAR / nume1);
        }
        static bool EsBarraderecha(string nuc1)
        {
            if (nuc1.Equals("/"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool CantConso(string subpal)
        {

            if (subpal != "A" && subpal != "a" && subpal != "E" && subpal != "e" && subpal != "I" && subpal != "i" && subpal
                != "O" && subpal != "o" && subpal != "U" && subpal != "u" && subpal != "U" && subpal != "X" && subpal != "x" && subpal != "y"
                && subpal != "Y" && subpal != "Z" && subpal != "z" && subpal != "B" && subpal != "b" && subpal != "C" && subpal != "c" && subpal != "d" && subpal != "D")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //SEPARAMOS LAS VARIABLES DE LOS NUMEROS (4X) = 4  //
        static double DespjValor(string nuc1)
        {
            double nur = 0;
            string subpalt = "";
            int longi = 0;
            string tom = "";
            longi = nuc1.Length;
            for (int i = 0; i < longi; i++)
            {
                subpalt = nuc1.Substring(i, 1);
                //CONTROLAR SI TIENE UN SIGNO DE NEGACION O UNA VARIABLE EJEMPLO (-4Y) == -4 //
                if (EsBarraderecha(subpalt) == false && CantConso(subpalt) == true)
                {
                    tom = tom + subpalt.ToString();
                }
            }
            //VERIFICAMOS SI NO HAY NUMERO O SI HAY SOLO SIGNO DE NEGACION Y LE AUMENTAMOS UNO 
            //EJEMPLO (-Y) <----> SE SOBRE ENTIENDE QUE HAY (-1) <----
            if (Esbarradiagonal(tom) == true || tom.Equals("+") || Esespacio(tom) == true)
            {
                tom = tom + "1".ToString();
            }
            nur = Convert.ToDouble(tom);
            return nur;
        }
        static void AumentarMatrizIdentidad(ref string[,] Mlt1,int num1,int nume1)
        {
            int aux1 = 0;
            int aux2 = 0;
            int aux = nume1;
            nume1 = nume1 * 2;
            aux1 = aux;
            for (int i = 0; i < num1; i++)
            {
                
                for (int j =aux;j<nume1;j++)
                {
                    if(Mlt1[i,j]== null)
                    {
                        if (aux2 == i&& aux1 == j)
                        {
                            Mlt1[i, j] = "1".ToString();                       
                           
                        }
                        else
                        {
                            Mlt1[i, j] = "0".ToString();
                          
                        }
                       
                    }                   
                }
                aux2++;
                aux1++;
            }
            nume = nume1;
        }
        static bool EsMoM(double nuc1)
        {
            string sub = Convert.ToString(nuc1);
            int longi = sub.Length;
            string aux = "";
            aux = sub.Substring(0, 1);
            // RETORNA FALSO O VERDADERO SI ES NEGATIVO
            if (Esbarradiagonal(aux) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Despeje(ref string[,] Mlt1, int num1, int nume1, ref double[,] MA1)
        {
            //CONTROLA SI HAY LETRA O UNA BARRA DE FRACCION  O QUE SEA  DIFERENTE DE UN NUMERO
            MA1 = new double[num1, nume1];
            string aux = "";
            double nu = 0;
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < nume1; j++)
                {
                    aux = (Mlt1[i, j]);
                    nu = DespjValor(aux);
                    MA1[i, j] = nu;
                    nu = 0;
                    aux = "";
                }
            }
        }

        static void Cambio(ref double[,] MA1, int num1, int nume1, ref double[] VE1, ref double[] VEC1, double colu, int esce)
        {
            //INTERCAMBIO  DE FILAS YA QUE EXISTIO UN CERO EN EL PIVOT DE LA MATRIZ
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < nume1; j++)
                {
                    if (i == esce)
                    {
                        MA1[i, j] = VEC1[j];
                    }
                    else
                    {
                        if (i == colu)
                        {
                            MA1[i, j] = VE1[j];
                        }
                    }
                }
            }
        }
        static void CambioUnaFILA(ref double[,] MA1, int esce, int nume1, ref double[] VE1)
        {
            //MOVEMOS UNA FILA PIVOT QUE SE VA SUMAR, RESTAR O MULTIPLICAR 
            //PARA QUE NO AFECTE  AL PIVOT Y SU FILA 
            VE1 = new double[nume1];
            for (int i = 0; i < nume1; i++)
            {
                VE1[i] = MA1[esce, i];
            }
        }
        //CARGAMOS FILAS DE LA MATRIZ PARA INTERCAMBIARLOS DE LUGAR POR EXISTENCIA DE CERO
        static void CargarFilaalVect(ref double[] VEC1, int num1, int nume1, ref double[,] MA1, ref double[] VE1, int esce, double colu)
        {
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < nume1; j++)
                {
                    if (i == colu)
                    {
                        VEC1[j] = MA1[i, j];
                    }
                    else
                    {
                        if (i == esce)
                        {
                            VE1[j] = MA1[i, j];
                        }
                    }
                }
            }
            Cambio(ref MA1, num1, nume1, ref VE1, ref VEC1, colu, esce);
        }
        // CONVERTIMOS AL NUMERO PIVOT EN UNO REALIZANDO UNA MULTIPLICACION POR SU INVERSA
        static void VolverUnoAPivot(double ayu1, ref double[,] MA1, int esc, int nume1)
        {
            for (int a = 0; a < nume1; a++)
            {
                MA1[esc, a] = (Multiplicar(MA1[esc, a], ayu1));
            }
        }
        //SUMA DE FILAS PARA VOLVER CERO A AQUELLOS NUMEROS QUE ESTAN SOBRE O BAJO EL PIVOT
        static void VolverCeroAdifrtUnoSum(ref double[,] MA1, ref double[] VE1, int nume1, int nu1)
        {
            for (int i = 0; i < nume1; i++)
            {
                MA1[nu1, i] = (SumaR(MA1[nu1, i], VE1[i]));
            }
        }
        //SUMA DE FILAS PARA VOLVER CERO A AQUELLOS NUMEROS QUE ESTAN SOBRE O BAJO EL PIVOT
        static void VolverCeroAdifrtUnoRes(ref double[,] MA1, ref double[] VE1, int nume1, int nu1)
        {
            for (int i = 0; i < nume1; i++)
            {
                MA1[nu1, i] = (Resta(MA1[nu1, i], VE1[i]));
            }
        }
        //EN ESTE PROCEDIEMTO SE CONTROLA LAS FILAS SI HAY CERO (CONTROL MADRE)
        //ADEMAS VERIFICA Y LOS NUMEROS QUE NO ESTAN EN LA DIAGONAL PRINCIPAL
        static void ControldeFIla(ref double[,] MA1, int num1, int nume1)
        {
            double fi = 0;
            int colm = 0;
            double[] VE1 = new double[nume1];
            double[] VA = new double[nume1];
            double col = 0;
            int escer = 0;
            double ayu = 0;
            int conta = 0;
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < nume1; j++)
                {                    
                    if (i == j)
                    {
                        colm = 1;
                        if (Neutro(MA1[i, j]) == false)
                        {
                            //ACA CONSEGUIMOS LA INVERSA DEL NUMERO PARA LA POSTERIOR MULTIPLICACION Y LLEGAR A UNO <---
                            ayu = Dividir(1, MA1[i, j]);
                            VolverUnoAPivot(ayu, ref MA1, i, nume1);
                            for (int b = 0; b < num1; b++)
                            {
                                if (b != i)
                                {
                                    if (Neutro(MA1[b, j]) == false)
                                    {
                                        if (EsMoM(MA1[b, j]) == true)
                                        {
                                            CambioUnaFILA(ref MA1, i, nume1, ref VE1);
                                            fi = MA1[b, j];
                                            MultiplicarFiPorvalorContrario(ref VE1, nume1, fi);
                                            VolverCeroAdifrtUnoRes(ref MA1, ref VE1, nume1, b);
                                        }
                                        else
                                        {
                                            CambioUnaFILA(ref MA1, i, nume1, ref VE1);
                                            fi = MA1[b, j];
                                            MultiplicarFiPorvalorContrario(ref VE1, nume1, fi);
                                            VolverCeroAdifrtUnoRes(ref MA1, ref VE1, nume1, b);
                                        }
                                    }
                                }
                            }
                            colm = 0;
                        }
                        else
                        {
                            //CONTROLAMOS SI HAY UN NUMERO DIFERNETE DE CERO O NO 
                            //EN CASO  DE NO HABER ENTONCES ESTAMOS RESOLVIENDO UNA SISTEMA -->
                            //CON  INFINITAS SOLUCIONES O SISTEMAS NO COMPATIBLES
                            escer = ContrFila(ref MA1, num, nume1, i);
                            if (escer != i && escer != 0)
                            {
                                CargarFilaalVect(ref VE1, num, nume1, ref MA1, ref VA, escer, i);
                                if (colm == 1)
                                {
                                    ayu = Dividir(1, MA1[i, j]);
                                    VolverUnoAPivot(ayu, ref MA1, i, nume1);
                                    for (int b = 0; b < num1; b++)
                                    {
                                        if (b != i)
                                        {
                                            if (Neutro(MA1[b, j]) == false)
                                            {
                                                if (EsMoM(MA1[b, j]) == true)
                                                {
                                                    CambioUnaFILA(ref MA1, i, nume1, ref VE1);
                                                    fi = MA1[b, j];
                                                    MultiplicarFiPorvalorContrario(ref VE1, nume1, fi);
                                                    VolverCeroAdifrtUnoRes(ref MA1, ref VE1, nume1, b);
                                                }
                                                else
                                                {
                                                    CambioUnaFILA(ref MA1, i, nume1, ref VE1);
                                                    fi = MA1[b, j];
                                                    MultiplicarFiPorvalorContrario(ref VE1, nume1, fi);
                                                    VolverCeroAdifrtUnoRes(ref MA1, ref VE1, nume1, b);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //VERIFICAR EN TODA LA ULTIMA FILA PARA SABER SI ES UN SISTEMA NO COMPATIBLE
                                MessageBox.Show("LA MATRIZ TIENE INFINITAS SOLUCIONES ");
                            }
                            colm = 0;
                        }
                    }                             
                }
            }
        }
        static void MultiplicarFiPorvalorContrario(ref double[] VE1, int nume1, double fi)
        {
            for (int i = 0; i < nume1; i++)
            {
                VE1[i] = (Multiplicar(fi, VE1[i]));
            }
        }
        //EN ESTE PROCEDIMIENTO CONTROLAMOS SI HAY CEROS (SUBCONTROL)
        static int ContrFila(ref double[,] MA1, int num1, int nume1, double col)
        {
            int cer = 0;
            int y = Convert.ToInt32(col);
            for (int i = y; i < num1; i++)//era 1 pero estoy probando
            {
                for (int j = 0; j < nume1; j++)
                {
                    if (j == col)
                    {
                        if (Neutro(MA1[i, j]) == false)
                        {
                            cer = i;
                        }
                    }
                }
            }
            return cer;
        }
        //MOSTRAR MATRIZ 
        static void MostrarMatrizEnter(ref double[,] MA1, int num1, int nume1,ref DataGridView P)
        {
            P.ColumnCount = nume1;
            P.RowCount = num1;
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < nume1; j++)
                {
                    P.Rows[i].Cells[j].Value = MA1[i, j];
                }
                
            }
        }
        //MOSTRAR MATRIZ CON LOS INGOGNITAS
        static void MostrarMatrizString(ref string[,] Mlt1, int num1, int nume1,ref DataGridView P)
        {
            P.ColumnCount = nume1;
            P.RowCount = num1;
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < nume1; j++)
                {
                    P.Rows[i].Cells[j].Value = Mlt1[i, j];
                }               
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IngreFila(ref num);
   IngreColum(ref nume);
            CargaMat(num, nume, ref Mlt);
            MostrarMatrizString(ref Mlt, num, nume, ref MMATRIZ1);
            AumentarMatrizIdentidad(ref Mlt, num, nume);
            Despeje(ref Mlt, num, nume, ref MA);            
            ControldeFIla(ref MA, num, nume);                            
            MostrarMatrizEnter(ref MA, num, nume,ref MATRIZ11);//hubo un error
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
