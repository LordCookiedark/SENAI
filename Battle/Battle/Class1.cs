using System;

namespace Battle
{
    public class Characteres
    {
        public class Warrior
        {
            private int lifeWarrior = 800;
            public int WarAxes = 0;
            public int WarShield = 0;
            public int WarBuff = 2;
            public bool WarBuffActive = false;
            private static readonly Random rnd = new Random();

            public void WarShieldBlock(CharacterBoss boss)
            {
                Console.WriteLine("O Guerreiro levanta seu escudo para bloquear o ataque...\n");
                WarShield = rnd.Next(5, 16);
                if (WarBuffActive && WarBuff >= 0)
                {
                    WarShield += WarBuff;
                    WarBuff--;
                }
                boss.ReceiveDamage(WarShield);
                lifeWarrior += WarShield;
               
                Console.WriteLine($"O Guerreiro bloqueou {WarShield} de dano.\n");
            }

            public void WarAxesAttack(CharacterBoss boss)
            {
                Console.WriteLine("O Guerreiro ataca com seu machado...\n");
                WarAxes = rnd.Next(10, 27);
                if (WarBuffActive && WarBuff >= 0)
                {
                    WarAxes += WarBuff;
                    WarBuff--;
                }
                boss.ReceiveDamage(WarAxes);
                Console.WriteLine($"O ataque do Guerreiro causou {WarAxes} de dano.\n");
            }

            public void WarBuffActivate()
            {
                WarBuffActive = true;
                WarBuff = 2;
                Console.WriteLine("O Guerreiro usou o grito de guerra, buff de habilidade ativo por 2 turnos.\n");
            }

            public void WarLifeStatus(CharacterBoss boss)
            {
                lifeWarrior -= boss.attackBoss;
                Console.WriteLine($"Vida do Guerreiro: {lifeWarrior}\n");
                if (lifeWarrior <= 0)
                {
                    Console.WriteLine("O Guerreiro foi derrotado!SS\n");
                }
            }

            public void ReceiveDamage(int amount)
            {
                lifeWarrior -= amount;
                if (lifeWarrior < 0) lifeWarrior = 0;
            }

            public void ReceiveHeal(int amount)
            {
                lifeWarrior += amount;
            }

            public int GetLife() => lifeWarrior;
            public bool IsAlive() => lifeWarrior > 0;
        }

        public class Mage
        { 
            private int lifeMage = 500;
            public int MagFireball = 0;
            public int MagWindBurst = 0;
            public int MagHeal = 0;
            private static readonly Random rnd = new Random();

            public void MageFireballAttack(CharacterBoss boss)
            {
                Console.WriteLine("O Mago lança uma esfera de fogo...\n");
                MagFireball = rnd.Next(15, 30);
                boss.ReceiveDamage(MagFireball);
                if (boss.GetLife() < 0) 
                    ;
                Console.WriteLine($"O ataque do Mago causou {MagFireball} de dano.\n");
            }

            public void MageWindBurstAttack(CharacterBoss boss)
            {
                Console.WriteLine("O Mago conjura uma rajada de ventos...\n");
                MagWindBurst = rnd.Next(8, 25);
                boss.ReceiveDamage(MagWindBurst);
                if (boss.GetLife() < 0) 
                    ;
                Console.WriteLine($"O ataque do Mago causou {MagWindBurst} de dano.\n");
            }

            public void MageHealSpell(CharacterBoss boss, Warrior ally)
            {
                Console.WriteLine("O Mago usa cura maior...\n");
                MagHeal = rnd.Next(350, 600);
                lifeMage += MagHeal;
                ally.ReceiveHeal(MagHeal);
                Console.WriteLine($"O Mago recuperou {MagHeal} de vida do time.\n");
            }

            public void MagLifeStatus(CharacterBoss boss)
            {
                lifeMage -= boss.attackBoss;
                Console.WriteLine($"Vida do Mago: {lifeMage}\n");
                if (lifeMage <= 0)
                {
                    Console.WriteLine("O Mago foi derrotado!\n");
                }
            }

            public int GetLife() => lifeMage;
            public bool IsAlive() => lifeMage > 0;
        }

    }
}