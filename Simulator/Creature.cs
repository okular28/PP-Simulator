namespace Simulator;

internal class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public string Name
    {
        get => name;
        init
        {
            name = value.Trim();
            if (string.IsNullOrEmpty(name))
            {
                name = "Unknown";
            }
            else
            {
                if (name.Length < 3)
                {
                    name = name.PadRight(3, '#');
                }

                if (name.Length > 25)
                {
                    name = name.Substring(0, 25).Trim();
                }

                if (char.IsLower(name[0]))
                {
                    name = char.ToUpper(name[0]) + name.Substring(1);
                }
            }
        }
    }

    public int Level
    {
        get => level;
        init
        {
            if (value < 1) level = 1;
            else if (value > 10) level = 10;
            else level = value;
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public string Info => $"{Name} [{Level}]";

    // Metoda powitania
    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
}
