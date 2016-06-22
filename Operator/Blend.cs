using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that outputs a weighted blend of the output values from
    /// two source modules given the output value supplied by a control module. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "blend")]
    public class Blend : ModuleBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of Blend.
        /// </summary>
        public Blend()
            : base(3)
        {
        }

        /// <summary>
        /// Initializes a new instance of Blend.
        /// </summary>
        /// <param name="lhs">The left hand input module.</param>
        /// <param name="rhs">The right hand input module.</param>
        /// <param name="controller">The controller of the operator.</param>
        public Blend(ModuleBase lhs, ModuleBase rhs, ModuleBase controller)
            : base(3)
        {
            Modules[0] = lhs;
            Modules[1] = rhs;
            Modules[2] = controller;
        }

        #endregion

        #region Properties

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

        #endregion
    }
}