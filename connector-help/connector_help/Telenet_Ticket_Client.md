---
uid: Connector_help_Telenet_Ticket_Client
---

# Telenet Ticket Client

The **Telenet Ticket Client** is part of the **SAM Ticketing Project**. It works as an interface between the automatic flows started by **alarms** and the **Telenet Ticket Gateway** connector that will send requests to the ticketing service (OSB) provided by Telenet.

## About

In order to minimize the load on the Ticket Gateway, any ticket **search requests** are made via the **Ticket Client**. Based on these results, the automatic flow will stop or continue to forward a request that will create, update or close tickets.
The communication of these search requests is stored in an overview table. This makes it possible to check if a search was successful or what caused the failure if it was not.

The information needed to make these request comes either from a search as mentioned above or from a topology database generated with the **Telenet Topology Database** driver.

As this connector is used as an interface between the automatic flow and the sending of commands to the ticketing service, more than one element can be generated in the DataMiner System. The number of **Ticket Clients** represents the number of automatic flows that can run at the same time. For example, if two tickets need to be created, and there are two or more Ticket Clients, the flow to create a ticket will run at the same time for both tickets. The actual request to the ticketing system, however, is buffered in the **Telenet Ticket Gateway** and thus handled in a sequential order.

As an extra check to monitor the correct operation of the entire ticketing flow, a heartbeat is sent to the **Generic Dynamic Heartbeat Receiver** driver.

### Version Info

| **Range**            | **Key Features**    | **Based on** | **System Impact** |
|----------------------|---------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Monitor and control | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- IP address/host: A random address, e.g. *127.0.0.1*, as the IP that will actually be used is the one of the selected service in the **Connection Details**.
- IP port: A random port, as the port that will actually be used is the one from the selected service in the **Connection Details**. Default value: *8650.*

### Initialization

#### Configuration of ticketing service

It is possible to make a list of different ticketing services, but only one can be selected and this service will be used to send the different commands.

As this info needs to be the same as defined in the **Telenet Ticket Gateway**, this configuration is only possible by importing or exporting a CSV file representing the different services to and from the **Service Info Table** that is displayed on the **Connection Details** page.

#### Configuration of related elements

This connector communicates with different connectors. The names of the elements using these drivers need to be filled in via the **Configuration** page button of the **Connection Details** page.

It is also possible to set the maximum number of rows in the **Communication - Response Table**.

### Redundancy

There is no redundancy defined.

## How to use

### Automatic Flow

The ticketing flow is started by an alarm, and will take hold of a Ticket Client. This is done by setting the **Lock Status**, the **LockGuidId** and the **Lock Time**. These are displayed on the **Connection Details** page.
It is possible to force an unlock via the **Lock Status** parameter on the **Configuration** subpage.

Once a Ticket Client is locked, the flow will start sending commands. On the **Communication** page, the parameter **Processing IAS Request Busy Status** will indicate when such a command is being executed.
This can also be forced to *Not Busy*. An indication of what is happening is shown in **Client Processing Data**.

Search requests will be displayed in the **Communication - Response Table** and will be sent to the **ticketing** **service** selected in the **Connection Details** page.

### Connection Details page

From this page, you can configure the possible **ticket** **services** via the **Export** and **Import CSV** **buttons**. You can pick the service to be used via **Service Selection**.

Other configuration options are available via the **Configuration** page button.

This page also shows the **lock status** of the Ticket Client.

### Communication page

This page contains an overview of the communication to and from the ticketing service. It will also indicate if anything is being processed and if so, what it is that is being processed.

### Search Results page

As mentioned in the "About" section, multiple items are needed to compose a request to create, update or close a ticket. The results of the flow are displayed on this page. It contains the needed topology in the **Ninas Network Path Details** and the searched tickets. Note that these values are used during the flow. This means that the data will change when a new flow uses the Ticket Client.

In order to minimize the load, the Ninas Network Path Details table will only be refreshed when the element is reopened.
