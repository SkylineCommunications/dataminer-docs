---
uid: SRM_logging_config
---

# Configuring SRM logging

> [!TIP]
> See also: [SRM logging](xref:SRM_logging)

## Standard SRM logging configuration

<!-- RN 31178 -->

1. In the Booking Manager, go to the *Config* > *General* page.

1. Under *History and Logs*, click *Settings*.

   This will open the *Logging Settings* window.

1. In the *Booking Logging location* box, enter the path for the booking logging.

   Keep the following in mind regarding this path:

   - Only a network path is supported.

   - The path must end in a backslash character.

   - Both the client machine and the DataMiner servers must have access to the network share. If necessary, validate the access to the shared folder using file explorer locally on each server.

1. Optionally, you can also configure the following settings in the *Logging Settings*  window:

   - *Booking Logging Date Time Format*: The datetime format for the booking logging. This must be a valid format, e.g. *dd/MM/yyyy HH:mm:ss.ffff*.

   - *Booking Logging Max File Size*: The maximum size of booking log files. Minimum: 1 MB. Maximum: 100 MB.

   - *Booking Minimum Logging Level*: Events must match this log level or a higher log level to be included in the logging. Can be set to *Verbose*, *Debug*, *Information*, *Warning*, or *Error*. <!-- RN 34336 -->

   - *Booking Logging Cleanup Status*: Determines whether the booking logging is cleaned up automatically or not. If parameter is set to *Enabled*, an automatic cleanup will occur every hour.

   - *Logging Files Time to Keep*: Determines how old logging files must be before they can be cleaned up.

   - *Cleanup now*: Click this button to manually trigger a cleanup of the log files older than than the configured *Logging Files Time to Keep*.

## Configuring custom log records

You can extend the booking log files with extra information generated in a custom script. <!-- RN 29545 -->

Example:

```csharp
var reservation = SrmManagers.ResourceManager.GetReservationInstance(reservationId) as ServiceReservationInstance;
var bookingManager = reservation.FindBookingManager();
using (var logging = SrmLogHandler.Create(Engine, bookingManager, reservation))
{
   logging.BufferMessage("Log debug information", LogFileType.Debug);
}
```

### Adding custom log records from a Profile-Load Script

From within a Profile-Load Script, you can add custom records to the action logs, together with a severity indication.

Example:

```csharp
helper.LogFailure("An issue occurred"); 
   // generate a log record with ‘Normal’ severity

helper.LogSuccess("Configuration was successful");
   // generate a log record with ‘Critical severity

helper.Log("Report a warning", LogEntryType.Warning);
   // generate a log record with a custom severity
   // Namespace Skyline.DataMiner.Library.Solutions.SRM.Logging.Orchestration is needed
```

### Adding custom log records from an LSO script

<!-- RN 31988 -->

From within an LSO script, you can add custom records to the action logs or debug logs, together with a severity indication.

Example:

```csharp
srmBookingConfig = new SrmBookingConfiguration(reservationGuid, bookingManagerInfo, enhancedAction.Event, engine);

srmBookingConfig.Logger.BufferMessage("Booking resource configuration is disabled", LogFileType.User, SrmLogLevel.Warning);
srmBookingConfig.Logger.LogActionMessage("Booking resource configuration is disabled", LogEntryType.Warning);
srmBookingConfig.Logger.LogDebugMessage("Booking resource configuration is disabled", LogEntryType.Warning);
```

In case many action log records need to be buffered before they are pushed to log files, you can use the following method:

```csharp
srmBookingConfig.Logger.BufferActionMessage("Booking resource configuration is disabled", LogEntryType.Warning);
```

To effectively push the records from the buffer to the log files, you then need to call the *Flush* method.
