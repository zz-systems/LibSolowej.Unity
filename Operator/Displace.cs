using System.Diagnostics;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that uses three source modules to displace each
    /// coordinate of the input value before returning the output value from
    /// a source module. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "displace")]
    public class Displace : ModuleBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of Displace.
        /// </summary>
        public Displace()
            : base(4)
        {
        }

        /// <summary>
        /// Initializes a new instance of Displace.
        /// </summary>
        /// <param name="input">The input module.</param>
        /// <param name="x">The displacement module of the x-axis.</param>
        /// <param name="y">The displacement module of the y-axis.</param>
        /// <param name="z">The displacement module of the z-axis.</param>
        public Displace(ModuleBase input, ModuleBase x, ModuleBase y, ModuleBase z)
            : base(4)
        {
            Modules[0] = input;
            Modules[1] = x;
            Modules[2] = y;
            Modules[3] = z;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the controlling module on the x-axis.
        /// </summary>
        public ModuleBase X
        {
            get { return Modules[1]; }
            set
            {
                Debug.Assert(value != null);
                Modules[1] = value;
            }
        }

        /// <summary>
        /// Gets or sets the controlling module on the z-axis.
        /// </summary>
        public ModuleBase Y
        {
            get { return Modules[2]; }
            set
            {
                Debug.Assert(value != null);
                Modules[2] = value;
            }
        }

        /// <summary>
        /// Gets or sets the controlling module on the z-axis.
        /// </summary>
        public ModuleBase Z
        {
            get { return Modules[3]; }
            set
            {
                Debug.Assert(value != null);
                Modules[3] = value;
            }
        }

        #endregion
    }
}