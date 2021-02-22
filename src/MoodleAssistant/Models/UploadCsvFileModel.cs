using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Models
{
    public class UploadCsvFileModel
    {
        public IFormFile CsvAnswers;

        public Error Error;

        private readonly string[] _mimeTypes = {"application/vnd.ms-excel", "text/csv"};

        public bool IsCsv()
        {
            return _mimeTypes.Contains(CsvAnswers.ContentType);
        }

        public bool IsEmpty()
        {
            using var streamReader = new StreamReader(CsvAnswers.OpenReadStream(), Encoding.UTF8);
            return streamReader.EndOfStream;
        }
    }
}
