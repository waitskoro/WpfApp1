using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.ViewModel
{
    public class MenuVM
    {
        private RelayCommand? profile;
        private RelayCommand? users;
        private RelayCommand? tasks;
        public RelayCommand? Profile
        {
            get
            {
                return profile ?? (profile = new RelayCommand(o =>
                {
                    MessageBox.Show($"Имя: {ServiceDb.userSession.Name}" + Environment.NewLine +
                        $"Фамилия: {ServiceDb.userSession.Surname}" + Environment.NewLine +
                        $"Отчество: {ServiceDb.userSession.Patronymic}" + Environment.NewLine +
                        $"Логин: {ServiceDb.userSession.Login}" + Environment.NewLine +
                        $"Пароль:{ServiceDb.userSession.Password}" + Environment.NewLine +
                        $"НомерТелефона: {ServiceDb.userSession.numberPhone}" + Environment.NewLine);
                }));
            }
        }
        public RelayCommand Users
        {
            get
            {
                return users ?? (users = new RelayCommand(o =>
                {
                    new View.UserV().Show();
                }));
            }
        }
        public RelayCommand Tasks
        {
            get
            {
                return tasks ?? (tasks = new RelayCommand(o =>
                {
                    new View.Task().Show();
                }));
            }
        }


        
    }
}
