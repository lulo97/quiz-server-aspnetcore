using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Report
    {
        [Key]
        public Guid ReportId { get; set; } = Guid.NewGuid();

        public Guid ReportReasonId { get; set; }

        public Guid ReportTargetId { get; set; }

        public Guid UserId { get; set; }

        public Guid ParentId { get; set; }

        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Guid UserResolveId { get; set; }

        public DateTime ResolvedAt { get; set; }
    }
}
