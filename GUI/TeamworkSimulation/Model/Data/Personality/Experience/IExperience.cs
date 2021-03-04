using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model
{
    public interface IExperience
    {

        int Age { get; set; }

        event EventHandler Changed;

        IExperience Copy();

    }
}
