using System;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents a user validator.
	/// </summary>
	[Serializable]
    public class UserValidator : TypeValidator<string>
    {
        // Nothing useful to do here, but still used to differentiate between user field and ordinary string field 
    }
}
