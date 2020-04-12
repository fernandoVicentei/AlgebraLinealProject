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
    public partial class ECUACIONESLINEALES : Form
    {
        static int num = 50;
        static int nume = 50;
        static int col = 0;
        static int esce = 0;
        static int ayu = 0;
        static double nu = 0;
        static double nur = 0;
        static string kl = "";
        static string nuc = "";
        static int[,] MT = new int[num, nume];
        static double[,] MASO = new double[num, num];
        static double[,] MA = new double[num, num];
        static string[,] Mle = new string[num, nume];
        static string[,] Mlt = new string[num, nume];
        static int[] VEC = new int[num];
        static int[] VE = new int[num];

        public ECUACIONESLINEALES()
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
        static void MostrMatrsTRIN(ref string[,] MA1, int num1, int num2, ref DataGridView p)
        {
            p.ColumnCount = num2;
            p.RowCount = num1;
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < num2; j++)
                {

                    p.Rows[i].Cells[j].Value = MA1[i, j];
                }
            }
        }
        static void CargaMat(int num1, int num2, ref string[,] MA1)
        {
            for (int i = 0; i < num1; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    MA1[i, j] = Convert.ToString(Interaction.InputBox("INGRESAR ELEMTOS", "Ingresar datos en la posicion M[" + i + "," + j + "]", "", 50, 50));
                }
            }
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
                //CONTROLAR SI TIENE UN SIGNO DE NEGACION O UNA VARIABLE EJEMPLO (-4  Y) ==>> // -4 //
                if (EsBarraderecha(subpalt) == false && CantConso(subpalt) == true)
                {
                    tom = tom + subpalt.ToString();
                }
            }
            //VERIFICAMOS SI NO HAY NUMERO O SI HAY SOLO SIGNO DE NEGACION Y LE AUMENTAMOS UNO 
            //EJEMPLO (-Y) <----> SE SOBRE ENTIENDE QUE HAY (-1) <----  -X = - 1
            if (Esbarradiagonal(tom) == true || tom.Equals("+") || Esespacio(tom) == true)
            {
                tom = tom + "1".ToString();
            }
            nur = Convert.ToDouble(tom);
            return nur;
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
                                            //SE SUMA CON LA FILA DELPIVOT
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
                            //EN CASO  DE NO HABER ENTONCES ESTAMOS RESOLVIENDO UN SISTEMA -->
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
                                int ou = 0;
                                for (int U = num1 - 1; U < num1; U++)
                                {
                                    for (int W = nume1 - 1; W < nume1; W++)
                                    {
                                        if (Neutro(MA1[U, W]) == false)
                                        {
                                            ou++;
                                        }
                                    }
                                }
                                if (ou > 0)
                                {
                                    MessageBox.Show("La matris no es compatible ");
                                }
                                else if (ou == 0)
                                {
                                    MessageBox.Show("Matriz INfinita");
                                }
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
        static string CambioSigno(string nuc1)
        {
            int leng = nuc1.Length;
            string subpal = "";
            string aux = "";

            subpal = nuc1.Substring(0, 1);
            if (Esbarradiagonal(subpal) == true)
            {
                subpal = "+".ToString();
            }
            else if (Esbarradiagonal(subpal) == false)
            {
                subpal = "-" + subpal.ToString();
            }
            aux = subpal;
            for (int i = 1; i < leng; i++)
            {
                subpal = nuc1.Substring(i, 1);
                aux = aux + subpal.ToString();
            }

            return aux;
        }
        static void ObteniendoResultFinal(ref double[,] MA1, int num1, int nume1,ref string nuc1,ref string kl1)
        {          
            string aux = "";
            string auxi = "";
            int ou = 0;
            int op = 0;
            for (int i = 0; i < num1; i++)
            {
                for (int j = nume1 - 2; j < nume1 - 1; j++)
                {
                    if (Neutro(MA1[i, j]) == true)
                    {
                        // SI OU LLEGASE A SER MAS QUE DOS ES MATRIZ CON SOLUCION UNICA
                        ou++;
                    }
                    else
                    {
                        //SI OP ES MAYOR DE DOS ENTONCES ES MATRIZ CON INFINITAS SOLUCIONES
                        op++;
                    }
                }
            }
            if (op >= 2)
            {
                kl1 = "Matriz con Infinitas Soluciones "+kl1;
                for (int l = 0; l < num1; l++)
                {
                    for (int k = nume1 - 2; k <= nume1 - 2; k++)
                    {
                        if (Neutro(MA1[l, k]) == false)
                        {
                            aux = Convert.ToString(MA1[l, k]);
                            auxi = CambioSigno(aux);
                            //para ver sii su resultado es cero
                            if (Neutro(MA1[l, k + 1]) == true)
                            {
                                nuc1=(" X = " + auxi + " t ; " )+nuc1;
                            }
                            else
                            {
                                nuc1=(" X = " + MA1[l, k + 1] +  "" + auxi + " t ; ")+nuc1;
                            }
                        }
                        else
                        {
                            nuc1= ( " x = t ; ") +nuc1 ;
                        }
                    }
                }
            }
            else
            {
                //CONTROLANDO  SI ES MATRIZ CON SOLUCION UNIV¡CA VERDADERAMENTE
                if (ou <= num1 - 1)
                ou = 0;
                for (int i = num1-1; i < num1; i++)
                {
                    for (int j = 0; j < nume1; j++)
                    {
                        if (Neutro(MA1[i, j]) == true)
                        {
                            ou++;
                        }
                    }
                }
                if (ou >= nume1 - 1)
                {
                    kl1 = "Matriz con Infinitas Soluciones" + kl1;
                    for (int l = 0; l < num1; l++)
                    {
                        for (int k = nume1 - 2; k <= nume1 - 2; k++)
                        {
                            if (Neutro(MA1[l, k]) == false)
                            {
                                aux = Convert.ToString(MA1[l, k]);
                                auxi = CambioSigno(aux);
                                //para ver sii su resultado es cero
                                if (Neutro(MA1[l, k + 1]) == true)
                                {
                                    nuc1 = (" X = " + auxi + " t ; ") + nuc1;
                                }
                                else
                                {
                                    nuc1 = (" X = " + MA1[l, k + 1] + "" + auxi + " t ; ") + nuc1;
                                }
                            }
                            else
                            {
                                nuc1 = (" x = t ; ") + nuc1;
                            }
                        }
                    }
                }
                else
                {
                    kl1 = "Matriz con Solucion Unica";
                    for (int l = 0; l < num1; l++)
                    {
                        for (int k = nume1 - 1; k < nume1; k++)
                        {
                            nuc1 = (" X = " + MA1[l, k] + " ; ") + (nuc1);
                        }
                    }
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {            
            //HOLA A TODOS............  <<<<---------
            //INICIO DEL PROGRAMA 
            IngreFila(ref num);
            IngreColum(ref nume);
            CargaMat(num, nume, ref Mlt);                   
            Despeje(ref Mlt, num, nume, ref MA);
            ControldeFIla(ref MA, num, nume);
            MostrMatr(ref MA, num, nume, ref MATRIC);
            MostrMatrsTRIN(ref Mlt, num, nume, ref MATRI);
            ObteniendoResultFinal(ref MA, num, nume, ref nuc,ref kl);
            RESULTADO result = new RESULTADO();
            result.txtresult.Text = nuc.ToString();
            result.lbltiul.Text = kl.ToString();
            result.Show();
            
        }

        private void MATRI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ECUACIONESLINEALES_Load(object sender, EventArgs e)
        {

        }
    }
}
