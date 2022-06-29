using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ClassFractal.Fractals
{
    class CantorSet : Fractal
    {
        /// <summary>
        /// Свойство для определение соотношения отрезков на каждой итерации
        /// </summary>
        private double Ratio { get; init; }

        /// <summary>
        /// Свойство для длины отрезка
        /// </summary>
        private double Length { get; init; }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public CantorSet() : base()
        {
            maxFractalDepth = 16;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="depth">Глубина прорисовки</param>
        /// <param name="ratio">Соотношение длин</param>
        /// <param name="length">Длина отрезка</param>
        /// <param name="start">Начальныц цвет градиента</param>
        /// <param name="end">Конечный цвет градиента</param>
        /// <param name="canvas">Холст на котором рисуем</param>
        public CantorSet(int depth, double ratio, double length, System.Drawing.Color start, System.Drawing.Color end, Canvas canvas) : base(depth, start, end, canvas)
        {
            FractalDepth = depth;
            Ratio = ratio;
            maxFractalDepth = 16;
            Length = length == 0 ? (PaintArea.ActualHeight - 40) / FractalDepth : length ;
        }

        /// <summary>
        /// Реализация метода отрисовки фрактала
        /// </summary>
        public override void DrawFractal()
        {
            SetGradientList(startGradient, endGradient);
            double x1 = PaintArea.ActualWidth / 30;
            double y1 = 20;
            double x2 = PaintArea.ActualWidth - PaintArea.ActualWidth / 30;
            double y2 = 20;
            DrawSet(x1, y1, x2, y2, Ratio, FractalDepth);
        }

        /// <summary>
        /// Вспомогательный метод для отрисовки Множества
        /// </summary>
        /// <param name="xa">Х координат первой точки отрезка</param>
        /// <param name="ya">У координат первой точки отрезка</param>
        /// <param name="xb">Х координат второй точки отрезка</param>
        /// <param name="yb">У координат второй точки отрезка</param>
        /// <param name="ratio">Соотношение</param>
        /// <param name="depth">Глубина прорисовки</param>
        public void DrawSet(double xa,
                            double ya,
                            double xb,
                            double yb,
                            double ratio,
                            int depth)
        {
            Line line = new();
            int index = depth != 0 ? depth - 1 : 0;
            line.Stroke = new SolidColorBrush(Color.FromArgb(gradient[index].A, gradient[index].R, gradient[index].G, gradient[index].B)); ;
            line.StrokeThickness = 10;

            if (depth > 0)
            {
                line.X1 = xa;
                line.Y1 = ya;
                line.X2 = xb;
                line.Y2 = yb;
                PaintArea.Children.Add(line);

                double xc, yc, xd, yd;
                xc = xa + (xb - xa) / ratio;
                yc = ya + Length;
                xd = xb - (xb - xa) / ratio;
                yd = yb + Length;
                ya += Length;
                yb += Length;

                DrawSet(xa, ya, xc, yc, ratio, depth - 1);
                DrawSet(xd, yd, xb, yb, ratio, depth - 1);
            }
        }
    }
}
