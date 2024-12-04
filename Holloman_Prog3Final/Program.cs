namespace Holloman_Prog3Final
{
    public class Program
    {
        static void Main(string[] args)
        {
            Battle Player = new Battle(1, 10,, 15, "Hero", "Elf");
            Battle Mob = new Battle(1, 10, 25, "Bandit", "Goblin");
            Merchant Peddler = new Merchant(0, 0, 100, "Bob", "Human");

            Console.WriteLine("There has been a battle encounter!");
            Console.ReadLine();

            Console.WriteLine("Level " + Player.Level + " " + Player.Name + " "+ Player.Race);
            Console.WriteLine("Vs");
            Console.WriteLine("Level " + Mob.Level + " " + Mob.Name + " " + Mob.Race);
            Console.ReadLine();

            Player.MakeAttack();
            Console.WriteLine("Player attacks for " + Player.Damage);
            Mob.Health = Mob.Health - Player.Damage;
            Console.WriteLine("Goblin's Health is now " + Mob.Health);
            Console.ReadLine();

            Mob.MakeAttack();
            Console.WriteLine("The Goblin attacks for " + Mob.Damage);
            Player.Health = Player.Health - Mob.Damage;
            Console.WriteLine("The Players health is now " + Player.Health);
            Console.ReadLine();


            Console.WriteLine("The Player has encountered a merchant.");

        }
    }
}
