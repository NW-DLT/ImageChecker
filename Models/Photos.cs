
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_StudioTestTask.Models
{
    public class Photos
    {
        public Photos() 
        {
            this.CopyCheck = false;
        }
        [Key]
        public int Id { get; set; } 
        public string Disription { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string? ImageSrc { get; set; }
        public DateTime uploadTime { get; set; }

        public bool CopyCheck { get; set; }

        public string getSrc(Photos item)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(item.Image.FileName);
            string fileName = item.Image.FileName;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                this.Image.CopyTo(stream);
            }
            return fileName;
        }

    }
}
