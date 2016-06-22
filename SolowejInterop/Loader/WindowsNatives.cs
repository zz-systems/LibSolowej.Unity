using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace LibSolowej
{
	public class WindowsNatives : INative
	{
		#region native
		[DllImport("kernel32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool FreeLibrary(IntPtr hModule);

		[DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
		private static extern IntPtr LoadLibrary(string lpFileName);

		[DllImport("kernel32")]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
		#endregion

		#region INative
		public IntPtr Load(string libpath)
		{
			return LoadLibrary (libpath);
		}

		public bool Unload(IntPtr libptr)
		{
			return FreeLibrary (libptr);
		}

		public string LastError 
		{ 
			get 
			{ 
				throw new NotImplementedException ();
			}
		}

		public void Invoke<T> (IntPtr library, params object[] args)
		{
			IntPtr funcPtr = GetProcAddress (library, typeof(T).Name);
			if (funcPtr == IntPtr.Zero) {
				Debug.LogWarning (string.Format ("Could not gain reference to method '{0}' address.", typeof(T).Name));
				return;
			}

			var func = Marshal.GetDelegateForFunctionPointer (funcPtr, typeof(T));
			func.DynamicInvoke (args);
		}

		public T Invoke<T, T2> (IntPtr library, params object[] args)
		{
			IntPtr funcPtr = GetProcAddress (library, typeof(T2).Name);
			if (funcPtr == IntPtr.Zero) {
				Debug.LogWarning ("Could not gain reference to method address.");
				return default(T);
			}

			var func = Marshal.GetDelegateForFunctionPointer (GetProcAddress (library, typeof(T2).Name), typeof(T2));
			return (T)func.DynamicInvoke (args);
		}
		#endregion
	}
}

