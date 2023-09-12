---
uid: Connector_help_Fox_Corp_Booking_Manager
---

# Fox Corp Booking Manager

This connector is used to manage bookings. It interacts with the Jobs and SRM modules via Automation scripts for the creation of bookings. It allows operators to interact with bookings in the pre-roll and post-roll phases, and it provides information on the status of existing bookings.

### Version Info

| **Range**            | **Key Features**              | **Based on** | **System Impact**   |
|----------------------|-------------------------------|--------------|---------------------|
| 1.0.0.x              | Initial version.              | \-           | \-                  |
| 1.0.1.x \[SLC Main\] | Confirm and Check In swapped. | 1.0.0.20     | Automation scripts. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

### General Settings

On the General Settings page, you need to configure how the bookings should be handled:

- The booking name configuration.
- The alarm times required for user interaction.
- The pre-roll and post-roll windows and the consecutive detection windows.
- The integration script.

### Follow Up

The Follow Up page contains a table with the bookings. It shows the bookings requests that have been received and allows you to process them, which will result in configurations sent to SRM via the integration script.

Alarm monitoring is possible based on the status of a booking in case an operator has not performed a required action within the configured time windows.

### Job API

This page contains information related to the interaction with the Jobs API.
