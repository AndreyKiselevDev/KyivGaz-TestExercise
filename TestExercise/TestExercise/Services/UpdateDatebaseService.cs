using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestExercise.Context;

namespace TestExercise.Services
{
    public class UpdateDatebaseService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public UpdateDatebaseService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<OrderContext>();
                await context.Database.MigrateAsync();
            }
        }
    }
}