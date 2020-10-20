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
        private int[] arreglo;
        private Graphics g;
        private int maxVal;
        private int width;
        private int sizeChart;
        private int height;

        // Colores de los rectangulos
        Brush BackBrush    = new System.Drawing.SolidBrush(Color.FromArgb(255, 255, 255, 255));
        Brush ChartBrush   = new System.Drawing.SolidBrush(Color.FromArgb(255, 0, 0, 0));
        Brush SucessBrush  = new System.Drawing.SolidBrush(Color.FromArgb(255, 34, 252, 10));
        Brush SelectBrush  = new System.Drawing.SolidBrush(Color.FromArgb(255, 255, 0, 0));

        public void DoWork(int[] arreglo_In, Graphics g_In, int maxVal_In, int maxWidth_In)
        {
            g = g_In;
            arreglo = arreglo_In;
            maxVal = maxVal_In;
            width = maxWidth_In;
            sizeChart = (width / arreglo.Length) - 1; // Ancho dinamico de los rectangulo segun el numero de datos
            height = maxVal / arreglo.Length;  // Altura dinamica de los rectangulo segun el numero de datos

            while (!IsSorted())
            {
                shellSort(arreglo);
                //shellSort2(arreglo);

                /*for (int i = 0; i < arreglo.Length - 1; i++)
                        if (arreglo[i] > arreglo[i + 1]) swap(i, i + 1);*/

                /*for (int i = 0; i < arreglo.Length; i++)
                    for (int j = i + 1; j < arreglo.Length; j++)
                        if (arreglo[i] > arreglo[j]) swap(i, j);*/
            }

            // Ciclo para pintar los retangulos verdes
            for (int i = 0; i < arreglo.Length; i++)
            {
                int x = (int)(((double)width / arreglo.Length) * i);
                g.FillRectangle(SucessBrush, x, maxVal - arreglo[i] * height, sizeChart, maxVal);
                Thread.Sleep(1);
            }

        }

        // Verifica en cada iteracion si el vector esta ordenado
        private bool IsSorted()
        {
            for (int i = 1; i < arreglo.Length - 1; i++)
                if (arreglo[i - 1] > arreglo[i]) 
                    return false;

            return true;
        }

        // ShellSort 
        private void shellSort(int[] arreglo)
        {
            for (int gap = arreglo.Length / 2; gap > 0; gap /= 2)
                for (int i = gap; i < arreglo.Length; i++)
                    for (int j = i - gap; j >= 0 && arreglo[j] > arreglo[j + gap]; j -= gap)
                        swap(j, j + gap);
        }

        // Funcion de Swap (cambio)
        private void swap(int i, int p)
        {
            int xi = (int)(((double)width / arreglo.Length) * i); // Calculo de la coordenada x para el sig. rect
            int xp = (int)(((double)width / arreglo.Length) * p); // Calculo de la coordenada x para el rect anterior despues del swap

            int temp = arreglo[i];
            arreglo[i] = arreglo[p];
            arreglo[p] = temp;

            g.FillRectangle(BackBrush, xp, 0, sizeChart, maxVal);
            g.FillRectangle(BackBrush, xi, 0, sizeChart, maxVal); // Dibujado de fondo

            g.FillRectangle(SelectBrush, xp, maxVal - arreglo[p] * height, sizeChart, maxVal);
            g.FillRectangle(SelectBrush, xi, maxVal - arreglo[i] * height, sizeChart, maxVal);
            Thread.Sleep(15);

            g.FillRectangle(ChartBrush, xi, maxVal - arreglo[i] * height, sizeChart, maxVal); // Redibujado de un rectangulo despues del swap
            g.FillRectangle(ChartBrush, xp, maxVal - arreglo[p] * height, sizeChart, maxVal);
        }

        /*private void shellSort2(int[] arr)
        {
            int n = arr.Length;
            int p;
            int temp;
            int xp = 0;

            for (int gap = n / 2; gap > 0; gap /= 2)
                for (int i = gap; i < n; i++)
                {
                    temp = arr[i];
                    int xi = (int)(((double)width / arreglo.Length) * i);

                    g.FillRectangle(BackBrush, xi, 0, sizeChart, maxVal);
                    g.FillRectangle(SelectBrush, xi, maxVal - (arr[i] * height), sizeChart, maxVal);
                    g.FillRectangle(ChartBrush, xi, maxVal - (arr[i] * height), sizeChart, maxVal);

                    for (p = i; p >= gap && arr[p - gap] > temp; p -= gap)
                    {
                        xp = (int)(((double)width / arreglo.Length) * p);
                        arr[p] = arr[p - gap];

                        g.FillRectangle(BackBrush, xp, 0, sizeChart, maxVal);
                        g.FillRectangle(SelectBrush, xp, maxVal - (arr[p] * height), sizeChart, maxVal);
                        Thread.Sleep(1000);
                        g.FillRectangle(ChartBrush, xp, maxVal - (arr[p] * height), sizeChart, maxVal);
                    }

                    arr[p] = temp;

                    xp = (int)(((double)width / arreglo.Length) * p);

                    g.FillRectangle(BackBrush, xp, 0, sizeChart, maxVal);
                    g.FillRectangle(ChartBrush, xp, maxVal - (arr[p] * height), sizeChart, maxVal);
                }
        }*/
    }
}
