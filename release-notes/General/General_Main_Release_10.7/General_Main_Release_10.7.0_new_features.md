---
uid: General_Main_Release_10.7.0_new_features
---

# General Main Release 10.7.0 – New features - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

*No highlights have been selected yet.*

## New features

#### Service & Resource Management: New PatchReservationInstanceProperties method to update properties of a reservation instance [ID 44084]

<!-- MR 10.7.0 - FR 10.6.1 -->

The ResourceManagerHelper now contains a new `PatchReservationInstanceProperties` method. This method can be used to update properties of a reservation instance.

See the following example:

```csharp
Guid bookingId = ...; 
var propertiesToPatch = new JSONSerializableDictionary();
propertiesToPatch.AddOrUpdate("Key to update", "New value");

var result = rmHelper.PatchReservationInstanceProperties(bookingId, propertiesToPatch);

if (result.UpdatePropertiesResult != UpdatePropertiesResult.Success)
{
    // Handle failure
}
else
{
    // Call returns the booking with the updated properties
    var booking = result.UpdatedInstance;
}
```

> [!NOTE]
>
> - Only the properties passed to the `propertiesToPatch` dictionary will be updated.
> - The result of the property update will contain the updated booking with all its properties (including those that were not updated).
> - This new method does not allow you to removed properties from a reservation instance.

#### User-defined APIs are now capable of returning bytes instead of a string [ID 44158]

<!-- MR 10.7.0 - FR 10.6.1 -->

User-defined APIs are now capable of returning bytes instead of a string.

The `ApiTriggerOutput` class now has a `ResponseBodyBytes` property of type byte[], which, when set, will take precedence over `ResponseBody` of type string. Both `ResponseBodyBytes` and `ResponseBody` are limited to 29 MB.

By default, a Content-Type header of type `application/octet-stream` will be returned. If necessary, this can be overridden by means of the `Headers` property in `ApiTriggerOutput`.

> [!NOTE]
>
> - `TriggerUserDefinableApiRequestMessage` is now also capable of returning bytes.
> - When a user-defined API being tested in the SLNetClientTest tool returns bytes, the following message will appear: "Response body is in bytes and cannot be displayed".
