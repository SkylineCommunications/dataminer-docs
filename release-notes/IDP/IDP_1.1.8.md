---
uid: IDP_1.1.8
---

# IDP 1.1.8

## New features

#### New DNS Lookup option \[ID_25830\]

In the IDP app, a new option is available that determines if IP addresses of discovered elements are resolved to the corresponding names. You can find this new *DNS Lookup* option by going to *Admin* > *Discovery* > *Settings*. If this parameter is enabled and a discovery is run, the name corresponding with the IP address will be displayed in the *Name* column of the *Discovered Elements* table. If *DNS Lookup* is disabled, this column will not be displayed.

#### Discovery by discovery profile \[ID_25860\]\[ID_25877\]

While previously, discovery of devices was only possible by CI type, now discovery by discovery profile is also supported. In that case, the discovery process is started based on a set of discovery actions, instead of a set of CI types. This can for instance be useful to discover devices that can easily be identified by their SNMP system description or via a common HTTP or serial command. When a discovery is done by discovery profile, IDP will try to match the discovery actions against all existing CI types in order to identify a device.

When you edit a scan range, you can now select whether discovery should happen by CI type or by discovery profile. In addition, you can also select whether a ping command should be sent before the discovery.

A number of changes have been implemented on the page *Admin* > *Discovery* > *Scan Ranges* to support this. The *Discovery Address Range* table, which lists scan ranges for discovery, now also displays whether a scan range is discovered by CI type or by discovery profile, and whether *Ping First* is enabled. Changing these settings is not possible in the table itself, but can be done via a wizard that you can open by clicking the *Edit* button above the table. Any existing scan ranges from before this change will be set to be discovered by CI type, with *Ping First* disabled.

When a scan range is selected in the *Discovery Address Range* table, at the bottom of the page, a table now also shows either the CI type or the discovery profile of the selected scan range.

#### Buttons to navigate to managed element \[ID_26057\]

On the *Inventory* > *Managed* tab of the IDP app, when you select an element in the *Managed Elements* table, an *Open* button now becomes available, which you can use to navigate to the card of the managed element.

#### New button to display device responses during discovery \[ID_26101\]

The *Inventory* > *Discovered* page of the IDP app now contains a *Show Response* button. If you select a row in the *Discovered Elements* table and click the button, the app will show the responses returned by the selected device during discovery.

#### New Identify All Matching CI Types setting \[ID_26105\]

A new setting, *Identify All Matching CI Types*, is now available on the *Inventory* > *Discovered* and *Admin* > *Discovery* > *Settings* pages in the IDP app. If this setting is enabled, the discovery process will try to match all possible CI types configured in the scan range. If the setting is disabled, the process will stop trying to match a device with other CI types once a CI type has been identified for it. By default, the setting is disabled.

#### Ping discovery \[ID_26140\]

The IDP Solution now supports ping discoveries. To do a ping discovery, you must run the discovery by discovery profile, using the *Ping* discovery profile.

Devices discovered using a ping discovery will only be displayed if the option *Identify Unknown Devices* is enabled, as these devices will by default be listed as *Unknown*.

#### Buttons to import and export CI types \[ID_26192\]

A number of buttons have been added in the IDP app on the page *Admin* > *CI Types* > *Overview*:

- *Import*: Opens a pop-up window where you can specify the file path and file name of a CI type in order to import it.
- *Export*: Allows you to export the CI type configuration for the selected entry.
- *Export all*: Allows you to export the configuration of all CI types.

## Changes

### Enhancements

#### IDP app layout improved \[ID_26151\]

The layout of the IDP app has been improved. Buttons are now displayed as an icon with a label next to it. In addition, if a button is not available, it is now grayed out instead of hidden.

### Fixes

#### Skyline IDP Discovery: Exception caused by QAction 5001 \[ID_25832\]

In some cases, QAction 5001 of the *Skyline IDP Discovery* driver could cause an exception to be thrown.

#### Pending Elements table empty if element without Created property exists \[ID_26017\]

If there was an element that did not have the *Created* property, it could occur that no information was displayed in the *Pending Elements* table.

The table will now be filled in in such a case, and in the *Creation Time* column for such an element, "N/A" will be displayed.

#### Incorrect status displayed after failed automatic provisioning \[ID_26028\]

When automatic provisioning of a device failed, it could occur that the provisioned status in the *Discovered Elements* table was incorrect.

#### Not possible to import HTTP or HTTPS discovery profiles \[ID_26120\]

In some cases, it could occur that HTTP or HTTPS discovery profiles could not be imported.
