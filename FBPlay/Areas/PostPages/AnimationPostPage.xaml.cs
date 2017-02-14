using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FBPlay
{
	public partial class AnimationPostPage : ContentPage
	{
		public AnimationPostPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            animation.Animate();
        }
	}
}
