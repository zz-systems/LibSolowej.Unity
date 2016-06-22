using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that moves the coordinates of the input value before
    /// returning the output value from a source module. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "translate_input")]
    public class Translate : ModuleBase
    {
        #region Fields

        private double _x = 1.0;
        private double _y = 1.0;
        private double _z = 1.0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Translate.
        /// </summary>
        public Translate()
            : base(1)
        {
        }

        /// <summary>
        /// Initializes a new instance of Translate.
        /// </summary>
        /// <param name="input">The input module.</param>
        public Translate(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
        }

        /// <summary>
        /// Initializes a new instance of Translate.
        /// </summary>
        /// <param name="x">The translation on the x-axis.</param>
        /// <param name="y">The translation on the y-axis.</param>
        /// <param name="z">The translation on the z-axis.</param>
        /// <param name="input">The input module.</param>
        public Translate(double x, double y, double z, ModuleBase input)
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
				return new { offset = new[] { X, Y, Z } };
			}
		}

        /// <summary>
        /// Gets or sets the translation on the x-axis.
        /// </summary>
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Gets or sets the translation on the y-axis.
        /// </summary>
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Gets or sets the translation on the z-axis.
        /// </summary>
        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        #endregion        
    }
}