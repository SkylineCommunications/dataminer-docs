using System;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents a user validator. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
	[Serializable]
    public class UserValidator : TypeValidator<string>
    {
        // Nothing useful to do here, but still used to differentiate between user field and ordinary string field 
    }
}
