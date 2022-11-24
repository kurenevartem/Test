using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using ControlzEx.Standard;

namespace TestApp1
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        ApplicationContext db;

        string dateTime = null;
        string description = null;
        int x = default;
        int y = default;

        public Client()
        {
            InitializeComponent();
            db = new ApplicationContext();
            List<DataDBs> dataDB = db.DataDBs.ToList();

            GridDataDB.ItemsSource = dataDB;
            TextBoxCounter.Text = "Колличество записей: " + dataDB.Count.ToString();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(GridDataDB.ItemsSource);
            view.Filter = DescriptionFilter;
            view.Filter = DateTimeFilter;
        }

        // Фильтрация
        private bool DescriptionFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return  (item as DataDBs).description.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool DateTimeFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return (item as DataDBs).dateTime.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(GridDataDB.ItemsSource).Refresh();
        }

        // Включение-выключение записи
        static bool fn_enable = false;
        private void Button_StartStop_Click(object sender, RoutedEventArgs e)
        {
            if (fn_enable == true)
            {
                System.Windows.MessageBox.Show("Запись остановлена");
                fn_enable = false;
            }
            else
            {
                System.Windows.MessageBox.Show("Запись началась");
                fn_enable = true;
            }
        }

        // Методы для событий мышки
        public void Grid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            int _X = (int)p.X;
            int _Y = (int)p.Y;

            if (fn_enable == true)
            {
                 if ((x + 10) == _X | (y + 10) == _Y | (x - 10) == _X | (y - 10) == _Y)
                {
                    dateTime = DateTime.Now.ToString();
                    description = "сдвиг курсора";
                    x = (int)p.X;
                    y = (int)p.Y;
                    DataDBs data = new DataDBs(dateTime, description, x, y);
                    db.DataDBs.Add(data);
                    db.SaveChanges();
                }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (fn_enable == true)
            {
                switch (e.ChangedButton)
                {
                    case MouseButton.Left:
                        dateTime = DateTime.Now.ToString();
                        description = "нажата левая кнопка мыши";
                        Point p = e.GetPosition(this);
                        x = (int)p.X;
                        y = (int)p.Y;
                        break;

                    case MouseButton.Middle:
                        dateTime = DateTime.Now.ToString();
                        description = "нажата средняя кнопка мыши";
                        p = e.GetPosition(this);
                        x = (int)p.X;
                        y = (int)p.Y;

                        break;
                    case MouseButton.Right:
                        dateTime = DateTime.Now.ToString();
                        description = "нажата правая кнопка мыши";
                        p = e.GetPosition(this);
                        x = (int)p.X;
                        y = (int)p.Y;

                        break;
                }
                DataDBs data = new DataDBs(dateTime, description, x, y);
                db.DataDBs.Add(data);
                db.SaveChanges();
            }
        }
    }
}
