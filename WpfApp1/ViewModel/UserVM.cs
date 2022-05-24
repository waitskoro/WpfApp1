using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    public class UserVM : BaseViewModel
    {
        private ObservableCollection<User>? users = new();
        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set { users = value; OnPropertyChanged(); }
        }
        public UserVM()
        {
            users = new ObservableCollection<User>(Helper.GetContext().Users);
        }
    }
}
