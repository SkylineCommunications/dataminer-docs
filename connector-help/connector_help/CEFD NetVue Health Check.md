---
uid: Connector_help_CEFD_NetVue_Health_Check
---

# CEFD NetVue Health Check

The **CEFD NetVue Health Check** is a driver designed to check on table cells and standalone parameters of the whole NetVue solution running on top of the DMA. It also implements dynamic checks that have come to light in a NetVue environment. In addition, it contains a **Pending Calls** functionality to run dynamic calls to elements running on the DMA and get their pending calls on the timers and groups. (This is a generic virtual protocol that does not interfere with NetVue functionalities.)

## About

This is a generic driver that engineers working with the Heights devices have designed to avoid issues seen in the field that can be easily looked at using this driver.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

This driver runs as an application in DataMiner. When you add the application, open the **Advanced element settings** section and select the **Hidden** option. This will make sure that the application will only show up under apps and not in the Surveyor.

## How to Use

The driver runs on timers that can be specified by the operator. It can also run manually or automatically. By default, manual configuration is initialized.

The driver contains the following pages:

- **General**: This page contains a **Timer** that can be set to run at a specific number. It can be set to *manual* or *automatic*.
  With the **Health Check Scope**, you can set this to run in a *cluster* or *locally*. If you have multiple DMAs and you run this in a cluster, be careful not to load the system with redundant calls. For example, DMA-1 runs elements that belong to DMA-1 and DMA-2 in a cluster environment. Making the NetVue Health Check run with the *cluster s*cope will be good here, since it wil get all the data needed. However, to continue the example, if DMA-2 is running its own elements and not sharing with DMA-1, and DMA-2 runs the NetVue Health Check with the *cluster* scope, then redundant calls will be running on both DMAs since DMA-2 is also getting the same info that DMA-1 is getting.
  The **Last Check** is a checkpoint where you can see the last time the health check ran. This also shows if there were any internal errors in the process by sending an exception.
- **Hubs** / **Remotes** / **Provisioning** / **VMS**: These pages each contain a table listing the HTO Hubs, H Remotes, Provisioning app element and VSM devices, respectively. The columns in these tables represent every check that the driver makes on each of the relevant devices. If a row is not available because the item is no longer in the system, then all the columns will show *Not Available*. They can then be manually removed. For more details on what the columns represent, refer to the driver itself.
- **Pending Calls**: Pending calls also run with a **Timer**, which can be set to manual or automatic mode. Elements can be added that run locally in the **Pending Call Elements** table.
  The **Pending Call Threshold** is a parameter to avoid small gaps in between the pending calls. For example, an element in timeout could fill up the table, so to avoid this, the threshold can be increased to capture bigger gaps.
  The **Pending Calls Table** will display pending calls from timers and groups so you can check why things are taking too long.
- **Circuits**: This page contains a table with each active circuit service on the current DMA. The columns represent the **Name**, **Remote**, and **Sync Status** of each circuit. If the name of a circuit does not match with the corresponding QoS Group Remote Site Circuit Name in the QoS Group Remote Site Table of the CEFD HTO SNMP driver, an error value will be displayed for the Sync Status. The table also includes a button to **Remove** any circuits that no longer exist from the table. This button will only be enabled when the **Remote** value is set to *Not Available*.
