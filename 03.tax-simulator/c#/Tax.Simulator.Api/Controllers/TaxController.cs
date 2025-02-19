using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tax.Simulator.Api.Exceptions;
using Tax.Simulator.Entities;

namespace Tax.Simulator.Api.Controllers
{
    [Route("api/tax")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        /// <summary>
        /// Permet de calculer les taxes d'une personne.
        /// </summary>
        /// <param name="situationFamiliale">Situation familiale de la personne.</param>
        /// <param name="salaireMensuel">Salaire mensuel de la personne.</param>
        /// <param name="salaireMensuelConjoint">Salaire mensuel du conjoint de la personne.</param>
        /// <param name="nombreEnfants">Nombre d'enfants de la personne.</param>
        /// <returns>Taxe de la personne</returns>
        [HttpGet ("calculate")]
        public IActionResult Calculate(string situationFamiliale, decimal salaireMensuel, decimal salaireMensuelConjoint, int nombreEnfants)
        {
            try
            {
                Personne personne = new Personne(SituationsFamilialesExtensions.StringToSituation(situationFamiliale), salaireMensuel, salaireMensuelConjoint, nombreEnfants);
                this.VerifierPersonne(personne);

                return Ok(
                    Simulateur.CalculerImpotsAnnuelPersonne(personne)
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void VerifierPersonne(Personne personne)
        {
            if (personne.SituationFamiliale is not SituationsFamiliales.CELIBATAIRE or is not SituationsFamiliales.MARIE_PACSE)
            {
                throw new SituationFamilialeInconnueException();
            }

            if (personne.SalaireMensuel <= 0)
            {
                throw new SalaireNegatifException();
            }

            if (personne.SituationFamiliale is not SituationsFamiliales.MARIE_PACSE && personne.SalaireConjoint <= 0)
            {
                throw new SalaireNegatifException();
            }

            if (personne.nbEnfants < 0)
            {
                throw new EnfantNegatifException();
            }
        }
    }
}
