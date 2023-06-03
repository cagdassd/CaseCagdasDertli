using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace WebAPI.RabbitMQ
{
	public class RabbitMQService
	{
		private readonly string _rabbitMQConnectionUrl;

		public RabbitMQService(string rabbitMQConnectionUrl)
		{
			_rabbitMQConnectionUrl = rabbitMQConnectionUrl;
		}

		public void SendMailMessage(MailModel mailModel)
		{
			var factory = new ConnectionFactory
			{
				Uri = new Uri(_rabbitMQConnectionUrl)
			};

			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "mail_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

				var message = mailModel;
				

				var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

				channel.BasicPublish(exchange: "", routingKey: "mail_queue", basicProperties: null, body: body);
			}
		}




		



		}

}
