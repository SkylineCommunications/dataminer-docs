---
uid: Troubleshooting_STaaS
keywords: cloud storage, cloud issues, cloud connected agent, CCA
---

# Troubleshooting - STaaS

[Storage as a Service (STaaS)](xref:STaaS) is a cloud-native data storage architecture that allows you to securely store your data without the need to maintain databases yourself.

One of the key advantages of STaaS is its ability to replace storage solutions like Cassandra and Elastic, while providing its own backup mechanism through Microsoft Azure.

> [!IMPORTANT]
> Communication between DataMiner Agents and STaaS occurs over the internet. This means all DataMiner Agents must:
>
> - Have internet access.
> - Be able to reach the STaaS endpoints.

> [!NOTE]
> Every interaction with the cloud has a cost. As with any storage system, the number of interactions should be reduced to a minimum. Using STaaS will highlight any inefficiencies because of their direct impact on costs. The approach to optimizing this, including how and when to implement it, will depend on the specific integration.

## Architecture

The diagram below provides an overview of two clusters using STaaS versus Cassandra.

![STaaS vs Cassandra](~/dataminer/images/STaaS_vs_Cassandra.png)

- **DMS A and B**: Interaction with STaaS

  The diagram provides a compact visualization of how DMS A and DMS B interact with STaaS. The SLDataGateway facilitates the exchange of data with STaaS. Each STaaS-connected Agent requires a secure HTTPS channel to the STaaS database, hosted on a Microsoft Azure endpoint (West Europe or UK South).

  This secure connection is established via port 443 and authenticated using an access token provided by the Cloud Gateway. Think of this token as a "key" that unlocks the secure communication channel.

  - **DMS A**: Both Agents in the cluster have a Cloud Gateway installed.

  - **DMS B**: Only one Cloud Gateway is installed in the cluster, which is the minimum required per cluster.

- **DMS C and D**: Cassandra-related databases

  The visualization for DMS C and D highlights their interaction with Cassandra-related databases.

  - **DMS C**: Communicates with a Cassandra cluster that also includes OpenSearch/Elasticsearch.

  - **DMS D**: Uses local Cassandra nodes and an external OpenSearch/Elasticsearch node.

All communication between the DMS and the databases is routed through SLDataGateway.

## Investigation

### Verify your setup is using STaaS

There are two ways to verify if you are using a STaaS setup:

- **In DataMiner Cube**:

  1. Navigate to *System Center* > *Database* > *General*.

  1. Check if "STaaS" is entered in the *Database* field.

     ![System Center - Database set to STaaS](~/dataminer/images/SystemCenter_STaaS.png)

     > [!NOTE]
     > The type of database (i.e. *Database per cluster* or *Database per Agent*) is not relevant, as all data from the cluster will be stored the same way.
     >
     > For example:
     >
     > ![System Center - Database per cluster](~/dataminer/images/SystemCenter_DB_per_cluster.png)

- **In the *DB.xml* file**:

  1. Open `C:\Skyline DataMiner\db.xml`.

  1. Verify that the `type` attribute of the `<Database>` element is set to `CloudStorage`.

     If the `type` attribute is set to something other than `CloudStorage`, the system is not configured for STaaS.

     Example of *DB.xml* file with a non-STaaS setup:

     ```xml
     <DataBase search="false" active="True" local="true" type="CassandraCluster">
      ... 
     </DataBase>
     ```

- **Only applicable to Skyline employees**: Navigate to the *CDMR Agent* element and check whether the *DB Engine type* on the *Database* page is set to "CloudStorage".

### Check if the prerequisites are met

The following prerequisites must be met for a successful STaaS setup:

- DataMiner version 10.4.0 or higher.

- [CloudGateway DxM](#install-or-upgrade-the-cloudgateway-dxm) version 2.8.0 or higher, deployed on at least one DataMiner Agent.

- A DataMiner System [connected to dataminer.services](#verify-your-dms-is-connected-to-dataminerservices).

- A [working internet connection](#verify-your-dma-has-a-working-internet-connection).

#### Install or upgrade the CloudGateway DxM

To install the *CloudGateway* module:

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *DxMs* page.

1. Locate the relevant node (i.e. the DMA).

1. Next to the *CloudGateway* module, click *Deploy* to start the automatic installation process.

If the *CloudGateway* module is installed on your DMA already, **verify that it is version 2.8.0 or higher**:

- **Using the Admin app**:

  1. On the *DxMs* page, locate the relevant node (i.e. the DMA).

  1. Verify that the current version of the *CloudGateway* DxM is 2.8.0 or higher.

  1. If necessary, click the *Upgrade* button to upgrade the module to a more recent version.

- **Using SLLogCollector**:

  1. Run the [SLLogCollector tool](xref:SLLogCollector).

  1. Open the resulting package and navigate to *Logs* > *DxM* > *DataMiner CloudGateway* > *DataMiner CloudGateway.exe_version.txt*.

  1. Confirm the CloudGateway DxM version under *Product Version*.

- **Using the Skyline Admin app** (for Skyline Technical Support only):

  1. In the [Skyline Admin app](https://skyline-admin.dataminer.services/organization), go to the *Organizations* tab and enter your organization in the search box to filter the results.

  1. Click the eye icon next to your organization to access an overview of all DataMiner Systems created under it.

  1. Locate your DMS and click the eye icon next to it.

  1. Select the node (i.e. the DMA) on which the *CloudGateway* module is installed to expand the overview of deployed DxMs. This includes details such as DxM version, DxM data timestamp, and extra data.

  1. Find the *DataMiner CloudGateway* DxM in the overview and verify that its version is 2.8.0 or higher.

#### Verify your DMS is connected to dataminer.services

> [!TIP]
> See also: [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)

There are two ways to verify whether your DMS is connected to dataminer.services:

- **Using DataMiner Cube**:

  1. Go to the System Center > *Cloud* page, and select *Open dataminer.services*.

  1. On this page, check the connection status between your system and the dataminer.services platform.

     If a green icon and a green bar are displayed next to the DMS information, your DMS is connected to dataminer.services.

     > [!TIP]
     > For details about other connection states, see [The dataminer.services home page](xref:dataminer_services_home_page#connection-states).

- **Using the SLCloudStorage log file**:

  1. Navigate to the `C:\Skyline DataMiner\logging` folder of your DataMiner Agent, and open the *SLCloudStorage.txt* log file.

  1. Check whether you can find the following error message in the log file:

     ```txt
     CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorageConnection.Repositories.Exceptions.CloudSettingsRepositoryException: Failed to do GetCloudAccessTokenRequest. Received the following error messages: { "message": "This DMS is not Cloud Registered." }
     ```

     This error message will be present if your system is trying to use STaaS but is not connected to dataminer.services.

#### Verify your DMA has a working internet connection

Ensure your STaaS-connected DMA has a working internet connection.

Verify the following:

- Confirm that the firewall allows traffic through port 443.

- Verify that the necessary endpoints are reachable.

  These depend on the region you have registered your system for. During the [STaaS setup](xref:Setting_up_StaaS), you should have received information from <support@dataminer.services> about the specific endpoints or IPs to whitelist.

## Common pitfalls

### Cloud session token expiration

Description:

In the *SLCloudStorage.txt* log file, you may encounter entries similar to the examples under [The session token has expired](xref:STaaS_Error_messages#the-session-token-has-expired).

Impact:

- DataMiner is not able to start up.

- Data cannot be retrieved or stored.

- Modules requiring an indexing database, such as SRM and Process Automation, cannot load.

Reason:

- The *CloudGateway* module is unable to refresh the cloud session automatically.

Actions:

- Use the SLNetClientTest tool to attempt to resolve the issue, as outlined under [The session token has expired](xref:STaaS_Error_messages#the-session-token-has-expired).

### DataMiner does not start up after registration

Description:

In the *SLError.txt* log file, you may find the error message detailed under [DataMiner is unable to start up after registration](xref:STaaS_Error_messages#dataminer-is-unable-to-start-up-after-registration).

Impact:

- DataMiner is not able start up.

- DataMiner startup gets stuck at 99%.

Reason:

- The DMA was previously registered under a different cloud organization.

- The *CloudGateway* module is not running.

Actions:

1. Make sure the CloudGateway DxM is running:

   1. Open Windows Task Manager and check whether the process called *DataMiner CloudGateway* is running.

   1. Alternatively, check the *Services* tab to see if the service with the same name has the *Running* status.

1. Manually remove the file `C:\ProgramData\Skyline Communications\DxMs Shared\Data\NodeId.txt`.

1. Restart the DMA.

### Slow interaction/performance

Impact:

- Overall system slowness.

- Inability to retrieve trend graphs, alarm history, etc.

Reason:

- High volume of interaction with dataminer.services.

- The upload/download bandwidth of the local internet connection is insufficient to handle the high load, resulting in queueing.

- dataminer.services cannot handle the high load, resulting in queueing.

- (Poor) integration design.

Actions:

- Navigate to the `C:\Skyline DataMiner\Logging` folder of your DataMiner Agent, open the *SLCloudStorage.txt* log file, and look for throttling warnings.

- If the DataMiner System relies heavily on inter-element or inter-automation communication, consider using the InterApp framework as a better architectural choice.

  If SLNet performance issues arise because of large interactions when using SLNet Subscriptions, ensure that you are using DataMiner version 10.3.12 or higher. InterApp communication efficiency has been significantly improved in this version, which also directly impacts interactions with STaaS.

  > [!TIP]
  > For more information, refer to [Skyline DataMiner Core InterAppCalls Range 1.0.1.1](xref:Skyline_DataMiner_Core_InterAppCalls_Range_1.0#1011).

## Adding a new DMA to a DMS running STaaS

For a detailed guide, refer to [Adding a DataMiner Agent to a DMS running STaaS](xref:Adding_a_DMA_to_a_DMS_running_STaaS). Note that this involves some additional steps compared to the instructions for [adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent).
