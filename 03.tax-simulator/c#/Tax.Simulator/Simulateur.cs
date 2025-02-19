using Tax.Simulator.Entities;

namespace Tax.Simulator;

/// <summary>
/// Simulateur de taxe
/// </summary>
public static class Simulateur
{
    private static readonly decimal[] TranchesImposition = { 10225m, 26070m, 74545m, 160336m, 500000m }; // Plafonds des tranches
    private static readonly decimal[] TauxImposition = { 0.0m, 0.11m, 0.30m, 0.41m, 0.45m, 0.48m}; // Taux correspondants

    private const int NOMBRE_MOIS_ANNEE = 12;
    private const decimal QUOTIENT_0_ENFANT = 0m;
    private const decimal QUOTIENT_1_ENFANT = 0.5m;
    private const decimal QUOTIENT_2_ENFANT = 1.0m;

    /// <summary>
    /// Calcul l'impot annuel selon la situation familiale
    /// </summary>
    /// <param name="personne">Personne dont on calcule l'impot annuel</param>
    public static decimal CalculerImpotsAnnuelPersonne(Personne personne)
    {
        decimal revenuMensuel =
            CalculerRevenuMensuelSelonSituationFamiliale(personne);

        decimal revenuAnnuel = revenuMensuel * NOMBRE_MOIS_ANNEE;

        var baseQuotient = (int)personne.SituationFamiliale;

        decimal quotientEnfants = CalculerQuotientEnfants(personne.NbEnfants);

        var partsFiscales = baseQuotient + quotientEnfants;
        var revenuImposableParPart = revenuAnnuel / partsFiscales;

        decimal impot = CalculerImpotSelonTranchesImposition(revenuImposableParPart);

        return Math.Round(impot * partsFiscales, 2);
    }

    /// <summary>
    /// Calcule le revenu mensuel en fonction de la situation familiale.
    /// </summary>
    /// <param name="person">Personne dont on calcule le revenu mensuel</param>
    /// <returns>Le revenu mensuel selon une situation familiale</returns>
    private static decimal CalculerRevenuMensuelSelonSituationFamiliale(
        Personne person)
    {
        return person.SituationFamiliale switch
        {
            SituationsFamiliales.CELIBATAIRE => person.SalaireMensuel,
            SituationsFamiliales.MARIE_PACSE => person.SalaireMensuel + person.SalaireConjoint,
        };
    }

    /// <summary>
    /// Calcule l'impôt en fonction des tranches d'impositions.
    /// </summary>
    /// <param name="revenuImposableParPart">Revenu imposable par part.</param>
    /// <returns>Le total d'impot selon les tranches d'impositions existantes.</returns>
    private static decimal CalculerImpotSelonTranchesImposition(decimal revenuImposableParPart)
    {
        decimal impot = 0;
        decimal val;

        for (var i = 0; i < TranchesImposition.Length; i++)
        {
            val = i > 0 ? TranchesImposition[i - 1] : 0;

            if (revenuImposableParPart <= TranchesImposition[i])
            {
                impot += (revenuImposableParPart - val) * TauxImposition[i];
                break;
            }

            impot += (TranchesImposition[i] - val) * TauxImposition[i];
        }

        if (revenuImposableParPart > TranchesImposition[^1])
        {
            impot += (revenuImposableParPart - TranchesImposition[^1]) * TauxImposition[^1];
        }

        return impot;
    }

    /// <summary>
    /// Calcule le quotient familial en fonction du nombre d'enfants
    /// </summary>
    /// <param name="nombreEnfants">Nombre d'enfants de la personne.</param>
    /// <returns>Le quotient familliale</returns>
    private static decimal CalculerQuotientEnfants(int nombreEnfants)
    {
        return nombreEnfants switch
        {
            0 => QUOTIENT_0_ENFANT,
            1 => QUOTIENT_1_ENFANT,
            2 => QUOTIENT_2_ENFANT,
            _ => QUOTIENT_2_ENFANT + (nombreEnfants - 2) * QUOTIENT_1_ENFANT
        };
    }
}