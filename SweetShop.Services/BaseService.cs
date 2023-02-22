using AutoMapper;
using SweetShop.Data;
using System;

namespace SweetShop.Services
{
    public abstract class BaseService
    {


        protected BaseService(SweetShopDbContext dbContext, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }

        protected SweetShopDbContext DbContext { get;}

        protected IMapper Mapper { get; }
    }
}
