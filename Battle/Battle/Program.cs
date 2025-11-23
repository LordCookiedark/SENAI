using System;  
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Battle
{
    public class CharacterBoss
    {
        private int lifeBoss = 1300;
        public int attackBoss = 0;
        public int heallingBoss = 400;
        public bool isEnraged = false;
        public int Enraged = 1;
        private static readonly Random rnd = new Random();
        private const int EnrageChancePercent = 50;

        public int lifeStatusBoss()
        {
            if(lifeBoss <= 0)
            {
                Console.WriteLine("Cthulhu foi derrotado!\nParabens Aventureiro!!");
            }


            if (lifeBoss <= 300 && Enraged == 1 && isEnraged == false)
            {
                if (rnd.Next(0, 100) < EnrageChancePercent)
                {
                    Console.WriteLine("Cthulhu está enfurecido!\nSeus ataques agora causam mais dano!\nCthulhu recupera 400 de vida.");
                    isEnraged = true;
                    lifeBoss += heallingBoss;               
                    Enraged = 0;
                }
            }

            return lifeBoss;
        }
        public void ReceiveDamage(int amount)
        {
            lifeBoss -= amount;
            if (lifeBoss < 0) lifeBoss = 0;
        }
        public int GetLife() => lifeBoss;
        public int AttackBoss()
        {
            attackBoss = rnd.Next(49, 80);
            if (isEnraged)
            {
                attackBoss += 1800;
            }
            if (lifeBoss < 0) lifeBoss = 0;
            Console.WriteLine($"O ataque de Cthulhu causou {attackBoss} de dano.");
            return attackBoss;
        }
    }

    public static class Program
    {
        static void Main(string[] args)
        {
            var boss = new CharacterBoss();
            var warrior = new Characteres.Warrior();
            var mage = new Characteres.Mage();

            Console.WriteLine("O grande Cthulhu aparece diante de você!");
            Console.WriteLine("Prepare-se para a batalha!\n");
            Console.WriteLine("Seu grupo é composto por um guerreiro e um mago\n");
            Console.WriteLine("Boa sorte Aventureiro!\n");
            Console.WriteLine($"\nStatus:\n Vida do Guerreiro: {warrior.GetLife()} | Vida do Mago: {mage.GetLife()} | Vida do Chefe: {boss.GetLife()}");



            while (boss.GetLife() > 0 && (warrior.IsAlive() || mage.IsAlive()))
            {
                Console.WriteLine("\n\n\nSeu Guerreiro possui 3 ataques:\n1 - Ataque com o machado.\n2 - Ataque com escudo.\n3 - Grito de guerra.\n");
                Console.WriteLine("\nEscolha a ação do Guerreiro (1/2/3):\n");
                var choiceW = Console.ReadLine();
                switch (choiceW)
                {
                    case "1":
                        warrior.WarAxesAttack(boss);
                        break;
                    case "2":
                        warrior.WarShieldBlock(boss);
                        break;
                    case "3":
                        warrior.WarBuffActivate();
                        break;
                    default:
                        Console.WriteLine("\n\nAção inválida para o Guerreiro. Perdeu o turno.\n\n");
                        break;
                }
                Console.WriteLine("\n\n\nSeu Mago possui 3 ataques:\n1 - Esfera de fogo.\n2 - Rajada de Ventos.\n3 - Cura Maior.\n\n\n");
                Console.WriteLine("\nEscolha a ação do Mago (1/2/3):\n");
                var choiceM = Console.ReadLine();
                switch (choiceM)
                {
                    case "1":
                        mage.MageFireballAttack(boss);
                        break;
                    case "2":
                        mage.MageWindBurstAttack(boss);
                        break;
                    case "3":
                        mage.MageHealSpell(boss, warrior);
                        break;
                    default:
                        Console.WriteLine("\n\nAção inválida para o Mago. Perdeu o turno.\n\n");
                        break;
                }
                boss.lifeStatusBoss();

                if (boss.GetLife() <= 0)
                    break;
                boss.AttackBoss();
                warrior.WarLifeStatus(boss);
                mage.MagLifeStatus(boss);
                Console.WriteLine("\nPressione Enter para continuar para o próximo turno...\n\n");
                Console.ReadLine();
                Console.Clear(); Console.WriteLine($"\nStatus: Vida do Guerreiro: {warrior.GetLife()} | Vida do Mago: {mage.GetLife()} | Vida do Chefe: {boss.GetLife()}");
            }
            if (boss.GetLife() <= 0)
            {
                Console.WriteLine("\nParabéns! Você venceu a batalha!");
            }
            else
            {
                Console.WriteLine("\nSeu time foi derrotado. Fim de jogo.");
            }
        }
    }
}