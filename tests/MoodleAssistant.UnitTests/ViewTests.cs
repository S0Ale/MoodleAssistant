using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoodleAssistant.Controllers;
using Moq;
using NUnit.Framework;

namespace MoodleAssistant.UnitTests;

[TestFixture]
internal class ViewTests{

    private Dictionary<string, Controller> _controllers;

    [SetUp]
    public void Setup() {
        _controllers = new Dictionary<string, Controller> {
            { "Main", new MainController() },
            { "Home", new HomeController(new Mock<ILogger<HomeController>>().Object) }
        };
    }

    [Test]
    public void Base_Test() {
        var result = ((HomeController)_controllers["Home"]).Index() as ViewResult;
        Assert.That(result.ViewName, Is.EqualTo("Index")); //returns null
    }

    [Test]
    public void Main_Index_Test() {
        var result = ((MainController)_controllers["Main"]).Index() as ViewResult;
        Assert.That(result.ViewName, Is.EqualTo("Index"));
    }

    [TearDown]
    public void TearDown() {
        foreach (var controller in _controllers.Values)
            controller.Dispose();
    }
}
