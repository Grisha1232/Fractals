using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ClassFractal.Fractals
{

    class FractalTree : Fractal
    {
        /// <summary>
        /// Свойство для угла левого отрезка
        /// </summary>
        private double AngleLeft { get; set; }

        /// <summary>
        /// Свойство для угла правого отрезка
        /// </summary>
        private double AngleRight { get; set; }

        /// <summary>
        /// Свойство для начальной длины отрезка
        /// </summary>
        private double Length { get; set; }

        /// <summary>
        /// Свойство определяющая во сколько отличается отрезок на каждой итерации
        /// </summary>
        private double RatioLength { get; set; }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public FractalTree() : base()
        {
            maxFractalDepth = 16;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="depth">Глубина прорисовки</param>
        /// <param name="angleLeft">Угл левого отрезка</param>
        /// <param name="angleRight">Угл правого отрезка</param>
        /// <param name="length">Длина отрезка</param>
        /// <param name="ratio">Определение во сколько раз отличаются отрезки на итерациях</param>
        /// <param name="start">Начальный цвет градиента</param>
        /// <param name="end">Конечный цвет градиента</param>
        /// <param name="canvas">Холст на котором рисуем</param>
        public FractalTree(int depth,
                           double angleLeft,
                           double angleRight,
                           double length,
                           double ratio,
                           System.Drawing.Color start,
                           System.Drawing.Color end,
                           Canvas canvas) : base(depth, start, end, canvas)
        {
            maxFractalDepth = 16;
            AngleLeft = angleLeft;
            AngleRight = angleRight;
            Length = length;
            RatioLength = ratio;
        }


        /// <summary>
        /// Реализация отрисовки фрактала
        /// </summary>
        public override void DrawFractal()
        {
            SetGradientList(endGradient, startGradient);
            
            DrawTree(PaintArea.ActualWidth / 2, PaintArea.ActualHeight, Length, 0, RatioLength, 0);
        }

        /// <summary>
        /// Вспомогательный метод для отрисовки Дерева
        /// </summary>
        /// <param name="x">Х координата</param>
        /// <param name="y">У координата</param>
        /// <param name="len">Длина отрезка</param>
        /// <param name="angle">Угл поворота</param>
        /// <param name="ratio">Соотношение отрезков</param>
        /// <param name="depth">Глубина прорисовки</param>
        private void DrawTree(double x, double y, double len, double angle, double ratio, int depth)
        {
            Line line = new();
            Brush brush = new SolidColorBrush(Color.FromArgb(gradient[depth].A, gradient[depth].R, gradient[depth].G, gradient[depth].B));
            line.Stroke = brush;
            line.X1 = x;
            line.Y1 = y; 
            double x2 = x + (len * Math.Sin(angle * Math.PI * 2 / 360));
            double y2 = y - (len * Math.Cos(angle * Math.PI * 2 / 360));
            line.X2 = x2;
            line.Y2 = y2;
            depth++;
            PaintArea.Children.Add(line);
            if (depth < FractalDepth)
            {
                DrawTree(x2, y2, len / ratio, angle + AngleRight, ratio, depth);
                DrawTree(x2, y2, len / ratio, angle - AngleLeft, ratio, depth);
            }
        }
    }
}
