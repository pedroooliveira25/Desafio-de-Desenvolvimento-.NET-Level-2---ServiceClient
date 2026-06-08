using SendGrid;
using SendGrid.Helpers.Mail;

public class EmailService
{
    private readonly string _apiKey;

    public EmailService(string apiKey)
    {
        _apiKey = apiKey;
    }

    public async Task SendCadastroEmAnalise(string nome, string email)
    {
        var client = new SendGridClient(_apiKey);

        var from = new EmailAddress(
            "noreply@pathbit.com",
            "PATHBIT"
        );

        var to = new EmailAddress(email, nome);

        var subject = "Cadastro em análise";

        var body = $@"
Olá {nome},

O seu cadastro está em análise e em breve você receberá um e-mail com novas atualizações sobre seu cadastro.

Atenciosamente,

Equipe PATHBIT";

        var msg = MailHelper.CreateSingleEmail(
            from,
            to,
            subject,
            body,
            body
        );

        await client.SendEmailAsync(msg);
    }
}