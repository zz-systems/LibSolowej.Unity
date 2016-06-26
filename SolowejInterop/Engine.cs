using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace LibSolowej
{
	public class SolowejEngine : MonoBehaviour
	{
		private static IntPtr libptr;

		private delegate string solowej_get_error();
		private delegate int solowej_compile_immediate(string instance_key, string content);
		private delegate int solowej_run(string instance_key, [In, Out] IntPtr target, float origin_x, float origin_y, float origin_z);
        private delegate int solowej_run_cvti(string instance_key, [In, Out] IntPtr target, float origin_x, float origin_y, float origin_z);

        public enum Capabilities
		{
			NO_LIMITS = -1,
			AVX512 	= 1 << 9,
			AVX2 	= 1 << 8,
			AVX1 	= 1 << 7,
			SSE4FMA = 1 << 3 | 1 << 4 | 1 << 5 | 1 << 6,
			SSE4 	= 1 << 3 | 1 << 4,
			SSSE3 	= 1 << 2,
			SSE3 	= 1 << 1,
			SSE2 	= 1 << 0,
			FPU 	= 0
		}

        public string LibraryPath { get; set; }

        public string Identifier { get; set; }
        public Capabilities MaxCapability 	{ get; set; }
		public Vector3 Dimensions 			{ get; set; }
		public Vector3 Scale 				{ get; set; }
		public Vector3 Offset 				{ get; set; }
		public bool    MakeSeam 			{ get; set; }
		public bool    Multithreaded		{ get; set; }

		public ModuleBase Root { get; set; }

        private bool _isInvalid;

        public SolowejEngine()
        {
            // *NIX
            //LibraryPath = "/home/szuyev/Dev/TestInfinityMap/libsolowej.so";

            LibraryPath = "solowej";
        }
        void Awake()
		{
			if (libptr != IntPtr.Zero) return;

			Debug.Log (IntPtr.Size == 8 ? "64bit" : "32bit");            

            libptr = Native.Instance.Load(LibraryPath);
            if (libptr == IntPtr.Zero)
			{
				Debug.LogError("Failed to load native libsolowej\n" + Native.Instance.LastError);
			}
		}

		void OnApplicationQuit()
		{
			if (libptr == IntPtr.Zero) return;

			Debug.Log(Native.Instance.Unload(libptr)
				? "Native library successfully unloaded."
				: "Native library could not be unloaded.");
		}

		public void Compile()
		{
            _isInvalid = false;

			var config = new {
				version = "0.9",
				id = Guid.NewGuid ().ToString (),

				environment = new {
					max_feature_set = MaxCapability,
					entryPoint 	= Root.Name,
					scheduler 	= new {
						dimensions = new [] { (int)Dimensions.x, (int)Dimensions.y, (int)Dimensions.z },
						seamless = MakeSeam,
						scale = new [] { Scale.x, Scale.y, Scale.z },
						offset = new [] { Offset.x, Offset.y, Offset.z },	
						use_threads = Multithreaded
					}
				},

				modules = Root.Modules.Flatten<ModuleBase>(node => node.Modules).Concat(new [] {Root}).Select(module => module.SolowejConfig).ToArray()
			};


			var config_str = JsonConvert.SerializeObject (config);
			Debug.Log ( config_str );

			if (0 != Native.Instance.Invoke<int, solowej_compile_immediate> (libptr, Identifier, config_str)) {

                var err = Native.Instance.Invoke<string, solowej_get_error>(libptr);

                Debug.LogError(err);
                _isInvalid = true;

                throw new InvalidOperationException (err); 
			}
		}

		public float[,] Execute(Vector3 at)
		{	
			float[,] result = new float[(int)Dimensions.x, (int)Dimensions.z];

            if (_isInvalid)
            {
                Debug.LogWarning("Engine malconfigured. Returning empty data.");
                return result;
            }

            GCHandle handle = GCHandle.Alloc(result, GCHandleType.Pinned);
			try
			{
				IntPtr pointer = handle.AddrOfPinnedObject();

				if(0 != Native.Instance.Invoke<int, solowej_run>(libptr, Identifier, pointer, at.x, at.y, at.z))
				{
					//throw new InvalidOperationException (Native.Instance.Invoke<solowej_get_error> ());
					Debug.LogError(Native.Instance.Invoke<string, solowej_get_error> (libptr));
				}

				return result;
			}
			finally
			{
				if (handle.IsAllocated)
				{
					handle.Free();
				}
			}
		}

        public int[,] ExecuteI(Vector3 at)
        {
            int[,] result = new int[(int)Dimensions.x, (int)Dimensions.z];

            if (_isInvalid)
            {
                Debug.LogWarning("Engine malconfigured. Returning empty data.");
                return result;
            }

            GCHandle handle = GCHandle.Alloc(result, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();

                if (0 != Native.Instance.Invoke<int, solowej_run_cvti>(libptr, Identifier, pointer, at.x, at.y, at.z))
                {
                    //throw new InvalidOperationException (Native.Instance.Invoke<solowej_get_error> ());
                    Debug.LogError(Native.Instance.Invoke<string, solowej_get_error>(libptr));
                }

                return result;
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }
        }
    }
}

