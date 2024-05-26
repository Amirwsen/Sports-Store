namespace SportsStore.Models;

public class EFStoreRepository : IStoreRepository
{
    private StoreDbContext context;

    public EFStoreRepository(StoreDbContext ctx)
    {
        context = ctx;
    }

    public IQueryable<Product> Products => context.Products;

    // public IList<Product> GetAll()
    // {
    //     return Products.Where( x => x.ProductID == 1).ToList();
    // }
}