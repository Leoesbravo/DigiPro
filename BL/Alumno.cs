using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
   public class Alumno
    {
       public static ML.Result Add(ML.Alumno alumno)
       {
           ML.Result result = new ML.Result();

           try
           {
               using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
               {
                   string query = "AddAlumno";

                   using(SqlCommand cmd = new SqlCommand()) 
                   {
                       
                            cmd.Connection = context;
                            cmd.CommandText = query;
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter[] collection = new SqlParameter[3];

                            collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                            collection[0].Value = alumno.Nombre;

                            collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                            collection[1].Value = alumno.ApellidoPaterno;

                            collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                            collection[2].Value = alumno.ApellidoMaterno;

                            cmd.Parameters.AddRange(collection);

                            cmd.Connection.Open();

                            int RowsAffected = cmd.ExecuteNonQuery();

                            cmd.Connection.Close();

                            if (RowsAffected > 0)
                            {
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se ha podido dar de alta al alumno";
                            }
                       
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
       public static ML.Result Delete(ML.Alumno alumno)
       {
           ML.Result result = new ML.Result();


           try
           {
               using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
               {
                   using (SqlCommand cmd = new SqlCommand("DeleteAlumno", context))
                   {
                       cmd.Connection = context;
                       cmd.CommandType = CommandType.StoredProcedure;

                       SqlParameter collection = new SqlParameter();

                       collection = new SqlParameter("IdAlumno", SqlDbType.Int);
                       collection.Value = alumno.IdAlumno;

                       cmd.Parameters.Add(collection);
                       cmd.Connection.Open();

                       int RowsAffected = cmd.ExecuteNonQuery();

                       if (RowsAffected > 0)
                       {
                           result.Correct = true;
                       }
                       else
                       {
                           result.Correct = false;
                           result.ErrorMessage = "No se pudo eliminar el registro.";
                       }
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
       public static ML.Result Update(ML.Alumno alumno)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
               {

                   using (SqlCommand cmd = new SqlCommand("UsuarioUpdate", context))
                   {
                       cmd.Connection = context;
                       cmd.CommandType = CommandType.StoredProcedure;


                       SqlParameter[] collection = new SqlParameter[4];

                       collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                       collection[0].Value = alumno.Nombre;

                       collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                       collection[1].Value = alumno.ApellidoPaterno;

                       collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                       collection[2].Value = alumno.ApellidoMaterno;

                       collection[3] = new SqlParameter("IdAlumno", SqlDbType.VarChar);
                       collection[3].Value = alumno.IdAlumno;

                       cmd.Parameters.AddRange(collection);
                       cmd.Connection.Open();

                       int RowsAffected = cmd.ExecuteNonQuery();

                       cmd.Connection.Close();

                       if (RowsAffected > 0)
                       {
                           result.Correct = true;
                       }
                       else
                       {
                           result.Correct = false;
                           result.ErrorMessage = "El registro no pudo ser modificado.";
                       }
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
       public static ML.Result GetById(int? IdAlumno)
       {
           ML.Result result = new ML.Result();

           try
           {
               using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
               {
                   string query = ("GetByIdAlumno");

                   using (SqlCommand cmd = new SqlCommand())
                   {
                       cmd.Connection = context;
                       cmd.CommandText = query;
                       cmd.CommandType = CommandType.StoredProcedure;

                       SqlParameter[] collection = new SqlParameter[1];

                       collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                       collection[0].Value = IdAlumno;

                       cmd.Parameters.AddRange(collection);
                       cmd.Connection.Open();

                       DataTable tableAlumno = new DataTable();

                       SqlDataAdapter da = new SqlDataAdapter(cmd);

                       da.Fill(tableAlumno);

                       if (tableAlumno.Rows.Count > 0)
                       {
                           DataRow row = tableAlumno.Rows[0];

                           ML.Alumno alumno = new ML.Alumno();

                           alumno.IdAlumno = int.Parse(row[0].ToString());
                           alumno.Nombre = row[1].ToString();
                           alumno.ApellidoPaterno = row[2].ToString();
                           alumno.ApellidoMaterno = row[3].ToString();
                          
                           result.Object = alumno;
                           result.Correct = true;
                       }
                       else
                       {
                           result.Correct = false;
                           result.ErrorMessage = " No existen registros en la tabla";
                       }
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
       public static ML.Result GetAll()
       {
           ML.Result result = new ML.Result();

           try
           { 
             using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
             {
                 using (SqlCommand cmd = new SqlCommand("GetAllAlumno"))
                  {
                      cmd.Connection = context;
                      cmd.CommandType = CommandType.StoredProcedure;

                      DataTable tableAlumno = new DataTable();

                      SqlDataAdapter da = new SqlDataAdapter(cmd);

                      da.Fill(tableAlumno);

                      if (tableAlumno.Rows.Count > 0)
                      {
                          result.Objects = new List<object>();

                          foreach (DataRow row in tableAlumno.Rows)
                          {
                              ML.Alumno alumno  = new ML.Alumno();

                              alumno.IdAlumno = int.Parse(row[0].ToString());
                              alumno.Nombre = row[1].ToString();
                              alumno.ApellidoPaterno = row[2].ToString();
                              alumno.ApellidoMaterno = row[3].ToString();

                              result.Objects.Add(alumno);
                          }
                          result.Correct = true;
                      }
                      else
                      {
                          result.Correct = false;
                          result.ErrorMessage = "No existen registros en la tabla";
                      }
                  }
             }
           }
           catch(Exception ex)
           {
               result.Correct = false;
               result.ErrorMessage = ex.Message;
               result.Ex = ex;
           }
           return result;
       }
      
    }
}
