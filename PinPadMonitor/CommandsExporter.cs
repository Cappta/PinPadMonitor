using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace PinPadMonitor
{
	public class CommandsExporter
	{
		public void Export(IList<Command> commands, string filename)
		{
			var serializedObject = JsonConvert.SerializeObject(commands);
			File.WriteAllText(filename, serializedObject);
		}
	}
}