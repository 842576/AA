using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using 仓库管理系统.Entities;

namespace 仓库管理系统
{
    internal class AppData
    {
        public static Member CurrentUser { get; set; }
        public static MainWindow MainWindow { get; set; }
        public static ContentControl Container { get; set; }
        public static ContentControl MainRegion { get; set; }
    }
}
