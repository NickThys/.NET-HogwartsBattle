namespace DotNetHogwartsBattle.Domain.Cards
{
    public class Location:Card ,IGameDiscard
    {
        public int LocationNr { get; set; }
        public int NrOfLocations { get; set; }
        public int NrOfDarkArtsReveals { get; set; }
        public int NrOfDarkMarkTokens { get; set; }
        public int NrOfDarkMarkTokensNeeded { get; set; }

        public override string ToString()
        {
            return $"LocationName= {Name} Location= {LocationNr}/{NrOfLocations}\n" +
                   $"Dark arts reveals= {NrOfDarkArtsReveals}\n" +
                   $"DarkMarkTokens= {NrOfDarkMarkTokens}/{NrOfDarkMarkTokensNeeded}";
        }
    }
}
