﻿using AutoMapper;
using SweetShop.Data;

namespace SweetShop.Services
{
    public abstract class BaseService
    {


        protected BaseService(SweetShopDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        protected SweetShopDbContext DbContext { get; }

        protected IMapper Mapper { get; }
    }
}
