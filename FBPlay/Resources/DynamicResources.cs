using System;
using Xamarin.Forms;

namespace FBPlay
{
    public class DynamicResources : IDynamicResources
    {
        public DynamicResources()
        {
            FriendListGrey = Color.FromRgb(82, 82, 82);
            BlueHeaderColor = Color.FromRgb(59, 88, 152);

        }

        public Color FriendListGrey { get; set; }
        public Color BlueHeaderColor { get; set; }
    }
}
