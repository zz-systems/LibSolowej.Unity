using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that outputs the product of the two output values from
    /// two source modules. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "mul")]
    public class Multiply : ModuleBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of Multiply.
        /// </summary>
        public Multiply()
            : base(2)
        {
        }

        /// <summary>
        /// Initializes a new instance of Multiply.
        /// </summary>
        /// <param name="lhs">The left hand input module.</param>
        /// <param name="rhs">The right hand input module.</param>
        public Multiply(ModuleBase lhs, ModuleBase rhs)
            : base(2)
        {
            Modules[0] = lhs;
            Modules[1] = rhs;
        }

        #endregion
    }
}