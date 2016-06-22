using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace LibSolowej
{
	public class LinuxNatives : INative
	{
		#region native
		[DllImport("libdl.so")]
		private static extern IntPtr dlopen(string filename, int flags);

		[DllImport("libdl.so")]
		private static extern IntPtr dlerror();

		[DllImport("libdl.so")]
		private static extern IntPtr dlsym(IntPtr handle, string symbol);

		[DllImport("libdl.so")]
		//[return: MarshalAs(UnmanagedType.Bool)]
		private static extern int dlclose(IntPtr handle);

		private const int RTLD_LAZY = 1;
		private const int RTLD_NOW = 2;

		#endregion

		#region INative
		public IntPtr Load(string libpath)
		{
			return dlopen (libpath, RTLD_LAZY);
		}

		public bool Unload(IntPtr libptr)
		{
			return dlclose (libptr) == 0;
		}

		public string LastError 
		{ 
			get 
			{ 
				var ptr = dlerror ();
				return Marshal.PtrToStringAnsi(ptr);
			}
		}

		public void Invoke<T> (IntPtr library, params object[] args)
		{
			IntPtr funcPtr = dlsym (library, typeof(T).Name);
			if (funcPtr == IntPtr.Zero) {
				Debug.LogWarning (string.Format ("Could not gain reference to method '{0}' address.", typeof(T).Name));
				return;
			}

			var func = Marshal.GetDelegateForFunctionPointer (funcPtr, typeof(T));
			func.DynamicInvoke (args);
		}

		public T Invoke<T, T2> (IntPtr library, params object[] args)
		{
			IntPtr funcPtr = dlsym (library, typeof(T2).Name);
			if (funcPtr == IntPtr.Zero) {
				Debug.LogWarning ("Could not gain reference to method address.");
				return default(T);
			}

			var func = Marshal.GetDelegateForFunctionPointer (dlsym (library, typeof(T2).Name), typeof(T2));
			return (T)func.DynamicInvoke (args);
		}
		#endregion
	}
}

