using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmVisualizer
{
    class SortEngineShell : IOrdenamiento
    {
        private bool sorted = false;
        private int[] arreglo;
        private Graphics g;
        private int maxVal;
        private int width;
        private int sizeChar;

        // Colores de los triangulos
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush GreenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen);
        Brush RedBrush   = new System.Drawing.SolidBrush(System.Drawing.Color.Red);

        public void DoWork(int[] arreglo_In, Graphics g_In, int maxVal_In, int maxWidth_In)
        {
            arreglo = arreglo_In;
            g = g_In;
            maxVal = maxVal_In;
            width = maxWidth_In;
            sizeChar = (width / arreglo.Length) - 1; // Tamaño dinamico de los rectangulo segun el numero de datos

            while (!sorted)
            {
                shellSort(arreglo);

                /*for (int i = 0; i < arreglo.Length - 1; i++)
                        if (arreglo[i] > arreglo[i + 1]) swap(i, i + 1);*/

                /*for (int i = 0; i < arreglo.Length; i++)
                    for (int j = i + 1; j < arreglo.Length; j++)
                        if (arreglo[i] > arreglo[j]) swap(i, j);*/

                sorted = IsSorted();
            }

            // Ciclo para pintar los retangulos verdes
            for (int i = 0; i < arreglo.Length; i++)
            {
                int x = (int)(((double)width / arreglo.Length) * i);
                g.FillRectangle(GreenBrush, x, maxVal - arreglo[i], sizeChar, maxVal);
                Thread.Sleep(5);
            }

        }

        // Verifica en cada iteracion si el vector esta ordenado
        private bool IsSorted()
        {
            for (int i = 1; i < arreglo.Length - 1; i++)
                if (arreglo[i - 1] > arreglo[i]) return false;

            return true;
        }

        // Funcion de Swap (cambio)
        private void swap(int i, int p)
        {
            int temp = arreglo[i];
            arreglo[i] = arreglo[p];
            arreglo[p] = temp;

            int xi = (int)(((double)width / arreglo.Length) * i); // Calculo de la coordenada x para el sig. rect
            int xp = (int)(((double)width / arreglo.Length) * p); // Calculo de la coordenada x para el rect anterior despues del swap

            g.FillRectangle(BlackBrush, xi, 0, sizeChar, maxVal); // Dibujado de fondo
            g.FillRectangle(BlackBrush, xp, 0, sizeChar, maxVal); // Dibujado de fondo despues de un swap

            //g.FillRectangle(RedBrush, xp, maxVal - arreglo[p], sizeChar, maxVal);
            g.FillRectangle(WhiteBrush, xi, maxVal - arreglo[i], sizeChar, maxVal); // Redibujado de un rectangulo despues del swap
            g.FillRectangle(RedBrush,   xp, maxVal - arreglo[p], sizeChar, maxVal); // Indica el rectangulo actual en ser acomodado
            Thread.Sleep(20);
            g.FillRectangle(WhiteBrush, xp, maxVal - arreglo[p], sizeChar, maxVal); // Redibujado de un rectangulo tras ser acomodado
        }

        // ShellSort 
        private void shellSort(int[] arreglo)
        {
            int gap;

            for (gap = arreglo.Length / 2; gap > 0; gap /= 2)
                for (int i = gap; i < arreglo.Length; i++)
                    for (int j = i - gap; j >= 0 && arreglo[j] > arreglo[j + gap]; j -= gap)
                        swap(j, j + gap);
        }
    }
}
