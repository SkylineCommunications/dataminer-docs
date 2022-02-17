namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections.Generic;
	using Templates;

	/// <summary>
	/// DataMiner protocol interface.
	/// </summary>
	public interface IDmsProtocol : IDmsObject
	{
		/// <summary>
		/// Gets the connection information.
		/// </summary>
		/// <value>The connection information.</value>
		IList<IDmsConnectionInfo> ConnectionInfo { get; }

		/// <summary>
		/// Gets the protocol name.
		/// </summary>
		/// <value>The protocol name.</value>
		string Name { get; }

		/// <summary>
		/// Gets the protocol version.
		/// </summary>
		/// <value>The protocol version.</value>
		string Version { get; }

		/// <summary>
		/// Gets the version this production protocol is based on.
		/// </summary>
		/// <value>The referenced version. This is only applicable for production protocols.</value>
		string ReferencedVersion { get; }

		/// <summary>
		/// Gets the type of the protocol.
		/// </summary>
		/// <value>The type of protocol.</value>
		ProtocolType Type { get; }

		/// <summary>
		/// Determines whether a standalone alarm template or alarm template group with the specified name exists for this protocol.
		/// </summary>
		/// <param name="templateName">Name of the alarm template.</param>
		/// <exception cref="ArgumentNullException"><paramref name="templateName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="templateName"/> is the empty string ("") or white space.</exception>
		/// <returns><c>true</c> if an alarm template with the specified name exists; otherwise, <c>false</c>.</returns>
		bool AlarmTemplateExists(string templateName);

		/// <summary>
		/// Determines whether an alarm template group with the specified name exists for this protocol.
		/// </summary>
		/// <param name="templateName">Name of the alarm template.</param>
		/// <exception cref="ArgumentNullException"><paramref name="templateName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="templateName"/> is the empty string ("") or white space.</exception>
		/// <returns><c>true</c> if an alarm template group with the specified name exists; otherwise, <c>false</c>.</returns>
		bool AlarmTemplateGroupExists(string templateName);

		/// <summary>
		/// Gets the alarm template with the specified name defined for this protocol.
		/// </summary>
		/// <param name="templateName">The name of the alarm template.</param>
		/// <exception cref="ArgumentNullException"><paramref name="templateName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="templateName"/> is the empty string ("") or white space.</exception>
		/// <exception cref="AlarmTemplateNotFoundException">No alarm template with the specified name was found.</exception>
		/// <returns>The alarm template with the specified name defined for this protocol.</returns>
		IDmsAlarmTemplate GetAlarmTemplate(string templateName);

		/// <summary>
		/// Gets the alarm templates (standalone and groups) defined for this protocol.
		/// </summary>
		/// <returns>The alarm templates (standalone and groups) defined for this protocol.</returns>
		ICollection<IDmsAlarmTemplate> GetAlarmTemplates();

		/// <summary>
		/// Gets the alarm template group with the specified name.
		/// </summary>
		/// <param name="templateName">The name of the alarm template group.</param>
		/// <returns>The alarm template group with the specified name.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="templateName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="templateName"/> is the empty string ("") or white space.</exception>
		/// <exception cref="AlarmTemplateNotFoundException">No alarm template group with the specified name was found for this protocol.</exception>
		IDmsAlarmTemplateGroup GetAlarmTemplateGroup(string templateName);

		/// <summary>
		/// Gets the alarm template groups defined for this protocol.
		/// </summary>
		/// <returns>The alarm template groups defined for this protocol.</returns>
		ICollection<IDmsAlarmTemplateGroup> GetAlarmTemplateGroups();

		/// <summary>
		/// Gets the standalone alarm template with the specified name defined for this protocol.
		/// </summary>
		/// <param name="templateName">The alarm template name.</param>
		/// <exception cref="ArgumentNullException"><paramref name="templateName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="templateName"/> is the empty string ("") or white space.</exception>
		/// <exception cref="AlarmTemplateNotFoundException">No alarm template group with the specified name was found for this protocol.</exception>
		/// <returns>The standalone alarm template with the specified name.</returns>
		IDmsStandaloneAlarmTemplate GetStandaloneAlarmTemplate(string templateName);

		/// <summary>
		/// Gets the standalone alarm templates defined for this protocol.
		/// </summary>
		/// <returns>The standalone alarm templates defined for this protocol.</returns>
		ICollection<IDmsStandaloneAlarmTemplate> GetStandaloneAlarmTemplates();

		/// <summary>
		/// Gets the trend template with the specified name for this protocol.
		/// </summary>
		/// <param name="templateName">The name of the trend template.</param>
		/// <returns>The trend template with the specified name for this protocol.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="templateName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="templateName"/> is the empty string ("") or white space.</exception>
		/// <exception cref="TrendTemplateNotFoundException">No trend template with the specified name was found.</exception>
		IDmsTrendTemplate GetTrendTemplate(string templateName);

		/// <summary>
		/// Gets the trend templates defined for this protocol.
		/// </summary>
		/// <returns>The trend templates defined for this protocol.</returns>
		ICollection<IDmsTrendTemplate> GetTrendTemplates();

		/// <summary>
		/// Determines whether a standalone alarm template with the specified name exists for this protocol.
		/// </summary>
		/// <param name="templateName">Name of the alarm template.</param>
		/// <exception cref="ArgumentNullException"><paramref name="templateName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="templateName"/> is the empty string ("") or white space.</exception>
		/// <returns><c>true</c> if a standalone alarm template with the specified name exists; otherwise, <c>false</c>.</returns>
		bool StandaloneAlarmTemplateExists(string templateName);

		/// <summary>
		/// Determines whether a trend template with the specified name has been defined for this protocol.
		/// </summary>
		/// <param name="templateName">The name of the trend template.</param>
		/// <exception cref="ArgumentNullException"><paramref name="templateName"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="templateName"/> is the empty string ("") or white space.</exception>
		/// <returns><c>true</c> if a trend template with the specified name exists for this protocol; otherwise, <c>false</c>.</returns>
		bool TrendTemplateExists(string templateName);
	}
}