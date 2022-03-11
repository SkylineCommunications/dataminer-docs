namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Specifies the spectrum preset value type.
	/// </summary>
	internal enum SpectrumPresetValueType
	{
		/// <summary>
		/// Undefined.
		/// </summary>
		Undefined = 0,
		/// <summary>
		/// Reference level.
		/// </summary>
		ReferenceLevel = 1,
		/// <summary>
		/// Reference scale.
		/// </summary>
		ReferenceScale = 2,
		/// <summary>
		/// Frequency span.
		/// </summary>
		FrequencySpan = 3,
		/// <summary>
		/// Start frequency.
		/// </summary>
		StartFrequency = 4,
		/// <summary>
		/// Stop frequency.
		/// </summary>
		StopFrequency = 5,
		/// <summary>
		/// Center frequency.
		/// </summary>
		CenterFrequency = 6,
		/// <summary>
		/// Video bandwidth.
		/// </summary>
		VBW = 7,
		/// <summary>
		/// Resolution bandwidth.
		/// </summary>
		RBW = 8,
		/// <summary>
		/// Sweep time.
		/// </summary>
		SweepTime = 9,
		/// <summary>
		/// Input attenuation.
		/// </summary>
		InputAttenuation = 10,
		/// <summary>
		/// Pre-amplifier.
		/// </summary>
		PreAmplifier = 11,
		/// <summary>
		/// First mixer input.
		/// </summary>
		FirstMixerInput = 12,
		/// <summary>
		/// Noise level avg count.
		/// </summary>
		NoiseLevelAvgCount = 13,
		/// <summary>
		/// Number of points in trace.
		/// </summary>
		AmountPointsInTrace = 14
	}
}