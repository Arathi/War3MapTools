using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace War3MapTools.Jass.Parser
{
    public class Variable
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public string Code { get; set; }

        public string Type { get; set; }

        public bool Array { get; set; }

        public string Name { get; set; }

        public Variable(string code)
        {
            Code = code;

            var sps = new char[] { ' ' };

            var tokens = code.Split(sps, 2, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 2)
            {
                logger.Warn($"无法解析的变量定义语句{code}");
                return;
            }

            // 第一位是类型
            Type = tokens[0];
            var leftP1 = tokens[1];
            string nameAndValue = null;

            tokens = leftP1.Split(sps, 2, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 1)
            {
                nameAndValue = leftP1;
            }
            else if (tokens.Length >= 2)
            {
                string first = tokens[0];
                var leftP2 = tokens[1];
                if (first == "array")
                {
                    // 第二位可能是数组标记
                    Array = true;
                    nameAndValue = leftP2;
                }
                else
                {
                    nameAndValue = leftP1;
                }
            }

            sps = new char[] { ' ', '=' };
            tokens = nameAndValue.Split(sps, 2, StringSplitOptions.RemoveEmptyEntries);
            Name = tokens[0];
        }

        public override string ToString()
        {
            string arr = Array ? "[]" : "";
            return $"{Name} : {Type}{arr}";
        }
    }
}
