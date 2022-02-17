#region Assembly SLManagedAutomation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// C:\Skyline DataMiner\Files\SLManagedAutomation.dll
#endregion

using Skyline.DataMiner.Net.Exceptions;
using System;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents a spectrum preset.
	/// </summary>
	public class SpectrumPreset
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SpectrumPreset"/> class.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="presetName">The name of the preset.</param>
		/// <exception cref="DataMinerException">The specified preset failed to load.<br />
		/// -or-<br />
		/// No data returned.<br />
		/// -or-<br />
		/// Invalid data returned.
		/// </exception>
		public SpectrumPreset(IActionableElement element, string presetName) { }

		/// <summary>
		/// Retrieves the center frequency.
		/// </summary>
		/// <returns>The center frequency.</returns>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// double centerFrequency = preset.GetCenterFrequency();
		/// </code>
		/// </example>
		public double GetCenterFrequency() { return 0; }

		/// <summary>
		/// Retrieves the frequency span.
		/// </summary>
		/// <returns>The frequency span.</returns>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// double frequencySpan = preset.GetFrequencySpan();
		/// </code>
		/// </example>
		public double GetFrequencySpan() { return 0; }

		/// <summary>
		/// Retrieves the resolution bandwidth (RBW) value.
		/// </summary>
		/// <returns>The resolution bandwidth (RBW).</returns>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// double rbw = preset.GetRBW();
		/// </code>
		/// </example>
		public double GetRBW() { return 0; }

		/// <summary>
		/// Retrieves the reference level.
		/// </summary>
		/// <returns>The reference level.</returns>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// double referenceLevel = preset.GetReferenceLevel();
		/// </code>
		/// </example>
		public double GetReferenceLevel() { return 0; }

		/// <summary>
		/// Retrieves the reference scale.
		/// </summary>
		/// <returns>The reference scale.</returns>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// double referenceScale = preset.GetReferenceScale();
		/// </code>
		/// </example>
		public double GetReferenceScale() { return 0; }

		/// <summary>
		/// Retrieves the start frequency.
		/// </summary>
		/// <returns>The start frequency.</returns>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// double startFrequency = preset.GetStartFrequency();
		/// </code>
		/// </example>
		public double GetStartFrequency() { return 0; }

		/// <summary>
		/// Retrieves the stop frequency.
		/// </summary>
		/// <returns>The stop frequency.</returns>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// double stopFrequency = preset.GetStopFrequency();
		/// </code>
		/// </example>
		public double GetStopFrequency() { return 0; }

		/// <summary>
		/// Retrieves the sweep time.
		/// </summary>
		/// <returns>The sweep time.</returns>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// double sweepTime = preset.GetSweepTime();
		/// </code>
		/// </example>
		public double GetSweepTime() { return 0; }

		///// <exception cref="DataMinerException">The type specified in <paramref name="type"/> is not supported.</exception>
		//public string GetValue(SpectrumPresetValueType type) { return ""; }

		///// <exception cref="ArgumentException">The specified position is invalid.</exception>
		//public string GetValue(int pos1, int pos2) { return ""; }

		/// <summary>
		/// Retrieves the video bandwidth (VBW).
		/// </summary>
		/// <returns>The video bandwidth (VBW).</returns>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// double vbw = preset.GetVBW();
		/// </code>
		/// </example>
		public double GetVBW() { return 0; }

		/// <summary>
		/// Saves the preset.
		/// </summary>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// preset.SetCenterFrequency(100000000);
		/// preset.Save();
		/// </code>
		/// </example>
		public void Save() { }

		/// <summary>
		/// Sets the center frequency.
		/// </summary>
		/// <param name="value">The center frequency.</param>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// preset.SetCenterFrequency(100000000);
		/// preset.Save();
		/// </code>
		/// </example>
		public void SetCenterFrequency(double value) { }

		/// <summary>
		/// Sets the frequency span.
		/// </summary>
		/// <param name="value">The frequency span.</param>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// preset.SetFrequencySpan(10000000);
		/// preset.Save();
		/// </code>
		/// </example>
		public void SetFrequencySpan(double value) { }

		/// <summary>
		/// Sets the resolution bandwidth (RBW).
		/// </summary>
		/// <param name="value">The resolution bandwidth (RBW).</param>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// preset.SetRBW(1000000);
		/// preset.Save();
		/// </code>
		/// </example>
		public void SetRBW(double value) { }

		/// <summary>
		/// Sets the reference level.
		/// </summary>
		/// <param name="value">The reference level.</param>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// preset.SetReferenceLevel(100);
		/// preset.Save();
		/// </code>
		/// </example>
		public void SetReferenceLevel(double value) { }

		/// <summary>
		/// Sets the reference scale.
		/// </summary>
		/// <param name="value">The reference scale.</param>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// preset.SetReferenceScale(100);
		/// preset.Save();
		/// </code>
		/// </example>
		public void SetReferenceScale(double value) { }

		/// <summary>
		/// Sets the start frequency.
		/// </summary>
		/// <param name="value">The start frequency.</param>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// preset.SetStartFrequency(100000000);
		/// preset.Save();
		/// </code>
		/// </example>
		public void SetStartFrequency(double value) { }

		/// <summary>
		/// Sets the stop frequency.
		/// </summary>
		/// <param name="value">The stop frequency.</param>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// preset.SetStopFrequency(10000000000);
		/// preset.Save();
		/// </code>
		/// </example>
		public void SetStopFrequency(double value) { }

		/// <summary>
		/// Sets the sweep time.
		/// </summary>
		/// <param name="value">The sweep time.</param>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// preset.SetSweepTime(10);
		/// preset.Save();
		/// </code>
		/// </example>
		public void SetSweepTime(double value) { }

		// Should not be documented.
		//public void SetValue(SpectrumPresetValueType type, object value) { }

		// Should not be documented.
		//public void SetValue(int pos1, int pos2, object value) { }

		/// <summary>
		/// Sets the video bandwidth (VBW).
		/// </summary>
		/// <param name="value">The video bandwidth.</param>
		/// <example>
		/// <code>
		/// Element mySpectrumAnalyzerElement = engine.FindElement("MyElement");
		/// SpectrumPreset preset = elementSa.GetSpectrumPreset("MyPreset");
		/// 
		/// preset.SetVBW(1000000);
		/// preset.Save();
		/// </code>
		/// </example>
		public void SetVBW(double value) { }
	}
}