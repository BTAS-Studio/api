using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace BTAS.API
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
		public IntPtr LoadUnmanagedLibrary(string absolutePath)
		{
			return LoadUnmanagedDll(absolutePath);
		}
		protected override IntPtr LoadUnmanagedDll(String unmanagedDllName)
		{
			return LoadUnmanagedDllFromPath(unmanagedDllName);
		}

		protected override Assembly Load(AssemblyName assemblyName)
		{
			throw new NotImplementedException();
		}
	}

	public static class WkHtmlToPdf
	{
		public static void Preload()
		{
			var wkHtmlToPdfContext = new CustomAssemblyLoadContext();
			var architectureFolder = (IntPtr.Size == 8) ? "64 bit" : "32 bit";
			var wkHtmlToPdfPath = Path.Combine(AppContext.BaseDirectory, $"{architectureFolder}\\libwkhtmltox");

			wkHtmlToPdfContext.LoadUnmanagedLibrary(wkHtmlToPdfPath);
		}
	}
}
