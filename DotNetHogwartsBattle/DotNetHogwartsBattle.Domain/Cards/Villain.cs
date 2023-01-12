namespace DotNetHogwartsBattle.Domain.Cards;

public class Villain : Card
{
    public Ability Ability { get; set; }
    public int Health { get; set; }
    public Reward Reward { get; set; }

    public override string ToString()
    {
        return "Ability: " + Ability + "\nHealth: " + Health + "\n Reward: " + Reward;
    }
}