using System;
using UnityEngine;

namespace LibSolowej
{
	public class Native
	{	
		private static INative _instance;

		public static INative Instance 
		{
			get {
				if (_instance == null) {
					switch (Application.platform) {
					case RuntimePlatform.WindowsEditor:
					case RuntimePlatform.WindowsPlayer:
						_instance = new WindowsNatives ();
						break;
					case RuntimePlatform.LinuxEditor:
					case RuntimePlatform.LinuxPlayer:
						_instance = new LinuxNatives ();
						break;
					default:
						// nop;
						break;
					}
				}

				return _instance;
			}
		}
	}
}

