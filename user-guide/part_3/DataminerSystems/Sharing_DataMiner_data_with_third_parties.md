# Sharing DataMiner data with third parties

There are many ways in which you can make your DataMiner System share information (real-time device readings, fault data, performance data, etc.) with third parties.

DataMiner Sharing allows you to share particular information via the DataMiner Cloud Platform. However, at present this feature is still in preview. See [DataMiner Sharing](../../part_51/Sharing/Sharing.md#dataminer-sharing).

In addition, several other DataMiner applications feature data sharing possibilities. Depending on the exact requirements, consider the following architectures and capabilities:

#### DataMiner Cube

- Allow the third party to remotely access your DataMiner System through the ports required for DataMiner Cube.

- Set up and maintain a dedicated user profile for the third party (which devices can be accessed, what kind of actions can be performed, etc.).

> [!TIP]
> See also:
> -  [Configuring client communication settings](../DataminerAgents/DMA_configuration_related_to_client_applications.md#configuring-client-communication-settings)
> -  [Security](../security/security.md)

#### DataMiner Monitoring app

- Allow the third party to remotely access your DataMiner System through the ports required for DataMiner web applications.

- Use the Monitoring app for mobile access to DataMiner.

- Set up and maintain a dedicated user profile for the third party (which devices can be accessed, what kind of actions can be performed, etc.).

> [!TIP]
> See also:
> -  [The Monitoring app user interface](../../part_1/GettingStarted/The_Monitoring_app_user_interface.md)
> -  [The legacy Monitoring & Control app user interface](../../part_1/GettingStarted/The_legacy_Monitoring_Control_app_user_interface.md#the-legacy-monitoring--control-app-user-interface)
> -  [Security](../security/security.md)

#### DataMiner Reports

- Create a custom report template that contains all relevant information that you want to share with the third party.

- Set up a time schedule or event trigger to send the report to the third party.

> [!TIP]
> See also:
> [DMS Reporter](../../part_4/reporter/reporter.md#dms-reporter)

> [!NOTE]
> DataMiner Reports & Dashboards requires an optional license.

#### DataMiner Dashboard Gateway

- Set up DataMiner Dashboard Gateway on your internet server.

- Define and configure the necessary dashboards, which should contain all relevant information that you want to share with the third party.

> [!TIP]
> See also:
> [Legacy Dashboard Gateway installation](../../part_4/dashboards/Legacy_Dashboard_Gateway_installation.md)

> [!NOTE]
> Both DataMiner Reports & Dashboards and DataMiner Dashboard Gateway require an optional license.

#### Custom dashboards and reports

- Set up DataMiner Dashboard Gateway on your internet server.

- Create custom web pages using DataMiner Reports & Dashboards components that present all relevant information you want to share with the third party.

> [!NOTE]
> Both DataMiner Reports & Dashboards and DataMiner Dashboard Gateway require an optional license.

#### DataMiner Northbound Interfaces

- Use the DataMiner NBIs to query DataMiner for the information that you want to share with the third party.

- Create the client application (e.g. web page, mobile phone app, etc.) with which you want to share the information with the third party.

- Not all DataMiner NBIs are available by default. Optional licenses may be required.

> [!TIP]
> See also:
> -  [DataMiner interfaces](DataMiner_interfaces.md)
> -  <https://help.dataminer.services/WebServices/>

#### DataMiner Replication

- Allow the third party to remotely access your DataMiner System through the ports required for DataMiner Cube.

- Set up and maintain a dedicated user profile for the third party.

- The third party needs to have a separate DataMiner System onto which the elements can be replicated.

> [!TIP]
> See also:
> [Replicated elements](../../part_2/elements/Replicated_elements.md)
