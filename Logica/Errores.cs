namespace ClubMeBack_End.Logica
{
    public class Errores
    {
        public static Common.Error LlenarError(Exception objException, string strMensajeUsuario)
        {
            Common.Error infoError = new Common.Error();
            infoError.Mensaje = objException.ToString();
            infoError.TipoError = objException.GetType().Name;
            infoError.Fuente = objException.Source;
            infoError.Pila = objException.StackTrace;
            infoError.MensajeUsuario = objException.Message;
            if (objException.InnerException != null)
            {
                infoError.InnerException = objException.InnerException.ToString();
            }
            else
            {
                infoError.InnerException = string.Empty;
            }

            return infoError;
        }

        public static Common.Error LlenarError(string MensajeUsuario, string Mensaje, string TipoError, string Fuente, string Pila, string InnerException)
        {
            Common.Error infoError = new Common.Error
            {
                Mensaje = Mensaje,
                TipoError = TipoError,
                Fuente = Fuente,
                Pila = Pila,
                MensajeUsuario = MensajeUsuario,
                InnerException = InnerException
            };

            return infoError;
        }


        public static void registrarErrores(Exception pobjException, string pstrModulo, string pstrFuncion)
        {
            //TODO: Implementar la funcionalidad para registrar el log de errores
        }
    }
}
