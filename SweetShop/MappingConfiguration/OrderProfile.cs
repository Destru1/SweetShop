﻿using AutoMapper;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.ViewModels.Order;

namespace SweetShop.MappingConfiguration
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            this.CreateMap<Order, OrderDTO>();

            this.CreateMap<Order, OrderIndexViewModel>()
                .ForMember(vm => vm.ProductId, mf => mf.MapFrom(o => o.Product.Name))
                .ForMember(vm => vm.ClientId, mf => mf.MapFrom(m => m.Client.FirstName)).ReverseMap();

        }
    }
}
