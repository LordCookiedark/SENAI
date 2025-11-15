using Jokenpo;
using System;

namespace Jokenpo
{
    public class Player : JokenpoJogo
    {
        private Random random = new Random();
        public int[] escolhaComputador = new int[3];
        public int[] escolha = new int[3];

        public void Rodadas()
        {
            for (int i = 0; i < rodada.Length; i++)
            {
                Jogo(i);
                EscolhaJogador(i);
                EscolhaComputador(i);
                Avaliar(i);
            }

            ResultadoFinal();
        }

        public void EscolhaJogador(int i)
        {
            int escolhaVal;
            while (true)
            {
                var input = Console.ReadLine();
                if (!int.TryParse(input, out escolhaVal) || escolhaVal < 1 || escolhaVal > 3)
                {
                    Console.WriteLine("Escolha inválida! Digite 1, 2 ou 3.");
                    continue;
                }
                break;
            }

            escolha[i] = escolhaVal;
            if (escolha[i] == 1)
            {
                Console.WriteLine("Você escolheu Pedra\n");
            }
            else if (escolha[i] == 2)
            {
                Console.WriteLine("Você escolheu Papel\n");
            }
            else
            {
                Console.WriteLine("Você escolheu Tesoura\n");
            }
        }

        public void EscolhaComputador(int i)
        {
            escolhaComputador[i] = random.Next(1, 4);
            if (escolhaComputador[i] == 1)
            {
                Console.WriteLine("Computador escolheu Pedra\n");
            }
            else if (escolhaComputador[i] == 2)
            {
                Console.WriteLine("Computador escolheu Papel\n");
            }
            else
            {
                Console.WriteLine("Computador escolheu Tesoura\n");
            }
        }

        private void Avaliar(int i)
        {
            int jogador = escolha[i];
            int cpu = escolhaComputador[i];

            if (jogador == cpu)
            {
                Console.WriteLine("Empate nesta rodada!\n");
                return;
            }
            bool jogadorGanha =
                (jogador == 1 && cpu == 3) ||
                (jogador == 2 && cpu == 1) ||
                (jogador == 3 && cpu == 2);

            if (jogadorGanha)
            {
                pontuacaoJogador++;
                Console.WriteLine("Você ganhou esta rodada!\n");
            }
            else
            {
                pontuacaoComputador++;
                Console.WriteLine("Computador ganhou esta rodada!\n");
            }
        }
    }
}