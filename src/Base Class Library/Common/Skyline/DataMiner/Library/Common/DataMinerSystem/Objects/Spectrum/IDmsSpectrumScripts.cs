namespace Skyline.DataMiner.Library.Common
{
	using System;

	/// <summary>
	///  Represents spectrum analyzer scripts.
	/// </summary>
	public interface IDmsSpectrumAnalyzerScripts
	{
		/// <summary>
		/// Deletes the script with the specified ID.
		/// Replaces: sa.NotifyElement(userID, elementID, SPA_NE_SETINFO (5), SPAI_SCRIPT (9), scriptMetaInfo, scriptStatements, out result);
		/// </summary>
		/// <param name="scriptId">The ID of the script to delete.</param>
		void DeleteScript(int scriptId);

		/// <summary>
		/// Executes the specified script.
		/// Replaces: sa.NotifyElement(userID, elementID, SPA_NE_GETINFO (4), SPAI_EXECUTE_SCRIPT (48), scriptInfo, null, out result);
		/// WARNING: Due to SLNet limitations the Return value only supports returning the content &amp; settings of the last GetTrace call.
		/// </summary>
		/// <param name="scriptInfo">All info needed to execute the script.</param>
		/// <returns>An object holding all the results of the script execution.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="scriptInfo"/> is <see langword="null"/>.</exception>
		/// <exception cref="InvalidOperationException"><paramref name="scriptInfo"/>Script failed to execute.</exception>
		/// <exception cref="TimeoutException">Script result timed out.</exception>
		object ExecuteScript(string[] scriptInfo);

		/// <summary>
		/// Retrieves all scripts.
		/// Replaces: sa.NotifyElement(userID, elementID, SPA_NE_GETINFO (4), SPAI_SCRIPTS_ALL (10), null, null, out result);
		/// </summary>
		/// <returns>All the scripts defined on the element.</returns>
		object GetAllScripts();

		/// <summary>
		/// Updates the specified script.
		/// Replaces: sa.NotifyElement(userID, elementID, SPA_NE_SETINFO (5), SPAI_SCRIPT (9), scriptMetaInfo, scriptStatements, out result);
		/// </summary>
		/// <param name="scriptId">The ID of the script.</param>
		/// <param name="scriptName">The name of the script.</param>
		/// <param name="scriptDescription">A description of the script.</param>
		/// <param name="scriptStatements">Details of the script.</param>
		/// <returns>The ID of the updated script.</returns>
		int UpdateScript(int scriptId, string scriptName, string scriptDescription, string[] scriptStatements);

		/// <summary>
		/// Adds the specified script.
		/// Replaces: sa.NotifyElement(userID, elementID, SPA_NE_SETINFO (5), SPAI_SCRIPT (9), scriptMetaInfo, scriptStatements, out result);
		/// Where scriptMetaInfo has scriptId set to 2100000000
		/// </summary>
		/// <param name="scriptName">The name of the script.</param>
		/// <param name="scriptDescription">A description of the script.</param>
		/// <param name="scriptStatements">Details of the script.</param>
		/// <returns>The id of the added script.</returns>
		int AddScript(string scriptName, string scriptDescription, string[] scriptStatements);
	}
}