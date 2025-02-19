using System.Reflection.Metadata;

namespace Tax.Simulator;

public static class Simulateur
{
    private static readonly decimal[] TranchesImposition = { 10225m, 26070m, 74545m, 160336m }; // Plafonds des tranches
    private static readonly decimal[] TauxImposition = { 0.0m, 0.11m, 0.30m, 0.41m, 0.45m }; // Taux correspondants

    public static decimal CalculerImpotsAnnuel(
        string situationFamiliale,
        decimal salaireMensuel,
        decimal salaireMensuelConjoint,
        int nombreEnfants)
    {
        if (situationFamiliale != "Célibataire" && situationFamiliale != "Marié/Pacsé")
        {
            throw new ArgumentException(_string.familleErreur);
        }

        if (salaireMensuel <= 0)
        {
            throw new ArgumentException(_string.SalairePositifErreur);
        }

        if (situationFamiliale == "Marié/Pacsé" && salaireMensuelConjoint < 0)
        {
            throw new InvalidDataException(_string.SalairePositifErreur);
        }

        if (nombreEnfants < 0)
        {
            throw new ArgumentException(_string.EnfantNegatifErreur);
        }

        decimal revenuAnnuel;
        if (situationFamiliale == "Marié/Pacsé")
        {
            revenuAnnuel = (salaireMensuel + salaireMensuelConjoint) * 12;
        }
        else
        {
            revenuAnnuel = salaireMensuel * 12;
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
            0 => 0,
            1 => 0.5m,
            2 => 1.0m,
            _ => 1.0m + (nombreEnfants - 2) * 0.5m
        };
    }
}