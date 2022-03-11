namespace Skyline.DataMiner.Library.Common.Selectors.Data
{
	/// <summary>
	/// Represents a parameter alarm level.
	/// </summary>
	public class ParamAlarmLevel
	{
		private readonly AlarmLevel alarmLevel;

		private readonly Param param;

		/// <summary>
		/// Initializes a new instance of the <see cref="ParamAlarmLevel"/> class.
		/// </summary>
		/// <param name="agentId">The DataMiner Agent ID.</param>
		/// <param name="elementId">The element ID.</param>
		/// <param name="parameterId">The parameter ID.</param>
		/// <param name="alarmLevel">The parameter alarm level.</param>
		public ParamAlarmLevel(int agentId, int elementId, int parameterId, AlarmLevel alarmLevel)
		{
			param = new Param(agentId, elementId, parameterId);
			this.alarmLevel = alarmLevel;
		}

		/// <summary>
		/// Gets the alarm level of the parameter.
		/// </summary>
		/// <value>The alarm level.</value>
		public AlarmLevel AlarmLevel { get { return alarmLevel; } }

		/// <summary>
		/// Gets the parameter.
		/// </summary>
		/// <value>The parameter.</value>
		public Param Param { get { return param; } }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var data = obj as ParamValue;
			return data != null && data.ToString() == this.ToString();
		}

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

		/// <summary>
		/// A textual representation in the format: DmaId/ElementId/ParameterId/AlarmLevel.
		/// </summary>
		/// <returns>The textual representation.</returns>
		public override string ToString()
		{
			return param.AgentId + "/" + param.ElementId + "/" + param.ParameterId + "/" + AlarmLevel;
		}
	}
}