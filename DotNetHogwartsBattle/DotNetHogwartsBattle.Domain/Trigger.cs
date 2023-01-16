using DotNetHogwartsBattle.Domain.Enums;

namespace DotNetHogwartsBattle.Domain;

public class Trigger
{
    public int Id { get; set; }
    public When When { get; set; }
    public IEnumerable<TriggerEvent> Events { get; set; }
    public IEnumerable<TriggerTriggeredBy>? TriggertBy { get; set; }
}

public class TriggerTriggeredBy
{
    public int TriggerId { get; set; }
    public Trigger Trigger { get; set; }
    public CardType CardType { get; set; }
}

public class TriggerEvent
{
    public int TriggerId { get; set; }
    public Trigger Trigger { get; set; }
    public Event Event { get; set; }
}