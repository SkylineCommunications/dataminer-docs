---
uid: Connector_help_Microsoft_Azure
---

# Microsoft Azure

Microsoft Azure, commonly referred to as Azure, is a cloud computing service created by Microsoft for building, testing, deploying, and managing applications and services through Microsoft-managed data centers.

This connector allows you to monitor relevant resource metrics available in Azure.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**      |
|-----------|-----------------------------|
| 1.0.0.x   | REST-API version 2018-01-01 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                               | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | See "Supported Resource Type Elements" table below. | \-                      |

### Supported Resource Type Elements

| **Connector**                                                                                                                                                     | **Resource Type**                          |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------|
| [Microsoft Azure Cloud Platform - Azure DB for PostgreSQL Servers](xref:Connector_help_Microsoft_Azure_-_Azure_DB_for_PostgreSQL_Servers)           | Microsoft.DBforPostgreSQL/servers          |
| [Microsoft Azure Cloud Platform - Disks](xref:Connector_help_Microsoft_Azure_-_Disks)                                                                       | Microsoft.Compute/disks                    |
| [Microsoft Azure Cloud Platform - Kubernetes Services](xref:Connector_help_Microsoft_Azure_-_Kubernetes_Services)                                         | Microsoft.ContainerService/managedClusters |
| [Microsoft Azure Cloud Platform - Load Balancers](xref:Connector_help_Microsoft_Azure_-_Load_Balancers)                                                   | Microsoft.Network/loadBalancers            |
| [Microsoft Azure Cloud Platform - Public IP Addresses](xref:Connector_help_Microsoft_Azure_-_Public_IP_Addresses)                                       | Microsoft.Network/publicIPAddresses        |
| [Microsoft Azure Cloud Platform - Storage Accounts](xref:Connector_help_Microsoft_Azure_-_Storage_Accounts)                                               | Microsoft.Storage/storageAccounts          |
| [Microsoft Azure Cloud Platform - VM Scale Sets](xref:Connector_help_Microsoft_Azure_-_VM_Scale_Sets)                                                   | Microsoft.Compute/virtualMachineScaleSets  |
| [Microsoft Azure Cloud Platform - Application Gateways](xref:Connector_help_Microsoft_Azure_-_Application_Gateways)                                       | Microsoft.Network/applicationGateways      |
| [Microsoft Azure Cloud Platform - Cosmos DB Accounts](xref:Connector_help_Microsoft_Azure_-_Cosmos_DB_Accounts)                                         | Microsoft.DocumentDb/databaseAccounts      |
| [Microsoft Azure Cloud Platform - Azure DB for MySQL Flexible Servers](xref:Connector_help_Microsoft_Azure_-_Azure_DB_for_MySQL_Flexible_Servers) | Microsoft.DBforMySQL/flexibleServers       |
| [Microsoft Azure Cloud Platform - Virtual Machines](xref:Connector_help_Microsoft_Azure_-_Virtual_Machines)                                               | Microsoft.Compute/virtualMachines          |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination. Usually: *https://management.azure.com.*
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

#### In Azure

Register an application or use an existing application in **App Registrations**. Add a client secret or use an existing client secret under **Certificates & Secrets**. The values in the registered application are the ones you will need to use to configure authentication in DataMiner. With this information, the connector will be able to retrieve the token from the REST API:

- Application (client) ID
- Directory (tenant) ID
- Client Secret

Under **Subscriptions**, select a subscription. Under **Access control** **(IAM)**, add a role assignment with the required permissions and associate it with the registered application.

Alternatively, under **Resource groups**, select the desired resource group, select **Access control** **(IAM)**, and click **Add Role Assignment**. Then configure the role assignment as follows:

- Virtual Machine Contributor.
- Option: User, group or service principal.
- Members: Select members.
- Enter the full name of the application and add the application.

#### In DataMiner

To initialize the connector, go to the **Authentication** page of the element, fill in the **Tenant ID**, **Client ID**, and **Client Secret** parameters, and click the **Authentication** button.

This is the information you can obtain from the service principal created in Microsoft Azure, as mentioned above.

Multiple elements using different service principals can be created in a DMS.

## How to use

This manager element will create a **view for each managed subscription**,and under each subscription view it will create a view for each **resource group**,which contains at least one **resource type** of which the metrics can be retrieved (defined in the Supported Resource Type Elements table).

The **resource type elements** are responsible for retrieving the **metrics** for every **resource** of the same type within the same **resource group**.

You can manage the resource type elements in the table on the **Resource Type Element** page. There, you can:

- **Enable/disable** the creation of the element.
- Change the metrics **Polling Frequency** for the element.
- View the **Element ID**.
- View the **Element State**.
- **Delete** the element.
- **Restart** the element.

The resource type elements will be created under the view of the resource group they belong to.

On the **Elements Configuration** subpage, you can also define the **Default Polling Frequency**,and enable or disablethe **automatic creation** of new resource type elements added to the table. These parameters will not affect the resource type elements that are already present in the table. This page also contains two buttons to enable and disable the creation of all resource type elements in the table.

### Polling Frequency Configuration

The manager element allows you to configure the **Default Polling Frequency** on the **Elements Configuration** subpage. Values are based on the possible **granularity** values Microsoft Azure Monitor supports, which are 1 minute, 5 minutes, 15 minutes, 30 minutes, 1 hour, 6 hours, 12 hours, and 24 hours.

When the polling frequency is set to 5 minutes, the connector will request allowed metrics every 5 minutes, aggregated over 5 minutes (timespan and time range are set to 5 minutes).

Every resource type may support different granularity values. For this reason, the polling frequency can also be configured in the **Resource Type Elements table** for each resource. When the selected default polling frequency on the Element Configuration page does not match an allowed value for a specific resource type, the nearest supported value will be selected for that resource type.

### Alarm and Trend Template Configuration

The **Elements Configuration** subpage allows you to configure which **alarm** and **trend template** need to be used during element creation for a resource. It contains an overview of available templates in the DMS.

When a template is selected, it will be applied for every resource of this type. Any change made to this selection will override the current configuration on resource level, which can be done in the Resource Type Elements table.

In case during installation and initial element creation no templates were available, and a new template has manually been assigned to an element, this will be synced to the overview in the **Resource Type Elements** table. The DMS state takes priority over any configuration in the Resource Type Elements table, but any change in the **Elements Configuration table** will override all.

## Notes

This connector does not poll any resource metrics. Metrics are polled via the resource type element connectors.
