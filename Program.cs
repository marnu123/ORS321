using ORSProject.classes;
using ORSProject.file_handlers;
using ORSProject.settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            startUp();

            Console.ReadKey();
        }

        private static void startUp()
        {
            Writer writer = new Writer();
            writer.checkConfigFile();

            Globals.CONFIG = new Config().loadConfig();

            Input input = new Input();
            input.loadInputFile();
        }

        
    }
}
