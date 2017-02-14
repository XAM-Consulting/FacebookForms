using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FBPlay
{
	public partial class PostPageTemplate : Grid
	{
		public PostPageTemplate()
		{
			InitializeComponent();
		}

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
	}
}
