using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL2.Controllers
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
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();

            ML.Result resultalumno = BL.Alumno.GetAll();

            if (IdAlumno == null)
            {
                return View(alumno);
            }
            else 
            {
                ML.Result result = new ML.Result();
                result = BL.Alumno.GetById(IdAlumno.Value);

                if (result.Correct)
                {
                    alumno = ((ML.Alumno)result.Object);
                    return View(alumno);
                }
                else
                {

                }
            }
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
        public ActionResult Delete(int IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.IdAlumno = IdAlumno;
            ML.Result result = BL.Alumno.Delete(alumno);

            if (result.Correct)
            {
                ViewBag.message = "Se ha eliminado exitosamente el registro";
            }
            else
            {
                ViewBag.message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

            }
            return View();
        }

	}
}