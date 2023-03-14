using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Skyline.DataMiner.Net.Automation
{
	/// <summary>
	/// Represents an Automation entry point.
	/// </summary>
	/// <remarks>
	/// <para>This type is used in the ExecuteScriptMessage to specify a custom entry point. For more information on how to define a custom entry point method, see AutomationEntryPointAttribute class.</para>
	/// </remarks>
	/// <example>
	/// <code>
	/// var customEntryPoint = new Skyline.DataMiner.Net.Automation.AutomationEntryPoint();
	/// 
	/// customEntryPoint.EntryPointType = Skyline.DataMiner.Net.Automation.AutomationEntryPoint.Types.AutomationEntryPointTest;
	/// customEntryPoint.Parameters.AddRange(new object[] { "message", new List&lt;int&gt;() { 1, 2, 3, 4, 5 } });
	/// 
	/// var executeScriptMessage = new ExecuteScriptMessage() { CustomEntryPoint = customEntryPoint, ScriptName = SCRIPT_NAME };
	/// </code>
	/// </example>
	[Serializable]
	public class AutomationEntryPoint
	{
		/// <summary>
		/// Defines the entry point types.
		/// </summary>
		[Serializable]
		public enum Types
		{
			/// <summary>
			/// Default.
			/// </summary>
			Default = 0,

			/// <summary>
			/// SRM service info state changes.
			/// </summary>
			SRMServiceInfoStateChanges = 1,

			/// <summary>
			/// An OnSrmQuarantineTrigger entry point is defined with:
			/// [AutomationEntryPoint(AutomationEntryPointType.Types.SrmQuarantineTrigger)]
			/// </summary>
			OnSrmQuarantineTrigger = 2,

			/// <summary>
			/// An OnSrmStartActionsFailure entry point is defined with:
			/// [AutomationEntryPoint(AutomationEntryPointType.Types.OnSrmStartActionsFailure)]
			/// </summary>
			OnSrmStartActionsFailure = 3,

			/// <summary>
			/// App package installation script
			/// </summary>
			InstallAppPackage = 4,

			/// <summary>
			/// App package configure script
			/// </summary>
			ConfigureApp = 5,

			/// <summary>
			/// App package uninstallation script
			/// </summary>
			UninstallApp = 6,

			/// <summary>
			/// An OnSrmBookingsUpdatedByReference entry point is defined with:
			/// [AutomationEntryPoint(AutomationEntryPointType.Types.OnSrmBookingsUpdatedByReference)]
			/// </summary>
			OnSrmBookingsUpdatedByReference = 7,

			/// <summary>
			/// An OnDomInstanceCrud entry point is defined with:
			/// [AutomationEntryPoint(AutomationEntryPointType.Types.OnDomInstanceCrud)]
			/// </summary>
			OnDomInstanceCrud = 8,

			/// <summary>
			/// Ticket CRUD operation script. Feature introduced in DataMiner 10.1.6 (RN 29191).
			/// </summary>
			OnTicketCrud = 9,

			/// <summary>
			/// An OnTicketCrud entry point is defined with:
			/// [AutomationEntryPoint(AutomationEntryPointType.Types.OnDomAction)]
			/// </summary>
			OnDomAction = 10,

			/// <summary>
            /// An OnApiTrigger entry point is defined with:
            /// [AutomationEntryPoint(AutomationEntryPointType.Types.OnApiTrigger)]
            /// </summary>
            OnApiTrigger = 11,

			/// <summary>
			/// Automation entry point for testing purposes.
			/// </summary>
			AutomationEntryPointTest = int.MaxValue
		}

		/// <summary>
		/// Gets or sets the entry point type.
		/// </summary>
		/// <value>The entry point type.</value>
		public Types EntryPointType { get; set; }

		/// <summary>
		/// Gets or sets the parameters for the custom entry point method.
		/// </summary>
		/// <value>The parameters for the custom entry point method.</value>
		public List<object> Parameters { get; set; }

		/// <summary>
		/// Initializes a new class of the <see cref="AutomationEntryPoint"/> class.
		/// </summary>
		public AutomationEntryPoint()
		{
		}

		public object ToEntryPointVariant()
		{
			return null;
		}

		public static object ToEntryPointVariant(Types type, params object[] parameters)
		{
			return null;
		}
	}
}
