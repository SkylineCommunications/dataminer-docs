---
uid: Troubleshooting_STaaS
---

# Troubleshooting – STaaS

STaaS (Storage as a Service) is a means to store your data in a cloud-native environment.

The key advantage is that this replaces storage via Cassandra and Elastic, and it has its own backup mechanism via Microsoft Azure.

For more detailed information, see [Storage as a Service (STaaS)](xref:STaaS).

> [!IMPORTANT]
> The communication between DataMiner Agents and STaaS is done via the internet. This means all DataMiner Agents must:
>
> - Have internet access.
> - Be able to reach the STaaS endpoints.

> [!NOTE]
> Every interaction with the cloud has a cost. As with any storage, the number of interactions should be reduced to a minimum. Using STaaS will highlight any inefficiencies because of their direct impact on cost. How and when to optimize this is specific to the integration.

## Architecture

The diagram below provides an overview of two clusters using STaaS versus Cassandra.

![STaaS vs Cassandra](~/images/STaaS_vs_Cassandra.png)

## How to find out your setup is using STaaS

There are several ways to find out whether you are using a STaaS setup:

- In DataMiner Cube, navigate to *System Center* > *Database* > *General* and check whether "STaaS" is entered into the *Database* field.

  ![System Center - Database set to STaaS](~/images/SystemCenter_STaaS.png)

  > [!NOTE]
  > The type of database (i.e. *Database per cluster* or *Database per Agent*) is not relevant, as all data from the cluster will be stored the same way.
  >
  > For example:
  >
  > ![System Center - Database per cluster](~/images/SystemCenter_DB_per_cluster.png)

- In the `C:\Skyline DataMiner\DB.xml` file, when the `type` attribute of the `<Database>` element is set to `CloudStorage`, the system is configured for a STaaS setup.

  If the `type` attribute is set to something other than `CloudStorage`, the system is not configured for STaaS.

  Example of *DB.xml* file when dedicated clustered storage is used:

  ```xml
  <DataBase search="false" active="True" local="true" type="CassandraCluster">
   ... 
  </DataBase>
  ```

- **Only applicable to Skyline employees**: Navigate to the *CDMR Agent* element and check whether the *DB Engine type* on the *Database* page is set to "CloudStorage".

## Investigation

1. [Verify that STaaS is used](#how-to-find-out-your-setup-is-using-staas).

1. Make sure the following prerequisites are met:

   - DataMiner 10.4.0 or higher.

   - The CloudGateway DxM (version 2.8.0 or higher) must be deployed on at least one DataMiner Agent.

     To install the module:

     1. In the Admin app, check whether the correct organization is mentioned in the header bar.

        > [!TIP]
        > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

     1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

     1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *DxMs* page.

     1. Locate the node (i.e. the DMA) you want to install the DxM on.

     1. Next to the *CloudGateway* module, click *Deploy* to start the automatic installation process.

     If the *CloudGateway* module is installed on your DMA already, verify that it is version 2.8.0 or higher:

     - SLLogCollector:

       1. Run the [SLLogCollector tool](xref:SLLogCollector).

       1. Open the resulting package, and navigate to *Logs* > *DxM* > *DataMiner CloudGateway* > *DataMiner CloudGateway.exe_version.txt*.

          The CloudGateway DxM version is displayed under *Product Version*.

     - Only applicable to Skyline employees (more specifically Techsupport): [Skyline Admin](https://skyline-admin.dataminer.services/organization) > search organization > search DMS (coordination) > check the status of the Nodes + DxMs

   - A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

     - In DataMiner Cube, go to System Center > Cloud. It should mention 'Session is active'

     - On the server, go to C:/Skyline DataMiner/Logging/SLCloudStorage.txt

       Issues are typically indicated with "Error Message = CloudSettings could not be retrieved from the cloud"

   - The STaaS-connected DMA has internet connection

     - Firewall allows port 443

     - Endpoints are reachable

       - STaaS West Europe: 20.76.71.123
       - STaaS UK South: 20.162.131.128

## Common pitfalls

### Cloud session token expiration

Impact:

- DataMiner will not start up
- No data can be retrieved / stored
- Modules requiring elastic search such as SRM, Process automation cannot load.

Reason:

- CloudGateway is unable to refresh the cloud session automatically.

Actions (Goal = understand and resolve why CloudGateway is unable to refresh the session):

- Check SLCloudStorage.txt for exceptions: CloudSettings could not be retrieved from the cloud
- Use Client Test tool to try to resolve: see [The session token has expired](xref:STaaS_Error_messages#the-session-token-has-expired)

### DataMiner does not start up after registration

Impact:

- DataMiner will not start up
- DataMiner startup stuck at 99%

Reason:

- DMA was previously registered with another cloud organization
- CloudGateway is down

Actions:

- Check SLErrors.txt for “ERR: Failed to get SAS token” see [DataMiner is unable to start up after registration](xref:STaaS_Error_messages#dataminer-is-unable-to-start-up-after-registration)
- Go to Task Manager and check if DataMiner CloudGateway service is started
- Manually remove the file: C:\ProgramData\Skyline Communications\DxMs Shared\Data\NodeId.txt.
- Restart the DMA

### Slow interaction/performance

Impact:

- Overall slowness
- Unable to retrieve trend graphs, alarm history,…

Reason:

- High load of interaction from / towards cloud
- Upload / download bandwidth of the local internet connection is unable to deal with the high load and is queueing
- Skyline cloud is unable to deal with the high load and is queueing.
- (bad) Integration design

Actions:

- On the server, go to C:/Skyline DataMiner/Logging/SLCloudStorage.txt. Check for Throttling warnings
- (Bad) design: The number of interactions can get high when using SLNet Subscriptions to perform specific actions. The efficiency of this (InterApp read calls) has been improved in

  - DataMiner 10.4.6 or higher
  - DataMiner 10.3.12 or higher

  Check with the squad if this is used. More info can be found here: [Skyline DataMiner Core InterAppCalls Range 1.0.1.1](xref:Skyline_DataMiner_Core_InterAppCalls_Range_1.0#1011)

- Check if skyline cloud is queueing: [Shared Cloud Storage - Microsoft Azure](https://portal.azure.com/#view/AppInsightsExtension/WorkbookViewerBlade/ComponentId/azure%20monitor/ConfigurationId/%2Fsubscriptions%2Fc1a16bf4-039a-4778-8053-72e813c52ca4%2Fresourcegroups%2Frg-workbooks%2Fproviders%2Fmicrosoft.insights%2Fworkbooks%2Fd36c92a8-ef00-4c26-bf09-13962d3b705d/WorkbookTemplateName/Shared%20Cloud%20Storage) (Skyline Internal)

  - EventHub > Throttled requests by EventHub
  - Events > Event Queue Time (check the instance that is used by the DMA: weu = West Europe or uks = UK South)

- Ask customer IT to verify the upload / download bandwidth consumption.

## Adding new DMA to DMS on STaaS

Some additional steps are required to add an extra Agent to a DMS using STaaS:

- [Adding a DataMiner Agent to a DMS running STaaS](xref:Adding_a_DMA_to_a_DMS_running_STaaS), vs
- [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent)
