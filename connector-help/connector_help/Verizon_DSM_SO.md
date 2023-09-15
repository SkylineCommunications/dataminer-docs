---
uid: Connector_help_Verizon_DSM_SO
---

# Verizon DSM SO

This connector is used to gather information **via inter-element communication** that will be exported to a location used by the **Generic Sun Outage** connector. The information gathered consists of key parameters used during the calculation of sun outages. This connector is purely a system connector with this sole responsibility.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**        |
|-----------|-------------------------------|
| 1.0.0.x   | Not available (system connector) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

As this is mainly a system connector, not much user interaction is needed. Below you can find more information on the different functionalities in the connector.

### General

Clicking the **update** button will perform a **full update of the system**. It will:

- Get the latest subscribers from the Profile Manager for both the **Earth Stations** and the **Satellites table.**
- Retrieve the data from these subscribers.
- Export information for both earth stations and satellites to the relevant **CSV** **file**.

### Configuration

#### Export Configuration

The following functionalities are available within this section:

- **File Export**: Allows you to control the connector exporting the information gathered from the subscribers to a CSV file.
- **File Export Path**: Determines the path used to export the CSV file.
- **Export Processing Time**: Allows you to control how **frequently** the system will gather new data to be exported.
- **Apply:** Allows you to do a **manual update** of the export logic.

#### Subscribers Configuration

The following functionalities are available within this section:

- **Update Subscribers**: Allows you to control the update of the subscribers table from Profile Manager.
- **Subscribers Timer**: Allows you to control how **frequently** the system will get updates from Profile Manager.

### ES Subscribers

The following functionalities are available on this page:

- Adding an entry to the subscriber table:

  1. Right-click anywhere within the table.
  1. Select **Add New Row** in the context menu.
  1. Fill in the necessary information in the pop-up window.
  1. Click OK.

- Editing an entry in the subscriber table:

  1. Right-click the entry you want to edit.
  1. Select **Edit ES Subscriber** in the context menu.
  1. Edit the necessary information in the pop-up window.
  1. Click OK.

- Deleting entries from the subscriber table:

  1. Select the entries you want to delete.
  1. Right-click the entries.
  1. Select **Delete selected row(s)** in the context menu.

- Clearing all entries from the table:

  1. Right-click anywhere within the table.
  1. Select **Clear Table** in the context menu.

- Updating the table: Click the update button at the bottom of the table to update it with the latest information from Profile Manager.

### Sat Subscribers

The following functionalities are available on this page:

- Adding an entry to the subscriber table:

  1. Right-click anywhere within the table.
  1. Select **Add New Row** in the context menu.
  1. Fill in the necessary information in the pop-up window.
  1. Click OK.

- Editing an entry in the subscriber table:

  1. Right-click the entry you want to edit.
  1. Select **Edit Sat Subscriber** in the context menu.
  1. Edit the necessary information in the pop-up window.
  1. Click OK.

- Deleting entries from the subscriber table:

  1. Select the entries you want to delete
  1. Right-click the entries.
  1. Select **Delete selected row(s)** in the context menu.

- Clearing all entries from table:

  1. Right-click anywhere within the table.
  1. Click **Clear Table**

- Updating the table: Click the update button at the bottom of the table to update it with the latest information from Profile Manager.

## Notes

The connector requires the following additional configuration in order to be fully functional:

- A **Correlation rule** needs to be set up that captures **information events** and executes a script. The following parameters should be used in this Correlation rule:

  - Earth Station Subscribers OnChange Event
  - Earth Station Subscribers OnUpdate Event
  - Satellite Subscribers OnChange Event
  - Satellite Station Subscribers OnUpdate Event

- An **Automation script** is needed to read the information event and pass the information to the correct element running the **Verizon WM DSM** to be processed.

- A **definition in Profile Manager** needs to be created with the name "**Protocols_SO**". Within this definition, **a parameter with the same name** needs to be created and linked with the **name and version of the connector that your element is currently using**.
