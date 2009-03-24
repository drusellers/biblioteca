namespace biblioteca.domain
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    public class Repository
    {
        private static string _path = @"E:\Development\biblioteca\src\biblioteca.web\packages";

       
        public static IEnumerable<SoftwarePackage> List()
        {
            string[] files = Directory.GetFiles(_path);
            var jss = new JavaScriptSerializer();
            var packages = files.Select((file) => jss.Deserialize<SoftwarePackage>(File.ReadAllText(file)));
          
            return packages;
        }
    }
}