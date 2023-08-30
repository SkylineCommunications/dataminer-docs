---
uid: CI_Types
---

# CI Types

The *CI Types* subtab of the *Admin* tab consists of several pages with overview tables. At the top of the pages, buttons are available:

- **New**: Available on each of the pages. Starts a wizard that allow you to add a new CI Type. You will need to specify the CI Type name and can optionally configure discovery actions, provisioning, etc. for the CI Type.

- **Duplicate**: Available on each of the pages if a CI Type is selected in the table.

- **Import**: Only available on the *Overview* page. Opens a pop-up window where you can specify the file path and file name of a CI Type in order to import it.

- **Export**: Only available on the *Overview* page. Allows you to export the CI Type configuration for the selected entry in the table.

- **Export all**: Only available on the *Overview* page. Allows you to export the configuration of all CI Types.

  > [!NOTE]
  > By default, CI Types are exported to the folder `C:\Skyline DataMiner\Documents\Skyline IDP CMDB\CI Types`.

- **Generate**: Only available on the *Overview* page. Starts a wizard that allows you to generate CI Types for the production protocols in the system. You can select to generate CI Types for all protocols, for all protocols that do not have a CI Type yet, or for a custom selection of protocols.

  > [!NOTE]
  >
  > - The wizard also allows you to select "None", so that you can easily clear the selection of all listed protocols in order to make a custom selection afterwards.
  > - By default, CI Types generated based on a protocol with an SNMPv3 connection have SNMPv2 port settings configured on that connection, as there is no way to automatically find out the security levels, algorithms and passwords.

  > [!TIP]
  > You can for instance use the *Generate* option to have existing DataMiner elements managed by IDP. You will then need to [correctly configure the CI Type](xref:CI_Types#using-the-ci-type-management-wizard), [enable the necessary activities](xref:Admin_activities) for the CI Type, and [add the element to the managed elements](xref:IDP_Inventory_tab#unmanaged).

On each of the pages, different settings are available. These are explained in the sections below.

## Overview page

This page contains an overview of all CI Types in the IDP app.

For each CI Type, an *Edit* button is available in this table. It opens the CI Type Management wizard. See [Using the CI Type Management wizard](#using-the-ci-type-management-wizard).

## Discovery page

This page contains an overview of discovery details for CI Types, with the following columns:

- **CI Type**: Contains the names of the CI Types.

- **Discovery**: Determines whether the Discovery activity is enabled or not.

- **Completeness**: Indicates whether mandatory fields are filled in. If there is a discovery condition, this is set to 100%.

- **Identifiers**: Contains a textual representation of the discovery identifiers and the conditions that should be used when a device is discovered. These can be configured via the *Advanced* button.

- **Advanced**: Contains a button that can be used to launch the CI Type Management wizard for the relevant CI Type. See [Discovery configuration](#discovery-configuration).

## Provisioning page

This page contains an overview of provisioning details for CI Types, with the following columns:

- **CI Type**: Contains the names of the CI Types.

- **Create**: Determines whether the Provisioning activity is enabled or not.

- **Completeness**: Indicates the percentage of mandatory fields that are filled in for the provisioning configuration. The mandatory fields are *Element Name*, *Initial Protocol* and *Initial Protocol Version*.

- **Element Name**: The name of the provisioned element. This name cannot be modified here.

- **Description**: The description of the provisioned element.

- **DMA**: The DMA where the element should be created. You can select any of the DMAs in the DMS, or select *Based on device address* to have a DMA assigned based on the discovered IP address (see [Provisioning](xref:Provisioning)).

- **Default Element State**: Allows you to set the state the provisioned element will have when it is created, i.e. *Active*, *Paused* or *Stopped*.

- **Initial Protocol**: The protocol that should be used for the provisioned element.

- **Initial Protocol Version**: The protocol version that should be used for the provisioned element.

- **Initial Alarm Template**: The alarm template that should be used for the provisioned element. This field can be left empty.

- **Initial Trend Template**: The trend template that should be used for the provisioned element. This field can be left empty.

- **Initial Views**: The view or views the provisioned element should be placed in. These can be configured via the *Advanced* button.

- **Update Property Script**: The Automation script that should be used to update the properties of the element once it has been created. You can select any of the scripts from the folder configured with the *CI Update Property Script* *Folder* setting on the *Admin* > *Settings* page.

- **Password Setup**: Displays the number of steps configured for the password setup (configurable via the *Advanced* button).

- **Advanced**: Contains a button that launches a wizard where you can configure the provisioning details for the CI Type. This includes advanced settings that are not available in the table. See [Provisioning configuration](#provisioning-configuration).

## Connectivity page

This page contains an overview of connectivity details for CI Types, with the following columns:

- **CI Type**: Contains the names of the CI Types.

- **Connectivity Discovery**: Determines whether the Connectivity Discovery activity is enabled or not.

- **Completeness Connectivity Discovery**: Indicates how complete the connectivity discovery configuration is for the CI Type. Enabling connectivity discovery on the *Processes* > *Automation* page is only possible if this indicates 100%.

- **Connectivity Discovery Script**: Allows you to select the script that will be used to discover connectivity for this CI Type. You can select any of the scripts from the folder configured with the *Connectivity Discovery Script* *Folder* setting on the *Admin* > *Settings* page.

- **Advanced**: Contains a button that launches a wizard where you can configure the connectivity discovery details for the CI Type. See [Connectivity configuration](#connectivity-configuration).

## Configuration Management page

This page contains an overview of configuration management details for CI Types, with the following columns:

- **CI Type**: Contains the names of the CI Types.

- **Backup**: Determines whether the Take Backup activity is enabled or not.

- **Backup Script**: Allows you to select the script that will be used to take a configuration backup of this CI Type. You can select any of the scripts from the folder configured with the *Backup Script* *Folder* setting on the *Admin* > *Settings* page.

- **Checksum Parameter**: Used in order to enable the triggering of alarms in case of configuration changes. Contains the current checksum value that the alarm baseline is compared with. A difference between this parameter and the baseline value will cause an alarm to be generated with the severity configured in the element alarm template.

- **Set Checksum in Alarm Template**: Used in order to enable the triggering of alarms in case of configuration changes. If this parameter is enabled and a configuration change is detected, *Checksum Parameter* is updated with the current checksum value, and the previous value is set as the alarm baseline value. If this parameter or *Take Backup* (via *Processes* > *Automation*) are disabled, the value 0 will be set to both *Checksum Parameter* and the alarm baseline.

- **Completeness Update**: Indicates the percentage of mandatory fields that are filled in with regard to the configuration update.

- **Configuration Update**: Determines whether the Configuration Update activity is enabled or not.

- **Update Script**: Allows you to select the script that will be used to do a configuration update for this CI Type. You can select any of the scripts from the folder configured with the *Configuration Management* > *Update Script Folder* setting on the *Admin* > *Settings* page.

- **Default Script**: Available from IDP 1.1.18 onwards. Allows you to select the script that will be used to restore the default configuration for this CI Type. You can select any of the scripts from the folder configured with the *Configuration Management* > *Default Script Folder* setting on the *Admin* > *Settings* page.

- **Default Location**: (Called "Default Update File" prior to IDP 1.1.18.) The configuration file that can be used by the update script. Depending on the script configuration, this field may not be required.

- **Advanced**: Contains a button that launches a wizard where you can specify all the Configuration Management settings for the CI Type. See [Configuration management configuration](#configuration-management-configuration).

## Software Management page

This page contains an overview of software management details for CI Types, with the following columns:

- **CI Type**: Contains the names of the CI Types.

- **Update**: Determines whether the Software Update activity is enabled or not.

- **Completeness Update**: Indicates the percentage of mandatory fields that are filled in for the software update configuration. Enabling software updates on the *Processes* > *Automation* page is only possible if this field indicates 100%.

- **Update Script Name**: Allows you to select the script that will be used to set a software configuration on the CI Type. You can select any of the scripts from the folder configured with the *Update Script* *Folder* setting on the *Admin* > *Settings* page.

- **Update Image File Location**: Allows you to specify the network path or URL to the configuration files that may be used in the script. If these are not required, set this field to *None*.

- **Compliance Check**: Determines whether the Software Compliancy activity is enabled or not.

- **Completeness Compliance**: Indicates the percentage of mandatory fields that are filled in for the software compliance configuration. Enabling software compliancy on the *Processes* > *Automation* page is only possible if this field indicates 100%.

- **Version Baseline**: Allows you to specify the software version that is considered compliant.

- **Version Parameter**: Displays the parameter name of the element where the software version is checked. This can be configured via the *Advanced* button.

- **Set Baseline in Alarm Template**: This option allows you to have an alarm generated if a managed element runs a different software version than expected. For this purpose, both this option and *Software Compliancy* must be enabled and the *Version Baseline* and *Version Parameter Name* must be specified (via the *Advanced* page button). In the alarm template for the managed element, dynamic alarm thresholds should be assigned. You can do so by adding an asterisk ("\*") at the alarm threshold level for the desired alarm severity. See [Configuring dynamic alarm thresholds](xref:Configuring_dynamic_alarm_thresholds).

- **Advanced**: Contains a button that launches a wizard where you can specify the software update script and image file location, as well as the compliancy version and the compliancy version parameter. See [Software image management configuration](#software-image-management-configuration).

## Facilities page

This page contains an overview of facilities configuration details for CI Types, with the following columns:

- **CI Type**: Contains the names of the CI Types.

- **Rack Assignment**: Determines whether the Rack Assignment activity is enabled or not.

- **Completeness Rack Assignment**: Indicates how complete the rack assignment configuration is for the CI Type. Enabling automatic rack assignment on the *Processes* > *Automation* page is only possible if this indicates 100%.

- **Rack Assignment Script**: Allows you to select the script that should be used for automatic rack assignment. You can select any of the scripts from the folder configured with the *Rack Assignment Script* *Folder* setting on the *Admin* > *Settings* page.

- **Advanced**: Contains a button that launches a wizard where you can specify the rack assignment settings for the CI Type. See [Facilities configuration](#facilities-configuration).

## Activity Management page

From IDP 1.1.20 onwards, this page is no longer available. The functionality that was previously available here is now available on the *Admin* > *Activities* > *Default Behavior* page. See [Default behavior](xref:Admin_activities#default-behavior)

## Using the CI Type Management wizard

On the *CI Types* subtab of the *Admin* tab, several buttons provide access to the CI Type Management wizard. In this wizard, you can configure the CI Type for discovery, provisioning, connectivity, configuration management, software image management and facilities.

The first window of the wizard contains *Configure* buttons for each of these. Depending on where you access the wizard from, this window may not be displayed.

In the first window, you can also delete the CI Type with the *Delete* button, but only if no elements are currently assigned to it.

To save changes to the configuration, use the *Save* button. To do so, you may first need to click *Previous* in order to return to the first window of the wizard.

### Discovery configuration

The discovery configuration window of the CI Type Management wizard allows you to edit the current discovery identifiers and add new discovery identifiers:

- **Current Discovery Identifiers**: This section displays the currently configured identifiers. If an identifier and discovery profile match the specified value according to the selected match operator, the CI Type will be used for a device. To edit the current identifiers, you can select a different operator in the *Match* box and/or specify a different value.

- **Conditions**: If only one identifier is configured, the *Conditions* box should simply contain "1". If there are more identifiers, there must be a number for each of them, and they must be combined with logical operators (*not*, *and*, or *or*). For example: "1 and 2".

- **Add New Discovery Identifiers**: To add a new discovery identifier, first select the type, then click the triangle button to expand the configuration section for the identifier. Alternatively, you can immediately click the triangle button to see all possible types. Click "+" next to the type you want to add. Then select a *Match* operator and specify the value that should be used to detect if the CI Type should be used.

### Provisioning configuration

The provisioning configuration window of the CI Type Management wizard contains the following settings:

- **Element Name**: The name of the provisioned element. Placeholders are supported in this name. See [Using keywords or placeholders](xref:CI_Types1#using-keywords-or-placeholders).

- **Description**: The description of the provisioned element. Placeholders are supported in this description. See [Using keywords or placeholders](xref:CI_Types1#using-keywords-or-placeholders).

- **DMA**: The DMA where the element should be created. You can select any of the DMAs in the DMS, or select *Based on device address* to have a DMA assigned based on the discovered IP address (see [Provisioning](xref:Provisioning)).

- **Element Details**: Click the *Details* button to specify the protocol that should be used for the provisioned element, the protocol version, the alarm and trend template, connection settings, and other details that would otherwise be available during element creation. See [Adding elements](xref:Adding_elements).

- **Password Setup**: Click the *Setup* button to specify any parameters required for authentication along with their values.

- **Views**: Click the *Views* button to go to a window where you can configure the views the provisioned element should be added to.

  - At the top of the window, you can add existing views. To do so, click the triangle button and then click "+" next to each view you want to add.

  - Below this, you can add new views. To do so, specify the view name and click the "+" button for each view you want to add.

  - The views to which the provisioned element will be added are listed under *Selected views*. Click the X next to a view to remove it from the list.

- **Properties**: Click the *Properties* button to go to a window where you can manage the properties of the provisioned elements.

  - In the *Properties* section at the top, you can manage the properties that IDP adds to the system. The units and ranges of the properties are displayed where relevant. Any properties that should not be changed by the user are hidden in the wizard.

  - Below this, all element properties related to rack and facility management are grouped in the *Configure Facility Details* section, which is collapsed by default.

  - At the bottom of the window, the *Other Properties* section allows you to add other properties and specify a value for them. These can be both existing or new properties. If a new property is added, it is created in the DMS as soon as an element for the CI Type is created.

- **Update Property Script**: The Automation script that should be used to update the properties of the element once it has been created. You can select any of the scripts from the folder configured with the *CI Update Property Script* *Folder* setting on the *Admin* > *Settings* page.

### Connectivity configuration

In the connectivity configuration window, you can select the script that will be used to discover connectivity for this CI Type. You can select any of the scripts from the folder configured with the *Connectivity Discovery Script* *Folder* setting on the *Admin* > *Settings* page.

### Configuration management configuration

The configuration management configuration window of the CI Type Management wizard contains the following settings in the **Backup** section:

- **Script**: The script that will be used to take a configuration backup of the CI Type. You can select any of the scripts from the folder configured with the *Backup Script* *Folder* setting on the *Admin* > *Settings* page.

- **Checksum parameter**: Used in order to enable the triggering of alarms in case of configuration changes. Contains the current checksum value that the alarm baseline is compared with. A difference between this parameter and the baseline value will cause an alarm to be generated with the severity configured in the element alarm template.

- **Set Checksum in Alarm Template**: Used to enable the triggering of alarms in case of configuration changes. If this parameter is enabled and a configuration change is detected, *Checksum Parameter* is updated with the current checksum value, and the previous value is set as the alarm baseline value. If this parameter or *Take Backup* (via *Processes* > *Automation*) are disabled, the value 0 will be set to both *Checksum Parameter* and the alarm baseline.

In the **Update** section, the following settings are available:

- **Script**: The script that will be used to do a configuration update for this CI Type. You can select any of the scripts from the folder configured with the *Default Script* *Folder* setting on the *Admin* > *Settings* page.

- **Default Update File**: The configuration file that can be used by the update script. Depending on the script configuration, this field may not be required.

### Software image management configuration

The software image configuration window of the CI Type Management wizard contains the following settings:

- **Script**: The script that will be used to set a software configuration on the CI Type. You can select any of the scripts from the folder configured with the *Update Script* *Folder* setting on the *Admin* > *Settings* page.

- **Image File Location**: The network path or URL to the configuration files that may be used in the script.

- **Version**: The software version that is considered compliant

- **Version parameter**: The parameter name of the element where the software version is checked.

- **Set Baseline in Alarm Template**: This option allows you to have an alarm generated if a managed element runs a different software version than expected. For this purpose, both this option and *Software Compliancy* must be enabled and the *Version Baseline* and *Version Parameter Name* must be specified. In the alarm template for the managed element, dynamic alarm thresholds should be assigned. You can do so by adding an asterisk ("\*") at the alarm threshold level for the desired alarm severity. See [Configuring dynamic alarm thresholds](xref:Configuring_dynamic_alarm_thresholds).

### Facilities configuration

In the facilities configuration window, you can select the script that should be used for automatic rack assignment. You can select any of the scripts from the folder configured with the *Rack Assignment Script* *Folder* setting on the *Admin* > *Settings* page.
