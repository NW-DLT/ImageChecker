using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_StudioTestTask.Models
{
    public class CopyPhoto
    {
        [Key]
        public int Id { get; set; }

        public int photosId { get; set; }

    }
}
