using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tax.Simulator.Entities;

namespace Tax.Simulator.Api.Controlleurs
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
        /// <returns></returns>
        [HttpGet ("calculate")]
        public IActionResult Calculate(string situationFamiliale, decimal salaireMensuel, decimal salaireMensuelConjoint, int nombreEnfants)
        {
            try
            {
                return Ok(
                    Simulateur.CalculerImpotsAnnuelPersonne(new Personne(SituationsFamilialesExtensions.StringToSituation(situationFamiliale), salaireMensuel, salaireMensuelConjoint, nombreEnfants))
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
