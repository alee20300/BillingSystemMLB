﻿using Domin.Models;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAtollRepository : IRepository<Atoll>
    {
        Task<Atoll> GetbyintIdAsync(int Id);
        Task<Atoll> Update(Atoll atoll);


    }


}
