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
            var repoDirPath = Path.Combine(projectPath, "Repositories");
            Directory.CreateDirectory(repoDirPath);

            // Sinh file IRepository
            // Lấy tên project
            string IRepoContent = RepositoryGen.GenerateIRepositoryContent(projectPath);

            var a = 0;

        }
    }
}
