using Event_Registration_System.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Event_Registration_System.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options)
        : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Generate random IDs for 10 events
            Random random = new Random();
            var randomEventIds = new HashSet<int>();

            // Ensure unique random IDs
            while (randomEventIds.Count < 10)
            {
                randomEventIds.Add(random.Next(1, 1000));
            }

            // Convert HashSet to array for easier access
            var eventIds = randomEventIds.ToArray();

            // Seed data for 10 events
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = eventIds[0],
                    Title = "Tech Conference 2024",
                    Date = new DateTime(2024, 6, 15, 9, 0, 0),
                    Description = "Join us for a day of tech talks and networking.",
                    Capacity = 500
                },
                new Event
                {
                    EventId = eventIds[1],
                    Title = "Art Exhibition",
                    Date = new DateTime(2024, 7, 20, 10, 0, 0),
                    Description = "Explore the latest art from local artists.",
                    Capacity = 200
                },
                new Event
                {
                    EventId = eventIds[2],
                    Title = "Cooking Workshop",
                    Date = new DateTime(2024, 8, 5, 14, 0, 0),
                    Description = "Learn to cook delicious meals with our expert chefs.",
                    Capacity = 50
                },
                new Event
                {
                    EventId = eventIds[3],
                    Title = "Business Seminar",
                    Date = new DateTime(2024, 9, 10, 10, 0, 0),
                    Description = "A seminar for small business owners to learn strategies for growth.",
                    Capacity = 150
                },
                new Event
                {
                    EventId = eventIds[4],
                    Title = "Music Festival",
                    Date = new DateTime(2024, 10, 1, 12, 0, 0),
                    Description = "Enjoy a weekend of live music and entertainment.",
                    Capacity = 1000
                },
                new Event
                {
                    EventId = eventIds[5],
                    Title = "Yoga Retreat",
                    Date = new DateTime(2024, 11, 3, 8, 0, 0),
                    Description = "A relaxing weekend retreat focusing on mindfulness and yoga.",
                    Capacity = 75
                },
                new Event
                {
                    EventId = eventIds[6],
                    Title = "Coding Bootcamp",
                    Date = new DateTime(2024, 12, 1, 9, 0, 0),
                    Description = "A 3-day immersive coding bootcamp for beginners.",
                    Capacity = 100
                },
                new Event
                {
                    EventId = eventIds[7],
                    Title = "Photography Workshop",
                    Date = new DateTime(2024, 10, 25, 11, 0, 0),
                    Description = "A hands-on workshop for amateur photographers to learn new skills.",
                    Capacity = 40
                },
                new Event
                {
                    EventId = eventIds[8],
                    Title = "Charity Gala",
                    Date = new DateTime(2024, 12, 20, 18, 0, 0),
                    Description = "A formal evening event to raise funds for local charities.",
                    Capacity = 300
                },
                new Event
                {
                    EventId = eventIds[9],
                    Title = "Book Fair",
                    Date = new DateTime(2024, 11, 15, 10, 0, 0),
                    Description = "A fair featuring local authors and book signings.",
                    Capacity = 200
                }
            );
        }
    }
}
