using Xamarin.Forms;
using System.Reflection;
using System.Linq;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]

namespace FBPlay
{
    public partial class App : Application
    {
		public static double ScreenWidth { get; set; }
		public static double ScreenHeight { get; set; }

		public static void SetWidthHeight(double width, double height)
		{
			ScreenWidth = width;
			ScreenHeight = height;
		}

        public App()
        {
            InitializeComponent();

            LoadDynamicResources(new DynamicResources());

			MainPage = new NavigationPage(new HomeWallPage());
        }

        void LoadDynamicResources(IDynamicResources resources)
        {
            if (Resources == null)
                Resources = new ResourceDictionary();

            var properties = resources.GetType().GetRuntimeProperties();
            foreach (var prop in properties)
            {
                Resources.Add(prop.Name, prop.GetValue(resources));
            }

            if (Device.OS == TargetPlatform.iOS)
            {
                var labelStyle = new Style(typeof(Label))
                {
                    Setters = {
                        new Setter{Property = Label.FontFamilyProperty, Value="HelveticaNeue"}
                    }
                };
                Resources.Add(labelStyle);

                var buttonStyle = new Style(typeof(Button))
                {
                    Setters = {
                        new Setter{Property = Button.FontFamilyProperty, Value="HelveticaNeue"}
                    }
                };
                Resources.Add(buttonStyle);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
