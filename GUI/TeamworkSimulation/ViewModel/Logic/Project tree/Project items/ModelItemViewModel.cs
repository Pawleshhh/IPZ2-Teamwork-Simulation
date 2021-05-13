using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public abstract class ModelItemViewModel : ProjectItemViewModel
    {
        protected ModelItemViewModel(ModelItem modelItem) : base(modelItem)
        {
            this.modelItem = modelItem;
            modelItem.UseModelChanged += ModelItem_UseModelChanged;
        }

        private ModelItem modelItem;

        public bool UseModel
        {
            get => modelItem.UseModel;
            set => SetProperty(() => modelItem.UseModel == value, () => modelItem.UseModel = value);
        }


        private void ModelItem_UseModelChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(UseModel));
        }


    }
}
