namespace DotNetHogwartsBattle.Domain;
public class Reward
{
    public int Id { get; set; }
    public IEnumerable<Action> Actions { get; set; }

    public override string ToString()
    {
        return string.Join("\n", Actions);
    }
}