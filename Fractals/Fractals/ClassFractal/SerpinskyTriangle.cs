using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ClassFractal.Fractals
{
    class SerpinskyTriangle : Fractal
    {

        private int indexColor;
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public SerpinskyTriangle() : base()
        {
            maxFractalDepth = 10;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="depth">Глубина прорисовки</param>
        /// <param name="start">Начальный цвет градиента</param>
        /// <param name="end">Конечный увет градиента</param>
        /// <param name="canvas">Холст на котором рисовать</param>
        public SerpinskyTriangle(int depth, System.Drawing.Color start, System.Drawing.Color end, Canvas canvas) : base(depth, start, end, canvas)
        {
            maxFractalDepth = 10;
        }

        /// <summary>
        /// Реализация отрисовки Треугольника
        /// </summary>
        public override void DrawFractal()
        {
            SetGradientList(startGradient, endGradient);
            PointCollection points = new(3);
            points.Add(new System.Windows.Point(PaintArea.ActualWidth / 4, PaintArea.ActualHeight - 20));
            points.Add(new System.Windows.Point(PaintArea.ActualWidth - PaintArea.ActualWidth / 4,  PaintArea.ActualHeight - 20));
            points.Add(new System.Windows.Point((points[0].X + points[1].X) / 2, points[0].Y - (points[1].X - points[0].X) * Math.Sin(Math.PI / 3)));
            indexColor = 0;
            DrawTriangle(FractalDepth, points[2], points[0], points[1]);
        }

        /// <summary>
        /// Вспомогательный метод для отрисовки Треугольника
        /// </summary>
        /// <param name="depth">Глубина прорисовки</param>
        /// <param name="top">Первая точка треугольника</param>
        /// <param name="left">Вторая точка треугольника</param>
        /// <param name="right">Третья точка треугольника</param>
        private void DrawTriangle(int depth,
                                  System.Windows.Point top,
                                  System.Windows.Point left,
                                  System.Windows.Point right)
        {
            if (depth == 0)
            {
                Polygon triangle = new();
                triangle.Stroke = new SolidColorBrush(Color.FromArgb(gradient[indexColor].A, gradient[indexColor].R, gradient[indexColor].G, gradient[indexColor].B));
                indexColor = indexColor + 1 < gradient.Count ? indexColor + 1 : 0;
                triangle.StrokeThickness = 0.5;
                PointCollection points = new(3);
                points.Add(top);
                points.Add(left);
                points.Add(right);

                triangle.Points = points;
                PaintArea.Children.Add(triangle);
            }
            else
            {
                System.Windows.Point leftMiddle = MidPoint(top, left);
                System.Windows.Point rightMiddle = MidPoint(top, right);
                System.Windows.Point topMiddle = MidPoint(left, right);

                DrawTriangle(depth - 1, top, leftMiddle, rightMiddle);
                DrawTriangle(depth - 1, leftMiddle, left, topMiddle);
                DrawTriangle(depth - 1, rightMiddle, topMiddle, right);
            }
        }


        /// <summary>
        /// Вспомогательный метод для нахождения середины отрезка
        /// </summary>
        /// <param name="p1">Первая точка отрезка</param>
        /// <param name="p2">Вторая точка отрезка</param>
        /// <returns>Точку середины отрезка</returns>
        private System.Windows.Point MidPoint(System.Windows.Point p1, System.Windows.Point p2)
        {
            return new System.Windows.Point((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
        }
    }
}
