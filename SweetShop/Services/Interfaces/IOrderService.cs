﻿using SweetShop.DTOs;
using SweetShop.ViewModels.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderIndexViewModel> GetAll();

        TEntity GetById<TEntity>(int id);

        DetailsOrderViewModel GetDetails(int id);

        Task CreateAsync(OrderDTO order);

        Task<bool> UpdateAsync(int id, OrderDTO order);

        Task<bool> DeleteAsync(int id);
    }
}
