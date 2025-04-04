using Framework2DGame;
using Framework2DGame.Base;
using Framework2DGame.Interfaces;

ReadConfig cnf = new ReadConfig();
cnf.Start();

LoggingClass loggingClass = new LoggingClass();
loggingClass.Start();

World world = new World(cnf);
Bandit creatura = new Bandit(cnf, "Diablo", 10, 0, 0, world);
WorldObject obj = new WorldObject("Chest", true, false, "Cofre normal", ItemCategory.attack, world);

Bandit bandido = new Bandit(cnf, "Weoncito", 10, 0, 0, world);
bandido.Throw(creatura);


Sword sword1 = new Sword("Excalibur", 20, 1, true, true, "Espada sagrada", world);

IAttackItem boostedSword = new AttackItemDecorator(sword1, 10);
Console.WriteLine($"La espada tiene {boostedSword.Hit} de daño");
Console.WriteLine(boostedSword);

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




