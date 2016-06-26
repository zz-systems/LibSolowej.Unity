using System;

namespace LibSolowej.Generator
{
    /// <summary>
    /// Provides a noise module that outputs concentric spheres. [GENERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Generator, "spheres")]
    public class Spheres : ModuleBase
    {
        #region Fields

        private double _frequency = 1.0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Spheres.
        /// </summary>
        public Spheres()
            : base(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of Spheres.
        /// </summary>
        /// <param name="frequency">The frequency of the concentric spheres.</param>
        public Spheres(double frequency)
            : base(0)
        {
            Frequency = frequency;
        }

        #endregion

        #region Properties

		protected override object SolowejModuleSettings {
			get {
				return new {
					frequency = Frequency
				};
			}
		}


        /// <summary>
        /// Gets or sets the frequency of the concentric spheres.
        /// </summary>
        public double Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        #endregion
    }
}