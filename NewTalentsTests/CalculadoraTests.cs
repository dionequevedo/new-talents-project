using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using NewTalentsConsole.Model;
using System.Configuration.Assemblies;

namespace NewTalentsTests
{
    public class CalculadoraTests
    {
        public Calculadora ConstruirClasse()
        {
            DateTime dataHora = DateTime.Now;
            Calculadora calc = new Calculadora(dataHora);
            return calc;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(7, 3, 10)]
        [InlineData(10, -2, 8)]
        [InlineData(1251, 49, 1300)]
        [InlineData(-50, -25, -75)]
        public void Recebe2ValoresERetornaASomaDeAmbos(int val1, int val2, int resultado)
        {
            Calculadora calc = ConstruirClasse();

            int soma = calc.Somar(val1, val2);

            Assert.Equal(resultado, soma);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(7, 3, 21)]
        [InlineData(10, -2, -20)]
        [InlineData(1251, 49, 61299)]
        [InlineData(-50, -25, 1250)]
        public void Recebe2ValoresERetornaAMultiplicaoDeAmbos(int val1, int val2, int resultado)
        {
            Calculadora calc = ConstruirClasse();

            int multiplicacao = calc.Multiplicar(val1, val2);

            Assert.Equal(resultado, multiplicacao);
        }

        [Theory]
        [InlineData(1, 2, 0)]
        [InlineData(7, 3, 2)]
        [InlineData(10, -2, -5)]
        [InlineData(1251, 49, 25)]
        [InlineData(-50, -25, 2)]
        public void Recebe2ValoresERetornaADivisaoDeAmbos(int val1, int val2, int resultado)
        {
            Calculadora calc = ConstruirClasse();

            int divisao = calc.Dividir(val1, val2);

            Assert.Equal(resultado, divisao);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(7, 3, 4)]
        [InlineData(10, -2, 12)]
        [InlineData(1251, 49, 1202)]
        [InlineData(-50, -25, -25)]
        public void Recebe2ValoresERetornaASubtracaoDeAmbos(int val1, int val2, int resultado)
        {
            Calculadora calc = ConstruirClasse();

            int subtracao = calc.Subtrair(val1, val2);

            Assert.Equal(resultado, subtracao);
        }

        [Fact]
        public void TestarDivisaoPorzero()
        {
            Calculadora calc = ConstruirClasse();
            Assert.Equal(0, calc.Dividir(10, 0));
        }

        [Fact]
        public void ApresentaHistoricoDeOperacoes()
        {
            Calculadora calc = ConstruirClasse();

            calc.Somar(1, 2);
            calc.Subtrair(7, 3);
            calc.Multiplicar(10, -2);
            calc.Dividir(1251, 49);


            Assert.Equal(3, calc.RetornaHistorico().Count);
        }

        [Fact]
        public void ValidarGravacaoErroDeDivisaoPorZero()
        {
            Calculadora calc = ConstruirClasse();

            calc.Dividir(10, 0);
            Assert.True(calc.RetornaHistorico()[0].Contains("Erro"));
        }
    }
}