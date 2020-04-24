using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RSVP
{
    [Key]
    public int RsvpId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //Foreign Keys
    public int UserId { get; set; }
    public int WeddingId { get; set; }

    //Navigation Properties
    public User Attendee { get; set; }
    public Wedding Wedding { get; set; }


}
