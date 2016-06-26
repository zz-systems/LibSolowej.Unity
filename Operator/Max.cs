using System;
using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that outputs the larger of the two output values from two
    /// source modules. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "max")]
    public class Max : ModuleBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of Max.
        /// </summary>
        public Max()
            : base(2)
        {
        }

        /// <summary>
        /// Initializes a new instance of Max.
        /// </summary>
        /// <param name="lhs">The left hand input module.</param>
        /// <param name="rhs">The right hand input module.</param>
        public Max(ModuleBase lhs, ModuleBase rhs)
            : base(2)
        {
            Modules[0] = lhs;
            Modules[1] = rhs;
        }

        #endregion
    }
}