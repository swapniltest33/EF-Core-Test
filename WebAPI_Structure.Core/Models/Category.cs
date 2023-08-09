using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI_Structure.Core.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Category

    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Product> products { get; set;} = null!;
    }
}
