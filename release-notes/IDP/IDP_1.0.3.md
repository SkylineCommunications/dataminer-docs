---
uid: IDP_1.0.3
---

# IDP 1.0.3

## New features

#### Skyline IDP Discovery: Discovery Templates table \[ID_22228\]

A new table is now available in the IDP Discovery element, which lists the discovery templates with the protocol types using the templates. This information is also available in the IDP app, on the tab *Admin* > *Discovery*.

#### Possibility to remove managed elements \[ID_22235\]

It is now possible to remove a specific managed element from the *Managed Elements* table. The element will only be removed as a managed element within the IDP Solution, but will still be present on the DMA until it is deleted manually. This makes it possible to re-provision a device using IDP.

By default, this feature will not be enabled. To make the feature customizable for specific deployments of the Solution, a different script can be used to remove the managed element. On the *Admin* > *Settings* page of the IDP app, two new settings are available to configure the feature:

- *CI Removal Folder*: The folder containing the script that is used to remove the managed elements.
- *CI Removal Script*: The script used to remove the managed elements. If no script is selected, it will not be possible to remove managed elements.

## Changes

### Enhancements

#### Skyline IDP Discovery: Improved performance of discovery process \[ID_22323\]

The discovery process will now be performed more efficiently, even when a large IP address range has been selected.

#### Setup wizard: Support for DMAs using HTTPS \[ID_22231\]

In order to support HTTPS, when the IDP solution is set up, the provisioning API now binds by default to the hostname of the hosting server instead of to localhost. In addition, the IDP Discovery element, IDP app and Rack Layout Manager element are now configured from the setup wizard to use the same settings as the provisioning API, i.e. the URI, HTTP/HTTPS and port.

### Fixes

#### Run-time error caused by Skyline Generic Provisioning element \[ID_22258\]

In some cases, the Skyline Generic Provisioning element could cause a run-time error to be thrown.

#### IDP app: Unnecessary warning when navigating to Inventory \> Managed tab \[ID_22304\]

When you navigated to the *Inventory* > *Managed* tab of the IDP app, it could occur that an unnecessary warning "Error while getting script 'NAME/N/A'" was displayed.
