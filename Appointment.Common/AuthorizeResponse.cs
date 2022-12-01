namespace Appointment.Common
{
    public class AuthorizeResponse
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}