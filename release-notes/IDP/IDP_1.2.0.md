---
uid: IDP_1.2.0
---

# IDP 1.2.0

## New features

#### Discovery by profile with existing CI Types that are not linked to it \[ID_33051\]

Previously, to do a discovery by profile, either there had to be no CI Types in the system, or the discovery profile had to be linked to at least one CI Type. Now it is possible to do a discovery by profile even if there are no CI Types using the discovery profile:

- If there are no CI Types available in the system, IDP will try to discover and report unknown devices.
- If there some CI Types, and some CI Types are linked to the discovery profile, IDP will try to discover and report the matched CI Type or unknown devices.
- If there are some CI Types and no CI Types are linked to the discovery profile, IDP will try to discover and report unknown devices.

#### Discovery profiles export \[ID_33075\]

Up to now, discovery profiles could only be loaded from a JSON file. The only way to change a discovery profile was to change the file and load it again. To create a new discovery profile, users had to start from one of the default profiles.

Now it is possible to export discovery profiles as a JSON file. You can use this to move discovery profiles from one DMA to another, or to create different starting points for new discovery profiles.

This feature is available on the page *Admin* > *Discovery* > *Discovery Profiles*, with the following buttons:

- *Export*: Allows you to export the selected profile from the table.
- *Export all*: Exports all profiles displayed in the table.

The import functionality on this same page was also adjusted so that users can now change the directory to import the discovery profiles from. Exported files will be placed in this same directory.

## Changes

### Enhancements

#### Provisioning API no longer supported \[ID_32719\]

The Provisioning API, which was already deprecated in earlier IDP versions, is now no longer supported. Consequently, in the setup wizard, the *Extra Configurations* step will no longer contain any settings related to the Provisioning API. In addition, no more information about this API is available via the *About* tab of the IDP app.

#### Notification in case of configuration backup/update while configuration archive is disconnected \[ID_33112\]

Up to now, if the configuration archive's credentials were not correctly configured, IDP failed to execute configuration backups and updates without warning the user.

Now the user will be notified in case they attempt to perform any of these operations while the configuration archive is disconnected.

For a configuration backup, the following message will be displayed:

```txt
Configuration Backup failed. Configuration Archive is disconnected.
```

For a configuration update, the following message will be displayed:

```txt
Configuration Update failed. Configuration Archive is disconnected.
```

#### Range \[0.0.0.0, 0.255.255.255\] no longer allowed for custom discoveries \[ID_33194\]

When you create or edit a custom discovery range, it will now no longer be possible to include IP addresses from within the \[0.0.0.0, 0.255.255.255\] range, as these should never be used.

#### Default behavior for activities now automatically enabled initially \[ID_33211\]

Previously, all activities under *Admin* > *Activities* > *Default Behavior* were by default set to *Manual* initially, so that users had to enable each activity manually to start using IDP's functionalities. To improve ease of use, the default behavior for the activities will now initially be set to *Automatic* instead.

> [!NOTE]
> This change will also be implemented when you upgrade an existing IDP setup to the current version: all settings under *Admin* > *Activities* > *Default Behavior* that have not been modified yet will be set to *Automatic*. If you do not want to have some activities enabled by default, please review your default behavior settings after upgrading.

#### Rack Assignment Script improvements \[ID_33217\]

A number of improvements were implemented in the Rack Assignment Script:

- The *Slot Occupancy* label has been renamed to *Rack Position*.
- The *Rack Size* label has been renamed to *Slot Size*.
- When an element has already been assigned to a rack, the information for the different levels is filled in automatically.

#### SSL/TLS feature availability no longer depends on DataMiner version \[ID_33240\]

As the minimum DataMiner version to be used with DataMiner IDP has increased to 10.1.0 CU10, the DataMiner version will no longer be checked to make the SSL/TLS feature available. Instead this feature will now always be available.

#### IDP setup wizard no longer configures ports \[ID_33823\]

Up to now, during initial setup, the IDP setup wizard still configured the ports that had been needed for some of the IDP elements in previous IDP versions. However, as these ports are no longer needed, these will now no longer be configured by the wizard.

### Fixes

#### Automatically Remove Empty Views setting no longer causes views to be recreated \[ID_32991\]

Previously, if the *Automatically Remove Empty Views* setting was enabled on the *Settings* data page of the DataMiner IDP Rack Layout Manager element, when this element was restarted, views that were not empty were removed and then created again. Now only the empty views will be removed after a restart. Note that this parameter is disabled by default.

> [!NOTE]
> This parameter is not available in the IDP app itself. Such parameters are not officially supported. These can be features that have been disabled until they are fully implemented or auxiliary parameters and tables used by DataMiner IDP in the background. Using such parameters without official support can cause system instability and is not advised. If you do wish to use such a feature, please make a [feature request](https://community.dataminer.services/feature-suggestions), and we will evaluate where we can fit this on the roadmap for DataMiner IDP. However, we cannot guarantee that the request will be implemented immediately or exactly as suggested.

#### RLM not loading correct info in system under heavy load \[ID_33058\]

In case a system was under a heavy load, it could occur that RLM could not load the correct information because DataMiner could not update properties quickly enough.

#### Problem transferring files when short path could not be derived from long path \[ID_33284\]

When the Windows server did not support the long path character \\\\?\\\\, it was not possible to derive the short path from the long path, which could cause issues when configuration files were transferred.

#### Issues with IS-04 service definitions \[ID_33523\]

A number of issues could occur with the service definitions *IS-04 Provision New Nodes* and *IS-04 Update Existing Nodes*:

- The *Token* node contained a duplicate property *StartEventType*.
- The LSO script was not correctly set to *SRM_LSO_IS04ProcessAutomation* for the actions START, STOP and STANDBY.
- Because the service property *Operation* was not set to *New* or *Update*, the LSO script could not identify for which process it was triggered and inform the AMWA IS-04 connector correctly.
- The process creation using *IS-04 Provision New Nodes* could fail because the profile parameters *IP Address* and *Port* of the profile definition *IP* were set to mandatory instead of optional. This caused the following exceptions:

    ```txt
    Script Failure (IDP_ProcessAutomationWizard): EXIT: "(Code: 0x80131500) Skyline.DataMiner.Automation.ScriptAbortException: failed creating new booking: Skyline.DataMiner.Library.Exceptions.ResourceManagerException: Parameter IP Address in Function Convert To Scan Range is mandatory must have a value assigned
    ```

    ```txt
    Script Failure (IDP_ProcessAutomationWizard): EXIT: "(Code: 0x80131500) Skyline.DataMiner.Automation.ScriptAbortException: failed creating new booking: Skyline.DataMiner.Library.Exceptions.ResourceManagerException: Parameter Port in Function Convert To Scan Range is mandatory must have a value assigned
    ```

#### Discovery activity token stuck in case no results are found \[ID_33755\]

When a discovery activity had 0 results, it could occur that the token for the activity was stuck in the queue. To prevent this, a message will now be sent back to the Process Automation framework to indicate that the discovery activity is ready to process the next token.

#### Last Provisioning Time column displays local time again \[ID_33760\]

After the switch to InterApp calls for inter-element communication, the *Last Provisioning Time* column in the *Discovered Elements* table (on the *Inventory* > *Discovered* page of the IDP app) showed UTC time instead of the local time of the server.

#### Null reference exception in case repeat gateway was missing \[ID_33824\]

When no repeat gateway was present in the system, it could occur that a null reference exception was thrown. This will now be prevented.

#### Setup wizard failed in case no resource pools were present \[ID_33825\]

If the setup wizard could not find any resource pools, it could occur that a null reference exception was thrown, causing the setup to fail.
