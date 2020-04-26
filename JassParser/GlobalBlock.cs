using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War3MapTools.Jass.Parser
{
    public class GlobalBlock
    {
        private IDictionary<string, Variable> variableDict;

        public IList<Variable> Variables { get; set; }

        public IDictionary<string, Variable> VariableDict 
        {
            get 
            {
                if (variableDict == null)
                {
                    variableDict = new Dictionary<string, Variable>();
                    foreach (Variable v in Variables)
                    {
                        variableDict[v.Name] = v;
                    }
                }
                return variableDict;
            }
        }

        public GlobalBlock()
        {
        }

        public void AddVariable(Variable v)
        {
            if (Variables == null)
            {
                Variables = new List<Variable>();
            }
            Variables.Add(v);
        }

        public override string ToString()
        {
            StringBuilder src = new StringBuilder();

            src.Append("globals");
            src.Append("\r\n");

            foreach (Variable v in Variables)
            {
                src.Append(v.Code);
                src.Append("\r\n");
            }

            src.Append("endglobals");
            src.Append("\r\n");

            return src.ToString();
        }
    }
}
