using System;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that rotates the input value around the origin before
    /// returning the output value from a source module. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "rotate")]
    public class Rotate : ModuleBase
    {
        #region Fields

        private double _x;
        private double _y;
        private double _z;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Rotate.
        /// </summary>
        public Rotate()
            : base(1)
        {
            SetAngles(0.0, 0.0, 0.0);
        }

        /// <summary>
        /// Initializes a new instance of Rotate.
        /// </summary>
        /// <param name="input">The input module.</param>
        public Rotate(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
        }

        /// <summary>
        /// Initializes a new instance of Rotate.
        /// </summary>
        /// <param name="x">The rotation around the x-axis.</param>
        /// <param name="y">The rotation around the y-axis.</param>
        /// <param name="z">The rotation around the z-axis.</param>
        /// <param name="input">The input module.</param>
        public Rotate(double x, double y, double z, ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
            SetAngles(x, y, z);
        }

        #endregion

		#region Properties

		protected override object SolowejModuleSettings {
			get {
				return new {
					angles = new { x = X, y = Y, z = Z }
				};
			}
		}

		/// <summary>
        /// Gets or sets the rotation around the x-axis in degree.
        /// </summary>
        public double X
        {
            get { return _x; }
            set { SetAngles(value, _y, _z); }
        }

        /// <summary>
        /// Gets or sets the rotation around the y-axis in degree.
        /// </summary>
        public double Y
        {
            get { return _y; }
            set { SetAngles(_x, value, _z); }
        }

        /// <summary>
        /// Gets or sets the rotation around the z-axis in degree.
        /// </summary>
        public double Z
        {
            get { return _x; }
            set { SetAngles(_x, _y, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the rotation angles.
        /// </summary>
        /// <param name="x">The rotation around the x-axis.</param>
        /// <param name="y">The rotation around the y-axis.</param>
        /// <param name="z">The rotation around the z-axis.</param>
        private void SetAngles(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        #endregion
    }
}