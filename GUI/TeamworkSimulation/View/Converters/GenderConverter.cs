using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.View
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Genders g)
            {
                if (g == Genders.Female)
                    return FontAwesomeIcon.Venus;
                else if (g == Genders.Male)
                    return FontAwesomeIcon.Mars;
            }

            return FontAwesomeIcon.Question;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is FontAwesomeIcon f)
            {
                if (f == FontAwesomeIcon.Venus)
                    return Genders.Female;
                else if (f == FontAwesomeIcon.Mars)
                    return Genders.Male;
            }

            return Genders.Female;
        }
    }
}
