using System;
using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that maps the output value from a source module onto an
    /// exponential curve. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "exp")]
    public class Exponent : ModuleBase
    {
        #region Fields

        private double _exponent = 1.0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Exponent.
        /// </summary>
        public Exponent()
            : base(1)
        {
        }

        /// <summary>
        /// Initializes a new instance of Exponent.
        /// </summary>
        /// <param name="input">The input module.</param>
        public Exponent(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
        }

        /// <summary>
        /// Initializes a new instance of Exponent.
        /// </summary>
        /// <param name="exponent">The exponent to use.</param>
        /// <param name="input">The input module.</param>
        public Exponent(double exponent, ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
            Value = exponent;
        }

        #endregion

        #region Properties

		protected override object SolowejModuleSettings {
			get {
				return new { value = Value };
			}
		}


        /// <summary>
        /// Gets or sets the exponent.
        /// </summary>
        public double Value
        {
            get { return _exponent; }
            set { _exponent = value; }
        }
        #endregion
    }
}