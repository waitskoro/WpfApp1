using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp1.ViewModel
{
    public class TaskVM : BaseViewModel
    {
        ApplicationContext db;
        IEnumerable<Task> tasks;
        private RelayCommand sorted;
        private RelayCommand cancel;
        private RelayCommand search;
        private RelayCommand myCTasks;
        private RelayCommand myATasks;
        private string searchOnPeople;
        private Task selectedItem;
        private RelayCommand changeStatus;
        private RelayCommand clickCommand;
        public RelayCommand ClickCommand
        {
            get
            {
                return clickCommand ?? (clickCommand = new RelayCommand(o =>
                {
                    if(SelectedItem != null)
                    {
                        if (SelectedItem.StatusTaskId == 1 && SelectedItem.userIDAccepted == null)
                        {
                            SelectedItem.StatusTask = ServiceDb.db.statusTasks.Find(2);
                            SelectedItem.userIDAccepted = ServiceDb.userSession.ID;
                            ServiceDb.db.Update(SelectedItem);
                            ServiceDb.db.SaveChanges();
                            OnPropertyChanged();
                        }
                        else
                        {
                            MessageBox.Show("Эта задача уже откликнута");
                        }
                    }
                }));
            }
        }
        public RelayCommand ChangeStatusCommand
        {
            get
            {
                return changeStatus ?? (changeStatus = new RelayCommand(o =>
                {
                    if (SelectedItem != null)
                    {
                        if (SelectedItem.userIDCreated == ServiceDb.userSession.ID)
                        {
                            MessageBox.Show("Вы не можете изменить статус у своей задачи");
                        }
                        else if (SelectedItem.userIDAccepted != ServiceDb.userSession.ID)
                        {
                            MessageBox.Show("Вы не можете изменить статус этой задачи если вы на нее не откликались");

                        }
                        else
                        {
                            if (SelectedItem.StatusTask.ID == 2)
                            {

                                SelectedItem.StatusTask = ServiceDb.db.statusTasks.Find(3);
                                ServiceDb.db.Update(SelectedItem);
                                ServiceDb.db.SaveChanges();
                                OnPropertyChanged();
                            }
                            else
                            {
                                MessageBox.Show("Статус изменить нельзя");
                            }

                        }
                    }
                }));
            }
        }
        public Task SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged(); }
        }
        public RelayCommand myTasksACommand
        {
            get
            {
                return myATasks ?? (myATasks = new RelayCommand(o =>
                {
                    Task = db.Tasks.Where(q => q.userIDAccepted == ServiceDb.userSession.ID).Include(f=>f.StatusTask).ToList();
                    OnPropertyChanged();
                }));
            }
        }
        public RelayCommand myTasksCCommand
        {
            get
            {
                return myCTasks ?? (myCTasks = new RelayCommand(o =>
                {
                    Task = db.Tasks.Where(q => q.userIDCreated == ServiceDb.userSession.ID).Include(f => f.StatusTask).ToList();
                    OnPropertyChanged();
                }));
            }
        }
        public RelayCommand SearchCommand
        {
            get
            {
                return search ?? (search = new RelayCommand(o =>
                {
                    
                    var Linq = ServiceDb.db.Users.FirstOrDefault(g => g.Login == SearchOnPeople);
                    if (Linq == null)
                    {
                        MessageBox.Show("Поле пустое");
                    }
                    else
                    {
                        Task = db.Tasks.Where(p => p.userIDCreated == Linq.ID).Include(f => f.StatusTask).ToList();
                        OnPropertyChanged();
                    }
                }));
            }
        }
        public string SearchOnPeople
        {
            get { return searchOnPeople; }
            set { searchOnPeople = value; OnPropertyChanged(); }
        }
        public IEnumerable<Task> Task
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand SortedCommand
        {
            get
            {
                return sorted ?? (sorted = new RelayCommand(o =>
                {
                    Task = db.Tasks.OrderBy(q=>q.Date).Include(f => f.StatusTask).ToList();
                    OnPropertyChanged();
                }));
            }
        }
        public RelayCommand CancelCommand
        {
            get
            {
                return cancel ?? (cancel = new RelayCommand(o =>
                {
                    Task = db.Tasks.Include(f => f.StatusTask).ToList();
                    OnPropertyChanged();

                }));
            }
        }
        public TaskVM()
        {
            db = new ApplicationContext();
            Task = db.Tasks.Include(f => f.StatusTask).ToList();
        }
    }
}
