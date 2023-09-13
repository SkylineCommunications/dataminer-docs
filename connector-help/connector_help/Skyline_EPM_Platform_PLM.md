---
uid: Connector_help_Skyline_EPM_Platform_PLM
---

# Skyline EPM Platform PLM

The EPM system encompasses various resources such as Circuit, NMS, Hub Network, Line Card, Chassis, and more. These resources require systematic scheduling of maintenance activities to ensure their optimal performance. To streamline this process, the Skyline EPM Platform PLM connector is used.

## About

The EPM PLM Solution facilitates seamless interaction with planned maintenance (PLM) activities associated with platform resources. With the internal connector logic, both one-time and recurrent PLM activities can be efficiently scheduled.

With this solution, users can perform the following actions directly from the connector interface or from a low-code app:

- Create PLM items
- Edit existing PLM items
- Delete PLM items

The Skyline EPM Platform PLM connector provides a streamlined and intuitive approach to manage and coordinate PLM activities, ensuring the optimal performance and maintenance of the EPM system.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Automation Scripts

Make sure the following EPM PLM scripts are available in the DMS:

- EPM PLM
- EPM PLM Add Subscriber
- EPM PLM Add Subscriber Type

## How to Use

### General

This page displays an overview of the system, including the number of **Active**, **Scheduled**, **Completed**, **Inactive**, **Expired**, and **Total** PLM activities.

### PLM

In the PLM Overview table, you can create PLM items directly from the connector interface:

1. Right-click the PLM Overview table.

1. Select **Add PLM Item** in the context menu.

1. In the pop-up window (which is an interactive Automation script), enter the following information:

   - **Title**: Provide a descriptive title for the PLM item (reservation).

   - **Resource Type**

   - **Resource**: Specify the name of the resource to assign the PLM item to.

   - **Start Time**

   - **End Time**

   - **Recurrence**: Select the recurrence pattern: *Once*, *Daily*, *Weekly*, or *Monthly*.

     - If you select *Once*, enter the date of the one-time PLM activity.

     - If you select *Daily*, specify the interval: *Every \_\_ day(s)*.

     - If you select *Weekly*, specify the interval: *Every \_\_ week(s)*. Also select the days of the week.

     - If you select *Monthly*, specify the interval: *Every \_\_ month(s)*. Also specify which day of the month: *Day\_\_*.

   - **Range of Recurrence**: Specify the range of dates in which the recurrence should apply.

     - **Start**: Enter the start date of the recurrence.
     - **End**: Enter the end date of the recurrence.

You can also edit or delete PLM items directly via the right-click menu. When delete an item, a confirmation box will be displayed.

### PLM Records

When a one-time PLM activity undergoes a status change from *Active* to *Complete*, or a recurrent PLM activity undergoes a status change from *Active* to *Inactive*, a new PLM record will automatically be added to the PLM Records table. This table serves as a repository for storing information related to PLM activities, providing a comprehensive history of completed or inactive PLMs. This behavior ensures that each significant status change is accurately recorded and tracked within the PLM system.

### Configuration

The connector contains several configuration sections to customize its behavior:

- **Processing Configuration:**

  - **PLM Status**: Enable or disable the updating of PLM activity statuses.

  - **PLM Timer**: Specify the frequency at which the PLM activity statuses are calculated and updated.

- **PLM Overview Table Auto Delete Options**

  - **Auto Delete**: Enable or disable the automatic deletion of completed or expired PLM activities from the PLM Overview table.

  - **Auto Delete Delay**: Specify for how long completed or expired PLM activities should be stored in the PLM Overview table before they are deleted.

- **PLM Records Table Auto Delete Options**

  - **Auto Delete**: Enable or disable the automatic deletion of PLM records.

  - **Auto Delete Delay**: Specify for how long PLM records should be stored in the PLM Records table before they are automatically deleted.

### Resource Subscription

The EPM PLM Solution contains two configuration tables that are necessary to validate if the entered resource is a valid EPM entity during the creation operation.

- **Resource Subscribers Table**: Allows the EPM PLM Solution to reference the EPM back-end elements.

- **Resource Types**: Delimits the supported EPM resources.

## Notes

A PLM entry can have 5 different statuses:

- **Scheduled**: One-time activities that have been created but are yet to occur.
- **Completed**: One-time PLM activities that have already been completed.
- **Active**: PLM activities that are currently happening, including both one-time and recurrent activities that are within their recurrence range.
- **Inactive**: Recurrent PLM activities that are not currently active but are within their recurrence range.
- **Expired**: Recurrent PLM activities that are outside the recurrence range, as the current date is beyond the specified range.
