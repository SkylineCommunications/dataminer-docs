---
uid: Connector_help_Discovery_Networks_Europe_Failover_Status
---

# Discovery Networks Europe Failover Status

This connector shows the Failover status and license status. It shows which Agent is online and if there are errors on the Agents.

It also shows how many elements are licensed and how much element capacity still remains.

Alarm monitoring and trending can be activated on these parameters.

## About

### Version Info

| **Range**            | **Key Features**                            | **Based on** | **System Impact** |
|----------------------|---------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | License and Failover information are shown. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Create a user in DataMiner that has access to the Agents module of System Center. Fill in the credentials of that user on the Failover Status page.

### Redundancy

There is no redundancy defined.

## How to use

If the correct credentials are filled in on the Failover Status page as detailed above, the element will display the Failover and license information. You can manually refresh the displayed information.
