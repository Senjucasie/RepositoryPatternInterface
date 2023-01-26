using Microsoft.AspNetCore.Mvc;
using PersonReader.CSV;
using PersonReader.Interface;
using PersonReader.Library;
using PersonReader.Service;
using PersonReader.SQL;
using System.Collections.Generic;

namespace PeopleViewer.Controllers
{
    public class PeopleController : Controller
    {
        private ReaderFactory _readerFactory = new ReaderFactory();

        public IActionResult UseService()
        {
            ViewData["Title"] = "Using a Web Service";
            return PopulatePeople("Service");
        }

        public IActionResult UseCSV()
        {
            ViewData["Title"] = "Using a CSV Database";
            return PopulatePeople("CSV");
        }

        public IActionResult UseSQL()
        {
            ViewData["Title"] = "Using a SQL Database";
            return PopulatePeople("SQL");
        }

        private IActionResult PopulatePeople(string readertype)
        {
            IPersonReader personreader = _readerFactory.GetReader(readertype);
            IEnumerable<Person> personlist = personreader.GetPeople();
            ViewData["ReaderType"] = personreader.GetType().ToString();
            return View("Index", personlist);
        }
    }
}