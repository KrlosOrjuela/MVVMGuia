using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MVVMGuia.Views
{
    public partial class PageOne : ContentPage
    {
        public PageOne()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.VMPageOne(this.Navigation);
        }
    }
}

