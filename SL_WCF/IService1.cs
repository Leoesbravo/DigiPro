﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
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
