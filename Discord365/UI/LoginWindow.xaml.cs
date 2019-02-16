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
using System.Windows.Shapes;
using static Discord365.UI.Extensions;

namespace Discord365.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        public LoginWindow()
        {
            App.LoginWnd = this;

            InitializeComponent();

            MainGrid.Opacity = 0;
            GridBackground.Opacity = 0;

            SetError("");
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string token = tbToken.Password;

            App.MainWnd = new MainClientWnd();

            Discord.TokenType type = Discord.TokenType.Bot;

            if ((bool)rUser.IsChecked)
                type = Discord.TokenType.User;

            if ((bool)cbRememberMe.IsChecked)
            {
                Properties.Settings.Default.TokenType = type;
                Properties.Settings.Default.Save();

                DiscordTokenManager.SavedToken = token;
            }
            else
            {
                Properties.Settings.Default.TokenType = Discord.TokenType.Bot;
                Properties.Settings.Default.Save();

                DiscordTokenManager.SavedToken = "";
            }

            App.MainWnd.StartConnection(token, type);

            App.AppWnd.CurrentScreen = AppWindow._Screens.Main;
        }

        public void SetError(string text)
        {
            tbError.Text = text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TokenCheck();
        }

        private void TokenCheck()
        {
            string token = DiscordTokenManager.SavedToken;

            if (token != null && token.Length >= 1)
            {
                cbRememberMe.IsChecked = true;

                tbToken.Password = token;

                var type = Properties.Settings.Default.TokenType;

                if (type == Discord.TokenType.Bot)
                    rBot.IsChecked = true;
                else if (type == Discord.TokenType.User)
                    rUser.IsChecked = true;

                App.AppWnd.ForceScreen(AppWindow._Screens.Main);
                App.AppWnd.LoginGrid.Visibility = Visibility.Hidden;
                App.AppWnd.MainGrid.Visibility = Visibility.Visible;
                App.AppWnd.MainGrid.Opacity = 1;
                App.MainWnd = new MainClientWnd();
                App.AppWnd.MainGrid.Children.Clear();
                App.AppWnd.MainGrid.Children.Add(App.MainWnd);
                App.MainWnd.StartConnection(token, type);
                //BtnLogin_Click(null, null);
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(this.Visibility == Visibility.Hidden || this.Visibility == Visibility.Collapsed)
            {
                MainGrid.Opacity = 0;
                GridBackground.Opacity = 0;
            }

            if (this.Visibility == Visibility.Visible)
            {
                MainGrid.FadeIn(750);
                App.AppWnd.WindowTitle = "Authorization";
                //Shadows.FadeIn(250);
                //LoginContent.FadeIn(250);

                GridBackground.FadeIn(4000, 751);
            }
        }
    }
}
