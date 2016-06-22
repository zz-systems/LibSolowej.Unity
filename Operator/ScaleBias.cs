using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that applies a scaling factor and a bias to the output
    /// value from a source module. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "scale_output_biased")]
    public class ScaleBias : ModuleBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of ScaleBias.
        /// </summary>
        public ScaleBias()
            : base(1)
        {
			Scale = 1;
        }

        /// <summary>
        /// Initializes a new instance of ScaleBias.
        /// </summary>
        /// <param name="input">The input module.</param>
        public ScaleBias(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
			Scale = 1;
        }

        /// <summary>
        /// Initializes a new instance of ScaleBias.
        /// </summary>
        /// <param name="scale">The scaling factor to apply to the output value from the source module.</param>
        /// <param name="bias">The bias to apply to the scaled output value from the source module.</param>
        /// <param name="input">The input module.</param>
        public ScaleBias(double scale, double bias, ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
            Bias = bias;
            Scale = scale;
        }

        #endregion

		#region Properties

		protected override object SolowejModuleSettings {
			get {
				return new {
					bias = Bias,
					scale = Scale
				};
			}
		}

        /// <summary>
        /// Gets or sets the bias to apply to the scaled output value from the source module.
        /// </summary>
		public double Bias { get; set; }

        /// <summary>
        /// Gets or sets the scaling factor to apply to the output value from the source module.
        /// </summary>
		public double Scale { get; set; }
        #endregion
    }
}