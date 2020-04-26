namespace JassInjectorGui
{
    partial class FormInjector
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMapFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenMapFile = new System.Windows.Forms.Button();
            this.clbScripts = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxScriptsPath = new System.Windows.Forms.TextBox();
            this.btnOpenScriptPath = new System.Windows.Forms.Button();
            this.btnInject = new System.Windows.Forms.Button();
            this.openMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地图文件";
            // 
            // textBoxMapFilePath
            // 
            this.textBoxMapFilePath.Location = new System.Drawing.Point(71, 6);
            this.textBoxMapFilePath.Name = "textBoxMapFilePath";
            this.textBoxMapFilePath.Size = new System.Drawing.Size(290, 21);
            this.textBoxMapFilePath.TabIndex = 1;
            // 
            // btnOpenMapFile
            // 
            this.btnOpenMapFile.Location = new System.Drawing.Point(367, 4);
            this.btnOpenMapFile.Name = "btnOpenMapFile";
            this.btnOpenMapFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenMapFile.TabIndex = 2;
            this.btnOpenMapFile.Text = "打开";
            this.btnOpenMapFile.UseVisualStyleBackColor = true;
            this.btnOpenMapFile.Click += new System.EventHandler(this.btnOpenMapFile_Click);
            // 
            // clbScripts
            // 
            this.clbScripts.FormattingEnabled = true;
            this.clbScripts.Location = new System.Drawing.Point(12, 65);
            this.clbScripts.Name = "clbScripts";
            this.clbScripts.Size = new System.Drawing.Size(430, 340);
            this.clbScripts.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "脚本目录";
            // 
            // textBoxScriptsPath
            // 
            this.textBoxScriptsPath.Location = new System.Drawing.Point(71, 36);
            this.textBoxScriptsPath.Name = "textBoxScriptsPath";
            this.textBoxScriptsPath.Size = new System.Drawing.Size(290, 21);
            this.textBoxScriptsPath.TabIndex = 5;
            // 
            // btnOpenScriptPath
            // 
            this.btnOpenScriptPath.Location = new System.Drawing.Point(367, 34);
            this.btnOpenScriptPath.Name = "btnOpenScriptPath";
            this.btnOpenScriptPath.Size = new System.Drawing.Size(75, 23);
            this.btnOpenScriptPath.TabIndex = 6;
            this.btnOpenScriptPath.Text = "打开";
            this.btnOpenScriptPath.UseVisualStyleBackColor = true;
            this.btnOpenScriptPath.Click += new System.EventHandler(this.btnOpenScriptPath_Click);
            // 
            // btnInject
            // 
            this.btnInject.Location = new System.Drawing.Point(367, 414);
            this.btnInject.Name = "btnInject";
            this.btnInject.Size = new System.Drawing.Size(75, 23);
            this.btnInject.TabIndex = 7;
            this.btnInject.Text = "注入脚本";
            this.btnInject.UseVisualStyleBackColor = true;
            this.btnInject.Click += new System.EventHandler(this.btnInject_Click);
            // 
            // openMapDialog
            // 
            this.openMapDialog.Filter = "冰封王座地图文件|*.w3x|混乱之治地图文件|*.w3m|所有文件|*.*";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 414);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(347, 23);
            this.progressBar.TabIndex = 8;
            // 
            // FormInjector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 445);
            this.Controls.Add(this.btnInject);
            this.Controls.Add(this.btnOpenScriptPath);
            this.Controls.Add(this.textBoxScriptsPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clbScripts);
            this.Controls.Add(this.btnOpenMapFile);
            this.Controls.Add(this.textBoxMapFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Name = "FormInjector";
            this.Text = "Jass脚本注入工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMapFilePath;
        private System.Windows.Forms.Button btnOpenMapFile;
        private System.Windows.Forms.CheckedListBox clbScripts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxScriptsPath;
        private System.Windows.Forms.Button btnOpenScriptPath;
        private System.Windows.Forms.Button btnInject;
        private System.Windows.Forms.OpenFileDialog openMapDialog;
        private System.Windows.Forms.SaveFileDialog saveMapDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

