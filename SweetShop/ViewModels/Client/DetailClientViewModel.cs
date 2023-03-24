using SweetShop.Models.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.ViewModels.Client
{
    public class DetailClientViewModel
    {
        public int Id { get; set; }

        [DisplayName("Име")]
        public string FirstName { get; set; }

        [DisplayName("Презиме")]
        public string LastName { get; set; }

        [DisplayName("Град")]
        public string City { get; set; }

        [DisplayName("Адрес")]
        public string Address { get; set; }

        [DisplayName("Телефонен номер")]
        public string PhoneNumber { get; set; }

        [DisplayName("Лице")]
        public PersonEntity PersonEntity { get; set; }

        [DisplayName("Дистрибутор")]
        public string DistributorId { get; set; }

        [DisplayName("Потребителско име")]
        public string UserId { get; set; }

        [DisplayName("Създадено на")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Променено на")]
        public DateTime? ModifiedOn { get; set;}
    }
}
