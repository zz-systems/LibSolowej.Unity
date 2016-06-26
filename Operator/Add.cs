using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that outputs the sum of the two output values from two
    /// source modules. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "add")]
    public class Add : ModuleBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of Add.
        /// </summary>
        public Add()
            : base(2)
        {
        }

        /// <summary>
        /// Initializes a new instance of Add.
        /// </summary>
        /// <param name="lhs">The left hand input module.</param>
        /// <param name="rhs">The right hand input module.</param>
        public Add(ModuleBase lhs, ModuleBase rhs)
            : base(2)
        {
            Modules[0] = lhs;
            Modules[1] = rhs;
        }

        #endregion        
    }
}