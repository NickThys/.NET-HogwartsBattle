using DotNetHogwartsBattle.Common;
using DotNetHogwartsBattle.Domain.Cards;

namespace DotNetHogwartsBattle.Domain;

public class Deck<TCard> where TCard : Card
{
    public int Id { get; set; }
    //ToDo maybe change it to a sorted list?
    public List<TCard> Cards { get; set; }=new List<TCard>();
    public byte[]? BackImg { get; set; }
}