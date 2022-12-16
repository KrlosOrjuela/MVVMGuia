using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MVVMGuia.Views
{	
	public partial class PageStatusBar : ContentPage
	{	
		public PageStatusBar ()
		{
			InitializeComponent ();
            this.BindingContext = new ViewModels.VMPageStatusBar();
        }
	}
}

