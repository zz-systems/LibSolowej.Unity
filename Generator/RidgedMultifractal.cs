using System;
using UnityEngine;

namespace LibSolowej.Generator
{
    /// <summary>
    /// Provides a noise module that outputs 3-dimensional ridged-multifractal noise. [GENERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Generator, "ridged")]
    public class RidgedMultifractal : ModuleBase
    {
        #region Fields

        private double _frequency = 1.0;
        private double _lacunarity = 2.0;
        private QualityMode _quality = QualityMode.Medium;
        private int _octaveCount = 6;
        private int _seed;
        
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of RidgedMultifractal.
        /// </summary>
        public RidgedMultifractal()
            : base(0)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of RidgedMultifractal.
        /// </summary>
        /// <param name="frequency">The frequency of the first octave.</param>
        /// <param name="lacunarity">The lacunarity of the ridged-multifractal noise.</param>
        /// <param name="octaves">The number of octaves of the ridged-multifractal noise.</param>
        /// <param name="seed">The seed of the ridged-multifractal noise.</param>
        /// <param name="quality">The quality of the ridged-multifractal noise.</param>
        public RidgedMultifractal(double frequency, double lacunarity, int octaves, int seed, QualityMode quality)
            : base(0)
        {
            Frequency = frequency;
            Lacunarity = lacunarity;
            OctaveCount = octaves;
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
        /// Gets or sets the lacunarity of the ridged-multifractal noise.
        /// </summary>
        public double Lacunarity
        {
            get { return _lacunarity; }
            set
            {
                _lacunarity = value;
            }
        }

        /// <summary>
        /// Gets or sets the quality of the ridged-multifractal noise.
        /// </summary>
        public QualityMode Quality
        {
            get { return _quality; }
            set { _quality = value; }
        }

        /// <summary>
        /// Gets or sets the number of octaves of the ridged-multifractal noise.
        /// </summary>
        public int OctaveCount
        {
            get { return _octaveCount; }
            set { _octaveCount = Mathf.Clamp(value, 1, Utils.OctavesMaximum); }
        }

        /// <summary>
        /// Gets or sets the seed of the ridged-multifractal noise.
        /// </summary>
        public int Seed
        {
            get { return _seed; }
            set { _seed = value; }
        }

        #endregion
    }
}