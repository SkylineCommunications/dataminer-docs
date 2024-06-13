---
uid: ChangeInterAppRange
---

# Change range of InterApp NuGet

Changing from the 1.0.0.X range to the 1.0.1.X range is considered a major change. There is backwards compatibility between these two ranges, but only in specific use cases. Moving to a new InterApp range requires any component (Automation Script, GQI, NuGet package...) interacting with the connector to reference the same range.

## Impact

Communication with components referencing other InterApp ranges can be broken.

## Actions to be taken

Any component interacting with the connector will need to reference the same range of InterApp NuGet.
