using System;
using Xamarin.Forms;

namespace FBPlay
{
	public class NameValidationBehavior : Behavior<SearchBar>
	{
		protected override void OnAttachedTo(SearchBar bindable)
		{
			bindable.TextChanged += OnEntryTextChanged;
			base.OnAttachedTo(bindable);
		}

		protected override void OnDetachingFrom(SearchBar bindable)
		{
			bindable.TextChanged -= OnEntryTextChanged;
			base.OnDetachingFrom(bindable);
		}

		void OnEntryTextChanged(object sender, TextChangedEventArgs args)
		{
			if ((SearchBar)sender == null)
				return;

			if (args.NewTextValue == null)
			{
				((Entry)sender).Text = string.Empty;
				return;
			}

			bool isValid = IsValidName(args.NewTextValue);

			if (!isValid)
			{
				((SearchBar)sender).Text = args.NewTextValue.Substring(0, Math.Max(args.NewTextValue.Length - 1, 0));
			}
		}

		static bool IsValidName(string thestring)
		{
			string regex = @"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ðíöüóőúűéáÍÖÜÓŐÚŰÉÁ '-]+$";
			System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(regex);
			if (re.IsMatch(thestring))
				return true;
			else
				return false;
		}
	}
}
