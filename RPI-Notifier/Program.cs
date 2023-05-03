using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Octokit;


using IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureServices(services =>
	{

	})
	.Build();


await host.RunAsync();

ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
IConfiguration configuration = configurationBuilder.AddUserSecrets<Program>().Build();
string githubToken = configuration.GetSection("secret")["supersecret"];


var client = new GitHubClient(new ProductHeaderValue("testApp"))
{
	Credentials = new Credentials(githubToken)
};
var user = await client.Issue.GetAllForCurrent();
Console.WriteLine(user.Count);

