using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoodleAssistant.Controllers;
using Moq;
using NUnit.Framework;

namespace MoodleAssistant.UnitTests;

[TestFixture]
internal class FileUploadTests {

    private MainController controller;

    [SetUp]
    public void Setup() {
        controller = new MainController();
    }

    [Ignore("Not ready")][Test]
    public void UploadXML_NonXMLFile(){
        var xml = TestService.GetFileResource("txtFile.txt");

        IFormFileCollection files = new FormFileCollection();
        Assert.Pass();
    }

    [TearDown]
    public void TearDown() {
        controller.Dispose();
    }
}
