using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }
    public int UserId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Groom's name must be at least 2 chars")]
    public string Groom { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Bride's name must be at least 2 chars")]
    public string Bride { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string Address { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //One to Many
    public User Creator { get; set; }
    //Many to Many
    public List<RSVP> ListPeople { get; set; }

}