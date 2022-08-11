---
uid: IDP_1.1.9
---

# IDP 1.1.9

## New features

#### Alarm notification in case device runs unexpected software version \[ID_26372\]

It is now possible to have an alarm generated if a managed element runs a different software version than expected. For this purpose, an alarm template using dynamic alarm thresholds has to be assigned to the element. In this alarm template, an asterisk ("\*") should be specified at the alarm threshold level for the desired alarm severity.

In the IDP app itself, this feature needs to be configured via *Admin* > *CI Types* > *Software Management*. In the table on this page, you can set the *Version Baseline* and *Version Parameter* *Name* (via the *Advanced* page button in the relevant row) and then enable *Set Baseline in Alarm Template* to activate the feature. If *Set Baseline in Alarm Template* and *Software Compliancy* are enabled, the version baseline will be filled in as a baseline value of the specified version parameter name of all elements associated with the CI type.

#### Telnet discovery support added \[ID_26645\]

IDP now supports Telnet discovery.

Telnet discovery profiles have the following fields:

- **Name**: The name of the action in this discovery profile. The name has to be unique in the profile and can be referenced by the CI types.

- **Method**: If set to *Welcome*, IDP will only connect to the device and read the first message without sending any command. If set to *Command*, IDP will connect and send the commands specified next to Parameter.

- **Parameter**: The commands to be sent if the method is *Command*. If additional steps are required to get to the commands, these must be specified in the *Options* field.

- **Port**: The destination port on the device to connect to.

- **ProtocolType**: This defines the discovery mechanism and is set to Telnet.

- **Options**: Any additional steps that are required to get to the commands, in case the method is *Command*. For example, for a Cisco device, before commands can be sent, first an enable command or configure terminal command must be sent.

Credentials can be specified by adding username and password under *GenericSettings*.

For example:

```json
{
     "Actions": [
           {
                "Name": "CheckPrompt",
                "Method": "welcome",
                "Parameter": "",
                "Port": 23,
                "ProtocolType": "Telnet"
           },
           {
                "Name": "Command",
                "Method": "command",
                "Parameter": "cat /etc/os-release",
                "Port": 23,
                "ProtocolType": "Telnet"

           },
          {
                "Name": "Commands",
                "Method": "command",
                "Parameter": "show version",
                "Port": 23,
                "ProtocolType": "Telnet",
                "Options": [
                     {
                           "Option": "enable"
                     },
                     {
                           "Option": "terminal length 0"
                     }
                ]
           }
     ],
     "Credentials": {
           "GenericSettings": {
                "Username": "test",
                "Password": "test123"
           }
     }
}
```

#### Support for IPV6 discovery and provisioning \[ID_26853\]

Discoveries and provisioning using IPv6 address ranges are now supported. It is possible to include IPv6 ranges and IPv4 ranges in the same request.

You can also use the *\[IPAddress\]* keyword with IPv6 addresses; however, note that if this keyword is used as part of an element name, this can cause characters to be replaced, because the normal separator for IPv6 is a colon (":") but this character is not allowed in element names.

## Changes

### Enhancements

#### IDP app: Improved support for SNMPv3 provisioning + improved sorting of properties \[ID_26341\]

It is now possible to configure SNMPv3 CI types within the IDP app. Previously, these had to be configured manually. In addition, the security level *AuthPriv* is now supported for SNMPv3 CI types. However, note that by default, CI types generated based on a protocol with an SNMPv3 connection have SNMPv2 port settings configured on that connection, as there is no way to automatically find out the security levels, algorithms and passwords.

In addition, in the CI type management wizard, properties are now sorted alphabetically.

#### Progress columns now display local time \[ID_26460\]

To improve consistency in the way time is displayed throughout the IDP app, the *Update Progress* column on the *Configuration* > *Summary* tab and the *Progress* column on the *Connectivity* > *Summary* tab will now display the local time instead of UTC time.

#### Deleting core IDP elements no longer possible with Provisioning API \[ID_26914\]

To avoid accidental deletion of core elements of the IDP Solution, it is now no longer possible to delete such elements using the Provisioning API.

#### Additional validation when uploading discovery profiles or CI types \[ID_26924\]

When a discovery profile or CI type is uploaded, additional validation is now applied. If a discovery profile does not contain any actions, it will be considered invalid. Similarly, CI types containing only empty fields will not be allowed.

#### Provisioning API: createView request with existing view now returns error \[ID_26932\]

A *createView* request using the name of an existing view will now return an error mentioning that the view already exists, along with the existing view.

#### Provisioning API: getViews request with invalid ID now returns error \[ID_26933\]

When a *getViews* has an invalid negative ID or non-existing positive ID, now a Bad Request error will be returned together with an empty *View* array.

#### Provisioning API: configureElement request with empty body array now triggers error \[ID_26935\]

Previously, when there was a *configureElement* request with an empty body array, no error was thrown. Now this will trigger an error 400 (Bad Request).

#### Provisioning API: getElements request with both protocol and ID filter returned no elements \[ID_26940\]

When a *getElements* request used both a protocol and ID filter at the same time, up to now, no elements were returned. Now an OR operation will be performed in order to return elements matching the filters.

#### Provisioning API: resolveNameSchemaFromTemplate request with invalid CI type now returns error \[ID_26943\]

When an invalid CI type is used in a *resolveNameSchemaFromTemplate* request, a Bad Request error will now be returned.

#### Provisioning API: setVisioForViews request with empty view IDs now returns error \[ID_26947\]

If a *setVisioForViews* request has empty view IDs, a Bad Request error will now be returned.

#### Provisioning API: replaceView call improved with errors in several cases \[ID_26953\]

The *replaceView* call in the Provisioning API will now return errors in the following cases:

- If the specified *FromViewID* and *ToViewId* are the same.
- If multiple views contain the same element and one of these views is set as the *ToViewId*; in this case the element will be removed from the *FromViewID*.
- If the *FromViewID* is set to a view that does not contain the element; in this case the element will be added to the view.

#### Local IP port from protocol now added to CI type when missing \[ID_26958\]

In case a CI type does not contain the local IP port, the IDP Solution will now read the local IP port value from the protocol and add it to the CI type, so that it can fill in this value when creating an element.

#### Improved IPv6 support \[ID_27002\]

Several enhancements were implemented in the IDP app to improve support for IPv6. When a scan range is configured, there will be additional validation for the IP range and improved messaging in case something is wrong.

#### Provisioning API: resolveNameSchemaFromTemplate call updated \[ID_27003\]

The *resolveNameSchemaFromTemplate* call in the Provisioning API was updated as follows:

- If it can resolve all names, it will send a response with the status *OK*.
- If it can only resolve some of the names, it will send a response with the status *PartialContent*.
- If it cannot resolve any of the names, it will send a response with the status *NoContent*.
- If the request is incorrect, it will return *BadRequest*.

### Fixes

#### Configuration backup path not updated when Manufacturer and Model properties were updated \[ID_26439\]

When the *Manufacturer* and *Model* properties were updated, the folder path where configuration backups were stored was not updated accordingly.

#### Problem with Skyline Infrastructure Discovery And Provisioning protocol when using DataMiner 10.0.6 \[ID_26461\]

If the IDP Solution was used with DataMiner version 10.0.6, it could occur that QAction 308 of the *Skyline Infrastructure Discovery And Provisioning* protocol failed.

#### 'Take Backup' setting not taken into account when backup script was launched from Automation app \[ID_26918\]

When the script that is used to take a backup of a device configuration was launched directly from the Automation app instead of via the IDP app, the workflow automation setting *Take Backup* was not taken into account, so that the backup was also taken when this setting was disabled.

#### Element created with invalid name \[ID_26931\]

Previously, if a *createElement* request used an invalid name, it could occur that the element was created anyway.

#### Password setup not changed when reapplied \[ID_26992\]

When the password setup was reapplied on an element, it could occur that no changes were applied.
