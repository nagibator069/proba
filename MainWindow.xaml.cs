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

namespace trr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //scaffold-dbContext "Port=3306;Database=ISPr23-35_PetryakovaDS_school;Password=ISPr23-35_PetryakovaDS;User ID=ISPr23-35_PetryakovaDS;Character Set=utf8;Server=cfif31.ru" Pomelo.EntityFrameworkCore.MySql
        }

        private void Autor_Click(object sender, RoutedEventArgs e)
        {
            Avtorizaciya user = CoreModel.init().Avtorizaciyas.FirstOrDefault(p => p.Login == LoginTB.Text && p.Password == PassTB.Text);
            if (user != null)
            {
                if (user.Role != null)
                {
                    if (user.Role == "1")
                    {
                        Admin form1 = new Admin();
                        form1.Show();
                        this.Hide();
                    }
                    else if (user.Role == "3")
                    {
                        User form = new User();
                        form.Background = Brushes.Gray;
                        form.Show();
                        this.Hide();
                    }
                }
            }
        }

    }
}
