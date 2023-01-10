using DotNetHogwartsBattle.Common.Enums;

namespace DotNetHogwartsBattle.Domain;

public abstract class Card
{
    public int Id { get; set; }
    public CardType CardType { get; set; }
    public string Name { get; set; }
    public int GameIdentifier { get; set; }
    public byte[]? Image { get; set; }
}