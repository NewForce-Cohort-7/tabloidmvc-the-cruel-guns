using TabloidMVC.Models;
using System.Collections.Generic;
using Humanizer;
using static Azure.Core.HttpHeader;
using System.Drawing.Drawing2D;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace TabloidMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
