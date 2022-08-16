---
uid: SRM_1.1.1
---

# SRM 1.1.1

## New features

#### Booking Wizard: Resources pre-filter now also filters profile instances [ID_24034]

When a filter is selected in the Booking Wizard to only display available resources with a particular capability, this will now also affect the list of available profile instances for the target node and the corresponding interfaces. However, note that this is only the case if the filter capability parameter is present in the profile definition.

#### 'By Reference' checkbox removed for function with Path parameter [ID_24122]

If a function contains at least one Path parameter, the By Reference functionality is not supported. As such, this option will no longer be available in the Booking Wizard in that case.

#### ResourceAssignment profile instance capability filter improved [ID_24172]

The configuration for the *ResourceAssignment* property has been slightly modified. Previously, the same capability filter could not be applied to different nodes, because the "var:" label was used instead of the capability name itself.

Now the text displayed next to "var:" in the configuration will be used for display purposes only, while filtering will depend on the *Capability* value. For example, with the configuration below, two drop-down lists, labeled *Location* and *Location2*, will be displayed in the Booking Wizard, and both lists will filter based on the *Location* capability.

Node one:

```json
{
  "Condition": "A",
  "Value": [
     {
        "Label": "A",
        "Type": "Operation",
        "Value": {
        "FirstOperand": { "Link": "[var:Location]" },
        "Operator": "=",
        "SecondOperand": {
           "Link": "RESOURCE",
           "Capability": "Location"
           }
        }
     }
  ]
}
```

Node two:

```json
{
 "Condition": "A",
 "Value": [
     {
        "Label": "A",
        "Type": "Operation",
        "Value": {
        "FirstOperand": { "Link": "[var:Location2]" },
        "Operator": "=",
        "SecondOperand": {
           "Link": "RESOURCE",
           "Capability": "Location"
           }
        }
     }
  ]
}
```

## Changes

### Enhancements

#### Booking can now leave quarantine after change to resources [ID_23459]

When a resource is removed from a quarantined booking or swapped for a different resource, and because of this all resources are again available for the booking, the booking will now be taken out of the quarantine state.

#### New methods for improved logging of parameter sets [ID_23665]

The following new methods have been added in the code library to improve logging of parameter sets:

- *LogSuccessResult*: Requires the name of the function, the parameter ID and the parameter value.
- *LogFailureResult*: Requires the name of the function, the parameter ID and the expected and actual parameter value.

The *SRM_ProfileLoadScriptTemplate* script has been updated to include these methods.

#### Start and End properties of reservationInstance object [ID_24003]

To support the transition to a Booking Manager without booking tables, the *reservationInstance* object now has two custom properties, *Start* and *End*, containing the respective datetime values as UTC and InvariantCulture string. This format is used both for regular and contributing bookings. For permanent bookings, *End* will have the exception value "Not Applicable".

#### Reference to non-existing script in profile definition now ignored [ID_24006]

When a profile definition refers to an Automation script that does not exist, the SRM resource configuration will now ignore this Automation script.

#### New AddOrUpdateCustomProperty method [ID_24008]

A new method, *AddOrUpdateCustomProperty*, has been added to the API, so that other scripts can make use of the *SRM_CustomProperty* script without calling it directly.

The method is located in *ReservationInstanceExtensions.TryAddOrUpdateCustomProperty*. To use the method, import the namespace *Skyline.DataMiner.Library.Solutions.SRM* and access the method through the extension method of the reservation.

#### State transition restrictions of contributing bookings adjusted [ID_24055]

The restrictions on possible state transitions for contributing bookings have been refined to account for the relation with the parent booking.

If a contributing booking is locked and in use, it will only be possible to change its timing, and only if the proposed timing is compatible with the parent booking. If a booking is unlocked and in use, only the transition of confirmed to on hold and vice versa and a change of the timing are allowed. If a contributing booking is not in use, only transitions from confirmed or on hold to deleted and from canceled to a state other than deleted are not possible.

#### Service definition nodes now need unique label [ID_24123]

If a service definition is used in the Booking Wizard, it must now always contain a label for each node. This label must be unique within the service definition.

For this purpose, a new set of validation rules has been added, which check if a service definition is selected in the Booking Wizard, if the selected service definition has missing labels and if it has non-unique labels.

#### Improved performance when retrieving contributing bookings [ID_24295]

Performance has improved when contributing bookings are retrieved for a booking.

#### SRM_AddDcfInterfacesAsResources script input data extended [ID_24303]

The input data of the *SRM_AddDcfInterfacesAsResources* script have been extended to allow concurrency

#### SRM_BookingActions script now throws exception if booking is set to 'Failed' [ID_24366]

The *SRM_BookingActions* script will now throw an exception when the booking it is modifying is set to "Failed", so that is easier for a parent booking to detect if a contributing booking failed.

### Fixes

#### SRM_CreateNewBooking script: Problem with LoadSource method [ID_24005]

A problem with the *LoadSource* method could cause the *SRM_CreateNewBooking* script to attempt to load a source while no source was selected in the booking data.

#### Booking incorrectly showed source selection when edited [ID_24007]

If the Booking Wizard was configured to use a service definition with generic source node by default, and a booking was created using a service definition without generic source, it could occur that source selection was available if you edited that booking even though this should not be the case.

#### Time for next quarantine not updated when booking left quarantined state [ID_24060]

When a booking left the quarantined state, it could occur that the time for the next quarantine was not updated immediately.

#### 'Copy to Service' not working if persistent service was enabled [ID_24146]

If *Persistent Service* was set to "Enabled" in the Booking Manager, it could occur that copying booking properties to a service did not work.

#### SRM_AddDcfInterfacesAsResources script: Element name repeated twice in resource name [ID_24302]

In some cases, it could occur that the element name was repeated twice in the names of resources created by the *SRM_AddDcfInterfacesAsResources* script.

#### Exception when using SaveOrUpdate method [ID_24386]

When the *SaveOrUpdate* method was used, it could occur that an exception was thrown, which could make it impossible to run the create booking action script configured in a node property.

#### Issue with ProfileParameterEntryHelper class resolved + methods added [ID_24418]

In some cases, an issue in the *ProfileParameterEntryHelper* class could cause state profiles not to be applied.

This issue has been resolved, and the following methods have also been added to this class:

```csharp
public IEnumerable<SrmParameterConfiguration> GetInterfaceSrmParameters(SrmResourceConfigurationInfo resourceConfiguration, InterfaceProfileConfiguration interfaceProfileConfiguration);
```

```csharp
public IEnumerable<SrmParameterConfiguration> GetInterfacesSrmParameters(SrmResourceConfigurationInfo resourceConfiguration, IEnumerable<InterfaceProfileConfiguration> interfacesProfileConfiguration);
```

#### Service state of contributing booking updated incorrectly [ID_24466]

In some cases, it could occur that the service state of a contributing booking was updated when this should not have been the case.

#### Contributing function generated with incorrect interfaces [ID_24502]

When a booking was converted to a contributing booking, it could occur that the corresponding function did not have the correct interfaces and could not be linked to the parent booking.

This issue has been resolved; however, to ensure that this works optimally, we recommend that the service definition for the contributing service starts and ends with the same interfaces as the parent system function.
