using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL2.Controllers
{
    public class AlumnoMateriaController : Controller
    {

        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.GetAll();

            alumno.Alumnos = result.Objects;

            return View(alumno);
        }
         [HttpGet]
        public ActionResult GetMateriaAsignada(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.GetMateriaAsignada(IdAlumno);
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            ML.Result resultalumno = BL.Alumno.GetById(IdAlumno);

            alumnomateria.AlumnoMaterias = result.Objects;
            alumnomateria.Alumno = ((ML.Alumno)resultalumno.Object);

            return View(alumnomateria);
        }
        public ActionResult Delete(int IdAlumnoMateria, int IdAlumno)
        {
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
            alumnomateria.IdAlumnoMateria = IdAlumnoMateria;
            ML.Result result = BL.AlumnoMateria.Delete(alumnomateria);

            ViewBag.MateriasAsignadas = true;
            ViewBag.IdAlumno = IdAlumno;

            if (result.Correct)
            {
                ViewBag.message = "Se ha eliminado exitosamente el registro";
            }
            else
            {
                ViewBag.message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult GetMateriaSinAsignar(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.GetMateriaNoAsiganda(IdAlumno);
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            ML.Result resultalumno = BL.Alumno.GetById(IdAlumno);

            alumnomateria.AlumnoMaterias = result.Objects;
            alumnomateria.Alumno = ((ML.Alumno)resultalumno.Object);

            return View(alumnomateria);
        }
        [HttpPost]

        public ActionResult GetMateriaSinAsignar(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            if (alumnomateria.AlumnoMaterias != null)
            {
                foreach (string IdMateria in alumnomateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnomateriaItem = new ML.AlumnoMateria();

                    alumnomateriaItem.Alumno = new ML.Alumno();
                    alumnomateriaItem.Alumno.IdAlumno = alumnomateria.Alumno.IdAlumno;

                    alumnomateriaItem.Materia = new ML.Materia();
                    alumnomateriaItem.Materia.IdMateria = int.Parse(IdMateria);

                    ML.Result resul = BL.AlumnoMateria.Add(alumnomateriaItem);
                }
                result.Correct = true;
                ViewBag.Message = "Se ha actualizado al alumno";
                ViewBag.MateriasAsignadas = true;
                ViewBag.IdAlumno = alumnomateria.Alumno.IdAlumno;
            }
            else
            {
                result.Correct = false;
            }
            return PartialView("Modal");
        }
	}

}