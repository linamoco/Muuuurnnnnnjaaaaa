using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace ClassLibrary1
{
    public class JaggedMatrix
    {
        double[] x; //массив вещественных значений
        List<double>[] arr; //массив ссылок на списки вещественных значений
        Random generator = new Random();
        /// <summary>
        /// Создает два массива, которые требуются в условии задачи
        /// </summary>
        /// <param name="max">Максимальное значение рандома</param>
        /// <param name="min">Минимальное значение рандома</param>
        /// <param name="n">количество списков</param>
        public JaggedMatrix(double max, double min, int n)
        {
            x = new double[n];
            arr = new List<double>[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = min + (max - min) * generator.NextDouble();
                arr[i] = CosArray(x[i]);

            }
        }
        /// <summary>
        /// Создает список из членов ряда разложения Маклорена
        /// </summary>
        /// <param name="x0"> </param>
        /// <returns> созданный список</returns>
        private List<double> CosArray(double x0)
        {
            double summaLast = 1; //
            double summaFirst = 0; //
            int k = 1;
            double i = 1;
            int iter = 0;
            List<double> tmp = new List<double>() { 1 };
            while (summaLast - summaFirst > double.Epsilon)
            {
                k *= (k + 1) * (k + 2);
                i *= x0 * x0 / k;
                summaFirst = summaLast;
                if (iter == 0)
                {
                    summaLast -= i;
                }
                else
                {
                    summaLast += i;
                }
                tmp.Add(summaLast);
            }
            return tmp;
        }
        /// <summary>
        /// Создает массив из строковых представлений элементов переданного массива списков
        /// </summary>
        /// <returns> созданный массив</returns>
        public string[] PrintStrings()
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                count += arr[i].Count;
            }
            string[] Arr = new string[count];
            count = 0;
            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("en-NZ");
            for (int i = 0; i < arr.Length; i++)
            {
                foreach (double tmp in arr[i])
                {
                    Arr[count++] = tmp.ToString("E03", culture);
                }
            }
            return Arr;
        }
    }
}
