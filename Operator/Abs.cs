using System;
using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that outputs the absolute value of the output value from
    /// a source module. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "abs")]
    public class Abs : ModuleBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of Abs.
        /// </summary>
        public Abs()
            : base(1)
        {
        }

        /// <summary>
        /// Initializes a new instance of Abs.
        /// </summary>
        /// <param name="input">The input module.</param>
        public Abs(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
        }

        #endregion
    }
}