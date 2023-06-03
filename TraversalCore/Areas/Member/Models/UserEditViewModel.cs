namespace TraversalCore.Areas.Member.Models
{
    public class UserEditViewModel
    {
        public string NameSurname { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string ImageURL { get; set; }
        public IFormFile Image { get; set; }
    }
}
