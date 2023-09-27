---
uid: IDP_1.1.19
---

# IDP 1.1.19

## New features

#### New 'Include Managed' toggle button for discovered connections \[ID_32355\]

When you view the details for a discovered element, via the *Show details* button on the *Connectivity* > *Discovered* tab, a new *Include Managed* toggle button is now available. This button determines whether discovered connections that are already provisioned by IDP are displayed or not. If the button is disabled, only unmanaged connections are displayed.

#### Improved discovery and manage scan range wizards \[ID_32577\]

Previously, when you started a discovery action or managed scan ranges, the same wizard was displayed. Now a different wizard will be displayed so that fewer steps are required to perform these actions.

- When you start a custom discovery from the *Inventory* > *Discovered* tab, the *run discovery* wizard will allow you to configure and run a custom discovery. In a second screen, it will allow you to save the configuration for future use.
- When you manage a scan range from the *Admin* > *Discovery* > *Scan Ranges* page, the *manage scan range* wizard will allow you to create new scan ranges or edit existing ones to simplify future discovery processes.

In both cases, an "Include" scan range is now automatically displayed, so that you can immediately start specifying the IP address range. In addition, when the discovery or scan range is based on a discovery profile, the out-of-the-box discovery profile SNMP_MIB_II is now selected by default.

## Changes

### Enhancements

#### Pop-up window with information in case compliancy check is not possible \[ID_32150\]

When you select one or more elements on the *Software* tab and click *Check compliancy*, now a pop-up window will be displayed with detailed information in case the compliancy check is not possible for all the selected elements. This will make it easier to track down what needs to be done to enable the compliancy check.

#### Aisle visual overviews now show rack names \[ID_32158\]

Aisle visual overviews will now show the name of each rack below the visualization of the rack.

#### Improved InterApp call response error messages \[ID_32167\]

To improve response error messages for InterApp calls, the same type of error messages will now be passed as were previously used in the deprecated HTTP Provisioning API.

#### Leaving Provisioning Details screen in CI Type Management wizard no longer possible with missing SNMPv1 and SNMPv2 credentials \[ID_32198\]

When you edit a CI Type in the CI Type Management wizard, it will now no longer be possible to leave the *Provisioning Details* screen if the credentials for SNMPv1 and SNMPv2 are not filled in.

#### Automatically Update Views setting removed from Admin \> Facilities \> View Settings page \[ID_32274\]

Up to now, on the *Admin* > *Facilities* > *View Settings* page, it was possible to select whether the Rack Layout Manager managed views based on element properties, using the *Automatically Update Views* setting. However, as this setting has never been used and users always applied the default behavior, it has now been removed. The Rack Layout Manager will therefore always manage views based on element properties now. With this change, a small performance improvement has also been implemented.

#### Front and back view of racks now displayed on separate tabs instead of with toggle button \[ID_32331\]

Up to now, to switch between the front and back view of the racks on an aisle visual overview, you needed to use a toggle button. To improve consistency throughout IDP, now the front and back view of the racks will be displayed on separate tabs instead.

#### Improved Help link \[ID_32634\]

The Help link in the IDP app now links to a URL that will always redirect to the latest version of the IDP help.

### Fixes

#### Connected DMAs not available in IDP app when DMA in cluster was disconnected \[ID_32155\]

When IDP was used in a DMS consisting of multiple DMAs, and one or more of the DMAs were disconnected, none of the DMAs were available in the app. Now, all connected DMAs in the cluster will always be listed. This affects the following features:

- The drop-down box to select a DMA in the *Discovered Elements* table on the *Inventory* > *Discovered* tab.
- The working directories table on the *Admin* > *Configuration* tab.
- The drop-down box to select the Fallback Agent, available via the *Admin* > *Provisioning* tab.

#### Rack not displayed correctly with Skyline Black theme \[ID_32156\]

When the Skyline Black theme was used, it could occur that racks in an aisle or rack view were not displayed correctly.

#### Not possible to use \[DNSName\] keyword for IP address/host in provisioning element details of CI Type Management wizard \[ID_32193\]

In the CI Type Management wizard, it could occur that it was not possible to use the keyword \[DNSName\] for the IP address/host in the element details for provisioning.

#### Not possible to add unmanaged elements to the managed inventory with CMDB component with non-default element name \[ID_32216\]

Up to now, if the element name of the CMDB component was something other than the default name "DataMiner IDP CI Types", it was not possible to add unmanaged elements to the managed inventory.

#### IDP elements in timeout after upgrade to version 1.1.18 \[ID_32267\]

After the upgrade to IDP 1.1.18, it could occur that the IDP component elements were incorrectly considered to be in timeout.

#### Incorrect error message when backup file extension was not supported for visualization \[ID_32297\]

When IDP could not visualize a backup file because its extension was not supported for visualization, the error message that informed the user where visualizations can be added showed outdated information, directing the user to *Admin* > *Configuration* > *Visualization* instead of the correct path *Admin* > *Configuration* > *Backup*.

#### IDP Setup wizard attempted to set parameter that no longer exists \[ID_32299\]

The IDP Setup wizard still attempted to set parameter 5023 of the Generic Rack Layout Manager connector, even though this parameter was removed when the Provisioning API became deprecated.

#### Elements removed from Connectivity tabs when CI Type was edited \[ID_32304\]

When the activity *Connectivity Discovery* is enabled for an element, that element is displayed in the tabs *Connectivity* > *Managed* and *Connectivity* > *Discovered*. However, when the CI Type was edited, it could occur that elements were no longer displayed in these tabs. This could happen even if no changes were implemented to the CI Type and it was merely saved again.

#### Provisioning request failed if invalid DMA ID was configured in CI Type \[ID_32363\]

Up to now, if IDP could not resolve the DMA during a provisioning request because the DMA ID configured in the CI Type was invalid, it could occur that the request failed instead of falling back to the Fallback Agent.

#### Provision DCF button did not provision all connections \[ID_32383\]

Up to now, the *Provision DCF* button on the *Connectivity* > *Discovered* tab only provisioned the connections for which the selected element was the source, but not the connections for which the selected element was the destination. Now it will provision all discovered connections for the selected element.

#### \[DNSName\] keyword not resolved during provisioning \[ID_32467\]

In some cases, it could occur that the *\[DNSName\]* keyword was not resolved during element provisioning.

#### IS-04 service definitions not correctly imported during IDP installation \[ID_32472\]

When IDP was installed, it could occur that IS-04 service definitions were not imported correctly. This caused the following information event to be generated:

```txt
Invalid Service Definition IDP IS-04 Provision New Nodes because there's no Profile Instance ID efb4e671-1ebc-413b-9f6c-2534f9028f97 (Script 'SRM_ServiceDefinitionImportExport')
```

#### Problem with communication between IDP components because of failed InterApp calls \[ID_32485\]

In some cases, it could occur that InterApp calls from the Class Library Project (CLP) failed, which made it impossible for the different IDP components to communicate properly with each other.
