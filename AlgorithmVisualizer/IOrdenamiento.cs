using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualizer
{
    interface IOrdenamiento
    {
        void DoWork(int[] arreglo, Graphics g, int maxVal, int MaxWidth);
    }
}
