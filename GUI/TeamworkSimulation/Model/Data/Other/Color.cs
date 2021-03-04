using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TeamworkSimulation.Model
{
    [DataContract]
    public class Color
    {

        #region Private fields

        private static List<string> colors = new List<string>()
        {
            "Default", "Blue", "DeepSkyBlue", "Green", "Lime", "Maroon", "Orange", "Purple", "Red", "Violet"
        };

        private string selectedColor = colors[0];

        #endregion

        #region Properties

        public IReadOnlyList<string> Colors => colors;

        [DataMember]
        public string SelectedColor
        {
            get => selectedColor;
            set
            {
                selectedColor = value;

                OnSelectedColorChanged(value);
            }
        }

        #endregion

        #region Event

        public event EventHandler<DataEventArgs<string>> SelectedColorChanged;

        protected void OnSelectedColorChanged(string color)
            => SelectedColorChanged?.Invoke(this, new DataEventArgs<string>(color));

        #endregion

        public override string ToString()
            => SelectedColor;

    }
}
