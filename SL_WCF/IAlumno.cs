using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    [ServiceContract]
    interface IAlumno
    {
        [OperationContract]
        SL_WCF.Result Add(ML.Alumno alumno);

        [OperationContract]
        SL_WCF.Result Delete(ML.Alumno alumno);

        [OperationContract]
        SL_WCF.Result Update(ML.Alumno alumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SL_WCF.Result GetById(int IdAlumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SL_WCF.Result GetAll();
    }
}
