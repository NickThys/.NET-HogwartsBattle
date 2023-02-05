using DotNetHogwartsBattle.Common;
using DotNetHogwartsBattle.Domain.Cards;

namespace DotNetHogwartsBattle.Domain;

public class Game
{
    public int Id { get; set; }
    public int CurrentGameIdentifier { get; set; }
    public List<PlayerBoard> PlayerBoards { get; set; }
    public Deck<Villain> VillainsDeck { get; set; }
    public List<Villain> Villains { get; set; } = new();
    public Deck<Location>? LocationDeck { get; set; }
    public Location? Location { get; set; }
    public Deck<GameDiscardable> DiscardDeck { get; set; } = new();
    public List<AbilityWithTrigger> AbilitiesToBeTriggered { get; set; }
    public int NrOfVillainsActive { get; set; } = 1;
    public virtual bool HasVillains => Villains.Any() || VillainsDeck.Cards.Any();
}