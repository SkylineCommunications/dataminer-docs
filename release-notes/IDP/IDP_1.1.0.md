---
uid: IDP_1.1.0
---

# IDP 1.1.0

## New features

#### New DataMiner IDP CI Types element \[ID_22309\]\[ID_22548\]

The IDP setup wizard now creates the element *DataMiner IDP CI Types*, using the production version of the protocol *Skyline IDP CMDB*. This element manages the CI types, previously referred to as provisioning templates. By default, the element is created in the view *APPLICATIONS*. In case the element already exists, it will not be created by the setup wizard.

All information regarding CI types is now kept in this new element. As such, the IDP Discovery element now no longer keeps any information about CI types, and the script to manage scan ranges links to the *DataMiner IDP CI Types* element instead of the *DataMiner IDP Discovery* element.

#### Discovery profiles list in the IDP app \[ID_22335\]\[ID_22345\]\[ID_22436\]

In the IDP app, on the tab *Admin* > *Discovery*, a list of discovery profiles is now displayed.

When you select a discovery profile in the list, the credentials used in the profile and the discovery actions for the profile will be displayed below the list.

In addition, in this tab you can load a particular discovery profile or load all discovery profiles at once. To do so, first click the upload icon next to the title of the *Discovery Profiles* table. Below the table, a dedicated section then becomes available where you can load the profiles.

#### Element software updates \[ID_22457\]

It is now possible to perform a software update on an element via the *Software* tab of the IDP app. To do so, select the element in the table on the *Software* tab and click the button below the table. The button will launch a script linked to the CI Types element. For this purpose, the CI type must be configured with software update options and an Automation script.

#### Management of scan ranges \[ID_22549\]

In the IDP app, on the tab *Admin* > *Discovery*, you can now add, edit and remove a scan range. On the tab *Inventory* > *Discovered*, a scan range can be selected to execute a new discovery process.

#### New validateProposedElementName method \[ID_22572\]

A new method, *validateProposedElementName*, is available in the provisioning API. It can be used to validate a proposed element name.

The validation will check whether the proposed name contains any forbidden characters and whether the name is already used by an element in the DataMiner System.

If the name is valid, the method will indicate this. If the name is not valid, the method will attempt to determine an alternative name and return this. The alternative name consists of the proposed name with any invalid character replaced by an underscore, and with the suffix "– copy" in case the name already exists. If the name with the "– copy" suffix also already exists, the method will instead append an index, e.g. "– copy (2)".

#### Extended software update information \[ID_22581\]

The *Software* tab of the IDP app now displays the software version detected for each managed element, along with the software version deployed during the last software update. The tab also displays summary information and KPIs, and allows you to navigate to the elements.

In the CI Type template, a new *SoftwareVersionPID* field is available.

## Changes

### Enhancements

#### Use of IDP resources \[ID_22386\]

If a DataMiner version featuring IDP resources is used (i.e. DataMiner 9.6.5 or higher), with the appropriate license, the IDP Solution will now make use of these resources. This means that the Activity Scheduler will no longer require the SRM license.

#### CreateElementWithTemplate method used to provision discovered elements \[ID_22449\]\[ID_22505\]

When discovered elements are provisioned, both in case this is done automatically or in case this is done manually after the discovery, the *CreateElementWithTemplate* API method is now used. This ensures that the latest CI types are always used.

#### Unicode support \[ID_22460\]\[ID_22485\]\[ID_22492\]\[ID_22496\]\[ID_22503\]

The different protocols used in the IDP Solution, i.e. *Skyline IDP CMDB*, *Generic Rack Layout Manager*, *Skyline Generic Provisioning*, *Skyline IDP Discovery* and *Skyline Infrastructure Discovery and Provisioning*, now support Unicode characters. However, note that this means that all existing IDP elements need to be removed before you upgrade to this version.

#### Discovery process enhancements \[ID_22558\]

To improve performance of the discovery process, the scan ranges that can be specified for discovery actions are now limited to 256 IP addresses. In addition, if the discovery process exceeds 7 minutes, the progress of the current discovery will display "Timed out".
