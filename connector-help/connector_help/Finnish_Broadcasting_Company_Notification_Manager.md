---
uid: Connector_help_Finnish_Broadcasting_Company_Notification_Manager
---

# Finnish Broadcasting Company Notification Manager

This connector generates different types of plasma notifications and sends these to the Plasma element. These notifications are also processed by the order manager, which will take care of the plasma integration logic.

This way, the connector can increase the plasma integration load, so that it can be combined with regression/performance tests to see if the system meets expectations.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**               | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Mediagenix WHATS On (2.0.1.x range) | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

## How to use

On the **Plasma** page, you can enable/disable the **Plasma Load**. The **Plasma Element ID** also needs to be defined on this page.

On the **General** page, you can define the **Load Time Window** representing the range when the actual load can be active. The **Time Window** and **Plasma Load** parameters are linked, so make sure these are correctly configured.

Via the **Plasma Notifications** page, you can add or remove notification entries. For each entry, you can configure the **Minimum Burst** and **Maximum Burst.** Based on this, a random number of new notifications will be generated and sent to the Plasma element. The **Interval** between two bursts can also be set. The **Notification** cell contains a dummy notification that newly created notifications are based on. The **Last Processed Burst Amount** is an indication of how many notifications have been sent in the previous burst. A **Description** can also be defined to give each notification entry a more readable value.
