using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodleAssistant.Controllers
{
    public class CsvController : Controller
    {
        public IActionResult Upload()
        {
            return View();
        }
    }
}
