using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FBPlay
{
    public partial class FriendsList : ListView
    {
        public FriendsList()
        {
            InitializeComponent();

            BindingContext = new FriendListViewModel();
        }
    }
}
