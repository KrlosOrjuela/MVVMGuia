using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MVVMGuia.Interfaces;

namespace MVVMGuia.ViewModels
{
    // This is the base ViewModel class   
    // implements the IPropertyChange interface.  
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
        }

        /// <summary>
        /// Interface abstracting platform-specific navigation.
        /// </summary>
        public INavigation Navigation;


        #region INotifyPropertyChanged
        /// <summary>
        /// Occurs when the property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnNotifyPropertyChanged(propertyName);
            return true;
        }

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void OnNotifyPropertyChanged(string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Binding Properties

        /// <summary>
        /// Property that gets or sets an image to use on the App Page
        /// </summary>
        private ImageSource _image;
        public ImageSource Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        /// <summary>
        /// Property that gets or sets an title to use on the App Apge
        /// </summary>
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        /// <summary>
        /// Property that gets or sets whether a process is wainting
        /// </summary>
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        #endregion

        #region Events Command
        public ICommand TranslucentCommand => new Command(() => TranslucentCommandExecute());
        public ICommand ChangeColorCommand => new Command(() => ChangeColorCommandExecute());
        public ICommand HideStatusBarCommand => new Command(() => HideStatusBarCommandExecute());
        public ICommand ShowStatusBarCommand => new Command(() => ShowStatusBarCommandExecute());
        #endregion

        #region Methods
        /// <summary>
        /// Presents an alert dialog to the application user with a single cancel button.
        /// </summary>
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        /// <summary>
        /// Presents an alert dialog to the application user with an accept and a cancel button.
        /// </summary>
        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public async virtual Task Init() { }
        public async virtual Task OnAppearing() { }
        public async virtual Task OnDisappearing() { }
        public async virtual Task OnBackButtonPressed() => await Navigation.PopAsync();

        #region Focusing Android: Status Bar
        public void HideStatusBarCommandExecute() => DependencyService.Get<IEventStatusBar>().HideStatusBar();
        public void ShowStatusBarCommandExecute() => DependencyService.Get<IEventStatusBar>().ShowStatusBar();
        public void TranslucentCommandExecute() => DependencyService.Get<IEventStatusBar>().Translucent();
        public void ChangeColorCommandExecute() => DependencyService.Get<IEventStatusBar>().ChangeColor("#D27D02");
        #endregion




        #endregion
    }
}

