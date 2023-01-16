namespace DotNetHogwartsBattle.Domain;

public class Ability
{
    public int Id { get; set; }
    public bool HasToChooseBetween { get; set; }
    public IEnumerable<Action> Actions { get; set; }
    public override string ToString()
    {
        return string.Join(", ", Actions.Select(x => x.ToString())) + " Has to choose between = " + HasToChooseBetween;
    }
}

public class AbilityWithTrigger : Ability
{
    public Trigger Trigger { get; set; }

    public override string ToString()
    {
        return string.Join(", ", Actions.Select(x => x.ToString())) + " Has to choose between = " + HasToChooseBetween;
    }
}