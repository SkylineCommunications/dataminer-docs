using System;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents a user validator. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	[Serializable]
    public class UserValidator : TypeValidator<string>
    {
        // Nothing useful to do here, but still used to differentiate between user field and ordinary string field 
    }
}
