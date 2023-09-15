---
uid: Connector_help_SES_S.A._CMCS
---

# SES S.A. CMCS

The SES S.A. CMCS connector can be used to monitor the inputs of the CMCS system.

## About

The CMCS system is based on a PLC system from Rockwell. The system has several inputs and outputs. Its own software monitors these inputs and controls the outputs that generate alarm notifications.

The SES S.A. CMCS connector monitors the inputs on this PLC through the Factorytalk Gateway software, which is a gateway between Ethernet/IP on the PLC side and the connector on the DataMiner side.

### Version Info

| **Range**     | **Description**                                | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                               | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Filters signals for specific listening groups. | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Configuration

This page allows you to configure the connection to the server.

To create the connection

1. Click the **User** page button and enter the user credentials: **Username**, **Password**, **Domain** and **Logon** **Type**.
2. On the main Configuration page, enter the **Host IP Address**, select the **Server** name and select the **Listening Group** to be displayed on the element.
3. Click the **Connect to Server** button.

It is possible to configure the server's **Update Period** via the **Server** page button.

This page also displays the **state of the server**, when the **connection was established** and **the last update time**.

### Data Access

This page displays the **Data Access Subscriptions** **Table**, with subscriptions that match the selected **Listening Group** on the Configuration page.

The **Data Access Subscriptions** **Table** contains the following columns:

- **Index**: The table index.
- **Signal Name:** The name of the signal.
- **Digital Value:** The value for the subscribed item.
- **Alarm State:** Indicates if the alarm is *Suppressed* or *Not Suppressed*.
- **Signal State:** Indicates whether the signal is in use.
- **Shelved State:** Indicates whether the signal is shelved.
- **Acknowledgment State:** Indicates whether the signal has been acknowledged.
- **Quality:** The quality of the received information for the Digital Value.
- **Alm** **State**: Indicates if Nominal State and Actual State are the same.
- **Actual State:** Indicates the Actual State.
- **Nominal State:** Indicates the Nominal State.
- **Comment:** Displays a custom comment.
- **Linked Relay:** Indicates the Linked Relay ID.
- **Linked Relay State:** Indicates if the Linked Relay is *Enabled* or *Disabled*.
- **Time Before Resend:** Indicates the Interval Time.
- **Label If Zero:** Displays the custom label if Alm State indicates 0.
- **Label If One:** Displays the custom label if Alm State indicates 1.
- **GOC:** Displays if the entry is listening on GOC location.
- **SMC2:** Displays if the entry is listening on SMC2 location.
- **SMC1:** Displays if the entry is listening on SMC1 location.
- **Spare Listening Group 1**: Displays if the entry is listening on Listening Group 1 location.
- **Spare Listening Group 2**: Displays if the entry is listening on Listening Group 2 location.
- **Spare Listening Group 3**: Displays if the entry is listening on Listening Group 3 location.
- **TimeStamp:** The time when the server sent an update for this subscription item.
- **Tag:** The tag of the subscription item.

This page also contains a subpage **Advanced Configuration**, which displays a table where you can **Import, Export, Remove,** **Clear** or **Add** the input subscriptions to the element. It is also in this table that subscriptions can be configured (e.g. Signal Name; GOC; SMC1;SMC2; Spare Listening Group 1;Spare Listening Group 2;Spare Listening Group 3).
