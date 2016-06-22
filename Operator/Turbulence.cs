using System.Diagnostics;
using LibSolowej.Generator;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that that randomly displaces the input value before
    /// returning the output value from a source module. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "turbulence")]
    public class Turbulence : ModuleBase
    {
        #region Constants

        #endregion

        #region Fields

        private double _power = 1.0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Turbulence.
        /// </summary>
        public Turbulence()
            : base(1)
        {}

        /// <summary>
        /// Initializes a new instance of Turbulence.
        /// </summary>
        /// <param name="input">The input module.</param>
        public Turbulence(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
        }

        /// <summary>
        /// Initializes a new instance of Turbulence.
        /// </summary>
        public Turbulence(double power, ModuleBase input)
			: this(input)
        {			
			Power = power;
        }

        #endregion

		#region Properties

		protected override object SolowejModuleSettings {
			get {
				return new {
					frequency = Frequency,
					roughness = Roughness,
					power = Power,
					seed = Seed,
				};
			}
		}

        /// <summary>
        /// Gets or sets the frequency of the turbulence.
        /// </summary>
		public double Frequency { get; set; }

        /// <summary>
        /// Gets or sets the power of the turbulence.
        /// </summary>
        public double Power
        {
            get { return _power; }
            set { _power = value; }
        }

        /// <summary>
        /// Gets or sets the roughness of the turbulence.
        /// </summary>
		public int Roughness { get; set; }

        /// <summary>
        /// Gets or sets the seed of the turbulence.
        /// </summary>
		public int Seed { get; set; }

        #endregion
    }
}