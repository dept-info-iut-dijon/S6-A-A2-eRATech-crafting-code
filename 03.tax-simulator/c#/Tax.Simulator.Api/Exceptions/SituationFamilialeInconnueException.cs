namespace Tax.Simulator.Api.Exceptions
{
    /// <summary>
    /// Classe d'exception si la situation familiale n'est pas reconnue.
    /// </summary>
    public class SituationFamilialeInconnueException : Exception
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="SituationFamilialeInconnueException"/>.
        /// </summary>
        public SituationFamilialeInconnueException() : base(Ressources._string.familleErreur)
        {
        }
    }
}
