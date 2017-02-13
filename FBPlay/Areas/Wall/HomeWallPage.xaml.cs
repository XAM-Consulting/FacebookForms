using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace FBPlay
{
    public partial class HomeWallPage : ContentPage
    {
        public HomeWallPage()
        {
			NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            InitializeComponent();

            BindingContext = new HomeWallViewModel(this);

            myListView.Scrolled += MyListView_Scrolled;

            var friendListGrey = Application.Current.Resources["FriendListGrey"];

            //panContainer.IsVisible = true;

			SizeChanged += HomeWallPage_SizeChanged;
        }

		void HomeWallPage_SizeChanged(object sender, EventArgs e)
		{
			App.SetWidthHeight(Width, Height);
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            friendList.TranslationX = this.Width;
        }

        void FriendListTapped(object sender, System.EventArgs e)
        {
            if (friendList.TranslationX == Width)
            {
                friendList.TranslateTo(Width - 300, 0);
                header.TranslateTo(-300, header.TranslationY);
                myListView.TranslateTo(-300, myListView.TranslationY);
            }
            else
            {
                friendList.TranslateTo(Width, 0);
                header.TranslateTo(0, header.TranslationY);
                myListView.TranslateTo(0, myListView.TranslationY);
            }
        }

        void MyListView_Scrolled(Point obj)
        {
            //if (panRunning)
            //    return;

            var headerHeight = 60;

            if (obj.Y <= 0)
            {
                header.TranslationY = 0;
                myListView.TranslationY = headerHeight;
            }
            else if (obj.Y <= headerHeight)
            {
                header.TranslationY = -obj.Y;
                myListView.TranslationY = -obj.Y + headerHeight;
            }
            else if (obj.Y > headerHeight) //scrolled 
            {
                header.TranslationY = -headerHeight;
                myListView.TranslationY = 0;
            }
        }

        double _endY;
        double _headerTranslationYBegin;
        double _myListViewTranslationYBegin;
        static double headerShownPoint = 0;
        static double headerHiddenPoint = -60;
        bool panRunning = false;

        //void Handle_PanUpdated(object sender, PanUpdatedEventArgs args)
        //{
        //    Debug.WriteLine($"Pan {args.TotalX} {args.TotalY} {args.StatusType}");

        //    if (!panContainer.IsVisible && args.StatusType == GestureStatus.Running)
        //    {
        //        myListView.ScrollToPoint(new Point(0, -(args.TotalY - _endY)));
        //        return;
        //    }            

        //    switch (args.StatusType)
        //    {
        //        case GestureStatus.Started:
        //            _headerTranslationYBegin = header.TranslationY;
        //            _myListViewTranslationYBegin = myListView.TranslationY;
        //            break;                    
        //        case GestureStatus.Running:

        //            var headerY =_headerTranslationYBegin + args.TotalY;
        //            var myListViewY = _myListViewTranslationYBegin + args.TotalY;

        //            bool inWindow = headerY > headerHiddenPoint
        //                                  && headerY < headerShownPoint;
                    
        //            Debug.WriteLine($" R + C {headerY} {myListViewY}");

        //            if (inWindow)
        //            {
        //                Debug.WriteLine($"In Window");
        //                header.TranslationY = headerY;
        //                myListView.TranslationY = myListViewY;
        //                panContainer.IsVisible = true;
        //            }
        //            else
        //            {
        //                panContainer.IsVisible = false;
        //                _endY = args.TotalY;
                                    
        //                //if (panContainer.IsVisible)
        //                //{
        //                //    Debug.WriteLine($"panContainer.IsVisible");
        //                //    panContainer.IsVisible = false;
        //                //    _endY = args.TotalY;
        //                //}

        //                //myListView.TranslationY = myListViewY;

        //                //if (header.TranslationY <= headerHiddenPoint)
        //                //{
        //                //    Debug.WriteLine($"header hidden point");

        //                //    //header.TranslationY = headerHiddenPoint;
        //                //    //myListView.TranslationY = 0;
        //                //}
        //                //else
        //                //{
        //                //    Debug.WriteLine($"header shown point");
        //                //    //header.TranslationY = headerShownPoint;
        //                //    //myListView.TranslationY = 60;
        //                //}
        //            }

        //            break;                    
        //        case GestureStatus.Completed:
        //            panRunning = false;
        //            break;
        //        case GestureStatus.Canceled:      
        //            panRunning = false;
        //            break;
        //        default:
        //            break;
        //    }

        //}
    }
}
