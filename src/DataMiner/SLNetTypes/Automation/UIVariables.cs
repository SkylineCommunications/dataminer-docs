using System;   

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents UI Variables.
	/// </summary>
	/// <remarks>Available from DataMiner 10.0.13 (RN 27895) onwards.</remarks>
	public static class UIVariables
    {
        #region Constructor 

        static UIVariables()
        {
        }

        #endregion Constructor
        
        #region Properties

		#endregion Properties

		#region Methods

		/// <summary>
		/// Creates a key by combining the prefix with the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>The key, which is the combination of the prefix with the specified key.</returns>
		public static String CreateKey(string key)
        {
			return "";
		}

		#endregion Methods
		/// <summary>
		/// Defines visual overview UI variables. This class allows you to pass script (output) values and convert these to Visual Overview session variables.
		/// </summary>
		/// <remarks>
		/// <para>Available from DataMiner 10.0.13 (RN 27895) onwards.</para>
		/// <list type="bullet">
		/// <item><description>This only works when the automation script has been executed in Visual Overview and the script has been executed successfully.</description></item>
		/// <item><description>The option SessionVariablePrefix is linked with this feature, which means it is possible to store 2 different values from the same script. For instance: 2 pages, each having a script that results in Script session variable 'MyPage'. Prefix 'One_' is used on the first page and 'Two_' is used as prefix. This will result in session variables 'One_MyPage' and 'Two_MyPage' if the script is executed successfully on both pages.</description></item>
		/// </list>
		/// </remarks>
		/// <example>
		/// <code>
		/// engine.AddScriptOutput(UIVariables.VisualOverview.ClosingWindow_Result, ClosingMode.Continue.ToString());
		/// // The following call will create a session variable in Visual Overview named MyOutput which has the value 'MyValue'.
		/// engine.AddScriptOutput(UIVariables.VisualOverview.CreateKey("MyOutput"), "MyValue");
		/// </code>
		/// </example>
		public static class VisualOverview
        {
            #region Constructor

            static VisualOverview()
            {
            }

			#endregion Constructor

			#region Methods
			/// <summary>
			/// Creates a key by combining the prefix with the specified variable name.
			/// </summary>
			/// <param name="variableName">The variable name.</param>
			/// <returns>The key, which is the combination of the prefix with the specified variable name.</returns>
			public static String CreateKey(string variableName)
            {
				return "";
			}
            
            #endregion Methods

            #region Properties
			/// <summary>
			/// Gets the prefix.
			/// </summary>
			/// <value>The prefix.</value>
            public static String Prefix { get; }

            #region Predefined Visio Variables

			/// <summary>
			/// Gets the closing window message.
			/// </summary>
			/// <value>The closing window message.</value>
			/// <remarks>
			/// <para>This session variable is optional. It will show a message in the client in an OK-message box, regardless of what the value of the result variable is. However, when the value of result variable is Stop, this message will be shown in the Yes/No message box mentioned in UIVariables.VisualOverview.ClosingWindow_Result property . In other words, you can expand the Yes/No message box with a custom message, and this can be done with the message variable.</para>
			/// </remarks>
			public static String ClosingWindow_Message { get; }

			/// <summary>
			/// Gets the closing window result.
			/// </summary>
			/// <value>The closing window result.</value>
			/// <remarks>
			/// Note: This variable must be set for this feature to work. The value should be one of the ClosingMode enum values (converted to string).
			/// </remarks>
			/// <example>
			/// <code>engine.AddScriptOutput(UIVariables.VisualOverview.ClosingWindow_Result, ClosingMode.Continue.ToString());</code>
			/// <para>In case the value of the variable is Stop, a Yes/No message box will be shown, asking if the window can be closed. If Yes is selected, the window will be closed.</para>
			/// </example>
			public static String ClosingWindow_Result { get; }

            #endregion Predefined Visio Variables

            #endregion Properties
        }

    }
}
