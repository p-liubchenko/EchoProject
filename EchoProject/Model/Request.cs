namespace EchoProject.Model;

public class Request
{
	public string Url { get; set; }
	public string Method { get; set; }
	public string[] UrlParts { get; set; }
	public Dictionary<string, string> Params { get; set;}
	public Dictionary<string, string> Headers { get; set;}
	public string Body { get; set;}
}
