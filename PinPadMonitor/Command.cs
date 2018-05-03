using System;

namespace PinPadMonitor
{
	[Serializable]
	public class Command
	{
		private Command(string type, string content)
		{
			this.Type = type;
			this.Content = content;
		}

		public string Type { get; }
		public string Content { get; }

		public static Command Request(string content)
		{
			return new Command("REQ", content);
		}

		public static Command Response(string content)
		{
			return new Command("RES", content);
		}
	}
}