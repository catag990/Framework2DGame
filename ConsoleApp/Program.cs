using System.Diagnostics;
using Framework2DGame;
using Framework2DGame.Base;

ReadConfig cnf = new ReadConfig();
cnf.Start();


LoggingClass.Source.Listeners.Clear();

//Can add different types of listeners, it's not neccesary to have one
LoggingClass.Source.Listeners.Add(new TextWriterTraceListener("log.txt"));

LoggingClass.Information("Game initialized.");

var observer = new HitObserver();

World world = new World(cnf);
Creature creatura = new Bandit(cnf, "Diablo", 10, 0, 0, world);
WorldObject obj = new WorldObject("Chest", true, false, "Cofre normal", ItemCategory.attack, world);

creatura.Attach(observer);

Bandit bandido = new Bandit(cnf, "Pedro", 10, 0, 0, world);
Bandit gary = new Bandit(cnf, "Gary", 10, 0, 0, world);
bandido.Attach(observer);
gary.Attach(observer);

bandido.Throw(creatura);
Console.WriteLine("=======================");
//Attack is a strategy, and Bandido "Pedro" doesn't have one at the moment.
bandido.Attack(gary);

Console.WriteLine("=======================");

gary.Strategy = new MeeleStrategy();
LoggingClass.Information($"{gary.Name}'s strategy: {gary.Strategy} Strategy");
gary.Attack(bandido);

Console.WriteLine("=======================");

Sword sword1 = new Sword("Excalibur", 20, 1, true, true, "Sacred sword", world);

gary.Loot(sword1);

Console.WriteLine("=======================");

gary.EquipWeapon("Excalibur");

Console.WriteLine("=======================");

gary.ApplyWeaponBoost(15);
Console.WriteLine($"The hit is {gary.EquippedWeapon.Hit}");

Console.WriteLine("=======================");

Bandit enemy = new Bandit(cnf, "Bad Guy", 35, 0, 0, world);
enemy.Attach(observer);
gary.Hit(enemy);

Console.WriteLine("=======================");

Sword zweihander = new Sword("Zweihander", 40, 1, true, true, "Very long sword", world);
gary.Loot(zweihander);
Bandit BigGuy = new Bandit(cnf, "Big Guy", 100, 0, 0, world);
BigGuy.Attach(observer);
gary.EquipWeapon("Zweihander");
gary.Hit(BigGuy);

Console.WriteLine("=======================");

foreach (Creature creature in world.creatures)
{
    Console.WriteLine($"The Creature called {creature.Name} is in the World");
}

foreach (WorldObject obj1 in world.objects)
{
    Console.WriteLine($"The Object called {obj1.Name} is in the World");
}
Console.WriteLine("=======================");

gary.Loot(obj);
foreach (WorldObject object1 in gary.Inventory)
{
    Console.WriteLine($"{gary.Name} has {object1.Name} in it's inventory");
}

Console.WriteLine("=======================");
CompositeAttackItem comboWeapon = new CompositeAttackItem();
comboWeapon.Add(sword1);
comboWeapon.Add(zweihander);
gary.EquippedWeapon = comboWeapon;
Console.WriteLine($"The combo weapon hit is: {gary.EquippedWeapon.Hit}");

LoggingClass.Source.Flush();
LoggingClass.Source.Close();



