using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientCertAuthWebApi.Models;

namespace ClientCertAuthWebApi.Controllers
{
    [Authorize]
    public class StudentGradesController : Controller
    {
        private StudentRepository _repository = new StudentRepository();
        
        public ActionResult Index()
        {
            var students = _repository.GetAll();
            return View(students);
        }
    }
}
