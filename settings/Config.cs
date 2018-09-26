using ORSProject.error_handle;
using ORSProject.file_handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ORSProject.settings
{
    public class Config
    {

        Algorithms Algorithm;
        bool DoSensitivityAnalysis;
        int Iterations;
        bool DoGraph;
        string InputFile;
        string OutputFile;
        private string[] algorithms = { "primal", "twophase", "dual", "branch", "cutting" };
        private bool[] settings = { false, false, false, false, false, false };

        public Config() { }

        public Config loadConfig()
        {
            Reader reader = new Reader();
            List<string> rawData = reader.getRawDataFromConfigFile(Globals.CONFIG_NAME);

            foreach (string line in rawData)
            {
                string varName = line.Split('=')[0];
                string varValue = line.Split('=')[1];

                if (varName == "algorithm" && this.algorithms.Contains(varValue))
                {
                    this.Algorithm = (Algorithms)Array.FindIndex(algorithms, row => row.Equals(varValue));
                    settings[0] = true;
                }

                if (varName == "do_sensitivity_analysis" && this.checkIfBoolean(varValue))
                {
                    this.DoSensitivityAnalysis = bool.Parse(varValue);
                    settings[1] = true;
                }

                if (varName == "iterations" && this.checkIfInt(varValue))
                {
                    this.Iterations = int.Parse(varValue);
                    settings[2] = true;
                }

                if (varName == "do_graph" && this.checkIfBoolean(varValue))
                {
                    this.DoGraph = bool.Parse(varValue);
                    settings[3] = true;
                }

                if (varName == "input_file")
                {
                    this.InputFile = this.sanitizeString(varValue);
                    Globals.INPUT_NAME = this.InputFile;
                    settings[4] = true;
                }

                if (varName == "output_file")
                {
                    this.OutputFile = this.sanitizeString(varValue);
                    Globals.OUTPUT_NAME = this.OutputFile;
                    settings[5] = true;
                }

    
            }

            if (settings.Contains(false)) { ErrorHandler.getInstance().messageAndExit("Incorrect Config Parameters"); }

            return this;
        }

        private bool checkIfBoolean(string value)
        {
            bool tryValue;
            return bool.TryParse(value, out tryValue);
        }

        private bool checkIfInt(string value)
        {
            int tryValue;
            return int.TryParse(value, out tryValue);
        }

        private string sanitizeString(string value)
        {            
            return Regex.Replace(value, "[^a-zA-Z0-9_]", "") + ".txt";
        }

        public enum Algorithms
        {
            Primal = 0,
            TwoPhase,
            Dual,
            BranchBound,
            CuttingPlane
        }

    }
}
