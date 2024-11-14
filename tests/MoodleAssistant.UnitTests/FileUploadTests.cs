using System;
using MoodleAssistant.Controllers;
using NUnit.Framework;

namespace MoodleAssistant.UnitTests;

[TestFixture]
internal class FileUploadTests {

    protected MainController controller;

    [SetUp]
    public void Setup() {
        controller = new MainController();
    }



    [TearDown]
    public void TearDown() {
        controller.Dispose();
    }
}
