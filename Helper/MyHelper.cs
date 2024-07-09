using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp1.Helper
{
    public static class MyHelper
    {
        public static string GetNamespaceModel(string modelPathStr, string projectNameStr)
        {
            // Tìm vị trí của targetFolder trong fullPath
            int startIndex = modelPathStr.IndexOf(projectNameStr);
            if (startIndex == -1)
            {
                // Nếu targetFolder không có trong fullPath, trả về chuỗi rỗng hoặc thông báo lỗi
                return string.Empty;
            }

            // Lấy phần của đường dẫn từ targetFolder trở đi
            string relevantPath = modelPathStr.Substring(startIndex);

            // Thay thế các dấu gạch chéo ngược bằng dấu chấm
            string formattedPath = relevantPath.Replace(Path.DirectorySeparatorChar, '.');

            return formattedPath;
        }
    }
}
