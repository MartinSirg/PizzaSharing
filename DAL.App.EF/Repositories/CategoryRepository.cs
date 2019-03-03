using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category> , ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Category>> AllAsync()
        {
            return await RepoDbSet
                .Include(category => category.Organization)
                .ToListAsync();
        }

        public override async Task<Category> FindAsync(params object[] id)
        {
            var category =  await base.FindAsync(id);

            if (category != null)
            {
                await RepoDbContext.Entry(category).Reference(cat => cat.Organization).LoadAsync();    
            }

            return category;
        }
    }
}