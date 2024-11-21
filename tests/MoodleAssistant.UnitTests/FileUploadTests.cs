using System;
using MoodleAssistant.Controllers;
using NUnit.Framework;

namespace MoodleAssistant.UnitTests;

[TestFixture]
internal abstract class FileUploadTests {

    protected ReplicatorController controller;

    [SetUp]
    public void Setup() {
        controller = new ReplicatorController();
    }

    [TearDown]
    public void TearDown() {
        controller.Dispose();
    }
}
