using System;

namespace Skyline.DataMiner.Net.Messages
{
	[Serializable]
    public class PropertyInfo // : ICloneable, ISLCustomSerialization
	{

		/// <summary>
		/// Specifies the property type.
		/// </summary>
		public enum DataTypes
        {
			/// <summary>
			/// Alarm.
			/// </summary>
            Alarm = 0,
			/// <summary>
			/// Element.
			/// </summary>
            Element = 1,
			/// <summary>
			/// View.
			/// </summary>
            View = 2,
			/// <summary>
			/// Service.
			/// </summary>
            Service = 3
        }
    }
}