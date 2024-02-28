namespace Rthread;
 
public class Horse
{
    public int lengthsRan = 0;
    public string horseName = "";
    public HorseRace hr;
    public Horse(string name, HorseRace id)
    {
        hr = id;
        horseName = name;
    }
 
    public void RunAllDistances()
    {
        lengthsRan=0;
        while (lengthsRan < hr.globalLengthOfRace && hr.WinnerDeclared==false)
        {
            RunOneDistance();
            lengthsRan++;
        }
        if (!hr.WinnerDeclared)
            hr.DeclareHorseWinner();
    }
    public void RunOneDistance()
    {
        while (Random.Shared.Next(50_000_000) != 0) ;
        return;
    }
}
public class HorseRace
{
    public int globalLengthOfRace = 50;
    public bool WinnerDeclared = false;
    public int numberOfHorses = 0;
    public void DeclareHorseWinner() { WinnerDeclared = true; }
    //private List<Horse> horsesInRace = new();
}
class Program
{
    static void Main(string[] args)
    {
        HorseRace race = new();
        Console.WriteLine("Welcome to the horse race");
        Console.WriteLine($"Each horse will run {race.globalLengthOfRace} lengths of the field.");
        var horse1 = new Horse("Fred", race);
        //horsesInRace.Add(horse1);
        var horse2 = new Horse("Sally", race);
        //horsesInRace.Add(horse2);
        var horse1Thread = new Thread(horse1.RunAllDistances);
        var horse2Thread = new Thread(horse2.RunAllDistances);
        horse1Thread.Start();
        horse2Thread.Start();
        while (race.WinnerDeclared == false)
        {
            Console.WriteLine($"{horse1.horseName}: {horse1.lengthsRan}       {horse2.horseName}: {horse2.lengthsRan}");
            Thread.Sleep(1000);
        }
        //Final race results
            Console.WriteLine($"FINAL RESULTS:  {horse1.horseName}: {horse1.lengthsRan}       {horse2.horseName}: {horse2.lengthsRan}");
    }
}
 