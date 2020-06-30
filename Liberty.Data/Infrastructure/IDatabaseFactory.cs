using System;

namespace Liberty.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ApplicationDbContext Create();
    }
}
