using RandomProviderInjection;

namespace RandomProviderInjectionTests;

public class RandomProviderTests
{
    [Test]
    public void TestSameSeedRestart()
    {
        RandomProvider.Restart(1000);
        double n1 = RandomProvider.Instance.NextDouble();
        RandomProvider.Restart(1000);
        double n2 = RandomProvider.Instance.NextDouble();
        Assert.That(n1, Is.EqualTo(n2));
    }
    
    [Test]
    public void TestDifferentSeedRestart()
    {
        RandomProvider.Restart(1000);
        double n1 = RandomProvider.Instance.NextDouble();
        RandomProvider.Restart(9999);
        double n2 = RandomProvider.Instance.NextDouble();
        Assert.That(n1, Is.Not.EqualTo(n2));
    }

    [Test]
    public void TestSubsequentNumbersAreNotEqual()
    {
        RandomProvider rnd = RandomProvider.Instance;
        double n1 = rnd.NextDouble();
        double n2 = rnd.NextDouble();
        Assert.That(n1, Is.Not.EqualTo(n2));
    }
}