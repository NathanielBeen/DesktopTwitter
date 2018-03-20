using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FinalProject
{
    class MainWindowView : INotifyPropertyChanged
    {
        public const int MAIN_VIEW = 0;
        public const int USER_VIEW = 1;
        public const int DM_VIEW = 2;

        private int viewMode;
        public int ViewMode
        {
            get { return viewMode; }
            set
            {
                if (value != viewMode)
                {
                    viewMode = value;
                    onPropertyChanged(nameof(ViewMode));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowView()
        {
            viewMode = MAIN_VIEW;
        }

        public void onPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class IntToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}
