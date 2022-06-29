using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ClassFractal.Fractals;
using Microsoft.Win32;

namespace Fractals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Fractal fractal;

        Point? lastCenterPositionOnTarget;
        Point? lastMousePositionOnTarget;
        Point? lastDragPoint;

        private bool isPressedPaint = false;

        /// <summary>
        /// Конструктор создания окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Height = SystemParameters.PrimaryScreenHeight * 0.5;
            Width = SystemParameters.PrimaryScreenWidth * 0.5;
            MinHeight = SystemParameters.PrimaryScreenHeight * 0.5;
            MinWidth = SystemParameters.PrimaryScreenWidth * 0.5;
            MaxHeight = SystemParameters.PrimaryScreenHeight;
            MaxWidth = SystemParameters.PrimaryScreenWidth;

            scrollViewer.ScrollChanged += OnScrollViewerScrollChanged;
            scrollViewer.MouseLeftButtonUp += OnMouseLeftButtonUp;
            scrollViewer.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp;
            scrollViewer.PreviewMouseWheel += OnPreviewMouseWheel;

            scrollViewer.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
            scrollViewer.MouseMove += OnMouseMove;

            slider.ValueChanged += OnSliderValueChanged;
        }

        /// <summary>
        /// Обработчик события завершения загрузки окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            paintButton.Click += Button_Click;
        }


        /// <summary>
        /// Обработчик события нажатия на кнопку нарисовать.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = int.TryParse(depthFractal.Text, out int depth);
            _ = double.TryParse(angleTreeLeft.Text, out double angleLeft);
            _ = double.TryParse(angleTreeRight.Text, out double angleRight);
            _ = double.TryParse(lengthTree.Text, out double len);
            _ = double.TryParse(ratioTree.Text, out double ratio);
            _ = double.TryParse(lengthSet.Text, out double lenSet);
            var startPick = startColorPicker.SelectedColor;
            var endPick = endColorPicker.SelectedColor;
            var carpetPick = backCarpetColorPicker.SelectedColor;
            System.Drawing.Color start = System.Drawing.Color.FromArgb(startPick.A, startPick.R, startPick.G, startPick.B);
            System.Drawing.Color end = System.Drawing.Color.FromArgb(endPick.A, endPick.R, endPick.G, endPick.B);
            System.Drawing.Color carpetColor = System.Drawing.Color.FromArgb(carpetPick.A, carpetPick.R, carpetPick.G, carpetPick.B);
            if (fractalName.SelectedIndex != -1 && IsAllPropertiesOkey())
            {
                mainCanvas.Children.Clear();
                fractal = fractalName.Text switch
                {
                    "Фрактальное дерево" => new FractalTree(depth, angleLeft, angleRight, len, ratio, start, end, mainCanvas),
                    "Кривая Коха" => new KochCurve(depth, start, end, mainCanvas),
                    "Ковер Серпинского" => new SerpinskyCarpet(depth, start, end, carpetColor, mainCanvas),
                    "Треугольник Серпинского" => new SerpinskyTriangle(depth, start, end, mainCanvas),
                    "Множество Кантора" => new CantorSet(depth, ratio, lenSet, start, end, mainCanvas),
                    _ => throw new NotImplementedException()
                };
                fractal.DrawFractal();
                isPressedPaint = true;

            }
            else
            {
                MessageBox.Show("Проверьте правильность заполнение полей.",
                "Неправильно заполнены поля.",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            }
        }


        /// <summary>
        /// Вспомогательный метод для определения  все ли поля введены правильно.
        /// </summary>
        /// <returns></returns>
        private bool IsAllPropertiesOkey()
        {
            return int.TryParse(depthFractal.Text, out int depth) && depth > 0 && depth < fractal.maxFractalDepth && (fractalName.SelectedIndex) switch
            {
                0 => IsTreePropertiesOkey(),
                1 => true,
                2 => true,
                3 => true,
                4 => IsSetPropertiesOkey(),
                _ => false
            };
        }


        /// <summary>
        /// Вспомогательный метод для определения правильность заполнения полей для дерева.
        /// </summary>
        /// <returns></returns>
        private bool IsTreePropertiesOkey()
        {
            return
                double.TryParse(lengthTree.Text, out double len) && double.TryParse(angleTreeLeft.Text, out double angleLeft) &&
                double.TryParse(angleTreeRight.Text, out double angleRight) && double.TryParse(ratioTree.Text, out double ratio) &&
                len > 0 && angleLeft > 0 && angleRight > 0 && ratio > 0;
        }


        /// <summary>
        /// Вспомогательный метод для определения правильности заполнения полей для Множества.
        /// </summary>
        /// <returns></returns>
        private bool IsSetPropertiesOkey()
        {
            return double.TryParse(ratioTree.Text, out double ratio) && ratio > 0;
        }


        /// <summary>
        /// Обработчик события для ComboBox при изменении выделения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fractalName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    fractal = new FractalTree();
                    DisableVisibilityForCarpet();
                    DisableVisibilityForSet();
                    EnableVisibilityForTree();
                    break;
                case 1:
                    fractal = new KochCurve();
                    DisableVisibilityForCarpet();
                    DisableVisibilityForTree();
                    DisableVisibilityForSet();
                    break;
                case 2:
                    fractal = new SerpinskyCarpet();
                    DisableVisibilityForTree();
                    DisableVisibilityForSet();
                    EnableVisibilityForCarpet();
                    break;
                case 3:
                    fractal = new SerpinskyTriangle();
                    DisableVisibilityForCarpet();
                    DisableVisibilityForTree();
                    DisableVisibilityForSet();
                    break;
                case 4:
                    fractal = new CantorSet();
                    DisableVisibilityForCarpet();
                    DisableVisibilityForTree();
                    EnableVisibilityForSet();
                    break;
            }
        }


        /// <summary>
        /// Вспомогательный метод для отображения полей для Дерева.
        /// </summary>
        private void EnableVisibilityForTree()
        {
            angleLabelLeft.Visibility = Visibility.Visible;
            borderTreeAngleLeft.Visibility = Visibility.Visible;
            angleLabelRight.Visibility = Visibility.Visible;
            borderTreeAngleRight.Visibility = Visibility.Visible;
            lengthLabel.Visibility = Visibility.Visible;
            borderTreeLen.Visibility = Visibility.Visible;
            ratioLabel.Visibility = Visibility.Visible;
            borderTreeRatio.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Вспомогательный метод для отображения полей для Ковра.
        /// </summary>
        private void EnableVisibilityForCarpet()
        {
            backCarpetColorPicker.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Вспомогательный метод для отображения полей для Множества.
        /// </summary>
        private void EnableVisibilityForSet()
        {
            ratioSetLabel.Visibility = Visibility.Visible;
            borderTreeRatio.Visibility = Visibility.Visible;
            setLengthLabel.Visibility = Visibility.Visible;
            borderSetLength.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Вспомогательный метод для скрытия полей для Дерева.
        /// </summary>
        private void DisableVisibilityForTree()
        {
            angleLabelLeft.Visibility = Visibility.Collapsed;
            borderTreeAngleLeft.Visibility = Visibility.Collapsed;
            angleLabelRight.Visibility = Visibility.Collapsed;
            borderTreeAngleRight.Visibility = Visibility.Collapsed;
            lengthLabel.Visibility = Visibility.Collapsed;
            borderTreeLen.Visibility = Visibility.Collapsed;
            ratioLabel.Visibility = Visibility.Collapsed;
            borderTreeRatio.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Вспомогательный метод для скрытия полей для Ковра.
        /// </summary>
        private void DisableVisibilityForCarpet()
        {
            backCarpetColorPicker.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Вспомогательный метод для скрытия полей для Множества.
        /// </summary>
        private void DisableVisibilityForSet()
        {
            ratioSetLabel.Visibility = Visibility.Collapsed;
            borderTreeRatio.Visibility = Visibility.Collapsed;
            setLengthLabel.Visibility = Visibility.Collapsed;
            borderSetLength.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Проверка на ввод букв в поле глубины прорисовки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depthFractal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out int i))
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// Проверка на правильность введенной глубины прорисовки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depthFractal_TextChanged(object sender, TextChangedEventArgs e)
        {
            isPressedPaint = false;
            TextBox text = (TextBox)sender;
            int.TryParse(text.Text, out int i);
            if (i >= (fractal == null ? 0 : fractal.maxFractalDepth))
            {
                borderTextDepth.BorderBrush = Brushes.Red;
                borderTextDepth.BorderThickness = new Thickness(1);
            }
            else
            {
                borderTextDepth.BorderBrush = Brushes.Black;
                borderTextDepth.BorderThickness = new Thickness(0);
            }
        }

        /// <summary>
        /// Проверка на ввод букв в поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeProperties_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!double.TryParse(e.Text, out double i))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// проверка на правильность введенной длины отрезка для дерева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lengthTree_TextChanged(object sender, TextChangedEventArgs e)
        {
            isPressedPaint = false;
            if (!double.TryParse(((TextBox)sender).Text, out double angle) || angle <= 0)
            {
                borderTreeLen.BorderBrush = Brushes.Red;
                borderTreeLen.BorderThickness = new Thickness(1);
            }
            else
            {
                borderTreeLen.BorderThickness = new Thickness(0);
            }
        }

        /// <summary>
        /// Проверка на правильность введенного угла для левого отрезка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void angleTreeLeft_TextChanged(object sender, TextChangedEventArgs e)
        {
            isPressedPaint = false;
            if (!double.TryParse(((TextBox)sender).Text, out double angle) || angle <= 0)
            {
                borderTreeAngleLeft.BorderBrush = Brushes.Red;
                borderTreeAngleLeft.BorderThickness = new Thickness(1);
            }
            else
            {
                borderTreeAngleLeft.BorderThickness = new Thickness(0);
            }
        }

        /// <summary>
        /// Проверка на правильность введенного угла для правого отрезка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void angleTreeRight_TextChanged(object sender, TextChangedEventArgs e)
        {
            isPressedPaint = false;
            if (!double.TryParse(((TextBox)sender).Text, out double angle) || angle <= 0)
            {
                borderTreeAngleRight.BorderBrush = Brushes.Red;
                borderTreeAngleRight.BorderThickness = new Thickness(1);
            }
            else
            {
                borderTreeAngleRight.BorderThickness = new Thickness(0);
            }
        }

        /// <summary>
        /// Проверка на правильность введенного коэффициента для следующего отрезка в дереве
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ratioTree_TextChanged(object sender, TextChangedEventArgs e)
        {
            isPressedPaint = false;
            if (!double.TryParse(((TextBox)sender).Text, out double ratio) || ratio <= 0)
            {
                borderTreeRatio.BorderBrush = Brushes.Red;
                borderTreeRatio.BorderThickness = new Thickness(1);
            }
            else
            {
                borderTreeRatio.BorderThickness = new Thickness(0);
            }
        }

        /// <summary>
        /// Проверка на правильность ввода символов в поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lengthSet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!double.TryParse(e.Text, out double _))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Проверка на правильность заполнения поля.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lengthSet_TextChanged(object sender, TextChangedEventArgs e)
        {
            isPressedPaint = false;
            if (!double.TryParse(((TextBox)sender).Text, out double angle) || angle <= 0)
            {
                borderSetLength.BorderBrush = Brushes.Red;
                borderSetLength.BorderThickness = new Thickness(1);
            }
            else
            {
                borderSetLength.BorderThickness = new Thickness(0);
            }
        }

        /// <summary>
        /// Обработчик события перемещения мышкой с нажатой левой кнопкой.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer);

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - dX);
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - dY);
            }
        }

        /// <summary>
        /// Обработчик события нажатия левой кнопки мыши.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(scrollViewer);
            if (mousePos.X <= scrollViewer.ViewportWidth && mousePos.Y <
                scrollViewer.ViewportHeight) //make sure we still can use the scrollbars
            {
                scrollViewer.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(scrollViewer);
            }
        }

        /// <summary>
        /// Обработчик события на колесико мыши.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            lastMousePositionOnTarget = Mouse.GetPosition(mainCanvas);

            if (e.Delta > 0)
            {
                slider.Value += 1;
            }
            if (e.Delta < 0)
            {
                slider.Value -= 1;
            }

            e.Handled = true;
        }

        /// <summary>
        /// Обработчик события отпуска левой кнопки мыши.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            scrollViewer.Cursor = Cursors.Arrow;
            scrollViewer.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        /// <summary>
        /// Обработчик события на изменения значения слайдера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSliderValueChanged(object sender,
             RoutedPropertyChangedEventArgs<double> e)
        {
            scaleTransform.ScaleX = e.NewValue;
            scaleTransform.ScaleY = e.NewValue;

            var centerOfViewport = new Point(scrollViewer.ViewportWidth / 2,
                                             scrollViewer.ViewportHeight / 2);
            lastCenterPositionOnTarget = scrollViewer.TranslatePoint(centerOfViewport, mainCanvas);
        }

        /// <summary>
        /// Обработчик события изменения слайдера ScrollView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnScrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
                        var centerOfViewport = new Point(scrollViewer.ViewportWidth / 2,
                                                         scrollViewer.ViewportHeight / 2);
                        Point centerOfTargetNow =
                              scrollViewer.TranslatePoint(centerOfViewport, mainCanvas);

                        targetBefore = lastCenterPositionOnTarget;
                        targetNow = centerOfTargetNow;
                    }
                }
                else
                {
                    targetBefore = lastMousePositionOnTarget;
                    targetNow = Mouse.GetPosition(mainCanvas);

                    lastMousePositionOnTarget = null;
                }

                if (targetBefore.HasValue)
                {
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / mainCanvas.Width;
                    double multiplicatorY = e.ExtentHeight / mainCanvas.Height;

                    double newOffsetX = scrollViewer.HorizontalOffset -
                                        dXInTargetPixels * multiplicatorX;
                    double newOffsetY = scrollViewer.VerticalOffset -
                                        dYInTargetPixels * multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    scrollViewer.ScrollToHorizontalOffset(newOffsetX);
                    scrollViewer.ScrollToVerticalOffset(newOffsetY);
                }
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки сохранить как изображение.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsPng_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)mainCanvas.RenderSize.Width,
            (int)mainCanvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(mainCanvas);

            var crop = new CroppedBitmap(rtb, new Int32Rect(0, 0, (int)mainCanvas.ActualWidth, (int)mainCanvas.ActualHeight));

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(crop));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Png файл (*.png)|*.png|Jpg файл (*.jpg)|*.jpg";
            string filePath;
            if (saveFileDialog.ShowDialog() == true)
                filePath = saveFileDialog.FileName;
            else
                return;

            using (var fs = System.IO.File.OpenWrite(filePath))
            {
                pngEncoder.Save(fs);
            }
        }

        /// <summary>
        /// Обработчик события изменения размера окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (isPressedPaint)
            {
                await Task.Delay(500);
                mainCanvas.Children.Clear();
                fractal.DrawFractal();
            }
        }

    }
}
