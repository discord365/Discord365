﻿using Discord.WebSocket;
using System;
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

namespace Discord365.UI.User.MessagesPage.Message
{
    /// <summary>
    /// Interaction logic for MessageHeader.xaml
    /// </summary>
    public partial class MessageHeader : UserControl
    {
        public MessageHeader()
        {
            InitializeComponent();
        }

        public SocketUser RelatedUser
        {
            set
            {
                Avatar.RelatedUser = value;
                User.RelatedUser = value;
            }
        }
    }
}
