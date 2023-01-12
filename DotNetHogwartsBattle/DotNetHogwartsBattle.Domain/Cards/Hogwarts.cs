namespace DotNetHogwartsBattle.Domain.Cards;

public class Hogwarts : StartHero
{
    public int Value { get; set; }
    public override string ToString()
    {
        return Name + " " + Type + " Value: " + Value + " Effect(s): " + string.Join(", ", CardEffect);
    }
}