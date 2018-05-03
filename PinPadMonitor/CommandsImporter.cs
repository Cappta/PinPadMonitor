using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PinPadMonitor
{
	public class CommandsImporter
	{
		private readonly BinaryFormatter binaryFormatter = new BinaryFormatter();

		public IList<Command> Import(string filename)
		{
			using (var fileStream = File.Open(filename, FileMode.Open))
			{
				return (IList<Command>) this.binaryFormatter.Deserialize(fileStream);
			}
		}
	}
}