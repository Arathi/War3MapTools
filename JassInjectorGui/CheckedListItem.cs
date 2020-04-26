using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JassInjectorGui
{
    public class CheckedListItem
    {
        public string ScriptName { get; set; }

        public string Path { get; set; }

        public CheckedListItem(string path)
        {
            int index = path.LastIndexOf("\\") + 1;
            Path = path;
            ScriptName = path.Substring(index);
        }

        public override string ToString()
        {
            return ScriptName;
        }
    }
}
