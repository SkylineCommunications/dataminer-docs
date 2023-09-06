---
uid: Connector_help_British_Telecom_-_Slate_Asset_Manager
---

# British Telecom - Slate Asset Manager

The Slate Asset Manager can be used to create virtual assets, which in case of slate assets are linked to files in the NAS.

With this manager, you will be able to track the usage of resources, change the file they are linked to, create new resources, and delete them. In addition, you can schedule the usage of these resources, and will have a visual way of tracking them

## About

### Version Info

| **Range**            | **Key Features**                                                                                                      | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version (POC).                                                                                                | \-           | \-                |
| 1.0.1.x \[SLC Main\] | \- User input now runs via interactive Automation scripts. - Visual Overview layer has been added to the application. | 1.0.0.1      | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     | Elemental Live        | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

On the **FAS Configurations** subpage, you can configure the file locations for the Available, Active and Archived files. With the **File Wildcard Filter** configuration, you can limit the list of available files shown in the available list.

With the **File Server User Name**, **Domain** and **Password**, you can specify how DataMiner needs to be impersonated in order to reach the network directory.

With **Encoder Mount Path**, you can specify what the path will look like on the encoder itself. By default, this should start with */data/mnt/...*

### Redundancy

There is no redundancy defined.

## How to use

To add, update or remove assets, the script **British Telecom Slate Asset Manager** is needed. The visual overview should be used on the application to launch the appropriate script in the correct mode.

To book resources, the script **British Telecom Switch Manager** is needed. Here resource reservations will be made to schedule activations.
