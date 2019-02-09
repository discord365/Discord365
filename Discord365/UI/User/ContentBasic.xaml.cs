﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Discord365.UI.User
{
    /// <summary>
    /// Interaction logic for ContentBasic.xaml
    /// </summary>
    public partial class ContentBasic : UserControl
    {
        public ContentBasic()
        {
            InitializeComponent();
        }
        public void Set(UIElement header, UIElement content)
        {
            SetHeader(header);
            SetContent(content);
        }

        public void SetHeader(UIElement header)
        {
            GridHeader.Children.Clear();

            if(header != null)
                GridHeader.Children.Add(header);
        }

        public void SetContent(UIElement content)
        {
            GridContent.Children.Clear();
            
            if(content != null)
                GridContent.Children.Add(content);
        }
    }
}
