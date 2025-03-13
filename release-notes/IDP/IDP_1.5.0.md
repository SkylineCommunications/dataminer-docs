---
uid: IDP_1.5.0
---

# IDP 1.5.0

> [!NOTE]
> This IDP version requires that DataMiner 10.3.0 [CU0] or higher is installed. Note that if you use DataMiner [10.4.0](xref:General_Main_Release_10.4.0_changes#dataminersolutionsdll-now-included-in-core-dataminer-software-id-38530)/[10.4.3](xref:General_Feature_Release_10.4.3#dataminersolutionsdll-now-included-in-core-dataminer-software-id-38530) or higher, installing DataMiner IDP will no longer require a DataMiner restart.

## New features

#### New default CI Types and discovery templates [ID 38675]

​IDP now comes with predefined default CI Types and discovery templates. These are largely non-editable: only the credentials of the default discovery templates can be edited by the user. To edit the default CI Types, you will need to duplicate these.

The following default CI Types have been added:

- Default - AppearTV General Platform

- Default - AppearTV X20 Platform

- Default - Arista Manager

- Default - Bridge Technologies VB Probe Series - VB120

- Default - Bridge Technologies VB Probe Series - VB220

- Default - Bridge Technologies VB Probe Series - VB240

- Default - Bridge Technologies VB Probe Series - VB242

- Default - Bridge Technologies VB Probe Series - VB250

- Default - Bridge Technologies VB Probe Series - VB252

- Default - Bridge Technologies VB Probe Series - VB260

- Default - Bridge Technologies VB Probe Series - VB262

- Default - Bridge Technologies VB Probe Series - VB270

- Default - Bridge Technologies VB Probe Series - VB272

- Default - Bridge Technologies VB Probe Series - VB330

- Default - CISCO DCM

- Default - CISCO Manager

- Default - CISCO Nexus

- Default - Ericsson RX8200

- Default - Harmonic NMX

- Default - Linux Platform

- Default - Microsoft Platform

- Default - NetInsight Nimbra

The following default discovery profiles have been added:

- Default - AppearTV General Platform

- Default - AppearTV X20 Platform

- Default - Bridge Technologies VB Probe Series (requires credentials)

- Default - Ericsson RX8200

- Default - Microsoft Platform (requires credentials)

#### New provisioning wizard [ID 38782]

When you click the *Provision* button, this will now open a wizard instead of immediately triggering the provision action. The wizard will show an overview of what will be provisioned, so you can first check this and make any necessary adjustments before you start the provisioning. The following things will be listed:

- **Missing connectors**: Devices that are assigned a CI Type, while the connector configured in the CI Type is not installed in the system. For these, you can click the *Open Catalog* button in the wizard to go to the Catalog page for the connector.

- **Unknown CI Types**: Devices that could not be assigned a CI Type during discovery.

- **CI Types with provisioning disabled**: CI Types for which the *Provisioning* setting (located under *Admin* > *Activities* > *Overview*) is disabled.

- **Ready to provision**: Devices that are ready to be provisioned.

## Changes

### Enhancements

#### Update to NuGet packages [ID 38480]

​IDP has been updated to use the *Skyline.DataMiner.Core.DataMinerSystem* and *Skyline.DataMiner.Core.InterAppCall* NuGet packages. In addition, a new NuGet (*Skyline.DataMiner.ConnectorAPI.IDP*) has been created for the inter-app communication between the scripts and connectors of IDP.

#### Generic Rack Layout Manager: New option to disable subscriptions [ID 38480]

In the Generic Rack Layout Manager element, you can now disable subscriptions with a new toggle button, in order to reduce the load on SLNet. When you disable subscriptions, changes to the element properties will not update the Rack Layout Manager.

#### Legacy dashboards replaced by new dashboards or removed [ID 38595]

In the rack utilization graph on the Overview page and on the Facilities page, the embedded bar chart is now based on the Dashboards app instead of the deprecated Reports & Dashboards module. In addition, the Software page no longer shows any dashboards or trend graphs.

#### Connectivity connector now only sends updates when there is data  [ID 38828]

To prevent the occurrence of many log entries similar to the example below in the IDP log file, the Skyline IDP Connectivity connector now only sends updates to the IDP app when there is data.

```txt
2024/02/19 16:36:52.131|SLManagedScripting.exe|ManagedInterop|INF|0|3|QA2098|Run|No elements available with connectivity enabled
```

#### Increased minimum DataMiner version [ID 38868]

The minimum DataMiner version for the IDP app has now been increased to DataMiner 10.3.0 [CU0].
