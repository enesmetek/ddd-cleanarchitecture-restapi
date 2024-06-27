using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository(BuberDinnerDbContext context) : IMenuRepository
    {
        private readonly BuberDinnerDbContext _context = context;

        public void Add(Menu menu)
        {
            _context.Add(menu);
            _context.SaveChanges();
        }
    }
}
