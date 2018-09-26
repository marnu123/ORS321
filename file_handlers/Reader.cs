using ORSProject.error_handle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ORSProject.file_handlers
{
    class Reader
    {

        public Reader()
        {

        }

        public List<string> getRawDataFromConfigFile(string filename)
        {
            List<string> rawData = new List<string>();

            try
            {

                using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            if (checkForValidLine(line.Replace(" ", string.Empty)))
                            {
                                rawData.Add(line.Replace(" ", string.Empty));
                            }                     
                        }
                    }
                }


            }
            catch (Exception exception)
            {
                ErrorHandler.getInstance().handle(exception, true);
            }

            return rawData;
        }

        public List<string> getRawDataFromInputFile(string filename)
        {
            List<string> rawData = new List<string>();

            try
            {

                using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            if (checkForValidInputLine(line))
                            {
                                rawData.Add(line);
                            }
                        }
                    }
                }


            }
            catch (Exception exception)
            {
                ErrorHandler.getInstance().handle(exception, true);
            }

            return rawData;
        }

        private bool checkForValidLine(string value)
        {
            if ( !string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value) )
            {
                if ((value.Trim().Substring(0, 1) != "#") && (value.Split('=').Length == 2))
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        private bool checkForValidInputLine(string value)
        {
            if (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
            {
                if ((value.Trim().Substring(0, 1) != "#"))
                {
                    return true;
                }
                return false;
            }

            return false;
        }

    }
}
