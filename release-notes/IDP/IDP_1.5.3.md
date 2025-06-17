---
uid: IDP_1.5.3
---

# IDP 1.5.3

## New features

#### New 'File Storage Behavior' setting for configuration backups [ID 42857]

On the *General* data page of the DataMiner IDP Configuration element, a new *File Storage Behavior* setting is now available, which determines when backups are stored in the configuration archive in case change detection is used. By default, all backup files will be stored in the configuration archive, but if this setting is set to *Only Store on Change*, backups will only be stored in the configuration archive when IDP detects a change.

This setting is only applicable when change detection is used. If change detection is not used, all backup files continue to be stored in the configuration archive.

#### Configuration Management: New column with change detection state per element [ID 43027]

On the *Configuration* > *Summary* tab of the IDP app, a new *Changes* column has now been added. This column represents the state of the change detection. It can contain the following values:

- **Unknown**: A backup exists, but change detection is not enabled.
- **No Change**: The latest backup has no changes compared to the previous one.
- **Changed**: The latest backup has changes compared to the previous one.

#### Provisioning of devices with unknown CI Type [ID 43095]

It is now possible to provision devices that have been discovered but for which no CI Type has been identified. To do so, on the *Inventory* > *Discovered* tab of the IDP app, select the discovered devices and click *Provision*, and then select the CI Types for the devices in the *Unknown CI Types* section.

![Unknown CI Types provisioning](~/release-notes/images/Unknown_CI_Types.png)

## Changes

### Enhancements

#### Configuration comparison now shown in new window [ID 43181]

On the *Configuration* > *Compare* tab of the IDP app, when you click the *Compare* button, the comparison page is now opened in a new window. Previously, the comparison was embedded within the app, but this could be inconvenient since the IDP visual overview does not support scaling.

### Fixes

#### Configuration Management subscript failed when changing value of password parameter [ID 43124]

When a subscript of the *IDP_ConfigurationMgmt* script tried to change the value of a password parameter, this would fail because the script could not verify the set of the password field. To resolve this issue, the *IDP_ConfigurationMgmt* script now calls the backup script with the *PerformChecks* property set to false.
