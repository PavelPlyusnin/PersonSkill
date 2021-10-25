using System.Collections.Generic;

namespace PersonSkill.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        
        [Key]
        [Required]
        public long PersonId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        [Required]
        public virtual List<Skill> Skills { get; set; }
    }
}
