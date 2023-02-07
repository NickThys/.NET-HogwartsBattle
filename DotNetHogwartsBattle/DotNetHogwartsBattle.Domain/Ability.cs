namespace DotNetHogwartsBattle.Domain;

public class Ability
{
    public int Id { get; set; }

    /// <summary>
    /// When the player needs to choose between 2 <see cref="Action"/> set this to true.
    /// </summary>
    public bool HasToChooseBetween { get; set; }

    /// <summary>
    /// A list of all the action that can be done by this <see cref="Ability"/>
    /// </summary>
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