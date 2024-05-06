using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Helpers
{
    public class ResponseWrapper<T>
    {
        public T Respuesta;
        public bool HayError;
        public string Error;

        public ResponseWrapper(T respuesta, bool hayerror)
        {
            Respuesta = respuesta;
            HayError = hayerror;
        }

        public ResponseWrapper(string error, bool hayerror)
        {
            Error = error;
            HayError= hayerror;
        }

        public ResponseWrapper(bool hayerror)
        {
            HayError = hayerror;
        }
    }
}
