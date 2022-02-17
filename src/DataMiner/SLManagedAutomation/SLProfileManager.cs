using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Profiles;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Allows interaction with DMS Profile Manager.
	/// </summary>
	public class SLProfileManager : IDisposable
	{
		internal SLProfileManager(bool handleEventsInBackgroundThread) { }

		internal SLProfileManager()
		{
		}

		//~SLProfileManager() { }

		/// <summary>
		/// Gets the <see cref="ProfileManagerHelper"/>.
		/// </summary>
		public ProfileManagerHelper Helper { get; }

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public virtual void Dispose()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves the profile parameters matching any of the specified filters.
		/// </summary>
		/// <param name="filters">Profile parameter filters.</param>
		/// <returns>The profile parameters that match at least one of the specified filters.</returns>
		public virtual IEnumerable<Net.Profiles.Parameter> GetParameters(params Net.Profiles.Parameter[] filters) { return null; }

		/// <summary>
		/// Retrieves the profile definitions matching any of the specified filters.
		/// </summary>
		/// <param name="filters">Profile definition filters.</param>
		/// <returns>The profile definitions that match at least one of the specified filters.</returns>
		public virtual IEnumerable<ProfileDefinition> GetProfileDefinitions(params ProfileDefinition[] filters) { return null; }

		/// <summary>
		/// Retrieves the profile instances matching any of the specified filters.
		/// </summary>
		/// <param name="filters">Profile instance filters.</param>
		/// <returns>The profile instances that match at least one of the specified filters.</returns>
		public virtual IEnumerable<ProfileInstance> GetProfileInstances(params ProfileInstance[] filters) { return null; }

		// This method is obsolete in the Helper.
		//public virtual ProfileManagerResponseMessage HandleProfileManagerRequestMessage(IProfileManagerRequestMessage request) { 
		//  return this._Helper.HandleProfileManagerRequestMessage(request, (object) null);	return null; 
		//}

		/// <summary>
		/// Removes the specified profile parameters.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="parameters">The profile parameters to remove.</param>
		/// <returns><c>true</c> if the profile parameter removal succeeded; otherwise, <c>false</c>.</returns>
		public virtual bool RemoveParameters(out string error, params Net.Profiles.Parameter[] parameters) { error = ""; return false; }

		/// <summary>
		/// Removes the specified profile definitions.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="definitions">The profile definitions that should be removed.</param>
		/// <returns><c>true</c> if the profile definition removal succeeded; otherwise, <c>false</c>.</returns>
		public virtual bool RemoveProfileDefinitions(out string error, params ProfileDefinition[] definitions) { error = ""; return false; }

		/// <summary>
		/// Removes the specified profile instances.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="instances">The profile instances to remove.</param>
		/// <returns><c>true</c> if the profile definition removal succeeded; otherwise, <c>false</c>.</returns>
		public virtual bool RemoveProfileInstances(out string error, params ProfileInstance[] instances) { error = ""; return false; }

		/// <summary>
		/// Adds or edits the specified profile parameters.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="parameters">The profile parameters to add or edit.</param>
		/// <returns><c>true</c> if the profile parameters were added/edited successfully; otherwise, <c>false</c>.</returns>
		public virtual bool SetParameters(out string error, params Net.Profiles.Parameter[] parameters) { error = ""; return false; }

		/// <summary>
		/// Adds or edits the specified profile definitions.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="definitions">The profile definitions to add or edit.</param>
		/// <returns><c>true</c> if the profile definitions were added/edited successfully; otherwise, <c>false</c>.</returns>
		public virtual bool SetProfileDefinitions(out string error, params ProfileDefinition[] definitions) { error = ""; return false; }

		/// <summary>
		/// Adds or edits the specified profile instances.
		/// </summary>
		/// <param name="error">Output string with notifications and/or errors that occurred.</param>
		/// <param name="instances">The profile instances to add/edit.</param>
		/// <returns><c>true</c> if the profile instances were added/edited successfully; otherwise, <c>false</c>.</returns>
		public virtual bool SetProfileInstances(out string error, params ProfileInstance[] instances) { error = ""; return false; }

		//[HandleProcessCorruptedStateExceptions]
		//protected virtual void Dispose(bool A_0) { }
	}
}