using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    [ServiceContract]
    interface IMateria
    {
        [OperationContract]
        SL_WCF.Result Add(ML.Materia materia);

        [OperationContract]
        SL_WCF.Result Delete(ML.Materia materia);

        [OperationContract]
        SL_WCF.Result Update(ML.Materia materia);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Materia))]
        SL_WCF.Result GetById(int IdMateria);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Materia))]
        SL_WCF.Result GetAll();
    }
}
