using RandomProviderInjection;

Pokemon charmander = new Pokemon("Charmander", 20);
Pokemon paras = new Pokemon("Paras", 8);

while (charmander.IsAlive && paras.IsAlive)
{
    charmander.Attack(paras);
    paras.Attack(charmander);
    Console.WriteLine();
}