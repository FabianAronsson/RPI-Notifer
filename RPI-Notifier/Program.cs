using Microsoft.Extensions.Configuration;
using Octokit;

ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
IConfiguration configuration = configurationBuilder.AddUserSecrets<Program>().Build();
string githubToken = configuration.GetSection("secret")["supersecret"];

Console.WriteLine("Hello, World!");

var client = new GitHubClient(new ProductHeaderValue("testApp"))
{
    Credentials = new Credentials(githubToken)
};
var user = await client.Issue.GetAllForCurrent();
Console.WriteLine(user.Count);
