using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.TemplateGeneral;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly List<string> listDesignPattern = new List<string>()
        {
            "MVC",
            "Repository",
            "CQRS"
        };
        public Form1()
        {
            InitializeComponent();
            LoadDataControls();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDataControls()
        {
            cmbDesignPattern.Properties.Items.AddRange(listDesignPattern);
        }

        private void btnProjectPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (!string.IsNullOrEmpty(txtProjectPath.Text))
                {
                    folderBrowserDialog.SelectedPath = txtProjectPath.Text;
                }
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtProjectPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnModelPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (!string.IsNullOrEmpty(txtProjectPath.Text))
                {
                    folderBrowserDialog.SelectedPath = txtProjectPath.Text;
                }
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtModelsPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string projectPath = txtProjectPath.Text;
            string modelsPath = txtModelsPath.Text;
            string designPattern = cmbDesignPattern.SelectedItem.ToString();

            GenCode(projectPath, modelsPath, designPattern);
        }

        #region Code logic
        private void GenCode(string projectPath, string modelsPath, string designPatternType)
        {
            switch (designPatternType)
            {
                case "MVC":
                    
                    break;
                case "Repository":
                    GenerateCode.GenerateRepositoryCode(projectPath, modelsPath);
                    break;
                case "CQRS":

                    break;
                default: 
                    break;
            }
        }
        #endregion
    }
}
