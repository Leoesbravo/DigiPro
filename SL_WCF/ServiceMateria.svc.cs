using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceMateria" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceMateria.svc or ServiceMateria.svc.cs at the Solution Explorer and start debugging.
    public class ServiceMateria : IMateria
    {
        public SL_WCF.Result Add(ML.Materia materia)
        {
            ML.Result result = BL.Materia.Add(materia);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF.Result Delete(ML.Materia materia)
        {
            ML.Result result = BL.Materia.Delete(materia);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF.Result Update(ML.Materia materia)
        {
            ML.Result result = BL.Materia.Update(materia);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF.Result GetById(int IdMateria)
        {
            ML.Result result = BL.Materia.GetById(IdMateria);
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF.Result GetAll()
        {
            ML.Result result = BL.Materia.GetAll();
            return new SL_WCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
    }
}
