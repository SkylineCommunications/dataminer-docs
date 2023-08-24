---
uid: Sharing_DataMiner_data_with_third_parties
---

# Sharing DataMiner data with third parties

There are many ways in which you can make your DataMiner System share information (real-time device readings, fault data, performance data, etc.) with third parties.

## DataMiner Sharing

DataMiner Sharing allows you to share live data via dataminer.services. For more information, see [DataMiner Sharing](xref:Sharing).

## DataMiner Cube

- Allow the third party to remotely access your DataMiner System through the ports required for DataMiner Cube.

- Set up and maintain a dedicated user profile for the third party (which devices can be accessed, what kind of actions can be performed, etc.).

> [!TIP]
> See also:
>
> - [Configuring client communication settings](xref:DMA_configuration_related_to_client_applications#configuring-client-communication-settings)
> - [Security](xref:About_DMS_Security)

## DataMiner Monitoring app

- Allow the third party to remotely access your DataMiner System through the ports required for DataMiner web applications.

- Use the Monitoring app for mobile access to DataMiner.

- Set up and maintain a dedicated user profile for the third party (which devices can be accessed, what kind of actions can be performed, etc.).

> [!TIP]
> See also:
>
> - [The Monitoring app user interface](xref:The_Monitoring_app_user_interface)
> - [The legacy Monitoring & Control app user interface](xref:The_legacy_Monitoring_Control_app_user_interface#the-legacy-monitoring--control-app-user-interface)
> - [Security](xref:About_DMS_Security)

## DataMiner Reports

- Create a custom report template that contains all relevant information that you want to share with the third party.

- Set up a time schedule or event trigger to send the report to the third party.

> [!TIP]
> See also: [DMS Reporter](xref:reporter)

> [!NOTE]
> DataMiner Reports & Dashboards requires an optional license.

## DataMiner Dashboard Gateway

- Set up DataMiner Dashboard Gateway on your internet server.

- Define and configure the necessary dashboards, which should contain all relevant information that you want to share with the third party.

> [!TIP]
> See also: [Legacy Dashboard Gateway installation](xref:Legacy_Dashboard_Gateway_installation)

> [!NOTE]
> Both DataMiner Reports & Dashboards and DataMiner Dashboard Gateway require an optional license.

## Custom dashboards and reports

- Set up DataMiner Dashboard Gateway on your internet server.

- Create custom web pages using DataMiner Reports & Dashboards components that present all relevant information you want to share with the third party.

> [!NOTE]
> Both DataMiner Reports & Dashboards and DataMiner Dashboard Gateway require an optional license.

## DataMiner Northbound Interfaces

- Use the DataMiner NBIs to query DataMiner for the information that you want to share with the third party.

- Create the client application (e.g. web page, mobile phone app, etc.) with which you want to share the information with the third party.

- Not all DataMiner NBIs are available by default. Optional licenses may be required.

> [!TIP]
> See also:
>
> - [DataMiner interfaces](xref:DataMiner_interfaces)
> - [Web Services](xref:WS_v1)

## DataMiner Replication

- Allow the third party to remotely access your DataMiner System through the ports required for DataMiner Cube.

- Set up and maintain a dedicated user profile for the third party.

- The third party needs to have a separate DataMiner System onto which the elements can be replicated.

> [!TIP]
> See also: [Replicated elements](xref:Replicated_elements)
