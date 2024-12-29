using Microsoft.Extensions.Logging;
using School.Data.Contexts;
using School.Data.Entities.MainEntities;
using System.Text.Json;


namespace School.Repository.Seeding.SeedingBase
{
    public class SchoolContextSeed
    {
        public static async Task SeedAsync(SchoolDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.Students != null && !context.Students.Any())
                {
        
                    var StudentsData = File.ReadAllText("../School.Repository/Seeding/SeedingData/StudentsData.json");
                    var Students = JsonSerializer.Deserialize<List<Student>>(StudentsData);

                    if (Students != null)
                    {
                        await context.Students.AddRangeAsync(Students);
                    }
                }
                if (context.Subjects != null && !context.Subjects.Any())
                {
        
                    var SubjectsData = File.ReadAllText("../School.Repository/Seeding/SeedingData/SubjectsData.json");
                    var subjects = JsonSerializer.Deserialize<List<Subject>>(SubjectsData);

                    if (subjects != null)
                    {
                        await context.Subjects.AddRangeAsync(subjects);
                    }
                }
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SchoolContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
