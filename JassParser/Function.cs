using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War3MapTools.Jass.Parser
{
    public class Function
    {
        public string Name { get; set; }

        public IList<string> Codes { get; set; }

        public Function(string name)
        {
            Name = name;
            Codes = new List<string>();
        }

        public void AddCode(string code)
        {
            Codes.Add(code);
        }

        public override string ToString()
        {
            return $"函数名{Name}，共{Codes.Count}行";
        }
    }
}
