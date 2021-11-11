using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    class WeatherControl : DependencyObject
    {
        public string WindDir { get; set; }
        public int WindSpeed { get; set; }
        public enum Osadki
        {
            Sunny = 0,
            Cloudy = 1,
            Rain = 2,
            Snow = 3
        }
        public static readonly DependencyProperty TempProperty;
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }

        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                    new ValidateValueCallback(ValidateTemp));
        }

        private static bool ValidateTemp(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50)
                return t;
            else
                return 0;
        }
    }
}
