using DotNetHogwartsBattle.Domain.Enums;

namespace DotNetHogwartsBattle.Domain;

public class Action
{
    public int Id { get; set; }
    public Target Target { get; set; }
    public int NrOfActions { get; set; }
    public ActionType ActionType { get; set; }

    public override string ToString()
    {
        return Target + " " + NrOfActions + " x " + ActionType;
    }
}