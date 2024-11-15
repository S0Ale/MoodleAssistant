using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MoodleAssistant.UnitTests;

[TestFixture]
internal class CsvTests : FileUploadTests{

    private IFormFile xml;

    [SetUp]
    public new void Setup(){
        xml = TestService.GetCorrectXmlFile();
    }

    [Test]
    public void UploadCSV_NonCSVFile(){
        var csv = TestService.GetFileResource("txtFile.txt", System.Net.Mime.MediaTypeNames.Text.Plain);

        var form = TestService.GetFormsMock(xml, csv);
        var res = controller.UploadFiles(form) as ViewResult;
        var m = res.Model as MainModel;
        Assert.That(m.Error, Is.EqualTo(Error.NonCsvFile));
    }
}
