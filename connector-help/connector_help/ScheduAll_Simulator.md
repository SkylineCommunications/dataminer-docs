---
uid: Connector_help_ScheduAll_Simulator
---

# ScheduAll Simulator

The **ScheduAll Simulator** is a simulation solution for the ScheduAll Manager.

This connector can communicate with the ScheduAll Manager, simulating the usual communication of the ScheduAll web service and Interop service.

## About

### Version Info

| **Range** | **Description**                                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.1          | Initial version                                                     | No                  | Yes                     |
| 2.1.0.7          | Additional check on number of fields                                | No                  | Yes                     |
| 2.1.0.8          | Added notes to edit                                                 | No                  | Yes                     |
| 2.1.0.9          | Forced time to M/DD/YYYY Added import functionality                 | No                  | Yes                     |
| 2.1.0.10         | Added Client_ID to simulation Added write controls to change status | No                  | Yes                     |

## Configuration

### Connections

This protocol uses HTTP to communicate with the ScheduAll services. It requires the following input during element creation:

**SERIAL connection:**

- **IP address/host**: The IP address of the main serial connection.
- **Port**: The main port the connector will communicate through.

**CHORUS INTEROP SERVICE connection:**

- **IP address/host**: The IP address of the web service API.
- **Port:** The port that the web service communicates on.

**INTEROP LISTENER connection:**

- **IP Address/Host**: The IP address of the Interop Listener.
- **Port:** The port used for Interop Listener communication.

## Usage

### Work Order Review

This page contains a table listing all **work orders** present in the simulator, with related information. You can edit, cancel, duplicate or delete any of the work orders in the table.

### Resource Overview

This page contains a table listing all current resources.

### Query Configuration

This page contains the **Booking Status Definition Table**. Here you can see the relation between the **DataMiner name** given to a task and the **ScheduAll name**. You can also configure the **Maximum Number of Work Orders**.

### Security

You can find two parameters on this page, **Username** and **Password**. This username and password combination will be used to simulate the **ScheduAll Credentials** usually required to communicate with the web and Interop services. These are the credentials that you must enter in the ScheduAll Manager when using this simulation connector.

### Session Overview

This page contains configuration parameters for **Session Timeout** and the maximum number of user sessions (i.e. **Session Maximum**). At the bottom of the page, the **Session Overview** table, displays current sessions and allows you to delete a session.

### Visio

This page contains Visio **configuration and status** information.

### Resource Pool

This page contains the **Resource Pool Table**, which lists the Resource Pool ID, Description and Band Segment for each resource pool.

### Available Resources

This page contains a table listing the available resources, with the columns Resources Description Available, Available Resource Pool Band Segment and Available Resources - Add.

When you add an available resource, it will be added to the Selected Resources Table, mentioned below.

### Selected Resources

This page contains the **Selected Resources** table, which lists all resources that have been added via the Available Resources table. Resources can be removed again from the table with the **Remove** button.

### Import

On this page, you can specify a **Chorus Import Filename** and then click the **Import Schedule button**. When you have done so, the **Chorus Data Row Counter** will be populated with the number of rows corresponding to the imported schedule.

### Test

This test page contains a **WO Task State Change** field for testing purposes.
