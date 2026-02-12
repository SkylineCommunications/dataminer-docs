using System;

using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.SimulationHelper
{
	/// <summary>
	/// This helper class allows you to load, enable and disable element simulations at runtime from within protocol QActions or automation scripts without having to restart DataMiner.
	/// </summary>
	/// <remarks>Available from DataMiner 10.1.6 (RN 29517) onwards.</remarks>
	/// <example>
	/// <para>This example shows how you can use this in an automation script.</para>
	/// <code>
	/// var simulationHelper = new SimulationHelper(Engine.SLNet.SendMessages);
	/// simulationHelper.LoadSimulations();
	/// </code>
	/// </example>
	public class SimulationHelper
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="SimulationHelper"/> class.
		/// </summary>
		/// <param name="messageHandler">Message handler.</param>
		/// <exception cref="ArgumentNullException"><paramref name="messageHandler"/> is <see langword="null"/>.</exception>
		public SimulationHelper(Func<DMSMessage[], DMSMessage[]> messageHandler)
		{
		}

		/// <summary>
		/// Disables a simulation on a specific element.
		/// <remarks>
		/// <note type="note">
		/// <para>The simulation needs to be loaded in memory of DataMiner at startup. If that was not the case, all simulations can be reloaded with <see cref="LoadSimulations"/>.</para>
		/// </note>
		/// </remarks>
		/// </summary>
		/// <param name="hostingDataMinerId">The hosting Agent ID of the element.</param>
		/// <param name="dataMinerId">The DataMiner ID of the element.</param>
		/// <param name="elementId">The element ID of the element.</param>
		public void DisableSimulation(int hostingDataMinerId, int dataMinerId, int elementId)
		{
		}

		/// <summary>
		/// Enables a simulation on the specified element.
		/// <remarks>
		/// <note type="note">
		/// <para>The simulation needs to be loaded in memory of DataMiner at startup. If that was not the case, all simulations can be reloaded with <see cref="LoadSimulations"/>.</para></note>
		/// </remarks>
		/// </summary>
		/// <param name="hostingDataMinerId">The hosting Agent ID of the element.</param>
		/// <param name="dataMinerId">The DataMiner ID of the element.</param>
		/// <param name="elementId">The element ID of the element.</param>
		public void EnableSimulation(int hostingDataMinerId, int dataMinerId, int elementId)
		{
		}

		/// <summary>
		/// Loads all simulation files stored under the Simulations folder on a specific agent.
		/// </summary>
		/// <param name="dataMinerId">The DataMiner ID of the Agent that needs to load the simulations.</param>
		public void LoadSimulations(int dataMinerId)
		{
		}
	}
}
