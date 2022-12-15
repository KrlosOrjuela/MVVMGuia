using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMGuia.ViewModels
{
    public class VMPageOne : BaseViewModel
    {

        #region Variable
        private int _number1;
        private int _number2;
        private string _result;
        private string _typeRol;
        private DateTime _date;
        private string _seledtedDate;
        #endregion

        #region Constructor
        public VMPageOne(INavigation navigation)
        {
            Navigation = navigation;
            Result = "0";
            Date = DateTime.Now;
        }
        #endregion

        #region Binding Objects
        public int Number1
        {
            get => _number1;
            set => SetProperty(ref _number1, value);
        }

        public int Number2
        {
            get => _number2;
            set => SetProperty(ref _number2, value);
        }

        public string Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public string TypeRol
        {
            get => _typeRol;
            set => SetProperty(ref _typeRol, value);
        }

        public string SelectedTypeRol
        {
            get => _typeRol;
            set
            {
                SetProperty(ref _typeRol, value);
                TypeRol = _typeRol;
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                SetProperty(ref _date, value);
                SelectedDate = _date.ToString("dd/MM/yyyy");
            }
        }

        public string SelectedDate
        {
            get => _seledtedDate;
            set => SetProperty(ref _seledtedDate, value);
        }
        #endregion

        #region Events Command
        public ICommand SubtractNumbersCommand => new Command(SubtractNumbersCommandExecute);
        public ICommand OnBackButtonPressedCommand => new Command(async () => await OnBackButtonPressed());
        public ICommand NavegatePageTwoCommand => new Command(async () => await NavegatePageTwoCommandExecute());
        #endregion

        #region Processes
        public void SubtractNumbersCommandExecute()
        {
            this.Result = (this.Number1 - this.Number2).ToString();
        }

        public async Task NavegatePageTwoCommandExecute()
        {
            await Navigation.PushAsync(new Views.PageTwo());
        }

        public override Task OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        #endregion
    }
}

