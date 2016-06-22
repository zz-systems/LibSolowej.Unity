using System;
using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that outputs the smaller of the two output values from two
    /// source modules. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "min")]
    public class Min : ModuleBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of Min.
        /// </summary>
        public Min()
            : base(2)
        {
        }

        /// <summary>
        /// Initializes a new instance of Min.
        /// </summary>
        /// <param name="lhs">The left hand input module.</param>
        /// <param name="rhs">The right hand input module.</param>
        public Min(ModuleBase lhs, ModuleBase rhs)
            : base(2)
        {
            Modules[0] = lhs;
            Modules[1] = rhs;
        }

        #endregion
    }
}