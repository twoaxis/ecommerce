using API.EmailSetting;

namespace Core.Interfaces.EmailSetting
{
    public interface IEmailSettings
    {
        public void SendEmail(Email email, string code);
    }
}