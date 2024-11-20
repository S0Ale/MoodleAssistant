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
        var m = res.Model as ReplicatorModel;
        Assert.That(m.Error, Is.EqualTo(Error.NonCsvFile));
    }

    [Test]
    public void UploadCSV_EmptyCSV(){
        var csv = TestService.GetFileResource("EmptyCsv.csv", System.Net.Mime.MediaTypeNames.Text.Csv);

        var form = TestService.GetFormsMock(xml, csv);
        var res = controller.UploadFiles(form) as ViewResult;
        var m = res.Model as ReplicatorModel;
        Assert.That(m.Error, Is.EqualTo(Error.EmptyFile));
    }

    [Test]
    public void UploadCSV_CSVWithoutHeader(){
        var csv = TestService.GetFileResource("CsvWithoutHeader.csv", System.Net.Mime.MediaTypeNames.Text.Csv);

        var form = TestService.GetFormsMock(xml, csv);
        var res = controller.UploadFiles(form) as ViewResult;
        var m = res.Model as ReplicatorModel;
        Assert.That(m.Error, Is.EqualTo(Error.CsvInvalidHeader));
    }

    [Test]
    public void UploadCSV_CSVBadFormed(){
        var csv = TestService.GetFileResource("CsvBadFormed.csv", System.Net.Mime.MediaTypeNames.Text.Csv);

        var form = TestService.GetFormsMock(xml, csv);
        var res = controller.UploadFiles(form) as ViewResult;
        var m = res.Model as ReplicatorModel;
        Assert.That(m.Error, Is.EqualTo(Error.CsvBadFormed));
    }

    [Test]
    public void UploadCSV_CSVWithSemicolonSeparator(){
        var csv = TestService.GetFileResource("CsvWithSemiColonSeparator.csv", System.Net.Mime.MediaTypeNames.Text.Csv);

        var form = TestService.GetFormsMock(xml, csv);
        var res = controller.UploadFiles(form) as ViewResult;
        var m = res.Model as ReplicatorModel;
        Assert.That(m.Error, Is.EqualTo(Error.CsvInvalidHeader));
    }

    [Test]
    public void UploadCSV_CorrectCSVFile(){
        var csv = TestService.GetFileResource("MoodleQuestionOk.csv", System.Net.Mime.MediaTypeNames.Text.Csv);

        var form = TestService.GetFormsMock(xml, csv);
        var res = controller.UploadFiles(form) as ViewResult;
        var m = res.Model as ReplicatorModel;
        Assert.Multiple(() => {
            Assert.That(m.Error, Is.EqualTo(Error.NoErrors));
            Assert.That(m.RenderParameters, Is.EqualTo(true));
        });
    }
}
