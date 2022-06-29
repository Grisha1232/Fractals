using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ClassFractal.Fractals
{
    class SerpinskyCarpet : Fractal
    {
        /// <summary>
        /// Начальный цвет для Ковра
        /// </summary>
        private System.Drawing.Color BackColor { get; set; }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public SerpinskyCarpet() : base()
        {
            maxFractalDepth = 6;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="depth">Глубина прорисовки</param>
        /// <param name="start">Начальный цвет градиента</param>
        /// <param name="end">Конечный цвет градиента</param>
        /// <param name="backColor">Начальныц цвет ковра</param>
        /// <param name="canvas">Холст на котором рисуем</param>
        public SerpinskyCarpet(int depth, System.Drawing.Color start, System.Drawing.Color end, System.Drawing.Color backColor, Canvas canvas) : base(depth, start, end, canvas)
        {
            maxFractalDepth = 6;
            BackColor = backColor;
        }

        /// <summary>
        /// Реализация отрисовки Ковра
        /// </summary>
        public override void DrawFractal()
        {
            Polygon rect = new();
            SetGradientList(endGradient, startGradient);
            double width = PaintArea.ActualWidth - 2 * PaintArea.ActualWidth / 6;
            double height = PaintArea.ActualHeight - 40;
            PointCollection points = new PointCollection(4);
            points.Add(new System.Windows.Point(PaintArea.ActualWidth / 6, 20));
            points.Add(new System.Windows.Point(PaintArea.ActualWidth / 6 + width, 20));
            points.Add(new System.Windows.Point(PaintArea.ActualWidth / 6 + width, height + 20));
            points.Add(new System.Windows.Point(PaintArea.ActualWidth / 6, height + 20));
            Brush brush = new SolidColorBrush(Color.FromArgb(BackColor.A, BackColor.R, BackColor.G, BackColor.B));
            rect.Fill = brush;
            rect.Stroke = brush;
            rect.Points = points;
            PaintArea.Children.Add(rect);
            DrawCarpet(1, width, height, points);
        }

        /// <summary>
        /// Вспомогательный метод для отрисовки фрактала
        /// </summary>
        /// <param name="depth">Глубина прорисовки</param>
        /// <param name="width">Ширина Ковра</param>
        /// <param name="height">Высота Ковра</param>
        /// <param name="points">Точки прямоугольника</param>
        private void DrawCarpet(int depth, double width, double height, PointCollection points)
        {
            width /= 3;
            height /= 3;
            Polygon rect = new();
            Brush brush = new SolidColorBrush(Color.FromArgb(gradient[depth - 1].A, gradient[depth - 1].R, gradient[depth - 1].G, gradient[depth - 1].B));
            rect.Fill = brush;
            PointCollection CenterPoints = MiddleMiddle(points, width, height);
            rect.Points = CenterPoints;
            PaintArea.Children.Add(rect);

            if (depth < FractalDepth)
            {
                PointCollection points11 = LeftUp(points, width, height);
                PointCollection points12 = MiddleUp(points, width, height);
                PointCollection points13 = RightUp(points, width, height);
                PointCollection points21 = LeftMiddle(points, width, height);
                PointCollection points23 = RightMiddle(points, width, height);
                PointCollection points31 = LeftDown(points, width, height);
                PointCollection points32 = MiddleDown(points, width, height);
                PointCollection points33 = RightDown(points, width, height);
                width = CenterPoints[1].X - CenterPoints[0].X;
                height = CenterPoints[3].Y - CenterPoints[0].Y;
                DrawCarpet(depth + 1, width, height, points11);
                DrawCarpet(depth + 1, width, height, points12);
                DrawCarpet(depth + 1, width, height, points13);
                DrawCarpet(depth + 1, width, height, points21);
                DrawCarpet(depth + 1, width, height, points23);
                DrawCarpet(depth + 1, width, height, points31);
                DrawCarpet(depth + 1, width, height, points32);
                DrawCarpet(depth + 1, width, height, points33);

            }
        }

        #region 9 Квадратов
        /// <summary>
        /// Вспомогательный метод для нахождения левого верхнего прямоугольника
        /// </summary>
        /// <param name="points">Начальные точки</param>
        /// <param name="width">Ширина деленная на 3 от начального прямоугольника</param>
        /// <param name="height">Высота деленная на 3 от начального прямоугольника</param>
        /// <returns>Точки левого верхнего прямоугольника</returns>
        private PointCollection LeftUp(PointCollection points, double width, double height)
        {
            PointCollection points11 = new(4);
            points11.Add(new System.Windows.Point(points[0].X, points[0].Y));
            points11.Add(new System.Windows.Point(points[1].X - 2 * width, points[1].Y));
            points11.Add(new System.Windows.Point(points[2].X - 2 * width, points[2].Y - 2 * height));
            points11.Add(new System.Windows.Point(points[3].X, points[3].Y - 2 * height));
            return points11;
        }

        /// <summary>
        /// Вспомогательный метод для нахождения среднего верхнего прямоугольника
        /// </summary>
        /// <param name="points">Начальные точки</param>
        /// <param name="width">Ширина деленная на 3 от начального прямоугольника</param>
        /// <param name="height">Высота деленная на 3 от начального прямоугольника</param>
        /// <returns>Точки среднего верхнего прямоугольника</returns>
        private PointCollection MiddleUp(PointCollection points, double width, double height)
        {
            PointCollection points12 = new(4);
            points12.Add(new System.Windows.Point(points[0].X + width, points[0].Y));
            points12.Add(new System.Windows.Point(points[1].X - width, points[1].Y));
            points12.Add(new System.Windows.Point(points[2].X - width, points[2].Y - 2 * height));
            points12.Add(new System.Windows.Point(points[3].X + width, points[3].Y - 2 * height));
            return points12;
        }

        /// <summary>
        /// Вспомогательный метод для нахождения правого верхнего прямоугольника
        /// </summary>
        /// <param name="points">Начальные точки</param>
        /// <param name="width">Ширина деленная на 3 от начального прямоугольника</param>
        /// <param name="height">Высота деленная на 3 от начального прямоугольника</param>
        /// <returns>Точки правого верхнего прямоугольника</returns>
        private PointCollection RightUp(PointCollection points, double width, double height)
        {
            PointCollection points13 = new(4);
            points13.Add(new System.Windows.Point(points[0].X + 2 * width, points[0].Y));
            points13.Add(new System.Windows.Point(points[1].X, points[1].Y));
            points13.Add(new System.Windows.Point(points[2].X, points[2].Y - 2 * height));
            points13.Add(new System.Windows.Point(points[3].X + 2 * width, points[3].Y - 2 * height));
            return points13;
        }

        /// <summary>
        /// Вспомогательный метод для нахождения левого среднего прямоугольника
        /// </summary>
        /// <param name="points">Начальные точки</param>
        /// <param name="width">Ширина деленная на 3 от начального прямоугольника</param>
        /// <param name="height">Высота деленная на 3 от начального прямоугольника</param>
        /// <returns>Точки левого среднего прямоугольника</returns>
        private PointCollection LeftMiddle(PointCollection points, double width, double height)
        {
            PointCollection points21 = new(4);
            points21.Add(new System.Windows.Point(points[0].X, points[0].Y + height));
            points21.Add(new System.Windows.Point(points[1].X - 2 * width, points[1].Y + height));
            points21.Add(new System.Windows.Point(points[2].X - 2 * width, points[2].Y - height));
            points21.Add(new System.Windows.Point(points[3].X, points[3].Y - height));
            return points21;
        }

        /// <summary>
        /// Вспомогательный метод для нахождения средедины прямоугольника
        /// </summary>
        /// <param name="points">Начальные точки</param>
        /// <param name="width">Ширина деленная на 3 от начального прямоугольника</param>
        /// <param name="height">Высота деленная на 3 от начального прямоугольника</param>
        /// <returns>Точки средины прямоугольника</returns>
        private PointCollection MiddleMiddle(PointCollection points, double width, double height)
        {
            PointCollection points22 = new(4);
            points22.Add(new System.Windows.Point(points[0].X + width, points[0].Y + height));
            points22.Add(new System.Windows.Point(points[1].X - width, points[1].Y + height));
            points22.Add(new System.Windows.Point(points[2].X - width, points[2].Y - height));
            points22.Add(new System.Windows.Point(points[3].X + width, points[3].Y - height));
            return points22;
        }

        /// <summary>
        /// Вспомогательный метод для нахождения правого среднего прямоугольника
        /// </summary>
        /// <param name="points">Начальные точки</param>
        /// <param name="width">Ширина деленная на 3 от начального прямоугольника</param>
        /// <param name="height">Высота деленная на 3 от начального прямоугольника</param>
        /// <returns>Точки правого среднего прямоугольника</returns>
        private PointCollection RightMiddle(PointCollection points, double width, double height)
        {
            PointCollection points23 = new(4);
            points23.Add(new System.Windows.Point(points[0].X + 2 * width, points[0].Y + height));
            points23.Add(new System.Windows.Point(points[1].X, points[1].Y + height));
            points23.Add(new System.Windows.Point(points[2].X, points[2].Y - height));
            points23.Add(new System.Windows.Point(points[3].X + 2 * width, points[3].Y - height));
            return points23;
        }

        /// <summary>
        /// Вспомогательный метод для нахождения левого нижнего прямоугольника
        /// </summary>
        /// <param name="points">Начальные точки</param>
        /// <param name="width">Ширина деленная на 3 от начального прямоугольника</param>
        /// <param name="height">Высота деленная на 3 от начального прямоугольника</param>
        /// <returns>Точки левого нижнего прямоугольника</returns>
        private PointCollection LeftDown(PointCollection points, double width, double height)
        {
            PointCollection points31 = new(4);
            points31.Add(new System.Windows.Point(points[0].X, points[0].Y + 2 * height));
            points31.Add(new System.Windows.Point(points[1].X - 2 * width, points[1].Y + 2 * height));
            points31.Add(new System.Windows.Point(points[2].X - 2 * width, points[2].Y));
            points31.Add(new System.Windows.Point(points[3].X, points[3].Y));
            return points31;
        }

        /// <summary>
        /// Вспомогательный метод для нахождения среднего нижнего прямоугольника
        /// </summary>
        /// <param name="points">Начальные точки</param>
        /// <param name="width">Ширина деленная на 3 от начального прямоугольника</param>
        /// <param name="height">Высота деленная на 3 от начального прямоугольника</param>
        /// <returns>Точки среднего нижнего прямоугольника</returns>
        private PointCollection MiddleDown(PointCollection points, double width, double height)
        {
            PointCollection points32 = new(4);
            points32.Add(new System.Windows.Point(points[0].X + width, points[0].Y + 2 * height));
            points32.Add(new System.Windows.Point(points[1].X - width, points[1].Y + 2 * height));
            points32.Add(new System.Windows.Point(points[2].X - width, points[2].Y));
            points32.Add(new System.Windows.Point(points[3].X + width, points[3].Y));
            return points32;
        }

        /// <summary>
        /// Вспомогательный метод для нахождения правого нижнего прямоугольника
        /// </summary>
        /// <param name="points">Начальные точки</param>
        /// <param name="width">Ширина деленная на 3 от начального прямоугольника</param>
        /// <param name="height">Высота деленная на 3 от начального прямоугольника</param>
        /// <returns>Точки правого нижнего прямоугольника</returns>
        private PointCollection RightDown(PointCollection points, double width, double height)
        {
            PointCollection points33 = new(4);
            points33.Add(new System.Windows.Point(points[0].X + 2 * width, points[0].Y + 2 * height));
            points33.Add(new System.Windows.Point(points[1].X, points[1].Y + 2 * height));
            points33.Add(new System.Windows.Point(points[2].X, points[2].Y));
            points33.Add(new System.Windows.Point(points[3].X + 2 * width, points[3].Y));
            return points33;
        }
        #endregion
    }
}
