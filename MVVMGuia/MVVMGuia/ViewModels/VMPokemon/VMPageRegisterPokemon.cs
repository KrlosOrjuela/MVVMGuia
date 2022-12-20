using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMGuia.ViewModels.VMPokemon
{
	public class VMPageRegisterPokemon: BaseViewModel
	{
        #region Variable
        private int _number1;
        #endregion

        #region Constructor
        public VMPageRegisterPokemon(INavigation navigation)
        {
            Navigation = navigation;
        }

        #endregion

        #region Binding Objects
        public ObservableCollection<Models.Menu> ListPageMenu { get; set; }
        #endregion

        #region Events Command
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
                case 4:
                    await Navigation.PushAsync(new Views.PageStatusBar());
                    break;
            }
        }


        public override Task OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        #endregion
    }
}

