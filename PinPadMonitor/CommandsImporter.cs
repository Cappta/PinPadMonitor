using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace PinPadMonitor
{
	public class CommandsImporter
	{
		public IList<Command> Import(string filename)
		{
			var fileContent = File.ReadAllText(filename);
			return JsonConvert.DeserializeObject<IList<Command>>(fileContent);
		}
	}
}