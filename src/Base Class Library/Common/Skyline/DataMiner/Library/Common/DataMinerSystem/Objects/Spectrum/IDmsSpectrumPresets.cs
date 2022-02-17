namespace Skyline.DataMiner.Library.Common
{
	using System;

	/// <summary>
	/// Represents the spectrum analyzer presets.
	/// </summary>
	public interface IDmsSpectrumAnalyzerPresets
	{
		/// <summary>
		/// Deletes the preset with the specified name.
		/// Replaces: sa.NotifyElement(userID, elementID, SPA_NE_PRESET_DELETE (2), 0, presetGlobalName, null, out result);
		/// </summary>
		/// <param name="presetName">The name of the preset to delete.</param>
		/// <param name="isGlobalPreset">Allows to define if the preset should be shared to all users or private for scripting.</param>
		void DeletePreset(string presetName, bool isGlobalPreset = true);

		/// <summary>
		/// Retrieves the preset with the specified name.
		/// Replaces: sa.NotifyElement(userID, elementID, SPA_NE_PRESET_LOAD (0), 0, presetName, presetLoadOptions, out result);
		/// </summary>
		/// <param name="presetName">The name of the preset to get.</param>
		/// <param name="isGlobalPreset">Allows to define if the preset should be shared to all users or private for scripting.</param>
		/// <returns>The preset data.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="presetName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="presetName"/> is empty.</exception>
		object GetPreset(string presetName, bool isGlobalPreset = true);

		/// <summary>
		/// Saves the specified preset.
		/// Replaces: sa.NotifyElement(userID, elementID, SPA_NE_PRESET_SAVE (1), 0, presetName, presetData, out result);
		/// </summary>
		/// <param name="presetName">The name of the preset to update or create.</param>
		/// <param name="presetData">Object array as required by old SpectrumAnalyzerClass for SPA_NE_PRESET_SAVE = 1.</param>
		/// <param name="isGlobalPreset">Allows to define if the preset should be shared to all users or private for scripting.</param>
		/// <exception cref="ArgumentNullException"><paramref name="presetName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="presetName"/> is empty.</exception>
		void SavePreset(string presetName, object[] presetData, bool isGlobalPreset = true);
	}
}