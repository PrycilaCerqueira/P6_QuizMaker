using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_QuizMaker
{
    internal class CSV
    {
        //TODO: Study the MS links and fix the Answers inner list
        //https://www.youtube.com/watch?v=Ch6dDFuKCV4
        //https://learn.microsoft.com/en-us/dotnet/api/system.object.gettype?view=net-7.0
        //https://learn.microsoft.com/en-us/dotnet/api/system.reflection.propertyinfo.getvalue?view=net-7.0
        //https://learn.microsoft.com/en-us/dotnet/api/system.type.getproperties?view=net-6.0

        public static void ExportFile(List<Quiz> quizDB)
        {
            //Created the CSV File Headers (column names)
            var colHeaders = string.Join(",", quizDB[0].GetType().GetProperties().Select(property => property.Name));

            //Createds the CSV rows (row data)
            var rows = from quiz in quizDB
                             let row  = string.Join(",",quiz.GetType().GetProperties().Select(p => p.GetValue(quiz)))
                             select row;

            //Creates a new list 
            var csvData = new List<string>();
            csvData.Add(colHeaders);
            csvData.AddRange(rows);

            //File export name and location
            string csvFilePath = @"C:\Users\pry_p\source\repos\P6_QuizMaker\QuizDB_Export.csv";
            System.IO.File.WriteAllLines(csvFilePath, csvData);
        }
    }
}
