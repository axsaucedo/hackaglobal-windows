using System.Collections.Generic;

namespace HackaGlobal
{
    internal class LoadedCountries
    {
        public List<string> countries { get; set; }

        public List<string> ToStringList()
        {
            return countries;
        }
    }
}
