using System;
using System.Collections.Generic;
using War3Net.IO.Mpq;
using NLog;
using System.IO;
using War3MapTools.Jass.Parser;

namespace War3MapTools.Jass.Injector
{
    public class JassInjector
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        protected MpqArchive MapFile { get; set; }

        protected JassFile JassFile { get; set; }

        public bool OpenMapFile(string path)
        {
            try
            {
                MapFile = MpqArchive.Open(path);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("MPQ文件打开失败：" + ex.Message);
            }
            return false;
        }

        public bool ParseMapJass()
        {
            try
            {
                string jPath = @"scripts\war3map.j";
                MpqStream jassStream = MapFile.OpenFile(jPath);

                StreamReader streader = new StreamReader(jassStream);
                IList<string> lines = new List<string>();
                while (!streader.EndOfStream)
                {
                    lines.Add(streader.ReadLine());
                }
                logger.Info($"读取jass文件{lines.Count}行");

                JassFile = new JassFile(lines);
                JassFile.Parse();
                logger.Info($"解析jass完成，共计{JassFile.Globals.Variables.Count}个全局变量，{JassFile.Functions.Count}个函数");

                return true;
            }
            catch (FileNotFoundException ex)
            {
                logger.Error("未找到jass文件：" + ex.Message);
            }
            return false;
        }

        public bool Inject(string gPath, string fPath, string mPath)
        {
            // 获取g.j文件内容
            string[] g = File.ReadAllLines(gPath);
            IList<Variable> globals = new List<Variable>();
            foreach (string code in g)
            {
                Variable v = new Variable(code);
                globals.Add(v);
            }

            // 获取f.j文件内容
            JassFile f = new JassFile(fPath);
            IList<Function> functions = f.Functions;

            // 获取m.j文件内容
            string[] m = File.ReadAllLines(mPath);
            List<string> mainCodes = new List<string>();
            mainCodes.AddRange(m);

            // 执行注入
            return Inject(globals, functions, mainCodes);
        }

        public bool Inject(IList<Variable> globals, IList<Function> functions, IList<string> mainCodes)
        {
            bool exists = CheckVariableAndFunctionExists(globals, functions, mainCodes);
            if (exists) return false;

            // 注入全局变量
            foreach (Variable v in globals)
            {
                JassFile.Globals.AddVariable(v);
            }

            // 注入新函数
            JassFile.AddFunctionsBeforeMain(functions);

            // 注入main代码
            foreach (string code in mainCodes)
            {
                JassFile.MainFunction.AddCode(code);
            }

            return true;
        }

        public bool CheckVariableAndFunctionExists(IList<Variable> globals, IList<Function> functions, IList<string> mainCodes)
        {
            // 检测全局变量冲突
            foreach (Variable v in globals)
            {
                if (JassFile.Globals.VariableDict.ContainsKey(v.Name))
                {
                    logger.Warn($"全局变量{v.Name}已存在");
                    return false;
                }
            }

            // 检测函数名冲突
            foreach (Function f in functions)
            {
                if (JassFile.FunctionDict.ContainsKey(f.Name))
                {
                    logger.Warn($"函数{f.Name}已存在");
                    return false;
                }
            }

            return true;
        }
    }
}
