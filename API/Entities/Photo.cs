using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url{ get; set; }
        public Boolean IsMain{ get; set; }
        public string PublicID{ get; set; }

        public int AppUserId { get; set; }
        public AppUsers AppUser { get; set; }
    }
}