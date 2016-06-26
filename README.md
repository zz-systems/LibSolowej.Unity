# LibSolowej.Unity

.NET Unity Wrapper for libsolowej which is mostly API compatible with [LibNoise.Unity](https://github.com/ricardojmendez/LibNoise.Unity)

It is as complete as the libsolowej native library. Thus, no sphere maps etc... at the moment

## License

LibNoise.Unity is released under the
[LGPL license](https://www.gnu.org/licenses/lgpl.html). See COPYING.txt and
COPYING.LESSER.txt for details.

## About

[LibNoise](http://libnoise.sourceforge.net/) was originally created by
Jason Bevins

[LibSolowej](https://github.com/zz-systems/solowej) is a config-driven, parallelized, vectorized, partially extended, partially incomplete (still in development!) port of LibNoise.

Please keep in mind, that this release is a **Preview/Alpha Release** and feel free to report issues and bugs to the [Issue tracker on GitHub](https://github.com/zz-systems/LibSolowej.Unity/issues)

You can find the original LibNoise.Unity [here](https://github.com/ricardojmendez/LibNoise.Unity).
Most of the documentation and examples apply to LibSolowej.Unity as well. 

## Example usage

### Preparation
Drop the solowej.dll (windows) or libsolowej.so (linux) into the unity project **root**, beneath the Assets, Bin, Library, etc.. floders

Adapt the LibraryPath in the Engine Constructor - I haven't found a way yet to load the libraries on different platforms (Linux search patchs do not include the current directory IIRC)

```C#
public SolowejEngine()
{
    // *NIX
    //LibraryPath = "/home/szuyev/Dev/TestInfinityMap/libsolowej.so";
    // windows
    LibraryPath = "solowej";
}
```

### (Singleton) Instantiation
```C#
private static LibSolowej.SolowejEngine _engineInstance;
public static LibSolowej.SolowejEngine EngineInstance
{
	get
	{
		return _engineInstance ?? (_engineInstance = (new GameObject("SolowejEngine")).AddComponent<LibSolowej.SolowejEngine>());
	}
}
```
### Configuration & Compilation
```C#
EngineInstance.Identifier       = "terragen"; // <- Engine instances are distinguished by this name
EngineInstance.Dimensions 		= new Vector3 (129, 1, 129); // <- standard settings you find in LibSolowej
EngineInstance.Scale 			= new Vector3 (1, 1, 1);
EngineInstance.Offset 			= new Vector3 (0, 0, 0);
EngineInstance.MakeSeam 		= true;
EngineInstance.Multithreaded 	= false;
EngineInstance.MaxCapability	= LibSolowej.SolowejEngine.Capabilities.AVX2;

// Build the computation tree
EngineInstance.Root = 
				new LibSolowej.Operator.Abs(
					new LibSolowej.Operator.ScaleBias(-0.5, 0.2,
					  new LibSolowej.Generator.Perlin ())	);
					
EngineInstance.Compile();
```
### Execution
```C#

// Returns a float array
Heightmap = EngineInstance.Execute (new Vector3(Position.X, 0, Position.Z));

// Returns an int array (internally the computation is with floats, but is rounded and casted to int afterwards)
var details = DetailGenerator.ExecuteI(Random.onUnitSphere);
terrainData.SetDetailLayer(0, 0, 0, details);
```
