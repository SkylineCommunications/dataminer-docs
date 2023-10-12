---
uid: Cassandra_Cluster_Validator
---

# Cassandra Cluster Validator

The Cassandra Cluster Validator can be used for monitoring and trending of parameters of the Cassandra nodes in a DataMiner cluster. It is intended to be used in DataMiner Systems where each DMA hosts its own Cassandra local database, not for setups where one Cassandra cluster is used for the entire DataMiner System (i.e. "Cassandra Cluster" setups). It can for instance be of use when investigating Cassandra-related issues in DataMiner.

> You can download the tool from [DataMiner Dojo](https://community.dataminer.services/download/cassandraclustervalidator/).

## Installation

You can use the Cassandra Cluster Validator by installing it on a DMA.

> [!NOTE]
> PowerShell version 4.0 or higher must be installed on the DMA as well, or the tool will not be able to function properly.

To install this tool:

1. Unzip the file you downloaded using the button above and place the resulting *.dmprotocol* file in a folder on the DMA.

1. In the Protocols & Templates app on the DMA, upload the *.dmprotocol* package.

1. Create an element using the newly added protocol *Skyline Cassandra Validator*.

   > [!TIP]
   > For more information on how to create elements, see [Adding elements](xref:Adding_elements).

1. When the element has been created, go to its *DATA > General > Settings* page and configure the domain user and password that will be used to retrieve the Cassandra information. The specified user must have access to all DMAs in the cluster and must belong to the Administrators group.

1. Enable Windows Remote Management on each of the DMAs in the cluster. To do so, execute *winrm quickconfig* with PowerShell.

   We recommend the following settings:

   - winrm set winrm/config/winrs ‘@{IdleTimeout=”7200000″}

   - winrm set winrm/config/winrs ‘@{MaxConcurrentUsers=”10″}

   - winrm set winrm/config/winrs ‘@{MaxProcessesPerShell=”25″}

   - winrm set winrm/config/winrs ‘@{MaxMemoryPerShellMB=”1024″}

   - winrm set winrm/config/winrs ‘@{MaxShellsPerUser=”30″}

   ![Windows PowerShell](~/user-guide/images/Windows_PowerShell.png)

## Usage

### Element card

Once you have created and configured the element, it will display information about the Cassandra databases in the cluster on its different data pages.

You can find more information on which information is displayed on which page in the driver help of the element. To access the driver help, click the hamburger button in the top-left corner of the element card and select *Help*.

In case you have any trouble running the element, it can also be useful to go to the driver help page, as it contains a *Troubleshooting* section listing common issues.

### Monitoring and trending

In the Protocols & Templates app, you can [configure an alarm template](xref:Configuring_normal_alarm_thresholds) and/or [configure a trend template](xref:Configuring_trend_templates) for the element in order to allow alarm monitoring and trending.

Useful parameters for alarm monitoring and trending are for example the *Load*, the *Heap Memory* and the *Hitrate* of the Cassandra Key Cache on the *Info* page, as these can allow you to identify memory and cache issues.

Monitoring the *Total Space Used*, the *Snapshots Space Used* and the *Max* and *Mean Partition* of the different database tables on each node can be very useful as well.

On the *Cassandra GC* page, parameters such as *Max Elapsed*, *Total Elapsed*, *Ratio* and *Reclaimed* can provide insight on how the internal garbage collection is performing, for example during compaction.
