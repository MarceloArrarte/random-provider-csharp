namespace RandomProviderInjection;

public class Pokemon
{
    public string Name { get; }
    public int HP { get; private set; } = 100;

    public bool IsAlive
    {
        get { return HP > 0; }
    }
    public int Power { get; }

    public Pokemon(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public void Attack(Pokemon other)
    {
        double precision = RandomProvider.Instance.NextDouble();
        Console.WriteLine($"Precisión generada: {precision}.");

        if (precision > 0.5)
        {
            int damage = this.Power;
            if (precision > 0.9)
            {
                damage = (int) Math.Round(damage * 1.2);
            }
            other.HP = Math.Max(other.HP - damage, 0);
            Console.WriteLine($"{this.Name} causó {this.Power} de daño. {other}.");
            if (!other.IsAlive)
            {
                Console.WriteLine($"{other.Name} fue derrotado.");
            }
        }
        else
        {
            Console.WriteLine($"{other.Name} evadió el ataque de {this.Name}.");
        }
    }

    public override string ToString()
    {
        return $"{Name} tiene {HP} HP";
    }
}