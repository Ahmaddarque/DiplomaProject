using System.ComponentModel.DataAnnotations;

namespace Olympiads.DAL.Domain
{
    public class TaskOption
    {
        public int Id { get; set; }
        public virtual Task Task { get; set; }
        public int? TaskId { get; set; }
        public bool IsCorrect { get; set; }
        public string Option { get; set; }
    }
}