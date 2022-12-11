using Microsoft.AspNetCore.Mvc;
using PersonReader.CSV;
using PersonReader.Interface;
using PersonReader.Service;
using PersonReader.SQL;
using System.Collections.Generic;

namespace PeopleViewer.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult UseService()
        {
            ViewData["Title"] = "Using a Web Service";
            IPersonReader personreader = new ServiceReader();
            return PopulatePeople(personreader);
        }

        public IActionResult UseCSV()
        {
            ViewData["Title"] = "Using a CSV Database";
            IPersonReader personreader = new CSVReader();
            return PopulatePeople(personreader);
        }

        public IActionResult UseSQL()
        {
            ViewData["Title"] = "Using a SQL Database";
            IPersonReader personreader = new SQLReader();
            return PopulatePeople(personreader);
        }

        private IActionResult PopulatePeople(IPersonReader personreader)
        {
            IEnumerable<Person> personlist = personreader.GetPeople();
            ViewData["ReaderType"] = personreader.GetType().ToString();
            return View("Index", personlist);
        }
    }
}