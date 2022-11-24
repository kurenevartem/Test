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

namespace TestApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Otm_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            client.Owner = this;
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Password.Trim();
            User authUser = null;
            using (ApplicationContext DB = new ApplicationContext())
            {
                authUser = DB.Users.Where(b => b.login == login && b.password == password).FirstOrDefault();
            }

            if (authUser != null)
            {
                client.Show();
                Hide();
            }
            else
                MessageBox.Show("Введен неверный логин или пароль!");
        }
    }
}
