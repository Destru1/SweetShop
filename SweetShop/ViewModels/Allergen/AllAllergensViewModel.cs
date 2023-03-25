using System.ComponentModel;

namespace SweetShop.ViewModels
{
    public class AllAllergensViewModel
    {
        public int Id { get; set; }

        [DisplayName("Име")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
    }
}
