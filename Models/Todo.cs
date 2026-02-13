using System;
using System.ComponentModel.DataAnnotations;

namespace abimanyu_todolist.Models
{
    public class Todo
    {
        
        public Guid Id { get; set; } = Guid.NewGuid(); 
        
        
        [Required(ErrorMessage = "Title tidak boleh kosong")]
        public string Title { get; set; } = string.Empty; 
        
        
        public bool IsCompleted { get; set; } = false; 
        

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    }
}