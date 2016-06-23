namespace LibSolowej.Generator
{
    /// <summary>
    /// Provides a noise module that outputs a constant value. [GENERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Generator, "const")]
    public class Const : ModuleBase
    {
        #region Fields

        private double _value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Const.
        /// </summary>
        public Const()
            : base(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of Const.
        /// </summary>
        /// <param name="value">The constant value.</param>
        public Const(double value)
            : base(0)
        {
            Value = value;
        }

        #endregion

        #region Properties

		protected override object SolowejModuleSettings {
			get {
				return new {
					value = Value
				};
			}
		}

        /// <summary>
        /// Gets or sets the constant value.
        /// </summary>
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        #endregion
    }
}