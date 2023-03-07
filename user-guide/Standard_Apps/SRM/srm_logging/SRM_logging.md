---
uid: SRM_logging
---

# SRM logging

In many situations, access to logging is essential to understand a particular situation. This is even more important for bookings, where any failure (e.g. configuration not succeeded) can have an impact on live operations.

![SRM logging example](~/user-guide/images/SRM_logging.png)

Two types of log files can be generated per booking:

- Debug: Used by Skyline to investigate issues reported by end users.
- Action: Contains details about actions done by users or by Automation (during orchestration).

To view the logging for a booking, select the booking in the list or on the timeline in the Booking Manager app, and click the *Debug Log* or *Action Log* button in the lower right corner of the UI.

This can for instance be useful in case a booking cannot be confirmed because not all mandatory items have been configured for it (resources, profile parameters, and profile instances). In that case, a line is added to the Debug log file. <!-- RN 31183 -->

> [!TIP]
> See also: [Configuring SRM logging](xref:SRM_logging_config)
