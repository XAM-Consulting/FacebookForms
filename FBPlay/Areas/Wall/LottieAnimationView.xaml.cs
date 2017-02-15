using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBPlay
{
	public partial class LottieAnimationView : ContentView
	{
        static List<string> Animations = new List<string>();
        static LottieAnimationView()
        {
            LoadAnimationStrings();
        }

        public LottieAnimationView()
        {
            InitializeComponent();

            var random = new Random();
            var idx = (int)(random.NextDouble() * 100) % Animations.Count;
            lottie.Loop = true;
            lottie.AutoPlay = true;
            lottie.Animation = Animations[idx];
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();


        }

        static string GetStringFromAssembly(Assembly assembly, string path)
        {
            var svgStream = assembly.GetManifestResourceStream(path);

            if (svgStream == null)
            {
                throw new Exception(string.Format("Error retrieving {0} make sure Build Action is Embedded Resource",
                    path));
            }
            using (svgStream)
            {
                using (var reader = new StreamReader(svgStream))
                {
                    return reader.ReadToEnd();
                }
            }        
        }

        static void LoadAnimationStrings()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            //Animations.Add(GetStringFromAssembly(assembly, "Watermelon.json"));
            //Animations.Add(GetStringFromAssembly(assembly, "vcTransition1.json"));
            //Animations.Add(GetStringFromAssembly(assembly, "TwitterHeart.json"));
            //Animations.Add(GetStringFromAssembly(assembly, "PinJump.json"));
            //Animations.Add(GetStringFromAssembly(assembly, "MotionCorpse-Jrcanest.json"));
            //Animations.Add(GetStringFromAssembly(assembly, "LottieLogo1.json"));
            //Animations.Add(GetStringFromAssembly(assembly, "HamburgerArrow.json"));
            //Animations.Add(GetStringFromAssembly(assembly, "9squares-AlBoardman.json"));

            Animations.Add("Watermelon.json");
            Animations.Add("vcTransition1.json");
            Animations.Add("TwitterHeart.json");
            Animations.Add("PinJump.json");
            Animations.Add("MotionCorpse-Jrcanest.json");
            Animations.Add("LottieLogo1.json");
            Animations.Add("HamburgerArrow.json");
            Animations.Add("9squares-AlBoardman.json");
        }
	}
}
