﻿using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    [Trait("Tipo", "Unidade")]
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, 1250, new double[] { 800, 1150, 1400, 1250 })]
        public void RetornaValorSuperiorMaisProximoDadoLeilaoNessaModalidade(double valorDestino,
                                                                             double valorEsperado,
                                                                             double[] lances)
        {
            #region Arrange
            IModalidadeAvaliacao modalidade = new LanceSuperiorMaisProximo(valorDestino);
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano");
            var maria = new Interessada("Maria");

            leilao.IniciarPregao();

            for (int i = 0; i < lances.Length; i++)
            {
                if ((i % 2 == 0))
                {
                    leilao.ReceberLance(fulano, lances[i]);
                }
                else
                {
                    leilao.ReceberLance(maria, lances[i]);
                }
            }
            #endregion

            #region Act
            leilao.TerminarPregao();
            #endregion

            #region Assert
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
            #endregion
        }

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double[] lances)
        {
            #region Arrange
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano");
            var maria = new Interessada("Maria");
            leilao.IniciarPregao();

            for (int i = 0; i < lances.Length; i++)
            {
                var valor = lances[i];

                if ((i % 2) == 0)
                {
                    leilao.ReceberLance(fulano, valor);
                }
                else
                {
                    leilao.ReceberLance(maria, valor);
                }
            }
            #endregion

            #region Act
            leilao.TerminarPregao();

            //Assert
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
            #endregion
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            #region Arrange
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            #endregion

            #region Assert
            var excecaoObtida = Assert.Throws<System.InvalidOperationException>(
                //Act - método sob teste
                () => leilao.TerminarPregao()
            );

            var msgEsperada = "Não é possível terminar o pregão sem que ele tenha começado. Para isso, utilize o método IniciaPregao().";
            Assert.Equal(msgEsperada, excecaoObtida.Message);
            #endregion
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            #region Arrange
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            leilao.IniciarPregao();
            #endregion

            #region Act
            leilao.TerminarPregao();
            #endregion

            #region Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
            #endregion
        }
    }
}
