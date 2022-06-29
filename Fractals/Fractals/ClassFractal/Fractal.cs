
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace ClassFractal.Fractals
{
    abstract class Fractal
    {
        /// <summary>
        /// Свойство для получения глубины прорисовки
        /// </summary>
        internal int FractalDepth { get; set; }

        /// <summary>
        /// Свойство для отрисовки фигур (Холст на котором рисуем)
        /// </summary>
        internal Canvas PaintArea { get; set; }

        /// <summary>
        /// Определения масимальной глубины
        /// </summary>
        internal int maxFractalDepth;

        /// <summary>
        /// Лист для хранения градиентного увета
        /// </summary>
        internal List<Color> gradient;

        /// <summary>
        /// Начальный цвет градиента
        /// </summary>
        internal Color startGradient;

        /// <summary>
        /// Конечный увет градиента
        /// </summary>
        internal Color endGradient;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Fractal()
        {
            maxFractalDepth = 16;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="depth">Глубина</param>
        /// <param name="start">Начальныц цвет</param>
        /// <param name="end">Конечный цвет</param>
        /// <param name="canvas">Холст на котором рисуем</param>
        public Fractal(int depth, Color start, Color end, Canvas canvas)
        {
            FractalDepth = depth;
            PaintArea = canvas;
            startGradient = start;
            endGradient = end;
        }

        /// <summary>
        /// Отрисовка фрактала
        /// </summary>
        public abstract void DrawFractal();

        /// <summary>
        /// Заполнение градиента
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        internal void SetGradientList(Color start, Color end)
        {
            int rMax = start.R;
            int rMin = end.R;
            int gMax = start.G;
            int gMin = end.G;
            int bMax = start.B;
            int bMin = end.B;

            gradient = new List<Color>();
            for (int i = 0; i < FractalDepth; i++)
            {
                var rAverage = rMin + (int)((rMax - rMin) * i / FractalDepth);
                var gAverage = gMin + (int)((gMax - gMin) * i / FractalDepth);
                var bAverage = bMin + (int)((bMax - bMin) * i / FractalDepth);
                gradient.Add(Color.FromArgb(rAverage, gAverage, bAverage));
            }
        }
    }
}
