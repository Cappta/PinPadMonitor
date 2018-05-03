using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PinPadMonitor
{
	public class CommandsExporter
	{
		private readonly BinaryFormatter binaryFormatter = new BinaryFormatter();

		public void Export(IList<Command> commands, string filename)
		{
			using (var fileStream = File.Open(filename, FileMode.Create))
			{
				this.binaryFormatter.Serialize(fileStream, commands);
			}
		}
	}
}