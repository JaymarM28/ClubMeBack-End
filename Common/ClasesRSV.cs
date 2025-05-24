using System.Runtime.Serialization;

namespace ClubMeBack_End.Common
{
    public class ClasesRSV
    {
        public class RSV_ResultadoEjecucion : Resultado
        {
            private int intRegistrosAfectados = 0;
            private int intIDRegistro = -1;
            private string strMensaje = string.Empty;

            public int RegistrosAfectados
            {
                get { return intRegistrosAfectados; }
                set { intRegistrosAfectados = value; }
            }

            public int IDRegistro
            {
                get { return intIDRegistro; }
                set { intIDRegistro = value; }
            }

            public string Mensaje
            {
                get { return strMensaje; }
                set
                {
                    strMensaje = value;
                }
            }

            public RSV_ResultadoEjecucion()
            {

            }
        }

        public class RSV_Resultado<T> : Resultado
        {
            T? colDatos;

            public T? Datos
            {
                get { return colDatos; }
                set { colDatos = value; }
            }
        }

        public class RSV_ResultadoArchivo : Resultado
        {
            private byte[]? objArchivo;

            public byte[]? Impresion
            {
                get { return objArchivo; }
                set { objArchivo = value; }
            }
        }
    }
}
