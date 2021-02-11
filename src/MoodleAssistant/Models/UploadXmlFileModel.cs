using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MoodleAssistant.Utils;

namespace MoodleAssistant.Models
{
    public class UploadXmlFileModel
    {
        public IFormFile XmlQuestion;

        public string Error;
    }

}
