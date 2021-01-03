using Domin.Models;

namespace Repository.SQL
{
    public
        class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
