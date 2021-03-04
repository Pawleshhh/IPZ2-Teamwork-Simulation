using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Utility
{
    public static class EnumHelper
    {

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }


    }
}
