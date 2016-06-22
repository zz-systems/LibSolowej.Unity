using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that scales the coordinates of the input value before
    /// returning the output value from a source module. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "scale_input")]
    public class Scale : ModuleBase
    {
        #region Fields

        private double _x = 1.0;
        private double _y = 1.0;
        private double _z = 1.0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Scale.
        /// </summary>
        public Scale()
            : base(1)
        {
        }

        /// <summary>
        /// Initializes a new instance of Scale.
        /// </summary>
        /// <param name="input">The input module.</param>
        public Scale(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
        }

        /// <summary>
        /// Initializes a new instance of Scale.
        /// </summary>
        /// <param name="x">The scaling on the x-axis.</param>
        /// <param name="y">The scaling on the y-axis.</param>
        /// <param name="z">The scaling on the z-axis.</param>
        /// <param name="input">The input module.</param>
        public Scale(double x, double y, double z, ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

		#region Properties

		protected override object SolowejModuleSettings {
			get {
				return new {
					scale = new [] { X, Y, Z }
				};
			}
		}

        /// <summary>
        /// Gets or sets the scaling factor on the x-axis.
        /// </summary>
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Gets or sets the scaling factor on the y-axis.
        /// </summary>
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Gets or sets the scaling factor on the z-axis.
        /// </summary>
        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        #endregion
    }
}