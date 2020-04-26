using System;
using System.IO;
using System.Windows.Forms;
using War3MapTools.Jass.Injector;
using War3MapTools.Jass.Parser;

namespace JassInjectorGui
{
    public partial class FormInjector : Form
    {
        private JassInjector Injector { get; set; }

        public FormInjector()
        {
            InitializeComponent();
        }

        private void btnOpenMapFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = openMapDialog.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }

            string path = openMapDialog.FileName;

            Injector = new JassInjector();
            bool succ = Injector.OpenMapFile(path);
            if (!succ)
            {
                MessageBox.Show("地图文件打开失败");
                return;
            }

            succ = Injector.ParseMapJass();
            if (!succ)
            {
                MessageBox.Show("Jass文件解析失败");
                return;
            }

            textBoxMapFilePath.Text = path;
        }

        private void btnOpenScriptPath_Click(object sender, EventArgs e)
        {
            string path = textBoxScriptsPath.Text;
            if (string.IsNullOrEmpty(path))
            {
                path = Directory.GetCurrentDirectory();
                folderBrowserDialog.SelectedPath = path;
            }

            DialogResult dr = folderBrowserDialog.ShowDialog();
            if (dr != DialogResult.OK)
            {
                MessageBox.Show("脚本目录打开失败");
                return;
            }
            path = folderBrowserDialog.SelectedPath;

            string[] dirs = Directory.GetDirectories(path);
            foreach (string dir in dirs)
            {
                int index = dir.LastIndexOf("\\") + 1;
                string name = dir.Substring(index);
                var item = new CheckedListItem(dir);
                clbScripts.Items.Add(item, false);
            }

            textBoxScriptsPath.Text = path;
        }

        private void btnInject_Click(object sender, EventArgs e)
        {
            if (clbScripts.CheckedItems.Count == 0)
            {
                MessageBox.Show("未选择任何脚本");
                return;
            }
            
            
            foreach (CheckedListItem item in clbScripts.CheckedItems)
            {
                string basePath = item.Path;
                string gPath = basePath + "\\g.j";
                string fPath = basePath + "\\f.j";
                string mPath = basePath + "\\m.j";

                bool succ = Injector.Inject(gPath, fPath, mPath);

                if (!succ)
                {
                    MessageBox.Show($"{item.ScriptName}注入失败");
                    return;
                }
            }

            MessageBox.Show("脚本注入完成");
        }
    }
}
