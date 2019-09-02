using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models{
    public class Comment{
        
        public int CommentId { get; set; }

        // [Required]
        public string ComContent { get; set; }

        //each comment belong to a message
        public int MessageId { get; set; }  
        public Message Message { get; set; }

        //each comment belong to a user
        public int UserId { get; set; } 
        public User User { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}