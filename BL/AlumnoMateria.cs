using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result GetMateriaAsignada(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LEscogido1DigiProEntities context = new DL.LEscogido1DigiProEntities())
                {
                    var query = context.MateriaGetAsignadas(IdAlumno).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
                            alumnomateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                            alumnomateria.Materia = new ML.Materia();
                            alumnomateria.Materia.Nombre = obj.NombreMateria;

                            alumnomateria.Alumno = new ML.Alumno();
                            alumnomateria.Alumno.IdAlumno = obj.IdAlumno.Value;

                            result.Objects.Add(alumnomateria);
                            result.Correct = true;
                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LEscogido1DigiProEntities context = new DL.LEscogido1DigiProEntities())
                {
                    var query = context.AlumnoMateriaDelete(alumnomateria.IdAlumnoMateria);

                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el delete";
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetMateriaNoAsiganda(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.LEscogido1DigiProEntities context = new DL.LEscogido1DigiProEntities())
                {
                    var query = context.AlumnoMateriaLeft(IdAlumno).ToList();
                    result.Objects = new List<object>();

                    if(query != null)
                    {

                        foreach(var obj in query)
                        {
                            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

                            alumnomateria.Materia = new ML.Materia();
                            alumnomateria.Materia.IdMateria = obj.IdMateria;
                            alumnomateria.Materia.Nombre = obj.NombreMateria;
                            alumnomateria.Materia.Costo = obj.Costo.Value;

                            result.Objects.Add(alumnomateria);
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.LEscogido1DigiProEntities context = new DL.LEscogido1DigiProEntities())
                {
                    var query = context.AlumnoMateriaAdd(alumnomateria.Alumno.IdAlumno, alumnomateria.Materia.IdMateria);
                    {
                          if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
                    }
                }
            }
           catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
