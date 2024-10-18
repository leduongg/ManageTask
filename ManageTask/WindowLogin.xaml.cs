
using ToDoListProject.Models;
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
using ToDoListProject;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private int role;
        public static class Session
        {
            public static int mId { get; set; }

        }
        public WindowLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            using var context = new ToDoListProjectContext();
            var mb = context.Members.SingleOrDefault(m => m.Email == txtUsername.Text && m.Password == txtPassword.Password);

            if (mb != null)
            {
                role = Login(txtUsername.Text, txtPassword.Password);
                if (role == 1)
                {
                    MessageBox.Show("Hello User");
                    Session.mId = mb.MemberId;
                    MainWindow wp = new MainWindow();
                    wp.SetUserRole(role);
                    this.Hide();
                    wp.ShowDialog();
                    this.Close();
                }
                else if (role == 0)
                {
                    MessageBox.Show("Hello Admin");
                    Session.mId = mb.MemberId;
                    MainWindow wp = new MainWindow();
                    wp.SetUserRole(role);
                    this.Hide();
                    wp.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong");
                }
            }
            else
            {
                MessageBox.Show("Username and password do not match any records.");
            }
        }

        public int Login(string userName, string password)
        {
            try
            {
                using var context = new ToDoListProjectContext();
                var member = context.Members.SingleOrDefault(m => m.Email == userName && m.Password == password);

                if (member != null)
                {
                    if (member.Email == "admin@fpt.com" && member.Password == "admin")
                    {
                        return 0; // Admin
                    }
                    else
                    {
                        return 1; // User
                    }
                }
                else
                {
                    return -1; // Invalid credentials
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}