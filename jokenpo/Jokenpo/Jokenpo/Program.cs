using System;
using System.Numerics;

namespace Jokenpo
{
    public class JokenpoJogo
    {
        public int pontuacaoJogador = 0;
        public int pontuacaoComputador = 0;
        public int[] rodada = { 1, 2, 3 };

        public void Jogo(int i)
        {
            Console.WriteLine("Rodada " + rodada[i] + " - Faça sua escolha:");
            Console.WriteLine("1 - Pedra");
            Console.WriteLine("2 - Papel");
            Console.WriteLine("3 - Tesoura");
        }

        public void Vitoria()
        {
            if (pontuacaoJogador > pontuacaoComputador)
            {
                Console.WriteLine("Jogador Venceu!");
            }
        }

        public void Derrota()
        {
            if (pontuacaoJogador < pontuacaoComputador)
            {
                Console.WriteLine("Computador Venceu!");
            }
        }

        public void ResultadoFinal()
        {
            Console.WriteLine($"\nPlacar final - Jogador: {pontuacaoJogador} | Computador: {pontuacaoComputador}");
            if (pontuacaoJogador > pontuacaoComputador)
                Console.WriteLine("Jogador Venceu!");
            else if (pontuacaoJogador < pontuacaoComputador)
                Console.WriteLine("Computador Venceu!");
            else
                Console.WriteLine("Empate!");
        }
    }

    // meu deus do ceu eu redigitei 3x e n sabia que o erro era esse main
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jokenpo - Pedra, Papel, Tesoura\n");
            var player = new Player();
            player.Rodadas();

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
