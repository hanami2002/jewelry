
namespace Utilities
{
    public interface IEmailService
    {
        Task<bool> Send(EmailSetting emailSetting);
    }
}