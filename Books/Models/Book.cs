using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        [MaxLength (100)]
        public string Author { get; set; }
        public DateTime AddedOn { get; set; }
        [ForeignKey("Category")]
        public byte CategoryId {  get; set; }
        public Category Category { get; set; }
        public Book()
        {
            
            AddedOn = DateTime.Now;
        }
    }
}
