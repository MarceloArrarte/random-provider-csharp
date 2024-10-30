namespace RandomProviderInjection;

public class RandomProvider
{
    // Esta clase interna almacena datos de configuración para crear la instancia del Singleton.
    // En este caso, podemos o no tener una seed inicial (por eso el ? en int?)
    private class Config
    {
        public int? Seed { get; set; }
    }
    
    // Creamos un objeto para almacenar la configuración actual del Singleton.
    // La configuración debe realizarse antes de acceder a Instance por primera vez.
    private static Config Settings { get; } = new Config();
    
    // Creamos un get/set que permite modificar la seed en la configuración
    // a usar para crear la instancia de RandomProvider.
    public static int? Seed
    {
        get { return Settings.Seed; }
    }

    public static void Restart(int? seed)
    {
        _instance = null;
        Settings.Seed = seed;
    }
    
    
    // Implementación del patrón Singleton.
    private static RandomProvider? _instance;
    public static RandomProvider Instance
    {
        get
        {
            if (_instance is null)
            {
                // Si la instancia de RandomProvider todavía no existe,
                // se crea con la configuración cargada actualmente.
                _instance = new RandomProvider(Settings);
            }
            return _instance;
        }
    }
    
    private RandomProvider(Config config)
    {
        if (config.Seed.HasValue)
        {
            random = new Random(config.Seed.Value);
            Console.WriteLine($"RandomProvider instanciado con seed = {config.Seed.Value}.");
        }
        else
        {
            int randomSeed = new Random().Next();
            random = new Random(randomSeed);
            Console.WriteLine($"RandomProvider instanciado con seed ALEATORIA = {randomSeed}.");
        }
    }
    
    // Atributo y métodos de clase que utilizamos para generar números aleatorios.
    private Random random;

    public double NextDouble()
    {
        return random.NextDouble();
    }
}