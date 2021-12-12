using System.IO;

namespace cssIconCompiler
{
    class CssIconCompiler
    {
        private string _baseClass;
        private string _iconPath;
        private string _iconFileType;

        public CssIconCompiler(string baseClass, string iconPath, string iconFileType)
        {
            _baseClass = baseClass;
            _iconPath = iconPath;
            _iconFileType = iconFileType;
        }

        public string CompileCss()
        {
            string css = "." + _baseClass + "{display:inline-block;width:1em;height:1em;background-size:cover;background-repeat:no-repeat;vertical-align:text-bottom;position:relative;top:-.1em}";

            var files = Directory.EnumerateFiles(_iconPath, $"*.{_iconFileType}");
            foreach (string file in files)
            {
                css += compileIcon(file);
            }

            return css;
        }

        private string compileIcon(string file)
        {
            string iconName = file.Replace("." + _iconFileType, "");
            iconName = iconName.Replace(_iconPath, "");

            return $".{_baseClass}.{iconName}{{background-image:url('{file}');}}";
        }
    }
}