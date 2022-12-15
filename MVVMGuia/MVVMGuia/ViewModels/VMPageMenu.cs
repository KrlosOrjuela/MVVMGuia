using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMGuia.ViewModels
{
    public class VMPageMenu : BaseViewModel
    {
        #region Variable
        private int _number1;
        #endregion

        #region Constructor
        public VMPageMenu(INavigation navigation)
        {
            Navigation = navigation;
            this.LoadMenuPage();
        }

        #endregion

        #region Binding Objects
        public ObservableCollection<Models.Menu> ListPageMenu { get; set; }
        #endregion

        #region Events Command
        public ICommand NavegationPageCommand => new Command<Models.Menu>(async (UserSelected) => await NavegationPageCommandExecute(UserSelected));
        public ICommand OnBackButtonPressedCommand => new Command(async () => await OnBackButtonPressed());

        #endregion

        #region Processes
        private async Task NavegationPageCommandExecute(Models.Menu PageSelected)
        {
            switch (PageSelected.Id)
            {
                case 1:
                    await Navigation.PushAsync(new Views.PageOne());
                    break;
                case 2:
                    await Navigation.PushAsync(new Views.PageTwo());
                    break;
                case 3:
                    await Navigation.PushAsync(new Views.PagePokemon());
                    break;
            }
        }

        private void LoadMenuPage()
        {
            this.ListPageMenu = new ObservableCollection<Models.Menu>()
            {
                new Models.Menu()
                {
                    Id = 1,
                    Page = "Entry, Detepicker, Picker, Labels, Navegation",
                    Icon = "https://i.ibb.co/85FCgBc/ic-page1.png"
                },
                new Models.Menu()
                {
                    Id = 2,
                    Page = "CollectionView",
                    Icon = "https://i.ibb.co/0ry37W9/ic-page2.png"
                },
                 new Models.Menu()
                {
                    Id = 3,
                    Page = "Pokemon",
                    Icon = "https://i.ibb.co/8b7SJFN/ic-pokemos.png"
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

