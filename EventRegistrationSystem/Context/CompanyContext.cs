namespace EventRegistrationSystem.Context
{
    using EventRegistrationSystemModels;
    using Microsoft.EntityFrameworkCore;
    

    public class CompanyContext:DbContext
    {
        public CompanyContext(DbContextOptions options): base(options)
        {

        }

      
        public DbSet<Permissions> permissions { get; set; }
        public DbSet<Ref_Event_Type> ref_Event_Types { get; set; }
        public DbSet<Events> events { get; set; }
        public DbSet<Event_Registration> event_Registrations { get; set; }

    }
}
