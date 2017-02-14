using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FBPlay
{
    public class AnimationView :  Grid
    {
        BoxView _bgNight;
        Image _carView;
        Image _houseView;
        Image _moonView;
        Image _monkeyView;
        Label _label1;
        Label _label2;
        Label _label3;
        bool _animating;

        public static readonly BindableProperty Line1Property = BindableProperty.Create(nameof(Line1), typeof(string), typeof(AnimationView), "In home.", BindingMode.Default, null, OnLine1PropertyChanged);
        public static readonly BindableProperty Line2Property = BindableProperty.Create(nameof(Line2), typeof(string), typeof(AnimationView), "Out of hours.", BindingMode.Default, null, OnLine2PropertyChanged);
        public static readonly BindableProperty Line3Property = BindableProperty.Create(nameof(Line3), typeof(string), typeof(AnimationView), "Bulk billed.", BindingMode.Default, null, OnLine3PropertyChanged);

        public string Line1
        {
            get { return (string)GetValue(Line1Property); }
            set { SetValue(Line1Property, value); }
        }
        public string Line2
        {
            get { return (string)GetValue(Line2Property); }
            set { SetValue(Line2Property, value); }
        }
        public string Line3
        {
            get { return (string)GetValue(Line3Property); }
            set { SetValue(Line3Property, value); }
        }

        public AnimationView()
        {
            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Start;
            Opacity = 0d;
            BackgroundColor = Color.FromHex("#27BDBE");

            _bgNight = new BoxView()
            {
                BackgroundColor = Color.FromHex("#003346"), //night color
            };

            _label1 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.White,
                Text = "Smooth Animations.",
            };

            _label2 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.White,
                Text = "Easy Animation.",
            };

            _label3 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.White,
                Text = "Post-Layout.",
            };

            _carView = new Image()
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.End,
            };

            _houseView = new Image()
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
            };

            _monkeyView = new Image()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Source = "monkey.png",
                TranslationY = 2
            };

            _moonView = new Image()
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Source = "animation_moon.png",
            };

            RowDefinitions = new RowDefinitionCollection()
            {
                new RowDefinition() { Height = new GridLength(0.2d, GridUnitType.Star) },
                new RowDefinition() { Height = new GridLength(0.2d, GridUnitType.Star) },
                new RowDefinition() { Height = new GridLength(0.2d, GridUnitType.Star) },
                new RowDefinition() { Height = new GridLength(0.2d, GridUnitType.Star) },
                new RowDefinition() { Height = new GridLength(1d, GridUnitType.Star) },
                new RowDefinition() { Height = new GridLength(0.5d, GridUnitType.Star) },
            };

            Reset(false);

            Children.Add(_bgNight, 0, 1, 0, 6);
            Children.Add(_moonView, 0, 1, 3, 4);
            Children.Add(_houseView, 0, 1, 3, 6);
            Children.Add(_carView, 0, 1, 5, 6);

            Children.Add(_label1, 0, 1, 1, 2);
            Children.Add(_label2, 0, 1, 2, 3);
            Children.Add(_label3, 0, 1, 3, 4);

            Children.Add(_monkeyView, 0, 1, 4, 6);

            _carView.Source = "car.png";
            _houseView.Source = "house.png";
        }

        static void OnLine1PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var label = (AnimationView)bindable;
            label._label1.Text = (string)newValue;
        }

        static void OnLine2PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var label = (AnimationView)bindable;
            label._label2.Text = (string)newValue;
        }

        static void OnLine3PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var label = (AnimationView)bindable;
            label._label3.Text = (string)newValue;
        }

        void Reset(bool setTranslation = true)
        {
            if (setTranslation)
            {
                _houseView.TranslationX = _houseView.Bounds.Width * 0.4d;
                _carView.TranslationX = _carView.Bounds.Width * -1d;
                _monkeyView.TranslationY = _monkeyView.Bounds.Height;
            }

            _monkeyView.Opacity = 0d;
            _label1.Opacity = 0d;
            _label2.Opacity = 0d;
            _label3.Opacity = 0d;
            _bgNight.Opacity = 0d;
            _carView.Opacity = 0d;
            _houseView.Opacity = 0d;
            _moonView.Opacity = 0d;
        }

        public void Animate()
        {
            if (_animating)
                return;

            _animating = true;

            Device.BeginInvokeOnMainThread(async () =>
            {
                Reset();
                await Task.Delay(100);
                Reset();

                if (!_animating)
                    return;

                _carView.Opacity = 1d;
                _houseView.Opacity = 1d;

                await this.FadeTo(1d, 500, Easing.Linear);
                if (!_animating)
                    return;
                
                await Task.WhenAll(FadeInHomeLabel(), 
                                   AnimateCarHouseShow(), 
                                   AnimateSky());
                if (!_animating)
                    return;
                
                //await Task.Delay(750);
                //if (!_animating)
                //  return;
                
                //await AnimateSky();
                //if (!_animating)
                //  return;
                
                await AnimateMoonHide();
                if (!_animating)
                    return;
                
                await Task.Delay(750);
                if (!_animating)
                    return;
                
                
                var fadeMonkeyTask = _monkeyView.FadeTo(1d, 500, Easing.Linear);
                var translatMonkeyTask = _monkeyView.TranslateTo(0, 0, 500);
                var rotateMonkeyTask = _monkeyView.RotateTo(360, 500);

                await Task.WhenAll(fadeMonkeyTask, translatMonkeyTask, rotateMonkeyTask);

                if (!_animating)
                    return;
                
                await Task.Delay(200);
                if (!_animating)
                    return;
                
                await _label3.FadeTo(1d, 250, Easing.Linear);

                await _houseView.FadeTo(0, 0, Easing.Linear);

                _animating = false;
            });
        }

        public void Stop()
        {
            _animating = false;
        }

        public async Task FadeInHomeLabel()
        {
            await Task.Delay(100);
            await _label1.FadeTo(1d, 300, Easing.Linear);
        }

        public async Task AnimateSky()
        {
            await Task.Delay(750); //delays before second text
            var nightTask = _bgNight.FadeTo(1d, 1000, Easing.Linear);
            var moonTask = AnimateMoon();

            await Task.Delay(750); //delays before second text
            var label2 = _label2.FadeTo(1d, 250, Easing.Linear);

            await Task.WhenAll(nightTask, moonTask, label2);
        }

        public Task AnimateMoon()
        {
            var moonTask1 = _moonView.TranslateTo(-20d, 0d, 1000, Easing.CubicOut);
            var moonTask2 = _moonView.FadeTo(1d, 1000, Easing.Linear);
            var moonTask3 = _moonView.ScaleTo(1.2d);

            return Task.WhenAll(moonTask1, moonTask2, moonTask3);
        }

        public Task AnimateCarHouseShow()
        {
            var task1 = _carView.TranslateTo(Bounds.Width + (_carView.Width/2), 0d, 2500, Easing.SinInOut);
            var task2 = _houseView.TranslateTo(Bounds.Width * -1d, 0d, 2500, Easing.SinInOut);

            return Task.WhenAll(task1, task2);
        }

        public Task AnimateMoonHide()
        {
            var hide3Task = _moonView.FadeTo(0d, 500, Easing.Linear);
            return hide3Task;

            //var hide1Task = _carView.TranslateTo(_carView.TranslationX + 300d, 0d, 800, Easing.SinIn);
            //var hide2Task = _houseView.TranslateTo(_houseView.TranslationX + 300d, 0d, 800, Easing.SinIn);
            
            //var hide4Task = _carView.FadeTo(0d, 500, Easing.Linear);
            //var hide5Task = _houseView.FadeTo(0d, 500, Easing.Linear);

            //return Task.WhenAll(hide1Task, hide2Task, hide3Task, hide4Task, hide5Task);
        }
    }
}

