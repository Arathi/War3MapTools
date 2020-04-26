using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;

namespace War3MapTools.Jass.Parser
{
    public class JassFile
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        private IDictionary<string, Function> functionDict;

        private IList<string> Codes { get; set; }

        public GlobalBlock Globals { get; set; }
        
        public List<Function> Functions { get; set; }

        public IDictionary<string, Function> FunctionDict
        { 
            get 
            {
                if (functionDict == null)
                {
                    functionDict = new Dictionary<string, Function>();
                    foreach (Function func in Functions)
                    {
                        functionDict[func.Name] = func;
                    }
                }
                return functionDict;
            }
        }

        public Function MainFunction
        { 
            get
            {
                return FunctionDict["main"];
            }
        }

        public JassFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<string> codes = new List<string>();
            codes.AddRange(lines);
            Codes = codes;
        }

        public JassFile(string[] contents)
        {
            List<string> codes = new List<string>();
            codes.AddRange(contents);
            Codes = codes;
        }

        public JassFile(IList<string> lines)
        {
            Codes = lines;
        }

        public void AddFunctionsBeforeMain(IList<Function> functions)
        {
            int index = Functions.Count - 1;
            for (; index > 0; index--)
            {
                Function f = Functions[index];
                if (f.Name == "main")
                {
                    break;
                }
            }

            Functions.InsertRange(index, functions);
        }

        public void Parse()
        {
            string blockType = null;
            Function func = null;
            foreach (string l in Codes)
            {
                string line = l.Trim();

                if (line == "globals")
                {
                    blockType = line;
                    Globals = new GlobalBlock();
                    continue;
                }

                if (line == "endglobals")
                {
                    blockType = null;
                    continue;
                }

                if (line.StartsWith("function"))
                {
                    if (Functions == null)
                    {
                        Functions = new List<Function>();
                    }

                    blockType = "functions";
                    string[] tokens = line.Split(' ');
                    string name = tokens[1];
                    func = new Function(name);
                    func.AddCode(line);
                    continue;
                }

                if (line == "endfunction")
                {
                    func.AddCode(line);
                    Functions.Add(func);
                    func = null;
                    continue;
                }

                if (blockType == "globals")
                {
                    Variable v = new Variable(line);
                    Globals.AddVariable(v);
                }
                else if (blockType == "functions")
                {
                    func.AddCode(line);
                }
                else
                {
                    logger.Warn($"获取到游离代码{line}");
                }
            }
        }
    }
}
