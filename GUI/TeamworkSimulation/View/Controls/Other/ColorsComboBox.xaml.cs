using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeamworkSimulation.View
{
    /// <summary>
    /// Interaction logic for ColorsComboBox.xaml
    /// </summary>
    public partial class ColorsComboBox : UserControl
    {
        public ColorsComboBox()
        {
            InitializeComponent();
            //colorsComboBox.ItemsSource = colors;
        }

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(ColorsComboBox), null);

        private static PropertyInfo[] colors = typeof(Colors).GetProperties();

    }
}
