namespace Tax.Simulator.Api.Exceptions
{
    /// <summary>
    /// Classe d'exception si le salaire est négatif.
    /// </summary>
    public class SalaireNegatifException : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="SalaireNegatifException"/>.
        /// </summary>
        public SalaireNegatifException() : base(Ressources._string.SalairePositifErreur)
        {
        }
    }
}
