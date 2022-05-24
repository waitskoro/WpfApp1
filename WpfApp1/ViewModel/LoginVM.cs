using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
            }
        }

        private RelayCommand? loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(o =>
                {
                    PasswordBox? pb = o as PasswordBox;
                    string pass = pb.Password;
                    User? LoginNPass = ServiceDb.db.Users.FirstOrDefault(p => p.Login == Login && p.Password == pass);

                    if (LoginNPass != null)
                    {
                        ServiceDb.userSession = LoginNPass;
                        new View.MenuV().Show();
                        
                        foreach (Window item in Application.Current.Windows)
                        {
                            if (item.DataContext == this) item.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("error");
                    }
                }));
            }
        }
        private RelayCommand? registrationCommand;
        public RelayCommand RegistrationCommand
        {
            get
            {
                return registrationCommand ?? (registrationCommand = new RelayCommand(o =>
                {
                    new View.Registartion().Show();
                }));
            }
        }


    }
}