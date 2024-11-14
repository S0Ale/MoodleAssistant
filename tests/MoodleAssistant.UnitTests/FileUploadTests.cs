using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoodleAssistant.Controllers;
using MoodleAssistant.Models;
using MoodleAssistant.Utils;
using Moq;
using MyTested.AspNetCore.Mvc.Builders.Http;
using MyTested.AspNetCore.Mvc.Internal.Http;
using MyTested.AspNetCore.Mvc.Utilities.Extensions;
using NUnit.Framework;

namespace MoodleAssistant.UnitTests;

[TestFixture]
internal class FileUploadTests {

    private MainController controller;

    [SetUp]
    public void Setup() {
        controller = new MainController();
    }

    [Test]
    public void UploadXML_NonXMLFile(){
        var xml = TestService.GetFileResource("txtFile.txt"); // wrong file
        var list = new Mock<IFormFileCollection>();
        list.Setup(l => l.GetFile(It.IsAny<String>())).Returns(xml);
        list.Setup(l => l.Count).Returns(2);

        var form = new Mock<IFormCollection>();
        form.Setup(f => f.Files).Returns(list.Object);

        var res = controller.UploadFiles(form.Object) as ViewResult;
        var m = res.Model as MainModel;
        var error = m.Error;
        //Assert.That(m.RenderParameters, Is.EqualTo(false));
        Assert.That(error, Is.EqualTo(Error.NonXmlFile));
    }

    [TearDown]
    public void TearDown() {
        controller.Dispose();
    }
}
