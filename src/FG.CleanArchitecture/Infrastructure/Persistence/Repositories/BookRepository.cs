using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.DbContext;

namespace Infrastructure.Persistence.Repositories;
public class BookRepository : GenericRepository<Book>, IGenericRepository<Book>
{
    public BookRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
}
