using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Producer");

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
var queueName = "hello";

channel.QueueDeclare(queueName,
    durable: false,
    exclusive: false, 
    autoDelete: false, 
    arguments: null);

var message = "Hello World";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: "", 
    routingKey: queueName, 
    basicProperties: null, 
    body: body);

Console.WriteLine("[x] Send message: {0}", message);

Console.ReadLine();