---
uid: Adding_related_parameters_to_a_trend_graph
---

# Adding related parameters to a trend graph

DataMiner is a powerful tool that helps you gain insights into your data. With this new feature, the light bulb, you can take your insights to the next level. This feature gives you the opportunity to add related parameters to your trends to give you a better understanding of your data patterns. By using the light bulb feature, you can uncover hidden connections in your data that you might not have noticed otherwise. This means that you do not have to spend hours sifting through your data to find connections - the light bulb does the work for you.

## Prerequisites

To make use of this feature, certain requirements must be met.

- The system must be connected to dataminer.services. You can check whether this is the case on the *Cloud* page in System Center.

  ![](~/user-guide/images/Cloud_connected.jpg)

  > [!TIP]
  > See also: [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- DataMiner ModelHost must be running on your system.

  To check if DataMiner ModelHost is installed, you must visit [DataMiner Admin Services](https://admin.dataminer.services/). Navigate to “DataMiner Systems”, select your system and go to “Nodes” to see a list of DataMiner extension Modules, including DataMiner ModelHost.

- DataMiner CloudFeed must be running on your system.

  To check if DataMiner CloudFeed is installed, you must visit [DataMiner Admin Services](https://admin.dataminer.services/). Navigate to “DataMiner Systems”, select your system and go to “Nodes” to see a list of DataMiner extension Modules, including DataMiner CloudFeed.

- The option *Allow performance and usage data offload* must be enabled. See [Controlling cloud feed data offloads](xref:Controlling_cloudfeed_data_offloads) for more information.

## Unlock all capabilities of this feature

In addition to these requirements, there are two optional requirements that will unlock the full capabilities of the feature.

- Cassandra must be installed on the system. If this is not the case yet, navigate to [Migrating the general database to Cassandra](xref:Migrating_the_general_database_to_Cassandra) and follow the instructions.

- Behavioral anomaly detection must be enabled.

  ![](~/user-guide/images/Analytics_anomaly_detection.jpg)

  Enabling this setting allows DataMiner to generate data based on what happens in your system. This is needed if you want DataMiner to understand what’s going on.

By fulfilling both optional requirements, you can help DataMiner to study your system more efficiently, leading to even more valuable insights.

After completing the necessary requirements, it may take up to a week before you start receiving new insights from the light bulb feature. During this time, DataMiner will analyze your system in order to understand what is going on.

## Adding a related parameter to your trend

In the top-right corner there is a light bulb (from DataMiner 10.2.12/10.3.0 onwards). Clicking this light bulb icon will allow you to add one or more of those related parameters to the trend graph you are viewing. When you open a trend graph, DataMiner Cube will consult the ModelHost Extension Module to retrieve all parameters related to those shown in the trend graph. If not all prerequisites are fulfilled, DataMiner did not found relations or you have not unlocked all capabilities of the feature, there will be a message shown when you open the light bulb.
