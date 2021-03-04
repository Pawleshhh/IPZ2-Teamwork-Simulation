using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class ColorViewModel : NotifyPropertyChanges
    {

        public ColorViewModel(Color color)
        {
            this.color = color;
            this.color.SelectedColorChanged += Color_SelectedColorChanged;
        }

        private readonly Color color;

        public IReadOnlyList<string> Colors => color.Colors;

        public string SelectedColor
        {
            get => color.SelectedColor;
            set => SetProperty(() => color.SelectedColor == value, () => color.SelectedColor = value);
        }

        private void Color_SelectedColorChanged(object sender, DataEventArgs<string> e)
        {
            OnPropertyChanged(nameof(SelectedColor));
        }

    }
}
