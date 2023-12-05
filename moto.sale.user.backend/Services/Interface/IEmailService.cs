namespace motosale.user.backend.Services.Interface
{
    public interface IEmailService
    {
        bool SendEmailForgetPassword(string userMail, string token);
    }
}
