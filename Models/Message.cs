using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models{
    public class Message{
        public int MessageId { get; set; }  

        // [Required]
        public string MegContent { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // each message belong to a user 
        public int UserId { get; set; }
        public User Creator { get; set; }

        // each message has List of comments
        public List<Comment> Comments { get; set; }
        
    }
}