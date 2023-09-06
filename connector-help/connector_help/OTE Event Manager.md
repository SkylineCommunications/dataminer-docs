---
uid: Connector_help_OTE_Event_Manager
---

# OTE Event Manager

This connector is used for the creation and management of events. For each event, one or more bookings are made in the SRM Booking Manager, which will also be monitored via this connector.

Note that this connector is **designed to be used together with the SRM Booking Manager** and with the required Automation scripts.

## About

### Version Info

| **Range** | **Key Features**                                 | **Based on** | **System Impact** |
|-----------|--------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | \- Event creation and monitoring.- SRM bookings. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

This connector interacts with Excel files via the Microsoft OLE DB API. To make the communication with Excel files possible, make sure the **Microsoft Access Runtime database tool** is installed before you use this connector.

## How to use

### General

New events can be created via the **Add Event Via Script** button, which will launch an interactive script where all the parameters for the event and the bookings can be set. You can also launch this script by right-clicking the **Events Table** and selecting **Add Event**.

The **Import All Events Files** button handles all Excel event files that are available in the import folder (see "Notes"). Automatic handling of newly added files can also be enabled via the **Automatic Import** toggle button. Validation errors for imported events are shown on the subpage **Import Errors**. After the validation errors are fixed, you can start a **Retry** to handle the files again.

The **Events Table** on this page shows an overview of all current and future events, with the state of the corresponding SRM bookings. You can view and edit each of the events. For the corresponding bookings, the **Cancel**, **Confirm** (again), and **Delete** actions are available. Bookings for an event can also be canceled individually.

Via the right-click menu, you can also execute actions on events. It contains the **Edit** and **View** options, as well as the option to apply the settings of the event to a device of your choice. When no bookings can be made for an event because there are no devices available, you can use this menu to access a script that lists all overlapping bookings and allows you to cancel some of them to make room for the event.

### Events History

Events that have ended will be moved to the **Events History Table** after some time. You can configure after how long this happens. You can also configure how long the events remain present in the table before they are permanently deleted.

## Notes

- **Important**: This connector interacts with files and directories in the system, which means there must be **only one element using this connector running at a time**. Otherwise, there could be directory errors and file handling inconsistencies.
- The directory where import files should be placed is *C:\Skyline DataMiner\Documents\OTE Event Manager*.
