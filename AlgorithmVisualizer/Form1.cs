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
            g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(255, 255, 255, 255)), 0, 0, panel1.Width, maxVal);

            //Random rand = new Random();

            //for (int i = 0; i < arreglo.Length; i++)
            //    arreglo[i] = rand.Next(0, maxVal);

            for (int i = 0; i < arreglo.Length; ++i)
                arreglo[i] = i + 1;

            Shuffle(arreglo);

            int height = maxVal / arreglo.Length;
            for (int i = 0; i < arreglo.Length; i++)
            {
                // Calculo de la coordenada x para colocar el sig. Rectangulo
                int x = (int)(((double)panel1.Width / arreglo.Length) * i);

                g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(255, 0, 0, 0)), x, maxVal - (arreglo[i] * height), (panel1.Width / arreglo.Length) - 1, maxVal);
            }
        }

        public void Shuffle(int[] arr)
        {
            // Instnacia de Random para barajar los datos
            Random rand = new Random();
            int tmp;

            for (int i = arr.Length; i > 1; i--)
            {
                int j = rand.Next(i);

                tmp = arr[j];
                arr[j] = arr[i - 1];
                arr[i - 1] = tmp;
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

        private void btnInvertir_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            int Nentradas = Convert.ToInt32(txtDatos.Text);
            int maxVal = panel1.Height;
            arreglo = new int[Nentradas];

            g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(255, 255, 255, 255)), 0, 0, panel1.Width, maxVal);

            for (int i = 0, j = arreglo.Length; i < arreglo.Length; ++i, j--)
                arreglo[i] = j;

            int height = maxVal / arreglo.Length;
            for (int i = 0; i < arreglo.Length; i++)
            {
                int x = (int)(((double)panel1.Width / arreglo.Length) * i);
                g.FillRectangle(new System.Drawing.SolidBrush(Color.FromArgb(255, 0, 0, 0)), x, maxVal - (arreglo[i] * height), (panel1.Width / arreglo.Length) - 1, maxVal);
            }
        }
    }
}
