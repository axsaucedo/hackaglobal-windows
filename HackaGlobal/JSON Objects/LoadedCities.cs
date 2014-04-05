using System.Collections.Generic;

namespace HackaGlobal
{
    internal class LoadedCities
    {
        public List<string> cities { get; set; }

        public List<string> ToStringList()
        {
            return cities;
        }
    }
}
