﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58398EFE270838DF3CCC28BCCB9E8DA7DDAB1BCC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Fractals;
using Haley.Abstractions;
using Haley.Enums;
using Haley.Events;
using Haley.MVVM;
using Haley.MVVM.Converters;
using Haley.Models;
using Haley.Utils;
using Haley.WPF;
using Haley.WPF.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Fractals {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem SaveAsImage;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox fractalName;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Tree;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Curve;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Carpet;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Traingle;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Set;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderTextDepth;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox depthFractal;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lengthLabel;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderTreeLen;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lengthTree;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label angleLabelLeft;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderTreeAngleLeft;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox angleTreeLeft;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label angleLabelRight;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderTreeAngleRight;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox angleTreeRight;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ratioLabel;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ratioSetLabel;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderTreeRatio;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ratioTree;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label setLengthLabel;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderSetLength;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lengthSet;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Haley.WPF.Controls.ColorPickerButton startColorPicker;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Haley.WPF.Controls.ColorPickerButton endColorPicker;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Haley.WPF.Controls.ColorPickerButton backCarpetColorPicker;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Haley.WPF.Controls.ColorPickerButton backColorPicker;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button paintButton;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrollViewer;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas mainCanvas;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ScaleTransform scaleTransform;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Fractals;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\MainWindow.xaml"
            ((Fractals.MainWindow)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\MainWindow.xaml"
            ((Fractals.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SaveAsImage = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\MainWindow.xaml"
            this.SaveAsImage.Click += new System.Windows.RoutedEventHandler(this.SaveAsPng_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.fractalName = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\..\MainWindow.xaml"
            this.fractalName.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.fractalName_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Tree = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 5:
            this.Curve = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 6:
            this.Carpet = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 7:
            this.Traingle = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 8:
            this.Set = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 9:
            this.borderTextDepth = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            this.depthFractal = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\MainWindow.xaml"
            this.depthFractal.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.depthFractal_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\MainWindow.xaml"
            this.depthFractal.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.depthFractal_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.lengthLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.borderTreeLen = ((System.Windows.Controls.Border)(target));
            return;
            case 13:
            this.lengthTree = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\..\MainWindow.xaml"
            this.lengthTree.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.lengthTree_TextChanged);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\MainWindow.xaml"
            this.lengthTree.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TreeProperties_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 14:
            this.angleLabelLeft = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.borderTreeAngleLeft = ((System.Windows.Controls.Border)(target));
            return;
            case 16:
            this.angleTreeLeft = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\MainWindow.xaml"
            this.angleTreeLeft.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.angleTreeLeft_TextChanged);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\MainWindow.xaml"
            this.angleTreeLeft.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TreeProperties_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 17:
            this.angleLabelRight = ((System.Windows.Controls.Label)(target));
            return;
            case 18:
            this.borderTreeAngleRight = ((System.Windows.Controls.Border)(target));
            return;
            case 19:
            this.angleTreeRight = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\..\MainWindow.xaml"
            this.angleTreeRight.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.angleTreeRight_TextChanged);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\MainWindow.xaml"
            this.angleTreeRight.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TreeProperties_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 20:
            this.ratioLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 21:
            this.ratioSetLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 22:
            this.borderTreeRatio = ((System.Windows.Controls.Border)(target));
            return;
            case 23:
            this.ratioTree = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\..\MainWindow.xaml"
            this.ratioTree.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ratioTree_TextChanged);
            
            #line default
            #line hidden
            return;
            case 24:
            this.setLengthLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 25:
            this.borderSetLength = ((System.Windows.Controls.Border)(target));
            return;
            case 26:
            this.lengthSet = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\MainWindow.xaml"
            this.lengthSet.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.lengthSet_TextChanged);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\MainWindow.xaml"
            this.lengthSet.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.lengthSet_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 27:
            this.startColorPicker = ((Haley.WPF.Controls.ColorPickerButton)(target));
            return;
            case 28:
            this.endColorPicker = ((Haley.WPF.Controls.ColorPickerButton)(target));
            return;
            case 29:
            this.backCarpetColorPicker = ((Haley.WPF.Controls.ColorPickerButton)(target));
            return;
            case 30:
            this.backColorPicker = ((Haley.WPF.Controls.ColorPickerButton)(target));
            return;
            case 31:
            this.paintButton = ((System.Windows.Controls.Button)(target));
            return;
            case 32:
            this.slider = ((System.Windows.Controls.Slider)(target));
            return;
            case 33:
            this.scrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 34:
            this.mainCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 35:
            this.scaleTransform = ((System.Windows.Media.ScaleTransform)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

