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

namespace Discord365.UI.User.MessagesPage
{
    /// <summary>
    /// Interaction logic for MessagesPageHeader.xaml
    /// </summary>
    public partial class MessagesPageHeader : UserControl
    {
        public MessagesPageHeader()
        {
            InitializeComponent();
        }

        public string Title { get => tbChannelName.Text; set => tbChannelName.Text = value; }
    }
}
