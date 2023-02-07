using DotNetHogwartsBattle.Common;
using DotNetHogwartsBattle.Domain.Cards;

namespace DotNetHogwartsBattle.Domain;

public class Game
{
    public int Id { get; set; }
    public int CurrentGameIdentifier { get; set; }

    /// <summary>
    /// All the <see cref="PlayerBoards"/> of the players who will be playing the game.
    /// </summary>
    public List<PlayerBoard> PlayerBoards { get; set; }
    
    /// <summary>
    /// The <see cref="Villain"/>'s who are still in the deck.
    /// </summary>
    public Deck<Villain> VillainsDeck { get; set; }
    
    /// <summary>
    /// The <see cref="Villain"/>'s who are currently in the game.
    /// </summary>
    public List<Villain> Villains { get; set; } = new();
    
    /// <summary>
    /// The <see cref="Location"/>'s that are still in the deck.
    /// </summary>
    public Deck<Location>? LocationDeck { get; set; }
    
    /// <summary>
    /// The current <see cref="Location"/>.
    /// </summary>
    public Location? Location { get; set; }
    
    /// <summary>
    /// The discard pile which will contain the defeated <see cref="Villain"/>'s and lost <see cref="Location"/>'s.
    /// </summary>
    public Deck<GameDiscardable> DiscardDeck { get; set; } = new();

    /// <summary>
    /// All <see cref="DarkArts"/> cards in the deck
    /// </summary>
    public Deck<DarkArts> DarkArtDeck { get; set; }

    /// <summary>
    /// All the discarded <see cref="DarkArts"/> cards
    /// </summary>
    public Deck<DarkArts> DarkArtsDiscardDeck { get; set; }

    /// <summary>
    /// A list of <see cref="AbilityWithTrigger"/> which need to be triggered at some point in the turn. 
    /// At the end of the turn, this list will be cleared.
    /// </summary>
    public List<AbilityWithTrigger> AbilitiesToBeTriggered { get; set; }

    /// <summary>
    /// This will be set at the start of a new game.
    /// Default is 1
    /// </summary>
    public int NrOfVillainsActive { get; set; } = 1;

    public virtual bool HasVillains => Villains.Any() || VillainsDeck.Cards.Any();
}