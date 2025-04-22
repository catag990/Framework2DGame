using Framework2DGame;
using Framework2DGame.Base;
using Framework2DGame.Interfaces;

ReadConfig cnf = new ReadConfig();
cnf.Start();

LoggingClass loggingClass = new LoggingClass();
loggingClass.Start();

var observer = new HitObserver();

World world = new World(cnf);
Bandit creatura = new Bandit(cnf, "Diablo", 10, 0, 0, world);
WorldObject obj = new WorldObject("Chest", true, false, "Cofre normal", ItemCategory.attack, world);

creatura.Attach(observer);
Bandit bandido = new Bandit(cnf, "Pedro", 10, 0, 0, world);
Bandit gary = new Bandit(cnf, "Gary", 10, 0, 0, world);
bandido.Attach(observer);
gary.Attach(observer);

bandido.Throw(creatura);

bandido.Attack(gary);
gary.Strategy = new MeeleStrategy();
gary.Attack(bandido);

Sword sword1 = new Sword("Excalibur", 20, 1, true, true, "Espada sagrada", world);

AttackItemDecorator boostedSword = new AttackItemDecorator(sword1, 10);
Console.WriteLine($"La espada tiene {boostedSword.Hit} de daño");

foreach (Creature creature in world.creatures)
{
    Console.WriteLine($"The Creature called {creature.Name} is in the World");
}

foreach (WorldObject obj1 in world.objects)
{
    Console.WriteLine($"The Object called {obj1.Name} is in the World");
}

creatura.Loot(obj);

foreach (WorldObject obj1 in world.objects)
{
    Console.WriteLine($"The Object called {obj1.Name} is in the World");
}



bandido.Loot(sword1);

foreach (WorldObject object1 in bandido.Inventory)
{
    Console.WriteLine($"{bandido.Name} has {object1.Name} in it's inventory");
}




