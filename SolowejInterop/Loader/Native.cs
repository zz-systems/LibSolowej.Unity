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
#if !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
                        case RuntimePlatform.LinuxEditor:
#endif
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

