namespace QuestionWare.Quiz.Domain.Common
{
    public class AuditableEntity : Entity<int>
    {
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
