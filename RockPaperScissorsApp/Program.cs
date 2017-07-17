using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissorsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var jogadores = new List<Jogador>();
            var jogadoresVencedores = new List<Jogador>();
            var jogosEmpatados = "";
            var jogoVencedor = "";

            string cadastrarMaisJogadores = "S";
            do
            {
                Console.Clear();
                var jogador = new Jogador();
                Console.WriteLine("Entre com o nome:");
                jogador.Nome = Console.ReadLine();

                jogador.Jogada = EscolherJogada();

                jogadores.Add(jogador);

                Console.WriteLine("Deseja Cadastrar mais um jogador? (S/N)");
                cadastrarMaisJogadores = Console.ReadLine();

                if (cadastrarMaisJogadores.ToUpper() != "S" && jogadores.Count % 2 != 0)
                {
                    Console.WriteLine("É necessário cadastrar mais um jogador");
                    Console.ReadLine();
                    cadastrarMaisJogadores = "S";
                }

            } while (cadastrarMaisJogadores.ToUpper() == "S");

            do
            {
                jogadoresVencedores.Clear();

                for (int i = 0; i < jogadores.Count; i = i + 2)
                {
                    if (jogadores[i].Jogada == jogadores[i + 1].Jogada)
                    {
                        jogosEmpatados = jogadores[i].Nome + " empatou com " + jogadores[i + 1].Nome + "\n";
                        continue;
                    }
                    
                    var venceSe = JogosVencedores[jogadores[i].Jogada];
                    if (venceSe == jogadores[i + 1].Jogada)
                    {
                        jogadoresVencedores.Add(jogadores[i]);
                    }
                    else
                    {
                        jogadoresVencedores.Add(jogadores[i + 1]);
                    }
                }               

                jogadores.Clear();
                jogadores.AddRange(jogadoresVencedores);
            } while (jogadoresVencedores.Count > 1);

            if (jogadoresVencedores.Count == 0)
            {
                jogoVencedor = "Não houve vencedor";
            }
            else
            {
                jogoVencedor = "O vencedor foi: " + jogadoresVencedores.First().Nome;
            }
            Console.WriteLine(jogoVencedor);
            Console.WriteLine("\n\n" + jogosEmpatados);
            Console.ReadLine();
        }

        static Dictionary<TipoJogada, TipoJogada> JogosVencedores = new Dictionary<TipoJogada, TipoJogada>
        {
            { TipoJogada.R, TipoJogada.S },
            { TipoJogada.S, TipoJogada.P },
            { TipoJogada.P, TipoJogada.R }
        };

        private static TipoJogada EscolherJogada()
        {
            TipoJogada jogoEscolhido = TipoJogada.Invalido;
            bool quit = false;
            while (jogoEscolhido == TipoJogada.Invalido)
            {

                Console.Write("Selecione a jogada: [R]ock, [P]aper, [S]cissors... ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "R":
                        jogoEscolhido = TipoJogada.R;
                        break;
                    case "P":
                        jogoEscolhido = TipoJogada.P;
                        break;
                    case "S":
                        jogoEscolhido = TipoJogada.S;
                        break;

                    default:
                        Console.WriteLine($"{choice} não é uma jogada valida. Selecione outro.\r\n");
                        break;
                }
            }

            return jogoEscolhido;
        }
    }
}
