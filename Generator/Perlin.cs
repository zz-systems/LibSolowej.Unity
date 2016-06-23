using UnityEngine;

namespace LibSolowej.Generator
{
    /// <summary>
    /// Provides a noise module that outputs a three-dimensional perlin noise. [GENERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Generator, "perlin")]
    public class Perlin : ModuleBase
    {
        #region Fields

        private double _frequency = 1.0;
        private double _lacunarity = 2.0;
        private QualityMode _quality = QualityMode.Medium;
        private int _octaveCount = 6;
        private double _persistence = 0.5;
        private int _seed;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Perlin.
        /// </summary>
        public Perlin()
            : base(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of Perlin.
        /// </summary>
        /// <param name="frequency">The frequency of the first octave.</param>
        /// <param name="lacunarity">The lacunarity of the perlin noise.</param>
        /// <param name="persistence">The persistence of the perlin noise.</param>
        /// <param name="octaves">The number of octaves of the perlin noise.</param>
        /// <param name="seed">The seed of the perlin noise.</param>
        /// <param name="quality">The quality of the perlin noise.</param>
        public Perlin(double frequency, double lacunarity, double persistence, int octaves, int seed,
            QualityMode quality)
            : base(0)
        {
            Frequency = frequency;
            Lacunarity = lacunarity;
            OctaveCount = octaves;
            Persistence = persistence;
            Seed = seed;
            Quality = quality;
        }

        #endregion

        #region Properties

		protected override object SolowejModuleSettings {
			get {
				return new {
					frequency = Frequency,
					lacunarity = Lacunarity,
					octaves = OctaveCount,
					persistence = Persistence,
					seed = Seed,
					quality = (int) Quality
				};
			}
		}

        /// <summary>
        /// Gets or sets the frequency of the first octave.
        /// </summary>
        public double Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        /// <summary>
        /// Gets or sets the lacunarity of the perlin noise.
        /// </summary>
        public double Lacunarity
        {
            get { return _lacunarity; }
            set { _lacunarity = value; }
        }

        /// <summary>
        /// Gets or sets the quality of the perlin noise.
        /// </summary>
        public QualityMode Quality
        {
            get { return _quality; }
            set { _quality = value; }
        }

        /// <summary>
        /// Gets or sets the number of octaves of the perlin noise.
        /// </summary>
        public int OctaveCount
        {
            get { return _octaveCount; }
            set { _octaveCount = Mathf.Clamp(value, 1, Utils.OctavesMaximum); }
        }

        /// <summary>
        /// Gets or sets the persistence of the perlin noise.
        /// </summary>
        public double Persistence
        {
            get { return _persistence; }
            set { _persistence = value; }
        }

        /// <summary>
        /// Gets or sets the seed of the perlin noise.
        /// </summary>
        public int Seed
        {
            get { return _seed; }
            set { _seed = value; }
        }

        #endregion
    }
}