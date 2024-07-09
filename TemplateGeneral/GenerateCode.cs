using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Sinh file IRepository
            // Lấy tên project
            var nameProject = Path.GetFileName(projectPath);
            string IRepoContent = RepositoryGen.GenerateIRepositoryContent(nameProject, nameRepoDir);

            

        }
    }
}
