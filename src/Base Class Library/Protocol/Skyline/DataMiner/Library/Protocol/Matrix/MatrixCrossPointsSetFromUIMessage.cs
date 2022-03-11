namespace Skyline.DataMiner.Library.Protocol.Matrix
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Provides data for the event that is raised when there are updates on the matrix cross points.
	/// </summary>
	[Serializable]
	public class MatrixCrossPointsSetFromUIMessage
	{
		private readonly List<MatrixCrossPointSetFromUI> crossPointSets;

		internal MatrixCrossPointsSetFromUIMessage(List<MatrixCrossPointSetFromUI> crossPointSets)
		{
			this.crossPointSets = crossPointSets;
		}

		/// <summary>
		/// Gets a List that contains all changed crosspoints.
		/// </summary>
		/// <value>List that contains all changed crosspoints.</value>
		public IList<MatrixCrossPointSetFromUI> CrossPointSets
		{
			get { return crossPointSets; }
		}
	}
}
