---
uid: Overview_MediaOps_Validation
---

# Validation of upcoming jobs

To ensure smooth operations, it is essential that each booking is properly configured and that all required resources are available when the booking starts. By default, a scheduled task runs every hour to verify this. The task will validate the upcoming jobs set to start within the next hour. However, the interval and period can be [customized](#customizing-the-interval-and-period).

When an error is detected, the job will enter the [error state](xref:MO_S_Job_States). This will be indicated with a red color, for example:

![Job with error(s)](~/solutions/images/Scheduling_Validation_Error_Job.png)

To see a detailed list of the issues that have been identified:

1. Click the pencil icon for the job to open the *Edit job* panel.

1. In the *Job Info* section, click the error icon.

   ![Job error icon](~/solutions/images/Scheduling_Validation_Error_Icon.png)

This will display a table listing all detected errors.

![Job error list](~/solutions/images/Scheduling_Validation_Error_List.png)

Detected errors cannot be cleared individually by a user. Instead, any change to the booking will automatically trigger a re-validation of the entire object. Errors that are no longer detected are automatically removed from the list.

## Customizing the interval and period

By default, validation occurs every hour. You can adjust this schedule by editing the **MediaOps // Scheduling - Validate upcoming bookings** scheduled task in the Scheduler module in DataMiner Cube. As long as the name of this scheduled task is not changed, it will not be adjusted when you install upgrades.

- To modify the **interval**, in the *schedule* tab of the task configuration, configure a different schedule. Default value: 60 minutes.

- To modify the **validation period**, in the *actions* tab of the task configuration, enter your custom value in the *UpcomingMinutes* box. Default value: 60 minutes.

> [!TIP]
> For more information on how to work with the Scheduler module in DataMiner Cube, see [About the Scheduler module](xref:About_the_Scheduler_module).

## Current tests

A flexible and extendable framework has been designed to validate various types of objects within MediaOps. This framework is capable of validating multiple object types such as jobs, resources, and resource pools, and allows you to add new validation checks or modify existing ones as necessary. The results of these tests are stored in the DOM object in a standardized and generic way.

<!-- TODO: explain how to add/modify checks -->

The current tests that get executed on job instances check for the following things:

- All resources exist and are valid.
- All mandatory configuration is done.
- All virtual signal groups exist and are valid (if defined on a resource).
- All flows exist and are valid (if defined on a resource).
