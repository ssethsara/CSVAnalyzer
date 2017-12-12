using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSVAnayser.Models
{
    public class FilmModel
    {
        
           
            public int movieId { get; set; }

            
            public string title { get; set; }

            
            public List<string> categories { get; set; }
        
    }
}