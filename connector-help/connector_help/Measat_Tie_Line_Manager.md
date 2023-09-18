---
uid: Connector_help_Measat_Tie_Line_Manager
---

# Measat Tie Line Manager

This Tie Line Manager connector is designed to facilitate the managing of available bidirectional tie lines between video routers located in different sites. These tie lines are available for redundancy purposes: the video signal of the backup site can be sent to the main site and used to broadcast. The Tie Line Manager makes use of the Generic Virtual Matrix connector, which builds a virtual matrix on top of existing matrices and allows the adding and maintaining of tie lines. The Tie Line Manager extends the functionality of the vMatrix to integrate services into the overall architecture. It monitors the alarm severity status of the related services, allowing users to verify the status of each service before deciding to switch back to the main path and free up the tie line. Tie lines can also be reserved so that they are not used by DataMiner.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you first start the element, configure the following parameters on the **Configuration** page:

- **vMatrix Element**: Select an element in your DataMiner System running the Generic Virtual Matrix connector. The list of elements you can select is automatically generated in the background during element startup.
- **Service Templates**: Select which service templates should be used to generate the related services. The list of service templates you can select is automatically generated based on the templates found in the system during element startup.

## How to use

The Tie Line Manager uses a publish-subscribe approach, so that polling is kept to a minimum. After you configure the Virtual Matrix (vMatrix) element and services templates to be used, the Tie Line Manager will subscribe to the selected vMatrix (though DataMiner standard subscriptions) and services (through InterApp communication). From that moment onwards, the Tie Line Manager will be immediately notified of any update in the tie lines configured on the vMatrix or in the alarm severity and properties of the related services. On top of that, the Tie Line Manager will also periodically check the system for new services to subscribe to.

The Tie Line Manager has the following data pages:

- **General**: Displays all information related to the tie line functionality. For each tie line that was found, the displayed table shows information regarding its direction, availability, use, and path status. You can also set a tie line (with the **Use Tie Line** parameter) or free up a tie line when it is in use (via the **Actions** column).
- **Services**: Provides an overview of the top- and sub-services found in the system, with information such as the service alarm level and property values. As the connector only looks for new services once a day, you can use the **Sync Services** button to perform a manual full synchronization.
- **Configuration**: Allows you to configure which vMatrix element and service templates should be used (see "Initialization" above). The **Full Service Update Hour** parameter allows you to select when the Tie Line Manager should search for new services. This way, you can select a time interval with less load on the system.
