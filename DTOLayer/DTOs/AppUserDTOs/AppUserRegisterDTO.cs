namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserRegisterDTO
    {
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
