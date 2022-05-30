using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace PL2.Controllers
{
    public class MateriaController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Materia resultmateria = new ML.Materia();
            resultmateria.Materias = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18999/api/");

                var responseTask = client.GetAsync("Materia/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                        resultmateria.Materias.Add(resultItemList);
                    }
                }
            }

            return View(resultmateria);
        }
        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            ML.Result resultmateria = BL.Materia.GetAll();

            if (IdMateria == null)
            {
                return View(materia);
            }
            else //esto es para el update
            {
                ML.Result result = new ML.Result();
                using (var client = new HttpClient())
                    try
                    {
                        client.BaseAddress = new Uri("http://localhost:18999/api/");
                        var responseTask = client.GetAsync("Materia/GetById/" + IdMateria);
                        responseTask.Wait();
                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Materia resultItemList = new ML.Materia();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            materia = ((ML.Materia)result.Object);
                            materia.Materias = resultmateria.Objects;
                            return View(materia);

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla ";
                        }
                    }


                        //if (result.Correct)
                    //{
                    //    materia = ((ML.Materia)result.Object);
                    //    return View(materia);
                    //}
                    //else
                    //{

                        //}
                    //}
                    //return View();
                    catch (Exception ex)
                    {
                        result.Correct = false;
                        result.ErrorMessage = ex.Message;
                    }

                return View();
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();


            char[] ValidacionNombreMateria=System.Configuration.ConfigurationManager.AppSettings["ValidacionNombreMateria"].ToCharArray();
            // &<>/
            foreach (char caracter in ValidacionNombreMateria)
            {
                materia.Nombre = materia.Nombre.Replace(caracter.ToString(),"");
            }

                if (materia.IdMateria == 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:18999/api/");

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
                        postTask.Wait();

                        var resultAseguradora = postTask.Result;
                        if (resultAseguradora.IsSuccessStatusCode)
                        {
                            ViewBag.Mensaje = "La materia se registro correctamente";
                        }
                        else
                        {
                            ViewBag.Mensaje = "La materia no se ha registrado correctamente" + result.ErrorMessage;
                        }
                    }

                }
                else
                {
                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("http://localhost:18999/api/");


                        var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Update/" + materia.IdMateria, materia);
                        postTask.Wait();

                        var resultmateria = postTask.Result;

                        if (resultmateria.IsSuccessStatusCode)
                        {
                            ViewBag.Mensaje = "La materia se ha actualizado correctamente";
                        }
                        else
                        {
                            ViewBag.Mensaje = "La materia no se ha actualizado correctamente" + result.ErrorMessage;
                        }
                    }


                }

                return PartialView("Modal");
        }
        public ActionResult Delete(ML.Materia materia)
        {

            ML.Result resultmateria = new ML.Result();
            int IdMateria = materia.IdMateria;            

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18999/api/");

                //HTTP POST
                var postTask = client.GetAsync("Materia/Delete/" + IdMateria);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "La materia ha sido eliminada";

                }
                else
                {
                    ViewBag.Message = "La materia no pudo ser eliminada" + resultmateria.ErrorMessage;
                }
            }

            return View();
        }
	}
}