using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.GetAll();

            alumno.Alumnos = result.Objects;
            return View(alumno);
        }
        [HttpGet]
        public ActionResult Form()
        {
            ML.Alumno alumno = new ML.Alumno();

            return View();
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            if (alumno.IdAlumno == 0)
            {
                result = BL.Alumno.Add(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "El alumno fue agregado";
                }
                else
                {
                    ViewBag.Message = "El alumno no pudo ser agregado";
                }
            }
            else
            {
                result = BL.Alumno.Update(alumno);
            }
            return View();
        }

    }
}
