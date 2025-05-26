using System.Runtime.Serialization;

namespace ClubMeBack_End.Common
{
    public abstract class Resultado
    {
        private bool blnExitoso = false;
        private Error? exException = null;
        private int intCantidadPaginas = 1;

        public bool Exitoso
        {
            get { return blnExitoso; }
            set { blnExitoso = value; }
        }

        public int CantidadPaginas
        {
            get { return intCantidadPaginas; }
            set { intCantidadPaginas = value; }
        }

        public Error? Error
        {
            get { return exException; }
            set { exException = value; }
        }
    }
}
