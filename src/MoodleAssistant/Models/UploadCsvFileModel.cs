using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Models
{
    public class UploadCsvFileModel
    {
        public IFormFile CsvAnswers;

        public Error Error;

        private readonly string[] _mimeTypes = {"application/vnd.ms-excel", "text/csv"};

        public IEnumerable<string> QuestionParametersList;

        public IEnumerable<string> AnswersParametersList;

        public bool IsCsv()
        {
            return _mimeTypes.Contains(CsvAnswers.ContentType);
        }

        public bool IsEmpty()
        {
            using var streamReader = new StreamReader(CsvAnswers.OpenReadStream(), Encoding.UTF8);
            return streamReader.EndOfStream;
        }

        public bool HasValidHeader()
        {
            using var fileReader = new StreamReader(CsvAnswers.OpenReadStream());
            using var csv = new CsvReader(fileReader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();
            var headerRow = csv.HeaderRecord;
            var questionAndAnswerList = (QuestionParametersList ?? Enumerable.Empty<string>())
                .Concat(AnswersParametersList ?? Enumerable.Empty<string>()).ToList();
            return headerRow.All(questionAndAnswerList.Contains) &&
                   Equals(headerRow.Count(), questionAndAnswerList.Count());
        }

        public bool IsWellFormed()
        {
            using var fileReader = new StreamReader(CsvAnswers.OpenReadStream());
            using var csv = new CsvReader(fileReader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();
            var numOfHeaders = csv.Parser.Count;
            while (csv.Read())
            {
                if (numOfHeaders != csv.Parser.Count)
                    return false;
                for (var i = 0; i < csv.Parser.Count; i++)
                    if(string.IsNullOrEmpty(csv.GetField<string>(i)))
                        return false;
            }
            return true;
        }
    }
}
