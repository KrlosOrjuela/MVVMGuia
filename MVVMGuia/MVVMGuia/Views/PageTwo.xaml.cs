using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MVVMGuia.Views
{	
	public partial class PageTwo : ContentPage
	{	
		public PageTwo ()
		{
			InitializeComponent ();
			this.BindingContext = new ViewModels.VMPageTwo(this.Navigation);
		}
	}
}

