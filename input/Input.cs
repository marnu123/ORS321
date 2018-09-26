using ORSProject.error_handle;
using ORSProject.file_handlers;
using ORSProject.settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ORSProject.input
{
    public class Input
    {

        public ProblemType Problem;
        public SortedList<int,decimal> ObjectiveFunction;
        public 


        public Input()
        {

        }

        public void loadInputFile()
        {
            Reader reader = new Reader();
            List<string> rawData = reader.getRawDataFromInputFile(Globals.INPUT_NAME);

            //Regex regex = new Regex(@"\-[^+-]+");
            //var matches = regex.Matches(rawData.ElementAt(0));
            //string[] objectiveFunction = matches.Cast<Match>().Select(x => x.Value).ToArray();

            string lineOne = rawData.ElementAt(0);

            string problemString = lineOne.Substring(0, 3).ToLower();
            if (problemString != "min" || problemString != "max")
            {
                ErrorHandler.getInstance().messageAndExit("Min or Max problem parameter not found in line 1");
            } else
            {
                Problem = (problemString == "min" ? ProblemType.Minimization : ProblemType.Maximization);
            }

            lineOne = lineOne.Remove(0, 4);

            string[] objectiveFunctionList = lineOne.Split(' ');
            if (objectiveFunctionList.Length == 0) ErrorHandler.getInstance().messageAndExit("No objective function specified in line 1");

            if (objectiveFunctionList.Length == 1) ErrorHandler.getInstance().message("Only one decision variable in line 1 - Please handle me");



        }

        

        public enum ProblemType
        {
            Maximization = 0,
            Minimization
        }
    }
}
