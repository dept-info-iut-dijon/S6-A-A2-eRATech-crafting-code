namespace Tax.Simulator.Api.Exceptions
{
    /// <summary>
    /// Classe d'exception si le nombre d'enfants est négatif.
    /// </summary>
    public class EnfantNegatifException : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="EnfantNegatifException"/>.
        /// </summary>
        public EnfantNegatifException() : base(Ressources._string.EnfantNegatifErreur)
        {
            
        }
    }
}
