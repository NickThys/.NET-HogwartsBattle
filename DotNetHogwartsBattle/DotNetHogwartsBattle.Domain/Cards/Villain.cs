using DotNetHogwartsBattle.Common;

namespace DotNetHogwartsBattle.Domain.Cards;

public class Villain : GameDiscardable
{
    public Ability Ability { get; set; }
    public int Health { get; set; }
    public Reward Reward { get; set; }

    public override string ToString()
    {
        return Name + " " + CardKind + " Value: " + "Ability: " + Ability + "\nHealth: " + Health + "\n Reward: " + Reward;
    }
}