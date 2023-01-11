using DotNetHogwartsBattle.Domain.Enums;

namespace DotNetHogwartsBattle.Domain;

public class StartHero:Card
{
    public StartHeroType Type { get; set; }
    public IEnumerable<Ability> CardEffect { get; set; }
}