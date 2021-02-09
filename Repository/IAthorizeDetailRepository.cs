using Domin.Data;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAthorizeDetailRepository : IRepository<AutorizeDetail>
    {


        Task<AutorizeDetail> GetauthorrizedData (string username);
    }
}
