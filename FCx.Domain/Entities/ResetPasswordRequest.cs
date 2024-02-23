namespace FCx.Domain.Entities
{
    public class ResetPasswordRequest
    {
        public string Login { get; set; }
        public string MotherName { get; set; }
        public string Document { get; set; }
    }
}
