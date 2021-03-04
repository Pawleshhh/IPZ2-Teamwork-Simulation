using System;
using System.Collections.Generic;
using System.Text;
using TeamworkSimulation.Model;

namespace TeamworkSimulation.ViewModel
{
    public static class ExperienceViewModelFactory
    {

        public static ExperienceViewModel Create(IExperience experience)
        {
            switch(experience)
            {
                case WorkerExperience w:
                    return new WorkerExperienceViewModel(w);
                case StudentExperience s:
                    return new StudentExperienceViewModel(s);
                default:
                    throw new InvalidOperationException($"Not recognized type of experience: {experience.GetType()}");
            }
        }

    }
}
