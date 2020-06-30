namespace Liberty.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private ApplicationDbContext _dbContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected ApplicationDbContext DbContext
        {
            get
            {
                return _dbContext ?? (_dbContext = databaseFactory.Create());
            }
        }

        public void Save()
        {
            DbContext.Save();
        }
    }
}
