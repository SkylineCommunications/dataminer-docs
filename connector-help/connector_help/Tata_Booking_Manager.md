---
uid: Connector_help_Tata_Booking_Manager
---

# Tata Communications Booking Manager

The Tata Booking Manager is a custom application designed to fully manage bookings using the DataMiner SRM Solution. It is based on a custom driver (Skyline Booking Manager, version 1.0.0.5_HF1_START) that was previously created for Tata Communications.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

## How to Use

This driver consists of the following pages:

- **Bookings**: Contains the **list of active bookings**, which includes running, partial and confirmed bookings. Also contains three page buttons that can be used to set booking **details**, **areas** and **statistics**.
- **Contacts**: Provides an overview of the contacts that can be assigned to a booking. Also contains two page buttons that can be used to view **types of contacts** as well as **import** selected contacts through a CSV file.
- **Sports/Events**: Provides an overview of the sports/events that can be assigned to a booking. Also allows you to **import** selected sports/events through a CSV file.
- **Origins**: Provides an overview of the origins that can be assigned to a booking. Also allows you to **import** selected origins through a CSV file.
- **External Requests**: Displays an overview of **IAS data** along with an overview of all the incoming/outgoing internal/external messages in the **Message Overview** table.
- **Configurations**: Allows you to configure settings related to **Additional Script Info**, **Default Virtual Platform**, etc.
- **Job Properties**: Displays the **Job Property** table.
- **Job Property Definitions**: Displays the **Job Property** **Definition** table.
- **Jobs**: Displays the **Jobs** table.
