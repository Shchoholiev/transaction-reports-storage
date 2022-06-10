using Microsoft.Extensions.DependencyInjection;
using TransactionReportsStorage.Core.Entities;
using TransactionReportsStorage.Infrastructure.EF;

namespace TransactionReportsStorage.Infrastructure.DataInitializer
{
    public static class DbInitializer
    {
        public static async Task InitializeDb(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            await Initialize(context);
        }

        private static async Task Initialize(ApplicationContext context)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var cell1 = new Cell { Name = "CellF" };
            var cell2 = new Cell { Name = "Second" };
            var cell3 = new Cell { Name = "Test" };

            await context.Cells.AddRangeAsync(cell1, cell2, cell3);
            await context.SaveChangesAsync();

            var petro = new User { Name = "Petro" };
            var andrii = new User { Name = "Andrii" };
            var mihail = new User { Name = "Mihail" };

            await context.Users.AddRangeAsync(petro, andrii, mihail);
            await context.SaveChangesAsync();

            var record1 = new Record 
            { 
                Name = "Moved Documentation", 
                DateTime = new DateTime().AddDays(-7),
                Cell = cell1,
                User = petro,
            };

            var record2 = new Record 
            { 
                Name = "Moved Project", 
                DateTime = new DateTime().AddDays(-15),
                Cell = cell1,
                User = andrii,
            };

            var record3 = new Record 
            { 
                Name = "Copied Images", 
                DateTime = new DateTime().AddDays(-9),
                Cell = cell2,
                User = mihail,
            };

            var record4 = new Record 
            { 
                Name = "Transfered data", 
                DateTime = new DateTime().AddDays(-4),
                Cell = cell3,
                User = andrii,
            };

            var record5 = new Record 
            { 
                Name = "Moved Pdfs", 
                DateTime = new DateTime().AddDays(-30),
                Cell = cell3,
                User = petro,
            };

            var record6 = new Record 
            { 
                Name = "Copied data", 
                DateTime = new DateTime().AddDays(-3.5),
                Cell = cell1,
                User = mihail,
            };

            var record7 = new Record 
            { 
                Name = "Changed data", 
                DateTime = new DateTime().AddDays(-3.2),
                Cell = cell3,
                User = andrii,
            };

            var record8 = new Record 
            { 
                Name = "Restored data", 
                DateTime = new DateTime().AddDays(-5.9),
                Cell = cell3,
                User = mihail,
            };

            var record9 = new Record 
            { 
                Name = "Copied data", 
                DateTime = new DateTime().AddDays(-1.5),
                Cell = cell2,
                User = andrii,
            };

            var record10 = new Record
            {
                Name = "Transfered data",
                DateTime = new DateTime().AddDays(-9),
                Cell = cell3,
                User = mihail,
            };

            var record11 = new Record
            {
                Name = "Moved data",
                DateTime = new DateTime().AddDays(-0.5),
                Cell = cell1,
                User = andrii,
            };

            var record12 = new Record
            {
                Name = "Changed data",
                DateTime = new DateTime().AddDays(-2),
                Cell = cell1,
                User = andrii,
            };

            var record13 = new Record
            {
                Name = "Changed data",
                DateTime = new DateTime().AddDays(-5),
                Cell = cell2,
                User = mihail,
            };

            await context.Records.AddRangeAsync(record1, record2, record3, record4, record5, record6, record7,
                                                record8, record9, record10, record11, record12, record13);
            await context.SaveChangesAsync();
        }
    }
}
