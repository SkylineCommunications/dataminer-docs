---
uid: SRM_1.2.23
---

# SRM 1.2.23

> [!NOTE]
> This version requires that **DataMiner 10.1.11-11105 or higher** is installed. The DataMiner Main Release track is not supported.

## New features

#### BREAKING CHANGE: Interface profile parameters now set on resource even when no profile instance is set \[ID 32702\]

When the initial configuration is applied to a resource, parameter values set on an interface will now be included even when no profile instance was set. Previously this only happened on the function itself.

> [!NOTE]
> This change in behavior may affect the way your current Profile Load scripts work. The following *ProfileParameterHelper* methods are affected:
>
> - *GetNodeSrmParametersConfiguration*, when *includeInterfaceParameters* is true
> - *GetNodeProfileParameterEntries*, when *includeInterfaceParameters* is true
> - *GetInterfacesSrmParameters*
> - *GetInterfacesProfileParameterEntries*

## Changes

### Enhancements

#### Additional validation of input \[ID 32185\]

Additional validation has been added in the SRM framework to avoid situations where invalid input is implemented.

#### Default Booking Logging Date Time Format updated \[ID 32405\]

The default value of the Booking Manager parameter *Booking Logging Date Time Format* has been changed to “dd/MM/yyyy HH:mm:ss.ffff".

#### Support for 'Pre-Roll End' and 'Post-Roll Start' as time reference in custom events \[ID 32460\]

It is now possible to add custom events using the time reference points "Pre-Roll End" and "Post-Roll Start".

#### SRM_ApplyProfileToResource and SRM_ExecuteProfileLoadScriptTests script dialogs moved to SRM namespace \[ID 32493\]

The dialogs shared by the scripts *SRM_ApplyProfileToResource* and *SRM_ExecuteProfileLoadScriptTests* have now been added to the *Skyline.DataMiner.Library.Automation.UserInterface.ApplyProfileToResource* namespace in *SLSRMLibrary.dll*. Previously, these were not included in an SRM-specific namespace.

> [!NOTE]
> Any copies you may have made of these scripts will need to be adjusted to refer to the new namespace.

#### Orchestration logging migrated to Serilog framework \[ID 32530\]

In order to standardize the used logging mechanisms, the SRM framework has been adjusted to make use of the Serilog framework for its orchestration logging.

> [!NOTE]
> In case there is a planned or active booking in the system when you upgrade to this SRM version, run the script *SRM_MigrateOrchestrationLogs* to make sure the new orchestration logs are logged correctly.

### Fixes

#### Custom events and properties added when these should have been disabled \[ID 32385\]

In some cases, when the *CustomEvents* or *CustomProperties* flags were disabled in the Booking Manager, it could occur that custom events or properties were added nevertheless.

#### Not possible to control transport bookings as user other than booking creator \[ID 32416\]

If a user other than the user who created a transport booking tried to control that booking, it could occur that this was not possible even if the Booking Locking feature was disabled in the Booking Manager

#### Various issues in Booking Manager Events and Properties table \[ID 32446\]

The following issues could occur in the Booking Manager *Events* and *Properties* table:

- In case of duplicate events, an incorrect error message was displayed that mentioned properties instead of events.
- It was possible to rename an event to an existing name.
- Properties could have duplicate names.
- It could occur that the *Default Value* column in the *Properties* table could not be set.
- Properties used by the standard framework were included in the *Custom Properties* table, even though configuring these as a custom property is not allowed.

#### Service created outside of conversion window \[ID 32468\]

When there were multiple Booking Managers that were set to the same virtual platform, it could occur that a service was created outside of the conversion window specified in one of the Booking Managers.

#### BookingManager.AddResource did not populate overridden parameters \[ID 32487\]

When a new resource was added using the *BookingManager.AddResource* method, it could occur that the overridden parameters of the resource used in the booking were not populated, so that the parameters could not be updated later.
