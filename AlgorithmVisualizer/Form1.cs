using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmVisualizer
{
    public partial class Form1 : Form
    {
        int[] arreglo;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.Close();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            int Nentradas = Convert.ToInt32(txtDatos.Text); // Captura del text box para los datos
            int maxVal = panel1.Height;     // Valor maximo para los datos generados
            arreglo = new int[Nentradas];   // Arreglo

            // Instacia de graphics para crear los rectangulos
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, panel1.Width, maxVal);
            // Instnacia de Random para la generacion de datos
            Random rand = new Random();

            for (int i = 0; i < arreglo.Length; i++)
                arreglo[i] = rand.Next(0, maxVal);  //Llenado del vector con numeros aleatorios

            for (int i = 1; i < arreglo.Length; i++)
            {
                // Calculo de la coordenada x para colocar el sig. Rectangulo
                int x = (int)(((double)panel1.Width / arreglo.Length) * i);
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), x, maxVal - arreglo[i], (panel1.Width / arreglo.Length) - 1, maxVal);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Instancia de la interfaz para el ordenamiento
            IOrdenamiento se = new SortEngineShell();
            // Llamada a la funcion para acomodar
            se.DoWork(arreglo, g, panel1.Height, panel1.Width);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
