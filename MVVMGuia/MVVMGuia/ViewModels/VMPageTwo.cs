using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMGuia.Models;
using Xamarin.Forms;

namespace MVVMGuia.ViewModels
{
    public class VMPageTwo : BaseViewModel
    {
        #region Variable
        private int _number1;
        #endregion

        #region Constructor
        public VMPageTwo(INavigation navigation)
        {
            Navigation = navigation;
            this.LoadUsers();
        }

        #endregion

        #region Binding Objects
        public ObservableCollection<User> ListUsers { get; set; }
        #endregion

        #region Events Command
        public ICommand AlertCommand => new Command<User>(async (UserSelected) => await AlertCommandExecute(UserSelected));
        public ICommand OnBackButtonPressedCommand => new Command(async () => await OnBackButtonPressed());

        #endregion

        #region Processes
        private async Task AlertCommandExecute(User UserSelected)
        {
            await DisplayAlert("Selected User", UserSelected.Name, "OK");
        }

        private void LoadUsers()
        {
            this.ListUsers = new ObservableCollection<User>()
            {
                new User()
                {
                    Name = "Carlos",
                    Image = "https://i.ibb.co/dkS0M4b/ic-user-one.png"
                },
                new User()
                {
                    Name = "Ana",
                    Image = "https://i.ibb.co/7gckFHg/ic-user-two.png"
                },
                new User()
                {
                    Name = "Andres",
                    Image = "https://i.ibb.co/K9PKrXB/ic-user-three.png"
                },
                new User()
                {
                    Name = "Camila",
                    Image = "https://i.ibb.co/vLX5sw5/ic-user-four.png"
                }
            };
        }

        public override Task OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        #endregion
    }
}

