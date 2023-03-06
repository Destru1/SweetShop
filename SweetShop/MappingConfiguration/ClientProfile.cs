﻿using AutoMapper;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.ViewModels.Client;

namespace SweetShop.MappingConfiguration
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            this.CreateMap<Client, ClientDTO>();

            this.CreateMap<Client, ClientIndexViewModel>();
        }
    }
}
