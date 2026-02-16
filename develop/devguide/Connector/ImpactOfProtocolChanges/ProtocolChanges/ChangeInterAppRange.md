---
uid: ChangeInterAppRange
---

# Change InterApp range

Changing from the 1.0.0.X range to the 1.0.1.X range of the InterApp NuGet is considered a major change. There is backwards compatibility between these two ranges, but only in specific use cases. To move to a new InterApp range, every component (automation script, GQI, NuGet package, etc.) interacting with the connector must reference the same range.

## Impact

Communication with components referencing other InterApp ranges can be broken.

## Actions to be taken

Any component interacting with the connector will need to reference the same InterApp NuGet range.
