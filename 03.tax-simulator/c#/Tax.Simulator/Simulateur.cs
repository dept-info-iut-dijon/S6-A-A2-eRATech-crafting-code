namespace Tax.Simulator;

/// <summary>
/// Simulateur de taxe
/// </summary>
public static class Simulateur
{
    private static readonly decimal[] TranchesImposition = { 10225m, 26070m, 74545m, 160336m }; // Plafonds des tranches
    private static readonly decimal[] TauxImposition = { 0.0m, 0.11m, 0.30m, 0.41m, 0.45m }; // Taux correspondants
    private const int NOMBRE_MOIS_ANNEE = 12;
    private const decimal QUOTIENT_0_ENFANT = 0m;
    private const decimal QUOTIENT_1_ENFANT = 0.5m;
    private const decimal QUOTIENT_2_ENFANT = 1.0m;
    
    
    /// <summary>
    /// Calcul l'impot annuel selon la situation familliale
    /// </summary>
    /// <param name="situationFamiliale">Situation familiale actuelle</param>
    /// <param name="salaireMensuel">salaire mensuel de l'imposé</param>
    /// <param name="salaireMensuelConjoint">salaire mensuel du conjoint de l'imposé</param>
    /// <param name="nombreEnfants">nombre d'enfant de l'imposé</param>
    /// <returns>taux d'imposition</returns>
    public static decimal CalculerImpotsAnnuel(
        string situationFamiliale,
        decimal salaireMensuel,
        decimal salaireMensuelConjoint,
        int nombreEnfants)
    {
        if (situationFamiliale != "Célibataire" && situationFamiliale != "Marié/Pacsé")
        {
            throw new ArgumentException("Situation familiale invalide.");
        }

        if (salaireMensuel <= 0)
        {
            throw new ArgumentException("Les salaires doivent être positifs.");
        }

        if (situationFamiliale == "Marié/Pacsé" && salaireMensuelConjoint < 0)
        {
            throw new InvalidDataException("Les salaires doivent être positifs.");
        }

        if (nombreEnfants < 0)
        {
            throw new ArgumentException("Le nombre d'enfants ne peut pas être négatif.");
        }

        decimal revenuAnnuel;
        if (situationFamiliale == "Marié/Pacsé")
        {
            revenuAnnuel = (salaireMensuel + salaireMensuelConjoint) * NOMBRE_MOIS_ANNEE;
        }
        else
        {
            revenuAnnuel = salaireMensuel * NOMBRE_MOIS_ANNEE;
        }

        var baseQuotient = situationFamiliale == "Marié/Pacsé" ? 2 : 1;
        
        decimal quotientEnfants = CalculerQuotientEnfants(nombreEnfants);


        var partsFiscales = baseQuotient + quotientEnfants;
        var revenuImposableParPart = revenuAnnuel / partsFiscales;

        decimal impot = 0;
        for (var i = 0; i < TranchesImposition.Length; i++)
        {
            if (revenuImposableParPart <= TranchesImposition[i])
            {
                impot += (revenuImposableParPart - (i > 0 ? TranchesImposition[i - 1] : 0)) * TauxImposition[i];
                break;
            }
            else
            {
                impot += (TranchesImposition[i] - (i > 0 ? TranchesImposition[i - 1] : 0)) * TauxImposition[i];
            }
        }

        if (revenuImposableParPart > TranchesImposition[^1])
        {
            impot += (revenuImposableParPart - TranchesImposition[^1]) * TauxImposition[^1];
        }

        var impotParPart = impot;

        return Math.Round(impotParPart * partsFiscales, 2);
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