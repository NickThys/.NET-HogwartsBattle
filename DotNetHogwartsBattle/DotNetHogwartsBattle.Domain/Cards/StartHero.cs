using DotNetHogwartsBattle.Common;
using DotNetHogwartsBattle.Common.Enums;

namespace DotNetHogwartsBattle.Domain.Cards;

public class StartHero : Card
{
    public CardType Type { get; set; }
    public IEnumerable<Ability> CardEffect { get; set; }

    public override string ToString()
    {
        return Name + " " + Type + " Effect(s): " + string.Join(", ", CardEffect);
    }
}