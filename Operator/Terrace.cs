using System;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;
using System.Linq;

namespace LibSolowej.Operator
{
    /// <summary>
    /// Provides a noise module that maps the output value from a source module onto a
    /// terrace-forming curve. [OPERATOR]
    /// </summary>
	[ModuleMapping(ModuleTypes.Modifier, "terrace")]
    public class Terrace : ModuleBase
    {
        #region Fields

        private readonly List<double> _data = new List<double>();
        private bool _inverted;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Terrace.
        /// </summary>
        public Terrace()
            : base(1)
        {
        }

        /// <summary>
        /// Initializes a new instance of Terrace.
        /// </summary>
        /// <param name="input">The input module.</param>
        public Terrace(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
        }

        /// <summary>
        /// Initializes a new instance of Terrace.
        /// </summary>
        /// <param name="inverted">Indicates whether the terrace curve is inverted.</param>
        /// <param name="input">The input module.</param>
        public Terrace(bool inverted, ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
            IsInverted = inverted;
        }

        #endregion

		#region Properties

		protected override object SolowejModuleSettings {
			get {
				return new {
					points = ControlPoints.ToArray ()
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
        public List<double> ControlPoints
        {
            get { return _data; }
        }

        /// <summary>
        /// Gets or sets a value whether the terrace curve is inverted.
        /// </summary>
        public bool IsInverted
        {
            get { return _inverted; }
            set { _inverted = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a control point to the curve.
        /// </summary>
        /// <param name="input">The curves input value.</param>
        public void Add(double input)
        {
            if (!_data.Contains(input))
            {
                _data.Add(input);
            }
            _data.Sort(delegate(double lhs, double rhs) { return lhs.CompareTo(rhs); });
        }

        /// <summary>
        /// Clears the control points.
        /// </summary>
        public void Clear()
        {
            _data.Clear();
        }

        /// <summary>
        /// Auto-generates a terrace curve.
        /// </summary>
        /// <param name="steps">The number of steps.</param>
        public void Generate(int steps)
        {
            if (steps < 2)
            {
                throw new ArgumentException("Need at least two steps");
            }
            Clear();
            var ts = 2.0 / (steps - 1.0);
            var cv = -1.0;
            for (var i = 0; i < steps; i++)
            {
                Add(cv);
                cv += ts;
            }
        }

        #endregion       
    }
}