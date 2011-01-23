using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HelloSvc.Greeting
{
	internal class FileGreeter : IGreeter
	{
		public FileGreeter()
		{
			
		}

		protected virtual String Filename()
		{
			return @"c:\greetings\hello.txt";
		}

		protected virtual FileStream OpenFile()
		{
			return
				new FileStream(
					Filename(),
					FileMode.OpenOrCreate,
					FileAccess.Write,
					FileShare.Read);
		}

		public void SayHello()
		{
			using (var fs = OpenFile())
			using (var writer = new StreamWriter(fs))
			{
				writer.Write("Hello World!");
			}
		}
	}
}
