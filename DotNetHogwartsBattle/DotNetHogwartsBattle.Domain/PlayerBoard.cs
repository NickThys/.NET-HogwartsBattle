using DotNetHogwartsBattle.Domain.Cards;

namespace DotNetHogwartsBattle.Domain;

public class PlayerBoard
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsActivePlayer { get; set; }
    public int PlayerOrder { get; set; }
    public int Health { get; private set; }

    public int NrOfAttacks { get; set; }
    public int NrOfInfluenceTokens { get; set; }
    public List<StartHero> PlayableCards { get; set; } = new();
    public Deck<StartHero> DrawDeck { get; set; } = new();
    public Deck<StartHero> DiscardDeck { get; set; } = new();
    public Game Game { get; set; }
}