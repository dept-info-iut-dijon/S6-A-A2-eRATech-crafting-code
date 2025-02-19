using Tax.Simulator.Entities;
using Xunit;

namespace Tax.Simulator.Tests;

public class SimulateurShould
{
    // Création test en méthode TDD
    
    /*
    * Revenus inférieurs au seuil :
        Situation familiale : "Célibataire"
        Salaire mensuel : 20 000 EUR (revenu annuel 240 000 EUR)
        Résultat attendu : Aucun changement par rapport au calcul précédent (pas de taxe appliquée à 48%).
    */
    [Fact]
    public void CalculateFirstCase()
    {
        // Arrange
        var personne = new Personne(SituationsFamiliales.CELIBATAIRE, 20000, 0, 0 );
        var expectedResult = 87308.56m;
        // Act
        var result = Simulateur.CalculerImpotsAnnuelPersonne(personne);
        // Assert
        Assert.Equal(expectedResult, result);
    }    
    
    /*
     * Revenus supérieurs au seuil :
        Situation familiale : "Célibataire"
        Salaire mensuel : 45 000 EUR (revenu annuel 540 000 EUR)
        Résultat attendu :
            Taxe pour les 500 000 premiers EUR basée sur les anciennes tranches.
            Taxe pour les 40 000 EUR restants à 48%.

    223 508.56 EUR
     */
    [Fact]
    public void CalculateSecondCase()
    {
        // Arrange
        var personne = new Personne(SituationsFamiliales.CELIBATAIRE, 45000, 0, 0 );
        var expectedResult = 223508.56m;
        // Act
        var result = Simulateur.CalculerImpotsAnnuelPersonne(personne);
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    /*
     * Revenus avec enfants (affectés par le quotient familial) :
        Situation familiale : "Marié/Pacsé"
        Salaire mensuel conjoint : 25 000 EUR
        Salaire mensuel principal : 30 000 EUR
        Nombre d'enfants : 2
        Résultat attendu :
            Application correcte de la nouvelle tranche après division par les parts fiscales.

    234 925.68 EUR
     */
    [Fact]
    public void CalculateThirdCase()
    {
        // Arrange
        var personne = new Personne(SituationsFamiliales.MARIE_PACSE, 30000, 25000, 2 );
        var expectedResult = 234925.68m;
        // Act
        var result = Simulateur.CalculerImpotsAnnuelPersonne(personne);
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    
}