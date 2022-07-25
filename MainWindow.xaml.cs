using System;
using System.ComponentModel;
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
using deals_app.data;
using deals_app.Services;

namespace deals_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string path = $"{Environment.CurrentDirectory}\\todo_datalist.json";
        private BindingList<todo_model> todo_date_list; //создали список
        private File_in_out io_serv;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            io_serv = new File_in_out(path);
            try
            {
                todo_date_list = io_serv.Load_date();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            dgTodoList.ItemsSource = todo_date_list;
            todo_date_list.ListChanged += todo_date_list_Changed;
            // при обновлении списка вызывается событие
            //которое необходимо нам для записи
        }

        private void todo_date_list_Changed(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    io_serv.Save_date(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
            
        }
    }
}
