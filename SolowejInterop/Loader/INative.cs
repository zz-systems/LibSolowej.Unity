using System;

namespace LibSolowej
{
	public interface INative
	{
		IntPtr Load(string libpath);
		bool Unload(IntPtr libptr);
		string LastError { get; }

		void Invoke<T> (IntPtr library, params object[] args);
		T Invoke<T, T2> (IntPtr library, params object[] args);
	}
}

