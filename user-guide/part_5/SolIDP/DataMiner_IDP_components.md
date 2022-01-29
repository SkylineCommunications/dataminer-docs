---
uid: DataMiner_IDP_components
---

# DataMiner IDP components

By default, DataMiner IDP consists of the following elements:

| Element                           | Protocol                                                    | Description                                                                                                                           |
|-----------------------------------|-------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------|
| DataMiner IDP                     | Skyline DataMiner Infrastructure Discovery and Provisioning | The IDP app itself. See [Overview of the IDP app UI](xref:Overview_of_the_IDP_app_UI).                                                  |
| DataMiner IDP CI Types            | Skyline IDP CMDB                                            | This element manages all CI Types (also known as provisioning templates).                                                             |
| DataMiner IDP Configuration       | Skyline Configuration Manager                               | This element makes it possible to store configuration files in a configuration archive in the network.                                |
| DataMiner IDP Connectivity        | Skyline IDP Connectivity                                    | This element processes DCF information and creates DCF connections for CI Types that have connectivity discovery enabled.             |
| DataMiner IDP Discovery           | Skyline IDP Discovery                                       | This element processes discovery requests, executes the discovery actions and provides the status and results of these actions.       |
| DataMiner IDP Provisioning        | Skyline Generic Provisioning                                | This element processes provisioning requests, executes the provisioning actions and provides the status and results of these actions. |
| DataMiner IDP Rack Layout Manager | Generic Rack Layout Manager                                 | This element is used to manage and monitor the location of managed devices.                                                           |

> [!NOTE]
> From IDP version 1.1.13 onwards, all elements used by the IDP app are set to be hidden, so that only the IDP app itself is visible to the user.
