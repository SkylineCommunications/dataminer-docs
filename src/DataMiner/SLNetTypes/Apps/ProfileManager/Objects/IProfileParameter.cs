using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Profiles
{
    public interface IProfileParameter
    {
        ProfileParameterCategory Categories { get; set; }

        Parameter.ParameterType Type { get; set; }

        ParameterValue DefaultValue { get; set; }
    }

	/// <summary>
	/// Capability profile parameter interface.
	/// </summary>
	public interface ICapabilityProfileParameter : IProfileParameter
    {
		/// <summary>
		/// Gets or sets the units.
		/// </summary>
		/// <value>The units.</value>
		string Units { get; set; }

		/// <summary>
		/// Gets or sets the discrete entries.
		/// </summary>
		/// <value>The discrete entries.</value>
		/// <remarks>
		/// Every value of a capability parameter of the discreet type should have a list of discrete entries that are a sub-list of the ones defined on the profile parameter.
		/// </remarks>
		List<string> Discretes { get; set; }

		/// <summary>
		/// Gets or sets the default capability usage value.
		/// </summary>
		/// <value>The default capability usage value.</value>
		CapabilityUsageParameterValue DefaultCapabilityUsageValue { get; set; }
    }

	/// <summary>
	/// Capacity profile parameter interface.
	/// </summary>
	public interface ICapacityProfileParameter : IProfileParameter
    {
        string Units { get; set; }

        CapacityUsageParameterValue DefaultCapacityUsageValue { get; set; }
    }

	/// <summary>
	/// Monitoring profile parameter interface.
	/// </summary>
	public interface IMonitoringProfileParameter : IProfileParameter
    {
        // No specific data for monitoring yet
    }

	/// <summary>
	/// Configuration profile parameter interface.
	/// </summary>
	public interface IConfigurationProfileParameter : IProfileParameter
    {
        // No specific data for monitoring yet
    }

	/// <summary>
	/// Profile parameter value interface.
	/// </summary>
	public interface IProfileParameterValue
    {
		/// <summary>
		/// Gets or sets the parameter  value type.
		/// </summary>
		/// <value>The parameter value type.</value>
		ParameterValue.ValueType Type { get; set; }

		/// <summary>
		/// Gets or sets the string value.
		/// </summary>
		/// <value>The string value.</value>
		string StringValue { get; set; }

		/// <summary>
		/// Gets or sets the double value.
		/// </summary>
		/// <value>The double value.</value>
		double DoubleValue { get; set; }
    }
}
