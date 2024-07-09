using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.TemplateGeneral
{
    public static class GenerateCode
    {
        public static void GenerateRepositoryCode(string projectPath, string modelsPath)
        {
            // Đọc các model từ thư mục modelsPath
            string[] modelFiles = Directory.GetFiles(modelsPath, "*.cs");

            // Tạo thư mục repository
            var nameRepoDir = "Repositories";
            var repoDirPath = Path.Combine(projectPath, nameRepoDir);
            Directory.CreateDirectory(repoDirPath);

            // IRepository
            // Lấy tên project
            var nameProject = Path.GetFileName(projectPath);
            string IRepoContent = RepositoryGen.GenerateIRepositoryContent(nameProject, nameRepoDir);

            // Ghi file
            File.WriteAllText(Path.Combine(repoDirPath, $"IRepository.cs"), IRepoContent);
            // ----------------------------------------------------------------------
            // Tạo thư mục Implement
            var nameImplDir = "Implements";
            
            var pathImplDir = Path.Combine(repoDirPath, nameImplDir);
            Directory.CreateDirectory(pathImplDir);

            // Tạo file implement content
            string repoContent = RepositoryGen.GenerateRepositoryImplContent(nameProject, nameRepoDir, nameImplDir);
            // Ghi file
            File.WriteAllText(Path.Combine(pathImplDir, $"Repository.cs"), repoContent);

            // Gen theo model
            var namespaceModel = MyHelper.GetNamespaceModel(modelsPath, nameProject);

            foreach (var item in modelFiles)
            {
                string modelName = Path.GetFileNameWithoutExtension(item);
                var IRepoModelContent = RepositoryGen.GenerateModelIRepositoryContent(namespaceModel, nameProject, nameRepoDir, modelName);

                File.WriteAllText(Path.Combine(repoDirPath, $"I{modelName}Repository.cs"), IRepoModelContent);
            }

            // Done
            MessageBox.Show("Gen source thành công.", "Thông báo", MessageBoxButtons.OK);
        }
    }
}
