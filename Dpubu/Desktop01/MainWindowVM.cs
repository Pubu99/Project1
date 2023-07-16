using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Desktop01
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser = null;

        public MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new User(21, "Malith", "Anjana", "01/4/2000", image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new User(20, "Sumudu", "Prasanna", "19/6/1998", image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new User(22, "Ruvini", "Apsara", "29/11/2002", image3));
            BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(21, "Ahasya", "perera", "16/4/2000", image4));

        }

        

        [RelayCommand]
        public void AddStudent()
        {
            var au = new AddUserVM();
            au.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(au);
            window.ShowDialog();

            if (au.Student.FirstName != null)
            {
                users.Add(au.Student);
            }
        }

        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var au = new AddUserVM(selectedUser);
                au.title = "EDIT USER";
                var window = new AddUserWindow(au);

                window.ShowDialog();


                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, au.Student);

            }
            else
            {
                MessageBox.Show("Please Select the Student", "Warning!");
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("Plese Select Student Before Delete.", "Error");
            }
        }

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4.", "Error");
        }


    }
}
