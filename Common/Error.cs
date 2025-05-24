using System.Runtime.Serialization;

namespace ClubMeBack_End.Common
{
    public class Error
    {
        private string strMensajeUsuario = string.Empty;
        private string strMensaje = string.Empty;
        private string strTipoError = string.Empty;
        private string strFuente = string.Empty;
        private string strPila = string.Empty;
        private string? strMensajeInnerException = null;

        public string MensajeUsuario
        {
            get { return strMensajeUsuario; }
            set { strMensajeUsuario = value; }
        }

        public string Mensaje
        {
            get { return strMensaje; }
            set { strMensaje = value; }
        }

        public string TipoError
        {
            get { return strTipoError; }
            set { strTipoError = value; }
        }

        public string Fuente
        {
            get { return strFuente; }
            set { strFuente = value; }
        }

        public string Pila
        {
            get { return strPila; }
            set { strPila = value; }
        }

        public string? InnerException
        {
            get { return strMensajeInnerException; }
            set { strMensajeInnerException = value; }
        }



    }
}
