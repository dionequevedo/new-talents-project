using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewTalentsConsole.Model
{
    public class Calculadora
    {
        public Calculadora(DateTime dataHora)
        {
            historico = new List<string>();
            DataHora = dataHora;
        }
        private List<string> historico { get; set;}
        private DateTime DataHora { get; set; }
        private int Numero1 { get; set; }
        private int Numero2 { get; set; }
        private int ResultadoCalculo { get; set; }
        
        public int Somar(int val1, int val2)
        {
            Numero1 = val1;
            Numero2 = val2;
            ResultadoCalculo = val1 + val2;
            AdicionaHistorico(DataHora, val1, val2, "+", ResultadoCalculo);
            return ResultadoCalculo;
        }

        public int Subtrair(int val1, int val2)
        {
            Numero1 = val1;
            Numero2 = val2;
            ResultadoCalculo = val1 - val2;
            AdicionaHistorico(DataHora, val1, val2, "-", ResultadoCalculo);
            return ResultadoCalculo;
        }

        public int Multiplicar(int val1, int val2)
        {
            Numero1 = val1;
            Numero2 = val2;
            ResultadoCalculo = val1 * val2;
            AdicionaHistorico(DataHora, val1, val2, "*", ResultadoCalculo);
            return ResultadoCalculo;
        }

        public int Dividir(int val1, int val2)
        {
            try
            {
                Numero1 = val1;
                Numero2 = val2;
                ResultadoCalculo = val1 / val2;
                AdicionaHistorico(DataHora, val1, val2, "/", ResultadoCalculo);
                return ResultadoCalculo;
            }catch(DivideByZeroException)
            {
                AdicionaHistoricoErro(DataHora, val1, val2, "/", "Erro: Divisão por zero!");
                return 0;
            }
        }

        private int Throw<T>(string v)
        {
            throw new NotImplementedException();
        }

        public void AdicionaHistorico(DateTime data, int val1, int val2, string op, int ResultadoCalculo)
        {
            historico.Insert(0, $"{data} - Cálculo: {val1} {op} {val2} = {ResultadoCalculo}");
        }

        public void AdicionaHistoricoErro(DateTime data, int val1, int val2, string op, string ResultadoCalculo)
        {
            historico.Insert(0, $"{data} - Cálculo: {val1} {op} {val2} = {ResultadoCalculo}");
        }

        public List<string> RetornaHistorico()
        {
            if(historico.Count > 3)
            {
                historico.RemoveRange(3, historico.Count - 3);
            }

            return historico;
        }
    }
}