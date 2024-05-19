namespace ABV_Calculator.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Calculation 
{
    public int Id { get; set; }
    [Required]
    [Column("original_gravity")]  // Map to the original_gravity column in the database
    public double OriginalGravity { get; set; }

    [Required]
    [Column("final_gravity")]  // Map to the final_gravity column in the database
    public double FinalGravity { get; set; }

    [Required]
    [Column("abv")]  // Map to the abv column in the database
    public double Abv { get; set; }
    public DateTime date_time { get; set; }
}