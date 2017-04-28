using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes.Logger
{
	public interface ILogger
	{
		void Write(string path, string message);
	}
}
