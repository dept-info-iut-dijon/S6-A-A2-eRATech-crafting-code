using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax.Simulator.Entities
{
    /// <summary>
    /// Classe pour une personne.
    /// </summary>
    public class Personne
    {
        private SituationsFamiliales situationFamiliale;
        private decimal salaireMensuel;
        private decimal salaireConjoint;
        private int nbEnfants;

        /// <summary>
        /// Obtient la situation familiale de la personne.
        /// </summary>
        public SituationsFamiliales SituationFamiliale => this.situationFamiliale;

        /// <summary>
        /// Obtient le salaire mensuel de la personne.
        /// </summary>
        public decimal SalaireMensuel => this.salaireMensuel;

        /// <summary>
        /// Obtient le salaire mensuel du conjoint de la personne.
        /// </summary>
        public decimal SalaireConjoint => this.salaireConjoint;

        /// <summary>
        /// Obtient le nombre d'enfants de la personne.
        /// </summary>
        public int NbEnfants => this.nbEnfants;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Personne"/>.
        /// </summary>
        /// <param name="situationFamiliale">Situation familialle de la personne.</param>
        /// <param name="salaireMensuel">Salaire mensuel de la personne.</param>
        /// <param name="salaireConjoint">Salaire du conjoint de la personne.</param>
        /// <param name="nbEnfants">Nombre d'enfants de la personne.</param>
        public Personne(SituationsFamiliales situationFamiliale, decimal salaireMensuel, decimal salaireConjoint, int nbEnfants)
        {
            this.situationFamiliale = situationFamiliale;
            this.salaireMensuel = salaireMensuel;
            this.salaireConjoint = salaireConjoint;
            this.nbEnfants = nbEnfants;
        }
    }
}
