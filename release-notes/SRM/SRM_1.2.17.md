---
uid: SRM_1.2.17
---

# SRM 1.2.17

## New features

#### Additional properties for alarms generated on Bookings table \[ID_30527\]

The Bookings table of the Skyline Booking Monitoring element now contains two additional columns:

- Service ID
- Skyline Booking Manager Element ID

In addition, alarms that are generated on the Bookings table of the Skyline Booking Monitoring element will now have the following 3 properties:

- Booking ID
- Service ID
- Skyline Booking Manager Element ID

#### New option to enable/disable 'Configure Resources' by default \[ID_30529\]

A new option, *Default Resource Configuration*, is now available on the *General* data page of the Booking Manager element. This option allows you to specify whether the *Configure Resources* option should be selected by default or not in the Booking Wizard. Note that this option, which determines whether a read-only booking is created or not, is only available if *Optional Resources Configuration* is enabled in the Booking Manager configuration.

#### Support for reuse of permanent contributing resources \[ID_30598\]

If the *Reuse Contributing Resource* property is set to *true* for a specific node, you can now reuse permanent contributing resources.

#### New GetUnmappedFunction method \[ID_30630\]

A new *GetUnmappedFunction* method is available, which makes it possible to access the unmapped nodes and the selected resources in the script responsible for transferring data between functions when creating a booking based on service profiles.

The method returns a helper that allows you to access those nodes.

```csharp
public UnmappedFunctionHelper GetUnmappedFunction(string nodeLabel, StringComparison stringComparison);
public UnmappedFunctionHelper GetUnmappedFunction(string nodeLabel);
public UnmappedFunctionHelper GetUnmappedFunction(int nodeId);
```

> [!NOTE]
> The existing *GetFunction* method will only return mapped functions from now on.

## Changes

### Enhancements

#### SRMEvent attribute marked as obsolete in Profile Load scripts \[ID_30520\]

In Profile Load scripts, the *SRMEvent* attribute is now marked as obsolete. The *ProfileParameterApplyType* attribute is used instead.

#### Any resource type supported for target resource of source/destination of network path \[ID_30524\]

The target resources of the source and destination functions of a network path can now be any type of resource. However, if the target resources are considered edges, only function resources will be considered in order to select the corresponding element.

#### Booking Manager app improvements \[ID_30588\]

Several improvements have been implemented in the Booking Manager app.

- On the *Dashboard* tab, the following changes have been implemented to improve performance:

  - Subshapes have been removed from the service shapes.
  - When the services are filtered by name, the services that are not displayed are collapsed instead of hidden (using the *Collapse* conditional shape manipulation action, available since DataMiner 10.1.8).

- Compatibility of the *Dashboard* tab with the Skyline Black theme has improved.

- On the *Bookings* tab, the style of the buttons has been reviewed, a service icon has been added to the shape representing the service alarm state, and the positioning of quarantine warnings has been improved.

#### SRM_About.txt moved to Webpages\\SRM directory \[ID_30653\]

The file *SRM_About.txt*, which contains the information on which SRM package is used, has been moved to the *C:\\Skyline DataMiner\\Webpages\\SRM* directory.

### Fixes

#### Locked contributing bookings confirmed without validation \[ID_30633\]

When a main booking was confirmed, the SRM framework did not validate if any associated locked contributing bookings could be confirmed as well. This meant that contributing bookings could be confirmed without any validation.

#### Resource pool inheritance not supported for silent booking creation based on service profile \[ID_30634\]

When a booking was created silently based on a service profile, this failed in case the resource pool inheritance feature was used on a parameter in the service definition. This will now succeed, and a resource will be selected based on the resource order configuration in the Booking Manager.

#### Not possible to rename transport booking \[ID_30635\]

When the name of a transport booking was changed, it could occur that this failed if the service definition generated for the booking did not have the *Contributing Configuration* property. An exception was thrown like the following:

```txt
Reservation Action failed due to: Skyline.DataMiner.Library.Exceptions.PropertyNotFoundException: Could not find property named "contributing config" or "contributing configuration" in the service definition Transport_53566400-f422-48ff-8a2e-b54b0ee44584
```

#### Booking Monitoring element not notified when element left quarantined state \[ID_30652\]

When a Booking Monitoring element was used to generate an alarm because a booking was quarantined, and this booking was edited so that it was no longer quarantined, it could occur that the Booking Monitoring element was not notified of this, so that the alarm persisted.

#### Exception when applying service state to contributing booking \[ID_30726\]

When a service state was applied to a contributing booking during orchestration, it could occur that an exception was thrown if the contributing function did not have a profile definition.

In the information events, the following information would be displayed:

```txt
Profile 00000000-0000-0000-0000-000000000000 doesn't exist.
```
