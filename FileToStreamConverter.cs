using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StreamSourceTest
{
    public class FileToStreamConverter : IValueConverter
    {
        protected Assembly IconAssembly { get; private set; }
        protected string ResourceStreamPrefix { get; private set; }

        public FileToStreamConverter()
        {
            IconAssembly = typeof(FileToStreamConverter).Assembly;
            AssemblyName iconAssemblyName = IconAssembly.GetName();
            ResourceStreamPrefix = iconAssemblyName.Name + ".";
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Stream pic = IconAssembly.GetManifestResourceStream(ResourceStreamPrefix + (string)value)!;
            return pic;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
