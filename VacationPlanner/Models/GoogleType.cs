using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace VacationPlanner.Models
{
    public class GoogleType
    {

        static bool IsDataLoaded = false;

        static List<string> allTypes = new List<string>();

        public static List<string> FindAll()
        {
            LoadData();

            return new List<string>(allTypes);
        }

        private static void LoadData()
        {

            if (IsDataLoaded)
            {
                return;
            }

            var rows = new List<string[]>();

            using (var reader = File.OpenText("Models/GoogleTypes.xlsx"))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    var rowArray = CSVRowToStringArray(line);
                    if (rowArray.Length > 0)
                    {
                        rows.Add(rowArray);
                    }
                }
            }
        }

        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            var isBetweenQuotes = false;
            var valueBuilder = new StringBuilder();
            var rowValues = new List<string>();

            // Loop through the row string one char at a time
            foreach (char c in row.ToCharArray())
            {
                if ((c == fieldSeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }
    }
}
