---
uid: Connector_help_Skyline_Configuration_Manager
---

# Skyline Configuration Manager

The Skyline Configuration Manager is used to manage scheduling of jobs (i.e. groups of tasks related to retrieving, editing and provisioning of device configurations) on selected elements of a DataMiner System and the associated file repository.

## About

The Skyline Configuration Manager app connector can be used to keep configuration file backups in the configured archive and to apply those backups on the elements in a DataMiner System. It also allows users to perform a comparison between backups, to display the results of such a comparison and to retrieve relevant metrics on the state of the configurations and assets.

In range **1.0.0.x**, once the target elements are specified in the manager's configuration tables, you can schedule jobs such as retrieving configuration files or pushing previously saved configurations onto elements. This functionality can be accessed via the **Create Scheduler Task** button of the DMS (Cluster) Manager element, also known as the primary element. The specifications of these jobs and affected elements are determined by filtering job parameters such as periodicity (once, daily, etc.), time of execution, job type, configuration type and the affected protocols, views and Agents. The DMA Manager, known as the secondary element, is then responsible for scheduling the respective DMA job and for informing the primary of any updates.

In range **2.0.0.x**, the configuration manager is mainly used for communication with the different managed elements and to keeps records on the archive state. The functionality of the configuration manager is integrated in **DataMiner** **Infrastructure Discovery & Provisioning (IDP)**.

### Version Info

| **Range**     | **Description**                                             | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                            | No                  | Yes                     |
| 2.0.0.x \[Obsolete\] | This range is intended to be integrated with DataMiner IDP. | No                  | Yes                     |
| 2.0.1.x \[SLC Main\] | Increased minimum DataMiner version to 10.0.0.0 - 9517 CU6  | No                  | Yes                     |

## Configuration

### Connections

This connector uses a virtual connection and does not require any input during element creation.

### Initialization (range 1.0.0.x)

On the **Configuration Files** page, click the **Network Share** page button and specify the **Domain**, **Username**, **Password** and **Path** in order to be able to work with the repository for the configuration files.

## How to use

In range **1.0.0.x** of this connector, depending on the version, the element created with the connector can have the following data pages:

- **General**: Lists the current Manager elements in the DMS. The primary manager will process the configuration repository from the secondary managers. The **Create Scheduler Task** button can be used to generate a scheduled task to retrieve the configuration from the specified Agents and elements by protocol and by view.
- **Elements**: Displays the target elements and the asset characteristics.
- **Compliance**: Contains tables related to policy validation and associated scripts.
- **Configuration Files**: Displays a tree view of the generated configuration repository. At the bottom of the page, a page button provides access to the **Network Share** and **File Repository Maintenance** configuration.
- **Configurations**: Contains comparison information on the stored configurations in the repository.
- **Jobs**: Contains a general overview of the scheduled jobs. A page button displays information on the associated job results.
- **Internal Configuration**: Lists the protocols run by the target elements in the DMS and the parameters from which the values are retrieved for the Configuration Table.
- **IAC**: Displays status info on the ongoing driver IAC communication, i.e. communication between DMS elements.

Range **2.0.0.x** is only intended to be used as part of DataMiner IDP, not as a separate element.
