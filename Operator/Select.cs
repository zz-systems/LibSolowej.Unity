using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that outputs the value selected from one of two source
    /// modules chosen by the output value from a control module. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "select")]
    public class Select : ModuleBase
    {
        #region Fields

        private double _fallOff;
        private double _raw;
        private double _min = -1.0;
        private double _max = 1.0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Select.
        /// </summary>
        public Select()
            : base(3)
        {
        }

        /// <summary>
        /// Initializes a new instance of Select.
        /// </summary>
        /// <param name="inputA">The first input module.</param>
        /// <param name="inputB">The second input module.</param>
        /// <param name="controller">The controller module.</param>
        public Select(ModuleBase inputA, ModuleBase inputB, ModuleBase controller)
            : base(3)
        {
            Modules[0] = inputA;
            Modules[1] = inputB;
            Modules[2] = controller;
        }

        /// <summary>
        /// Initializes a new instance of Select.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="fallOff">The falloff value at the edge transition.</param>
        /// <param name="inputA">The first input module.</param>
        /// <param name="inputB">The second input module.</param>
        public Select(double min, double max, double fallOff, ModuleBase inputA, ModuleBase inputB)
            : this(inputA, inputB, null)
        {
            _min = min;
            _max = max;
            FallOff = fallOff;
        }

        #endregion

		#region Properties

		protected override object SolowejModuleSettings {
			get {
				return new {
					edgeFalloff = FallOff,
					lowerBound = Minimum,
					upperBound = Maximum
				};
			}
		}
        /// <summary>
        /// Gets or sets the controlling module.
        /// </summary>
        public ModuleBase Controller
        {
            get { return Modules[2]; }
            set
            {
                Debug.Assert(value != null);
                Modules[2] = value;
            }
        }

        /// <summary>
        /// Gets or sets the falloff value at the edge transition.
        /// </summary>
		/// <remarks>
		/// Called SetEdgeFallOff() on the original LibSolowej.
		/// </remarks>
        public double FallOff
        {
            get { return _fallOff; }
            set
            {
                var bs = _max - _min;
                _raw = value;
                _fallOff = (value > bs / 2) ? bs / 2 : value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum, and re-calculated the fall-off accordingly.
        /// </summary>
        public double Maximum
        {
            get { return _max; }
            set
            {
                _max = value;
                FallOff = _raw;
            }
        }

        /// <summary>
		/// Gets or sets the minimum, and re-calculated the fall-off accordingly.
        /// </summary>
        public double Minimum
        {
            get { return _min; }
            set
            {
                _min = value;
                FallOff = _raw;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the bounds.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        public void SetBounds(double min, double max)
        {
            Debug.Assert(min < max);
            _min = min;
            _max = max;
            FallOff = _fallOff;
        }

        #endregion        
    }
}