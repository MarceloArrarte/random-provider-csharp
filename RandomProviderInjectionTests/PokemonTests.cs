using RandomProviderInjection;

namespace RandomProviderInjectionTests;

public class PokemonTests
{
    private Pokemon charmander;
    private Pokemon paras;

    private int seed12 = 178908615;
    private int seed58 = 1960753258;
    private int seed92 = 590239632;
    
    [SetUp]
    public void Setup()
    {
        charmander = new Pokemon("Charmander", 20);
        paras = new Pokemon("Paras", 8);
    }

    [TearDown]
    public void TearDown()
    {
        Console.SetOut(Console.Out);
    }

    [Test]
    public void TestAtaqueExitosoVidaCompleta()
    {
        RandomProvider.Restart(seed58);
        charmander.Attack(paras);
        Assert.That(paras.HP, Is.EqualTo(80));
    }

    [Test]
    public void TestAtaqueCritico()
    {
        RandomProvider.Restart(seed92);
        charmander.Attack(paras);
        Assert.That(paras.HP, Is.EqualTo(76));
    }

    [Test]
    public void TestAtaqueEsquivado()
    {
        RandomProvider.Restart(seed12);
        charmander.Attack(paras);
        Assert.That(paras.HP, Is.EqualTo(100));
    }

    [Test]
    public void TestEsDerrotadoEventualmente()
    {
        TextWriter output = new StringWriter();
        Console.SetOut(output);
        while (paras.IsAlive)
        {
            charmander.Attack(paras);
        }
        Assert.That(output.ToString(), Does.Contain("Paras fue derrotado."));
        Assert.That(paras.IsAlive, Is.False);
        Assert.That(paras.HP, Is.Zero);
    }

    [Test]
    public void TestVidaNoBajaDe0()
    {
        while (charmander.IsAlive)
        {
            paras.Attack(charmander);
        }
        
        Assert.That(charmander.HP, Is.Zero);
    }
}