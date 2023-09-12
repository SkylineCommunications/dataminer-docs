---
uid: Connector_help_Generic_Ticketing_Gateway
---

# Generic Ticketing Gateway

This is a DataMiner driver that allows for the polling of tickets created in the **DataMiner Ticketing App** for a given ticketing domain. This driver is generic so that any custom column is able to be retrieved from the configured domain.

About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial Version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

In order to start the polling of tickets, the **Ticket Domain** in the **Configuration Page** must be set. By default, only the **ID**, **Creation Date,** and **Revision** are polled for each ticket.

To poll more columns, add the field name to each to the **Column Mapping** table in the **Configuration Page** to populate the table with those custom columns.

## How to use

### General

This page contains the table that displays all tickets and their respective columns for the configured domain.

### Configuration

This is the configuration page for the driver. Here we can find:

- **Ticket Domain:** name of the ticket domain to poll tickets for;
- **Owner Support Configuration:** allows reassigning the ticket to someone else (Email notifications have to be enabled). When a ticket is reassigned, the new owner is automatically added to the mailing list (the **To** field of the e-mails). The **Ticket Owner Email** should be configured with the index of the column that is mapped (in the **Column Mapping** table) to the field that holds that information for each ticket.
- **Custom Ticket ID Configuration:** allows for custom ticket IDs to be generated. These custom ticket IDs will have the prefix configured in **Prefix** and a fixed number of digits configured in **Number of Digits**. The ID will use the one generated from the ticketing app. Additionally, a column index is needed for the field that will be holding that information for each ticket;
- **Column Mapping:** the table that maps each column to its respective field in the ticket domain.

### Notifications

This page allows configuring the notifications to be sent by the element. Notifications are sent on each ticket revision. Both email and SMS notifications can be enabled.

The fields **Email to**, **Email CC** and **SMS to** should be configured with the index of the column that is mapped (in the **Column Mapping** table) to the field that holds that information for each ticket.. The field **Email Structure** should contain a semicolon-separated list of column indexes to be sent in the e-mail.

If the **Title in Email** parameter is enabled, the driver will include the value in the 'Title' Column in the email subject.

### Add Tickets

This page allows the user to add a ticket through DataMiner.

It contains the **Add Ticket Parameters** table that contains all the parameters configured in the **Column Mapping** table. All changes in the Column Mapping table will be reflected in the Add Ticket Parameter Table.

When filling the **Value** Column in the **Add Ticket Parameters** table, the format of the data will be checked.

After filling all mandatory rows, you can press the **Add Ticket** button to create a ticket. If **not** all of the mandatory parameters are filled, it will not be possible to add another ticket and the missing mandatory fields will be logged in the **Add Ticket Status**. This parameter will also show any errors if there's any issue with the format of the inserted data.


