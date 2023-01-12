using DotNetHogwartsBattle.Domain.Enums;

namespace DotNetHogwartsBattle.Domain.Cards;

public abstract class Card
{
    public int Id { get; set; }
    public CardKind CardKind { get; set; }
    public string Name { get; set; }
    public int GameIdentifier { get; set; }
    public byte[]? Image { get; set; }

    public override string ToString()
    {
        return Name + " " + CardKind + " " + GameIdentifier;
    }
}