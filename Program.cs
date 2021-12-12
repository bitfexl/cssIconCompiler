using System;
using System.IO;

namespace cssIconCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generate css icon library.");

            Console.Write("Enter css base class (e.g. icon): ");
            string cssBaseClass = Console.ReadLine();

            Console.Write("Enter icons directory relative or absolute (must end with '/'): ");
            string iconsDir = Console.ReadLine();

            Console.Write("Enter icon file type (e.g. svg): ");
            string iconFileType = Console.ReadLine();

            CssIconCompiler compiler = new CssIconCompiler(cssBaseClass, iconsDir, iconFileType);
            
            string css = compiler.CompileCss();

            using (StreamWriter writer = new StreamWriter("icon-lib.css"))  
            {
                writer.WriteLine(css);
            }

            Console.WriteLine("Generated icon-lib.css");
        }
    }
}
