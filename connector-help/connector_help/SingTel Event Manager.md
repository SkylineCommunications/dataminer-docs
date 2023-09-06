---
uid: Connector_help_SingTel_Event_Manager
---

# SingTel Event Manager

This connector can be used to collect information from different Event Manager applications.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

On the **Settings** page, you can define the **scripts** that will be launched when you click the **Approve**, **Remove** or **Booking** button in the Events table.
Keep in mind that those **scripts need an input parameter called "instance"**, which will be filled in with the Events row primary key.

The **event managers** to be used by this connector need to have the **InterApp functionality** available on PID 9000000 and 9000001 and must reply to an Events message.

The **Events namespace** definition is the following:

namespace EventsInformation
{
using System;
public class Events
{
public string Name { get; set; }
public DateTime? StartTime { get; set; }
public DateTime? StopTime { get; set; }
public string Status { get; set; }
public string Source { get; set; }
public string ForeignKey { get; set; }
}
}

It is also possible to **create event entries** in the Events table by setting **parameter 100** on the element. This parameter receives an array of events in **JSON format**. For example:

\[{"Name":"New Test","StartTime":"2021-10-28T13:09:24.6567087+02:00","StopTime":"2021-10-28T15:09:24.6567087+02:00","Status":"Approved","Source":"Automation","ForeignKey":null}\]
