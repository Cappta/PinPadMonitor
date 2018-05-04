using System;

namespace PinPadMonitor
{
	[Serializable]
	public class Command
	{
		public Command(CommandType type, string content)
		{
			this.Type = type;
			this.Content = content;
		}

		public CommandType Type { get; }
		public string Content { get; }
	}
}