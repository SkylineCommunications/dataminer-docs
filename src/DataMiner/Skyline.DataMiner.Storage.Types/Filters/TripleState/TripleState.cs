using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyline.DataMiner.Net.Messages.SLDataGateway
{
	/// <summary>
	/// Holds a result in terms of <c>true</c>, <c>false</c> or exception and holds the boolean/triple logic for calculating with this.
	/// </summary>
	public class TripleState
	{
		/// <summary>
		/// Global constant used for a true value.
		/// </summary>
		public static TripleState TRUE;

		/// <summary>
		/// Global constant used for a false value.
		/// </summary>
		public static TripleState FALSE;

		/// <summary>
		/// Translates a regular lambda predicate on T into a Triple-function on T with an exception translating into an EXCEPTION output.
		/// </summary>
		/// <typeparam name="T">The type</typeparam>
		/// <param name="original">The lambda predicate on T.</param>
		/// <param name="value">The value.</param>
		/// <returns>The triple state.</returns>
		public static TripleState TranslateToFailSafe<T>(Func<T, bool> original, T value)
		{
			return null;
		}

		/// <summary>
		/// Translates the Triple-predicate into a normal boolean predicate translating EXCEPTION into FALSE.
		/// </summary>
		/// <typeparam name="T">The type.</typeparam>
		/// <param name="original">The Triple-predicate.</param>
		/// <param name="value">The value.</param>
		/// <returns>The boolean value.</returns>
		public static bool TranslateToNormal<T>(Func<T, TripleState> original, T value)
		{
			return original.Invoke(value).reducedState;
		}

		/// <summary>
		/// Internal check for a true value.
		/// </summary>
		public static Func<TripleState, bool> TRUE3 = x => x == TRUE;

		/// <summary>
		/// Internal check for a false value.
		/// </summary>
		public static Func<TripleState, bool> FALSE3 = x => x == FALSE;

		/// <summary>
		/// Internal check for an exception value.
		/// </summary>
		public static Func<TripleState, bool> EXCEPTION3 = x => x.exception;

		/// <summary>
		/// A check whether a TripleState will give raise to an AND fall-through (e.g. false in regular boolean logic)
		/// </summary>
		public static Func<TripleState, bool> isAND_FALSE;

		/// <summary>
		/// A check whether a TripleState will give raise to an OR fall-through (e.g. a true in regular boolean logic)
		/// </summary>
		public static Func<TripleState, bool> isOR_TRUE;

		/// <summary>
		/// Initializes a new instance of the <see cref="TripleState"/> class in exception state with knowledge on the failure.
		/// </summary>
		/// <param name="failure">The failure.</param>
		public TripleState(string failure) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="TripleState"/> by merging the failure lists into one TripleState Exception.
		/// </summary>
		/// <param name="failures">The failures.</param>
		/// <param name="additionalFailures">The additional failures.</param>
		public TripleState(List<string> failures, List<string> additionalFailures)
		{
		}

		/// <summary>
		/// The reduced - regular boolean - state.
		/// </summary>
		public bool reducedState;

		/// <summary>
		/// The exception state.
		/// </summary>
		/// <remarks>Should be combined with reduced state false.</remarks>
		public bool exception;

		/// <summary>
		/// The list of accumulated failures or <see langword="null"/> if not used.
		/// </summary>
		public List<string> accumulatedFailures;

		/// <summary>
		/// Performs a logical AND on this <see cref="TripleState"/> and the specified <see cref="TripleState"/>.
		/// </summary>
		/// <param name="other">The other triple state.</param>
		/// <returns>A <see cref="TripleState"/> instance that is the result of the performed logical AND operation.</returns>
		public TripleState AND(TripleState other)
		{
			return null;
		}

		/// <summary>
		/// Performs a logical OR on this <see cref="TripleState"/> and the specified <see cref="TripleState"/>.
		/// </summary>
		/// <param name="other">The other triple state.</param>
		/// <returns>A <see cref="TripleState"/> instance that is the result of the performed logical OR operation.</returns>
		public TripleState OR(TripleState other)
		{
			return null;
		}

		/// <summary>
		/// Performs a logical NOT operation on this <see cref="TripleState"/>.
		/// </summary>
		/// <returns>a <see cref="TripleState"/> instance that is the result of the performed logical NOT operation.</returns>
		public TripleState NOT()
		{
			return null;
		}

		/// <summary>
		/// prints out the string value of a TripleState
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (this == TRUE)
			{
				return "TRUE";
			}
			if (this == FALSE)
			{
				return "FALSE";
			}
			return "EXCEPTION";
		}
	}
}
