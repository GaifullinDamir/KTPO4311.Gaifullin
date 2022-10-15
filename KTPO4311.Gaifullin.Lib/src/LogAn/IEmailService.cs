namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    public interface IEmailService
    {
        public void SendEmail(string to, string subject, string body);
    }
}
