using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ClassFractal.Fractals
{
    class KochCurve : Fractal
    {
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public KochCurve() : base()
        {
            maxFractalDepth = 9;
        }

        /// <summary>
        /// Конструктор с пармаетрами
        /// </summary>
        /// <param name="depth">глубина прорисовки</param>
        /// <param name="start">Начальный цвет градиента</param>
        /// <param name="end">Конечный цвет градиента</param>
        /// <param name="canvas">Холст на котором рисуем</param>
        public KochCurve(int depth, System.Drawing.Color start, System.Drawing.Color end, Canvas canvas) : base(depth, start, end, canvas)
        {
            maxFractalDepth = 9;
        }

        private int indexColor;
        /// <summary>
        /// Реализация отрисовки фрактала
        /// </summary>
        public override void DrawFractal()
        {
            SetGradientList(endGradient, startGradient);
            double x1 = PaintArea.ActualWidth / 10;
            double y1 = PaintArea.ActualHeight - 20;
            double x2 = PaintArea.ActualWidth - PaintArea.ActualWidth / 10;
            double y2 = PaintArea.ActualHeight - 20;
            indexColor = 0;
            DrawKochCurve(FractalDepth, x1, y1, x2, y2);
        }

        /// <summary>
        /// Вспомогательный метод отрисовки кривой Коха
        /// </summary>
        /// <param name="depth">Глубина прорисовки</param>
        /// <param name="x1">Х координата для первой точки отрезка</param>
        /// <param name="y1">У координата для первой точки отрезка</param>
        /// <param name="x2">Х координата для второй точки отрезка</param>
        /// <param name="y2">У координата для второй точки отрезка</param>
        private void DrawKochCurve(int depth, double x1, double y1, double x2, double y2)
        {
            if (depth == 0)
            {
                Line line = new();
                line.Stroke = new SolidColorBrush(Color.FromArgb(gradient[indexColor].A, gradient[indexColor].R, gradient[indexColor].G, gradient[indexColor].B));
                line.StrokeThickness = 1.0 / (FractalDepth * 1.5);
                line.X1 = x1;
                line.Y1 = y1;
                line.X2 = x2;
                line.Y2 = y2;
                PaintArea.Children.Add(line);
                indexColor = indexColor + 1 < gradient.Count ? indexColor + 1 : 0;
                return;
            }
            else
            {
                double alpha = Math.Atan2(y2 - y1, x2 - x1);
                double r = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
                double xa = x1 + r * Math.Cos(alpha) / 3;
                double ya = y1 + r * Math.Sin(alpha) / 3;

                double xc = xa + r * Math.Cos(alpha - Math.PI / 3) / 3;
                double yc = ya + r * Math.Sin(alpha - Math.PI / 3) / 3;

                double xb = x1 + 2 * r * Math.Cos(alpha) / 3;
                double yb = y1 + 2 * r * Math.Sin(alpha) / 3;

                DrawKochCurve(depth - 1, x1, y1, xa, ya);
                DrawKochCurve(depth - 1, xa, ya, xc, yc);
                DrawKochCurve(depth - 1, xc, yc, xb, yb);
                DrawKochCurve(depth - 1, xb, yb, x2, y2);
            }
        }
    }
}
