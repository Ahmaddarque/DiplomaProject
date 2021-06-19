using Olympiads.DAL.Domain;
using System.Data.Entity;

namespace Olympiads.DAL.EF
{
    public partial class OlympiadDb : DbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Visiter> Visiters { get; set; }
        public DbSet<Test> Tests { get; set; }

        public DbSet<TaskOption> TaskOptions { get; set; }
        public DbSet<Task> Tasks { get; set; }
        
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ParticipantCategory> Categories { get; set; }
        public DbSet<PhoneRestore> PhoneRestores { get; set; }
        public DbSet<EmailRestore> EmailRestores { get; set; }
        public DbSet<TestPassing> TestPassings { get; set; }
        public DbSet<OlympiadPassing> OlympiadPassings { get; set; }
        public DbSet<TaskAnswer> TaskAnswers { get; set; }
        public DbSet<ParticipantLogin> ParticipantLogins { get; set; }
        public DbSet<Admin> Administrators { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Olympiad> Olympiads { get; set; }
        public OlympiadDb() : base("OlympiadDb") { }

        static OlympiadDb()
        {
            Database.SetInitializer(new OlympiadDbInitializer());
        }
    }
}