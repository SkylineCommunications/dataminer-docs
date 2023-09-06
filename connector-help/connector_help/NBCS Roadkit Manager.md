---
uid: Connector_help_NBCS_Roadkit_Manager
---

# NBCS Roadkit Manager

This connector can be used to manage the NBCS Roadkit.

## About

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Key Features</strong></td>
<td><strong>Based on</strong></td>
<td><strong>System Impact</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x [SLC Main]</td>
<td><p>Initial version:- Processes CSV events through inter-app calls.- Merges CSV events with job data.- Polls job information from the Jobs app.- Allows you to approve jobs and create bookings, as well as edit bookings from the Jobs app.</p>
<p>This version is still an MVP.</p></td>
<td>-</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

### Events Table

On the **General** page, a table lists the events known by the connector. This table includes the following information:

- **Event State**: Reflects the overall state of the event. Possible values are *Invalid Profile* (if CSV event data is incomplete), *Fail* (if there is a failure while performing any action on the event), *Job Created* (if there is a job for the event), and *Booked* (if there is a booking for the event). More detailed information about the state of the job or booking can be found in the *Job State* or *Booking State* column, respectively.

- **Event State Details**: Displays more details in case the Event State is *Fail*.

- **Job State**: Reflects the state of the job, if any. Possible values are *N/A* (i.e. Not Applicable), *Not Created* (if a job could not be created), and *Created* (if a job has been created).

- **Booking State**: Reflects the state of the booking, if any. If there is **no booking**, the possible values are *N/A* (i.e. Not Applicable) or *Not Created* (if the booking could not be created). When there **is a booking**, the values fall back to the same values as the booking status (i.e. *Undefined*, *Pending*, *Confirmed*, *Completed*, *Disconnected*, *Interrupted*, or *Canceled*). The booking state is updated based on a timer.

- **Start Proximity**

- **Job Actions**: At present, only the *Remove* action is supported. When you click this button, all objects related to an event (job, booking, and entry in the table) will be removed.

- **Administrative State**: Possible values: *Approved* or *Not Approved*. The operator can manipulate this configuration **both in the Jobs app and in the events table**.

- If the Administrative State is *Not Approved*, the event has a job, but there is no booking. If you try to switch a job to *Approved*, if all the necessary conditions are met, a booking is created. The Booking State will reflect the booking status and the Event State will go from *Job Created* to *Booked*.
  - If the Administrative State is *Approved*, the event has a job and a booking that has not yet started. When you switch a job to *Not Approved*, the corresponding booking is canceled and deleted. The Booking State will be set to *N/A*, and the Event State will go from *Booked* to *Job Created*.

- **Truck in PxP Date**: The truck park and power date. This is used as the booking start time.

- **Disconnect**: The date when the VPNkit is disconnected from the network. This is used as the booking end time.

This table is populated as follows:

1.  An update message from the NBCS NEP Provisioner connector is received by the NBCS Roadkit Manager through inter-app communication.
2.  Every 30 seconds, jobs are polled from the Jobs app, so that they can be updated in the NBCS Roadkit Manager.

### Creating Jobs

The connector can create jobs every time there is an inter-app call, using an import CSV made with the NBCS NEP Provisioner. CSV import is used only for job creation. If a CSV event has already been translated into a job, it will be ignored.

Jobs can also be created directly in the Jobs app. These will be imported to the NBCS Roadkit Manager based on a timer.

### Editing Jobs

A job can be edited through the Jobs app. Based on a timer, updates will be imported into the NBCS Roadkit Manager.

Job updates can be reflected in booking updates if the event has a booking that has not yet started.
