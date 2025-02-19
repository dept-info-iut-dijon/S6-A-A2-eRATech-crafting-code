using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax.Simulator.Entities;
using Xunit;

namespace Tax.Simulator.Tests
{
    public class PersonneTest
    {
        [Fact]
        public void PersonneConstructorTest()
        {
            // Arrange & Act
            Personne personne = new Personne(SituationsFamiliales.CELIBATAIRE, 10, 10, 1);

            // Assert
            personne.SituationFamiliale
                .Should()
                .Be(SituationsFamiliales.CELIBATAIRE);

            personne.SalaireMensuel
                .Should()
                .Be(10);

            personne.SalaireConjoint
                .Should()
                .Be(10);

            personne.NbEnfants
                .Should()
                .Be(1);
        }

        [Fact]
        public void StringToSituationTest()
        {
            SituationsFamilialesExtensions.StringToSituation("Marié/Pacsé")
                .Should()
                .Be(SituationsFamiliales.MARIE_PACSE);

            SituationsFamilialesExtensions.StringToSituation("Célibataire")
                .Should()
                .Be(SituationsFamiliales.CELIBATAIRE);

            Assert.Throws<ArgumentOutOfRangeException>(() => SituationsFamilialesExtensions.StringToSituation("Test"));
        }
    }
}
