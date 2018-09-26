using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ORSProject.file_handlers
{
    public class Writer
    {

        public Writer() { }


        /// <summary>
        /// If the Config file does not exist, the program will create a default config file.
        /// </summary>
        public void checkConfigFile()
        {
            try
            {

                if (!File.Exists(settings.Globals.CONFIG_NAME))
                {
                    using (StreamWriter writer = File.AppendText(settings.Globals.CONFIG_NAME))
                    {
                        writer.WriteLine("# Which solving algorithm to use to solve the problem.");
                        writer.WriteLine("# Can be ' primal, twophase, dual, branch, cutting '.");
                        writer.WriteLine("algorithm=primal");
                        writer.WriteLine(" ");
                        writer.WriteLine(" ");
                        writer.WriteLine("# To enable ensitivity analysis after the solving.");
                        writer.WriteLine("do_sensitivity_analysis=false");
                        writer.WriteLine(" ");
                        writer.WriteLine(" ");
                        writer.WriteLine("# Amount of iterations that the solver needs to do.");
                        writer.WriteLine("# 0 = infinite/until done.");
                        writer.WriteLine("iterations=0");
                        writer.WriteLine(" ");
                        writer.WriteLine(" ");
                        writer.WriteLine("# Do graphically solve the problem.");
                        writer.WriteLine("do_graph=false");
                        writer.WriteLine(" ");
                        writer.WriteLine(" ");
                        writer.WriteLine("# The name of the input file, without the .txt");
                        writer.WriteLine("input_file=input");
                        writer.WriteLine(" ");
                        writer.WriteLine(" ");
                        writer.WriteLine("# The name of the output file, without the .txt");
                        writer.WriteLine("output_file=output");
                        writer.WriteLine(" ");
                    }
                }


                
            }
            catch (Exception exception)
            {
                
            }
        } 


        public void writeLog(string message)
        {
            try
            {

                //if (!File.Exists(settings.Globals.LOG_NAME))
                //{
                    using (StreamWriter writer = File.AppendText(settings.Globals.LOG_NAME))
                    {
                        writer.WriteLine("message");
                        // Write error here.
                    }
                //}



            }
            catch (Exception exception)
            {

            }
        }

    }
}
