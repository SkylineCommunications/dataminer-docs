---
uid: Connector_help_Sky_UK_Audio_Description_Workflow
---

# Sky UK Audio Description Workflow

This connector can be used to create an enhanced service containing elements using the connector Imagine Communications EPIC MV, Axon ACP - GDR26, [Sky UK SSR](xref:Connector_help_Sky_UK_SSR) and [Sky UK VICC](xref:Connector_help_Sky_UK_VICC).

With this connector, alarms can be generated according to predefined rules.

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

To use this connector, create a service that uses it as its service definition. Then configure the following child element/parameters.

When you create a service using this connector, configure the following child elements/parameters:

- Imagine Communications EPIC MV

  - **Audio Silence Description (PiP)**: This parameter is needed to indicate which PiP entry should be monitored.
  - **Audio Silence State (PiP)**: This parameter is needed to indicate which PiP entry should be monitored.

- Axon ACP - GDR26

  - **Active-A**

- Sky UK SSR

  - **Audio Description (Current Events)**: This parameter is needed to indicate which Service Key should be monitored.

- [Sky UK VICC](xref:Connector_help_Sky_UK_VICC)

  - **Type Of Material**

## How to Use

Once the service has been created, DataMiner will check if there is a control track, if it is the chain in reserve, if it is the slot expecting Audio Description and if it is a programme on air.

The connector will then trigger alarms according to Audio Description Workflow V4.

A service created using this connector will have the data pages detailed below.

### Alarms

This page contains the **ALPB Table**, with the Index, Cause, Suggested Action, Alarm State, Alarm Target UI, Channel Name and Short Description columns.

### Admin

On this page, you can configure the service and check information related to its child elements.

**Debug Logging** allows you to enable or disable detailed logging while the service is working, which can be useful in case you suspect the service is not working correctly.

**Service Element Status** shows an overview of the status of the service child elements.

### Subscriptions Active

On this page, the **Subscription Table** shows all the parameters contained within this enhanced service. The primary key of the table is the **SourceKey**, which is a string concatenation of the DataMiner ID, element ID, parameter ID and row key filter of each parameter, with a forward slash ("/") as separator. For each parameter, the table shows the Row Key Filter, Protocol Name, Element Name, Parameter Description and Parameter Value. The latter is always displayed as a string, even if it is a numeric parameter.

The **Reset Subscriptions** button below the table resets all the subscriptions.

### Workflow Conditions

This page displays the workflow conditions values:

- **Control Track** is *Yes* when Multiviewer Audio Silence Description does not contain "Audio Description Missing", or Multiviewer Audio Silence State is different from *Alarm*. For all other possibilities, this is *No*.
- **Chain in Reserve** is *No* when GDR26 Active A is *Input A*; otherwise it is *Yes*.
- **Slot Expecting AD** is *Yes* when SSR Audio Description Flag is *Yes;* otherwise it is *No*.
- **Programme** is *Yes* when VICC Type of Material is *Program,* *MultiSegmentProgramEvent* or *SingleSegmentProgramEvent;* otherwise it is *No*.

### Device Data

This page displays the parameter values of the child elements: Multiviewer Audio Silence Description, Multiviewer Audio Silence State, GDR26 Active A, SSR Audio Description Flag and VICC Type of Material.

It also shows the **BSS Service Status** value. When this is *Off-Air*, this workflow will not trigger any alarms. If it is set to *NA* or *On-Air*, the workflow will run as expected.

### General Parameters

This page contains a table with parameters included in the service.
