---
uid: IDP_1.0.1
---

# IDP 1.0.1

## New features

#### Skyline Infrastructure Discovery and Provisioning: Element provisioning can now be retried \[ID_21353\]

If the provisioning of an element failed for some reason, it is now possible to retry the provisioning.

#### Skyline IDP Discovery: AutoCreate option in provisioning templates \[ID_21355\]

A provisioning template can now contain the *AutoCreate* option. This option determines whether an element is created automatically if a device is discovered with the template. However, note that if the parameter *Auto Create Elements* of the IDP Discovery element is set to *Disabled*, automatic element creation will not occur, regardless of the *AutoCreate* configuration in the template files.

#### Skyline DataMiner Infrastructure Discovery and Provisioning: Total number of discovered elements \[ID_21372\]

On the overview page of the IDP app, the *Discovered Elements* KPI now displays the total number of rows in the *Discovered Elements* table.

#### Skyline IDP Discovery: Possibility to specify view name in discovery template \[ID_21402\]

In a provisioning template, you can now configure where a discovered element should be created by specifying the view name. If the view name does not exist yet, the view will be created in the root view. If the creation of the element fails, the created view will be kept. If the creation of the view fails, the element will be created in the root view instead.

For example:

```json
"View" : [22, 31],
"ViewName" : ["View Name 1", "View Name 2"]
```

#### Skyline IDP Discovery: Log in case template file could not be loaded \[ID_21439\]

When all discovery or provisioning templates are loaded at once, the Solution will now mention in a log entry if any of the files could not be loaded.

#### Skyline IDP Discovery: Serial device discovery supported \[ID_21492\]

The Skyline IDP Discovery protocol now supports the discovery of devices using a serial (UDP or TCP) connection.

#### IDP setup wizard: Improved view structure creation \[ID_21624\]

Up to now, the setup wizard created all views directly under the root view. Now the views *Applications*, *Devices* and *Infrastructure* will be created under the view *DataMiner infrastructure Discovery and Provisioning*.

#### Skyline Infrastructure Discovery and Provisioning: Enhanced Infrastructure tab \[ID_21638\]

Several minor improvements were implemented to the *Infrastructure* tab of the IDP app. Among others, a refresh button has been added for the *Devices* table.

#### IDP setup wizard: Activity Scheduler screen only displayed when relevant \[ID_21641\]

In the IDP setup wizard, the screen related to the Activity Scheduler is now only displayed when relevant, i.e. when a DataMiner version below 9.6.5 is used and an SRM license is detected. The default option selected in the screen is now *No*.

#### Skyline Infrastructure Discovery and Provisioning: New tab control style \[ID_21745\]

The IDP app now uses the new tab control style introduced in DataMiner 9.6.4. This style will only be applied if DataMiner 9.6.4 or higher is used.

## Fixes

#### IDP setup wizard: No SRM license detected upon first installation of IDP Solution \[ID_21430\]

When the IDP Solution was installed for the first time on a clean system, it could occur that it failed to detect the presence of an SRM license.

#### IDP setup wizard: Incorrect element names displayed during setup \[ID_21471\]\[ID_21662\]\[ID_21679\]

In the IDP setup wizard, it could occur that the displayed element names did not reflect the actual names of the IDP elements. Now the correct element names will be displayed.

#### IDP setup wizard: 'Parent Building View ID' and 'Obsolete Device View ID' not set to correct view IDs \[ID_21620\]

Previously, it could occur that the *Parent Building View ID* and *Obsolete Device View ID* parameters of the Rack Layout Manager element were not set to the correct view ID during the initial setup of the IDP Solution.

#### Skyline Infrastructure Discovery and Provisioning: 'Rack Usage per Location' dashboard not displayed correctly \[ID_21628\]

On the *Infrastructure* tab of the IDP app, up to now the *Rack Usage per Location* dashboard referred to a fixed element, so that it was not always displayed correctly. Now the setup wizard will make sure the dashboard is correctly linked to the current Rack Layout Manager element.

#### Generic Rack Layout Manager: Fixes to default behavior when (un)assigning a device to a rack \[ID_21694\]

The default behavior when a device is assigned or unassigned to a rack has been improved. Several fixes have been implemented, so that when an element is assigned, it now becomes visible in the designated rack and in the *Visibility* column of the *DataMiner Devices* table of the Rack Layout Manager. In addition, when an element is unassigned, it is removed from the rack view, but remains part of the obsolete view if no other view is assigned.
