using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax.Simulator.Entities
{
    /// <summary>
    /// Enumération pour les situations familiales
    /// </summary>
    public enum SituationsFamiliales
    {
        MARIE_PACSE = 2,
        CELIBATAIRE = 1
    }
    
    public static class SituationsFamilialesExtensions
    {
        public static SituationsFamiliales StringToSituation(string situationFamiliale)
        {
            switch (situationFamiliale)
            {
                case "Marié/Pacsé":
                    return SituationsFamiliales.MARIE_PACSE;
                case "Célibataire":
                    return SituationsFamiliales.CELIBATAIRE;
                default:
                    throw new ArgumentOutOfRangeException(nameof(situationFamiliale), situationFamiliale, null);
            }
        }
    }
}
