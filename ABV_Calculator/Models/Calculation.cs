namespace ABV_Calculator.Models;

public class Calculation 
{
    public int Id { get; set; }
    public double OriginalGravity { get; set; }
    public double FinalGravity { get; set; }
    public double Abv { get; set; }
    public DateTime Date { get; set; }
}