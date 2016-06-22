using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that inverts the output value from a source module. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "invert")]
    public class Invert : ModuleBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of Invert.
        /// </summary>
        public Invert()
            : base(1)
        {
        }

        /// <summary>
        /// Initializes a new instance of Invert.
        /// </summary>
        /// <param name="input">The input module.</param>
        public Invert(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
        }

        #endregion
    }
}