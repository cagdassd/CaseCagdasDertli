using Entities.Concrete;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net;
using System.Net.Mail;
using System.Text;

internal class Program
{
	static void Main(string[] args)
	{
		var factory = new ConnectionFactory();
		factory.Uri = new Uri("amqps://pfrxyapi:bfeX09-lnmiLAHZzeRDltpcFswm_z8zv@cow.rmq2.cloudamqp.com/pfrxyapi");

		using var connection = factory.CreateConnection();

		var channel = connection.CreateModel();

		channel.QueueDeclare("mail_queue", true, false, false, null);

		var consumer = new EventingBasicConsumer(channel);
		channel.BasicConsume("mail_queue", true, consumer);

		consumer.Received += Consumer_Received;

		Console.ReadLine();
	}
	private static void Consumer_Received(object? sender, BasicDeliverEventArgs e)
	{
		string reportString = Encoding.UTF8.GetString(e.Body.ToArray());
		MailModel mailmodel = JsonConvert.DeserializeObject<MailModel>(reportString);
		SendMail(mailmodel);
	}
	public static void SendMail(MailModel model)
	{
		string adminMail = "casecagdasdertli@hotmail.com";
		string adminPassword = "Casecaco1!";
		try
		{

			MailMessage mesaj = new MailMessage(adminMail, model.Reciever, model.Subject, model.Content);
			SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
			smtp.Credentials = new NetworkCredential(adminMail, adminPassword);
			smtp.EnableSsl = true;
			smtp.Send(mesaj);
		}
		catch (Exception ex)
		{
			
		}
	}
}