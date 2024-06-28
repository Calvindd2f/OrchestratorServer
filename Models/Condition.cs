using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrchestratorServer.Models
{
    public class Condition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string PropertyName { get; set; }

        [MaxLength(50)]
        public string OptMode { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        [MaxLength(100)]
        public string OptionButton { get; set; }

        [MaxLength(500)]
        public string OptionText { get; set; }

        [MaxLength(100)]
        public string OptionCategory { get; set; }

        public List<InputProperty> InputProperties { get; set; } = new List<InputProperty>();
        public List<OutputProperty> OutputProperties { get; set; } = new List<OutputProperty>();
    }

    public class InputProperty
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string PropertyName { get; set; }

        public bool Required { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Option { get; set; }
    }

    public class OutputProperty
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string PropertyName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public List<string> Values { get; set; } = new List<string>();
    }
}
