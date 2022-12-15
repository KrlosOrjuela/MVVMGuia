using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MVVMGuia.Views
{	
	public partial class PageMunu : ContentPage
	{	
		public PageMunu ()
		{
			InitializeComponent ();
            this.BindingContext = new ViewModels.VMPageMenu(this.Navigation);
        }
	}
}

