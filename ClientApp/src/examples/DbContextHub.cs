public class DbContextHub : Hub
{
    private readonly DbContext _dbContext;

    public DbContextHub(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Entity> GetEntity()
    {
      return await _dbContext.Entities.FirstOrDefaultAsync();
    }
}