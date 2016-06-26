using System;

namespace LibSolowej.Generator
{
    /// <summary>
    /// Provides a noise module that outputs a checkerboard pattern. [GENERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Generator, "checker")]
    public class Checker : ModuleBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of Checker.
        /// </summary>
        public Checker()
            : base(0)
        {
        }

        #endregion
    }
}