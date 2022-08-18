namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Net.Messages;
	using Newtonsoft.Json;
	using Skyline.DataMiner.Scripting;

	/// <summary>
	/// Represents a matrix UI control in a DataMiner protocol.
	/// Do not use this class directly. Instead, please use one of the inherited classes, depending on the type of available parameters in the protocol: <see cref="MatrixHelperForMatrix"/>, <see cref="MatrixHelperForTables"/>, or <see cref="MatrixHelperForMatrixAndTables"/>.
	/// </summary>
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("Newtonsoft.Json.dll")]
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLManagedScripting.dll")]
	[Skyline.DataMiner.Library.Common.Attributes.DllImport("SLNetTypes.dll")]
	public class MatrixHelper
	{
		/// <summary>
		/// Gets or sets the number of displayed inputs.
		/// </summary>
		/// <value>The number of displayed inputs.</value>
		/// <exception cref="ArgumentOutOfRangeException">The value of a set operation is not in the range [1, MaxInputs].</exception>
		public int DisplayedInputs
		{
			get
			{
				return displayedInputs;
			}

			set
			{
				if (value > 0 && value <= MaxInputs)
				{
					if (displayedInputs != value)
					{
						displayedInputs = value;
						changeMatrixSize = true;
					}
				}
				else
				{
					throw new ArgumentOutOfRangeException("The number of displayed inputs must be in the range [1, " + MaxInputs + "].");
				}
			}
		}

		/// <summary>
		/// Gets or sets the number of displayed outputs.
		/// </summary>
		/// <value>The number of displayed outputs.</value>
		/// <exception cref="ArgumentOutOfRangeException">The value of a set operation is not in the range [1, MaxOutputs].</exception>
		public int DisplayedOutputs
		{
			get
			{
				return displayedOutputs;
			}

			set
			{
				if (value > 0 && value <= MaxOutputs)
				{
					if (displayedOutputs != value)
					{
						displayedOutputs = value;
						changeMatrixSize = true;
					}
				}
				else
				{
					throw new ArgumentOutOfRangeException("The number of displayed outputs must be in the range [1, " + MaxOutputs + "].");
				}
			}
		}

		/// <summary>
		/// Gets the inputs of this matrix.
		/// </summary>
		/// <value>The inputs of this matrix.</value>
		public MatrixInputs Inputs
		{
			get { return inputs; }
		}

		/// <summary>
		/// Gets the maximum number of connected inputs per output.
		/// </summary>
		/// <value>The maximum number of connected inputs per output.</value>
		public int MaxConnectedInputsPerOutput { get; private set; }

		/// <summary>
		/// Gets the maximum number of connected outputs per input.
		/// </summary>
		/// <value>The maximum number of connected outputs per input.</value>
		public int MaxConnectedOutputsPerInput { get; private set; }

		/// <summary>
		/// Gets the maximum number of inputs this matrix supports.
		/// </summary>
		/// <value>The maximum number of inputs this matrix supports.</value>
		public int MaxInputs { get; private set; }

		/// <summary>
		/// Gets the maximum number of outputs this matrix supports.
		/// </summary>
		/// <value>The maximum number of outputs this matrix supports.</value>
		public int MaxOutputs { get; private set; }

		/// <summary>
		/// Gets the minimum number of connected inputs per output.
		/// </summary>
		/// <value>The minimum number of connected inputs per output.</value>
		public int MinConnectedInputsPerOutput { get; private set; }

		/// <summary>
		/// Gets the minimum number of connected outputs per input.
		/// </summary>
		/// <value>The minimum number of connected outputs per input.</value>
		public int MinConnectedOutputsPerInput { get; private set; }

		/// <summary>
		/// Gets the outputs of this matrix.
		/// </summary>
		/// <value>The outputs of this matrix.</value>
		public MatrixOutputs Outputs
		{
			get { return outputs; }
		}

		/// <summary>
		/// Processes write parameter changes on matrix, discreet info, or table.
		/// </summary>
		/// <param name="protocol">Link with SLProtocol process. This needs to be the SLProtocol object that triggered the QAction as the SLProtocol.GetTriggerParameter method is being called internally.</param>
		/// <param name="triggerParameter">ID of the parameter that triggered the QAction.</param>
		/// <exception cref="ArgumentNullException"><paramref name="protocol"/> is <see langword="null"/>.</exception>
		public void ProcessParameterSetFromUI(SLProtocol protocol, int triggerParameter = 0)
		{
		}

		/// <summary>
		/// Applies all changes on the parameter controls (connection changes, label changes, etc.).
		/// </summary>
		/// <param name="protocol">Link with SLProtocol process.</param>
		/// <exception cref="ArgumentException">Matrix cannot be retrieved. Exception could only occur when needing to switch DisplayType between tables and matrix.</exception>
		public void ApplyChanges(SLProtocol protocol)
		{
		}

		/// <summary>
		/// Gets triggered when crosspoint connections are changed.
		/// </summary>
		/// <param name="set">Information about the changed crosspoint connections.</param>
		protected virtual void OnCrossPointsSetFromUI(MatrixCrossPointsSetFromUIMessage set)
		{
		}

		/// <summary>
		/// Gets triggered when the label of an input or output is changed.
		/// </summary>
		/// <param name="set">Information about the changed label.</param>
		protected virtual void OnLabelSetFromUI(MatrixLabelSetFromUIMessage set)
		{
		}

		/// <summary>
		/// Gets triggered when an input or output is locked or unlocked.
		/// </summary>
		/// <param name="set">Information about the changed lock.</param>
		protected virtual void OnLockSetFromUI(MatrixLockSetFromUIMessage set)
		{
		}

		/// <summary>
		/// Gets triggered when an input or output is enabled or disabled.
		/// </summary>
		/// <param name="set">Information about the changed state.</param>
		protected virtual void OnStateSetFromUI(MatrixIOStateSetFromUIMessage set)
		{
		}
	}
}