using System;

namespace LibSolowej.Generator
{
    /// <summary>
    /// Provides a noise module that outputs concentric cylinders. [GENERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Generator, "cylinders")]
    public class Cylinders : ModuleBase
    {
        #region Fields

        private double _frequency = 1.0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Cylinders.
        /// </summary>
        public Cylinders()
            : base(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of Cylinders.
        /// </summary>
        /// <param name="frequency">The frequency of the concentric cylinders.</param>
        public Cylinders(double frequency)
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
        /// Gets or sets the frequency of the concentric cylinders.
        /// </summary>
        public double Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        #endregion
    }
}