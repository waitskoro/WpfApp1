using System.Linq;
using System.Windows;

namespace WpfApp1.ViewModel
{
    public class RegistrationVM : BaseViewModel
    {
        private string? namePerson;
        public string NamePerson
        {
            get { return namePerson; }
            set { namePerson = value;}
        }

        private string? surnamePerson;
        public string SurnamePerson
        {
            get { return surnamePerson; }
            set { surnamePerson = value; }
        }

        private string? patronymicPerson;
        public string PatronymicPerson
        {
            get { return patronymicPerson;}
            set { patronymicPerson = value;}
        }

        private string? loginPerson;
        public string LoginPerson
        {
            get { return loginPerson; }
            set { loginPerson = value; }
        }

        private string? passwordPerson;
        public string PasswordPerson
        {
            get { return passwordPerson; }
            set { passwordPerson = value; }
        }

        private string? numberPhonePerson;
        public string NumberPhonePerson
        {
            get { return numberPhonePerson; }
            set { numberPhonePerson = value; }
        }

        private RelayCommand? registrationPersonCommand;
        public RelayCommand RegistrationPersonCommand
        {
            get
            {
                return registrationPersonCommand ?? (registrationPersonCommand = new RelayCommand(o =>
                {
                    if(NamePerson != null && SurnamePerson != null && LoginPerson != null && PasswordPerson != null && NumberPhonePerson != null)
                    {
                        var linq = ServiceDb.db.Users.FirstOrDefault(d=>d.Login == LoginPerson);
                        if(linq == null)
                        {
                            User user = new()
                            {
                                Name = NamePerson,
                                Surname = SurnamePerson,
                                Patronymic = PasswordPerson,
                                Login = LoginPerson,
                                Password = PasswordPerson,
                                numberPhone = NumberPhonePerson
                            };

                            ServiceDb.db.Users.Add(user);
                            ServiceDb.db.SaveChanges();
                            MessageBox.Show("Успешная регистрация");
                            foreach (Window item in Application.Current.Windows)
                            {
                                if (item.DataContext == this) item.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Логин {LoginPerson.ToString()} занят");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Поля пустые");
                    }
                    

                }));
            }
        }
    }
}
