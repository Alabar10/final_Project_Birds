using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace final_Project_Birds
{
    public class ExcelManager
    {
        private string filepath;
        public ExcelManager(string filepath)
        {
            filepath = Path.Combine(GetProjectDirectory(), filepath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public static string GetProjectDirectory()
        {
            string codebase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codebase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);

        }
    }   
}
