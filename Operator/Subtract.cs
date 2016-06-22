using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that outputs the difference of the two output values from two
    /// source modules. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "sub")]
    public class Subtract : ModuleBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of Subtract.
        /// </summary>
        public Subtract()
            : base(2)
        {
        }

        /// <summary>
        /// Initializes a new instance of Subtract.
        /// </summary>
        /// <param name="lhs">The left hand input module.</param>
        /// <param name="rhs">The right hand input module.</param>
        public Subtract(ModuleBase lhs, ModuleBase rhs)
            : base(2)
        {
            Modules[0] = lhs;
            Modules[1] = rhs;
        }

        #endregion
    }
}