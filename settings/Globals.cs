using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORSProject.settings
{
    public static class Globals
    {
        public static string CONFIG_NAME = "config.txt";

        public static string INPUT_NAME = "input.txt";

        public static string OUTPUT_NAME = string.Format("output - {0}.txt", DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt"));

        public static string LOG_NAME = "log.txt";

        public static Config CONFIG;

    }
}
