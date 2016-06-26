using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;
using System.Linq;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that maps the output value from a source module onto an
    /// arbitrary function curve. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "curve")]
    public class Curve : ModuleBase
    {
        #region Fields

        private readonly List<KeyValuePair<double, double>> _data = new List<KeyValuePair<double, double>>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Curve.
        /// </summary>
        public Curve()
            : base(1)
        {
        }

        /// <summary>
        /// Initializes a new instance of Curve.
        /// </summary>
        /// <param name="input">The input module.</param>
        public Curve(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
        }

        #endregion

        #region Properties


		protected override object SolowejModuleSettings {
			get {
				return new {
					points = ControlPoints.Select (point => new { @in = point.Key, @out = point.Value }).ToArray ()
				};
			}
		}

        /// <summary>
        /// Gets the number of control points.
        /// </summary>
        public int ControlPointCount
        {
            get { return _data.Count; }
        }

        /// <summary>
        /// Gets the list of control points.
        /// </summary>
        public List<KeyValuePair<double, double>> ControlPoints
        {
            get { return _data; }
        }



        #endregion

        #region Methods

        /// <summary>
        /// Adds a control point to the curve.
        /// </summary>
        /// <param name="input">The curves input value.</param>
        /// <param name="output">The curves output value.</param>
        public void Add(double input, double output)
        {
            var kvp = new KeyValuePair<double, double>(input, output);
            if (!_data.Contains(kvp))
            {
                _data.Add(kvp);
            }
            _data.Sort(
                delegate(KeyValuePair<double, double> lhs, KeyValuePair<double, double> rhs)
                {
                    return lhs.Key.CompareTo(rhs.Key);
                });
        }

        /// <summary>
        /// Clears the control points.
        /// </summary>
        public void Clear()
        {
            _data.Clear();
        }

        #endregion       
    }
}