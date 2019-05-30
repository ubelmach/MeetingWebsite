using MimeKit;
using MimeKit.Text;

namespace MeetingWebsite.BLL.Builders
{
    public class EmailBuilder
    {
        private readonly MimeMessage _message;

        public EmailBuilder()
        {
            _message = new MimeMessage();
        }

        public EmailBuilder From()
        {
            _message.From.Add(new MailboxAddress(Constants.Administrator_Name, Constants.Administrator_Email));
            return this;
        }

        public EmailBuilder To(string email)
        {
            _message.To.Add(new MailboxAddress(string.Empty, email));
            return this;
        }

        public EmailBuilder Subject(string subject)
        {
            _message.Subject = subject;
            return this;
        }

        public EmailBuilder Body(string bodyText)
        {
            _message.Body = new TextPart(TextFormat.Html)
            {
                Text = bodyText
            };
            return this;
        }

        public MimeMessage Build()
        {
            return _message;
        }
    }
}