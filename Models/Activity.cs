using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrchestratorServer.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Task { get; set; }

        [Required]
        [MaxLength(100)]
        public string PropertyName { get; set; }

        [MaxLength(50)]
        public string ExecutionEnvironment { get; set; }

        [MaxLength(100)]
        public string ExecutionEnvironmentKey { get; set; }

        [MaxLength(100)]
        public string ExecutionClientId { get; set; }

        [MaxLength(100)]
        public string Alias { get; set; }

        [MaxLength(50)]
        public string Skip { get; set; }

        [MaxLength(500)]
        public string Document { get; set; }

        public Dictionary<string, string> Inputs { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Outputs { get; set; } = new Dictionary<string, string>();
    }
}
