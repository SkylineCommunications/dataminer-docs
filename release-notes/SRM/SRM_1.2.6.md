---
uid: SRM_1.2.6
---

# SRM 1.2.6

> [!NOTE]
> This version requires DataMiner 10.0.9 or higher.

## New features

#### Profile instance selection can now be cleared in Booking Wizard \[ID_27118\]

In the Booking Wizard, it is now possible to clear the selection of a specific profile instance with the option *Unselect*. If this option is selected, all associated parameter values will be restored to the default values.

#### Possibility to exclude edge resources \[ID_27197\]

It is now possible to exclude edge resources from a transport contributing booking. To do so, configure the edge node with the *ExcludeEdgeResource* attribute set to true in the *Path* parameter. For example:

```json
"Source": {
            "Link": "RESOURCE",
            "Function": "Demodulating",
            "Property": "Connected Resource",
            "ExcludeEdgeResource": true
          }
```

If the new *ExcludeEdgeResource* attribute is not included in the configuration, edge resources will by default remain included.

#### New SkipResourceValidation property \[ID_27284\]

A new *SkipResourceValidation* property is now available in the *Function* class. By default, this property is set to false, but it can be set to true to skip the resource validation step when a custom script creates a booking silently with all resources already defined in the script.

Note that if this new option is set to true, using automatic resource selection is not recommended, as this may not work correctly without resource validation.

#### Data Transfer Rules extended with ProfileInstance trigger type \[ID_27352\]

Data Transfer Rules (DTR) have been extended to allow triggers on profile instances changes. You can now create such a trigger using the trigger type *ProfileInstance*. For example:

```json
{
  "Script": "SRM_DataTransferRulesTemplate",
  "Triggers": [
    {
      "NodeLabel": "Demodulator 1",
      "TriggerType": "ProfileInstance"
    },
    {
      "InterfaceId": 11,
      "NodeLabel": "Demodulator 1",
      "TriggerType": "ProfileInstance"
    }
  ]
}
```

To support this, the following methods were added to the class *SrmResourceUsageConfiguration*:

- `public void SetProfileInstance(Guid *profileId*, int *interfaceId*);`

  Sets the profile instance in the specified interface configuration.

  Parameters:

  - *profileId*: ID of the profile instance.
  - *interfaceId*: ID of the interface.

- `public void SetProfileInstance(Guid *profileId*);`

  Sets the profile instance in the node configuration.

  Parameters:

  - *profileId*: ID of the profile instance.

The *SRM_DataTransferRulesTemplate* script has been updated with an example of this.

## Changes

### Enhancements

#### Notification in case error occurs in created booking action script \[ID_26616\]

With the *CreatedBooking* action, a script can be run for each function before the booking is confirmed. Now if an error occurs in the script, the user will be notified.

#### SRM_DiscoverResources script now supports string and time-dependent capabilities \[ID_27028\]

The *SRM_DiscoverResources* script now supports string and time-dependent capabilities. In a file exported from the script, you can specify "time-dependent" in the relevant cell to configure a time-dependent capability.

#### LSO scripts now receive previous service state as input \[ID_27090\]

Life cycle service orchestration (LSO) scripts will now receive an indication of the previous service state as input. This can be used to skip the resource configuration when the service is in the Failed state. The script *SRM_LSOTemplate* contains an example of this behavior.

#### Deprecated ProfileManagerHelper methods replaced \[ID_27133\]

The SRM Solution now uses *ProfileHelper* methods instead of the deprecated *ProfileManagerHelper* methods. In addition, extension methods for *ProfileDefinitionCrudHelper*, *ProfileInstanceCrudHelper* and *ProfileParameterCrudHelper* were added to the *Skyline.DataMiner.Library.Profile* namespace, to make sure the same extension methods as in the *ProfileManagerHelper* class are available.

#### 'SRMFunction\_' prefix no longer used \[ID_27152\]

From DataMiner 10.0.9 onwards, the prefix “SRMFunction\_” is no longer used for virtual functions. The standard SRM Solution has now been updated to also no longer use this prefix.

#### Same lock life cycle for regular and permanent booking types \[ID_27316\]

Locked permanent bookings now behave in the same way as locked regular bookings.

### Fixes

#### Locked contributing resource discarded by AssignResources method if main booking was already running \[ID_27107\]

When the *AssignResources* method was used with a locked contributing resource while the main booking was already running, it could occur that valid resources were discarded.

#### PathComparer did not take network paths consisting of one element/network device into account \[ID_27198\]

The *PathComparer* method did not yet take into account that network paths can now consist of only a single element or network device (since DataMiner SRM 1.2.1). A comparison of two such paths always returned false.

#### Not possible to edit booking with unavailable resources \[ID_27223\]

If a booking contained unavailable resources, it could occur that the booking could not be edited. Now, to prevent this problem, such resources will be removed from a booking when it is edited.

#### Problem with datetime control in interactive scripts \[ID_27228\]

When an interactive script contained the possibility to select a date, a problem could occur with the datetime control that made it impossible to select the date.

#### SRM_ReservationAction script did not show updated start/stop time \[ID_27238\]

Previously, if the start or stop time of a booking was updated, the *SRM_ReservationAction* script still displayed the old start or stop time in its confirmation window.

#### 'Created by' and 'Last modified by' columns in Bookings list mentioned Administrator instead of actual user \[ID_27246\]

The *Created by* and *Last modified by* columns of the Bookings list always mentioned *Administrator* instead of the name of the user who actually created or edited the booking.

#### Problem in SLAutomation when running many LSO scripts \[ID_27258\]

If many LSO (Life cycle Service Orchestration) scripts were triggered at the same time, as a result of many bookings starting at the same time, a problem could occur in the SLAutomation process.

#### Exception when custom script used ScriptOutput \[ID_27298\]

Whenever a custom script used ScriptOutput in its logic, an exception was thrown, even when this should not have been the case.

#### Problem when triggering DTR with multiple service definition nodes of the same type \[ID_27367\]

When a Data Transfer Rule (DTR) rule was triggered on a resource, and the relevant service definition had multiple nodes of the same type, with resources that had a concurrency of 1, concurrency overflow errors could occur.
