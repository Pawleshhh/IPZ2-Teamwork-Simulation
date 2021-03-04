using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public class WorkplaceTemplateViewModel : NotifyPropertyChanges
    {
        #region Constructors

        public WorkplaceTemplateViewModel(WorkplaceTemplateBuilder workplaceTemplate)
        {
            this.workplaceTemplate = workplaceTemplate ?? throw new ArgumentNullException(nameof(workplaceTemplate));
        }

        #endregion

        #region Private fields

        private readonly WorkplaceTemplateBuilder workplaceTemplate;

        #endregion

        #region Properties

        public WorkplaceType WorkplaceType
        {
            get => workplaceTemplate.WorkplaceType;
            set => SetProperty(() => workplaceTemplate.WorkplaceType == value, () => workplaceTemplate.WorkplaceType = value);
        }

        #endregion

    }
}
