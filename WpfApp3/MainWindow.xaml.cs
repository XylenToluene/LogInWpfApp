using Microsoft.EntityFrameworkCore;
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
using WpfApp3.DB;
using WpfApp3.MyForms;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Поиск юзера в базе данных и отпрытие соответсвующих окон
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btLogIn_Click(object sender, RoutedEventArgs e)
        {
            MyContext Db = new MyContext();

            try
            {
                var user = Db.Users.Include(x=>x.Status).Single(x => x.Login == tbLogin.Text
            && x.Password == tbPassword.Password.ToString());

                switch (user.Status.StatusName)
                {
                    case "User":
                        {
                            MessageBox.Show("Вы вошли как User");
                            UserWindow userWindow = new UserWindow();
                            userWindow.Show();
                            Close();
                            return;
                        }
                    case "Manager":
                        {
                            MessageBox.Show("Вы вошли как Manager");
                            ManagerWindow managerWindow = new ManagerWindow();
                            managerWindow.Show();
                            Close();
                            return;
                        }
                    case "Admin":
                        {
                            MessageBox.Show("Вы вошли как Admin");
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                            Close();
                            return;
                        }
                    
                }

                if(user == null)
                {
                    MessageBox.Show("Пользователь не найден");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// осуществление входа в режиме гостя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btLogInGuest_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow guestWindow = new GuestWindow();
            guestWindow.Show();
            Close();
        }
    }
}
