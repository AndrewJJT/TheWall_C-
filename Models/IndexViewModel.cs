using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models{
    public class IndexViewModel { 
        public Comment IndexComment{get;set;}
        public Message IndexMessage{get;set;}
    }
}