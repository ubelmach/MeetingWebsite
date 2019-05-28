using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class Friendship
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FirstFriend")]
        public string IdFirstFriend { get; set; }

        [ForeignKey("SecondFriend")]
        public string IdSecondFriend { get; set; }

        public bool Confirmed { get; set; }

        public virtual User User { get; set; }
    }
}