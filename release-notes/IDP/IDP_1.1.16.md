---
uid: IDP_1.1.16
---

# IDP 1.1.16

## New features

#### \[IDP_DR\_\*\] placeholders in CI Types \[ID_30689\]

You can now use placeholders in CI Types that refer to discovery responses from the device. These placeholders must have the following format:

```txt
[IDP_DR_<discovery profile name>/<discovery profile action name>]
```

For example:

```txt
[IDP_DR_SNMP_MIB_II/sysDescr]
```

IDP will poll each \[IDP_DR\_\*\] placeholder and try to resolve it when provisioning a discovered element. These placeholders can be used in the element name, element description, properties, etc.

In case a placeholder cannot be polled (e.g. an HTTP placeholder on an SNMP-only device), the placeholder will not be resolved during provisioning and the text of the placeholder itself will be filled in instead of a value.

#### Activity management toggle buttons \[ID_30838\]

On the *Admin* > *CI Types* tab of the IDP app, an *Activity Management* page has been added. The toggle buttons on this page allow you to determine the default behavior of the process activation settings. If a toggle button is set to *Manual*, users will need to manually enable automation for the relevant activity when completeness is 100%. If a toggle button is set to *Automatic*, automation will be enabled automatically as soon as completeness is 100% for the activity.

In all other sections of the *Admin* > *CI Types* tab (except the *Overview* section), toggle buttons have also been added to allow you to enable or disable each activity:

- In the *Discovery* section, these are available in the *Discovery* column.
- In the *Provisioning* section, these are available in the *Create* column.
- In the *Connectivity* section, these are available in the *Connectivity Discovery* column.
- In the *Configuration Management* section, these are available in the *Backup* and *Configuration Update* columns.
- In the *Software Management* section, these are available in the *Update* and *Compliance Check* columns.
- In the *Facilities* section, these are available in the *Rack Assignment* column.

#### Processes \> Automation tab renamed to Processes \> Activities \[ID_30839\]

To be more in line with the nomenclature used in the rest of the IDP app, the *Processes* > *Automation* tab has been renamed to *Processes* > *Activities*.

#### Process Automation activities using discovery responses \[ID_30908\]\[ID_30942\]

Discovery responses can now be used in Process Automation activities to provision an element, reapply a CI Type or reassign a CI Type.

IDP will save the discovery responses for each device. If a CI Type contains a reference to a discovery response for which no value is saved, the Process Automation activity will fail, and a new discovery will need to be run.

You will be able to reapply or reassign CI Types even if a CI Type contains placeholders linking to discovery responses. When you do so, you can click the *Show Details* button in the wizard to get an overview of what all selected replacements look like and what the end result will be.

#### Possibility to choose rack side when assigning element to rack \[ID_30932\]

When you assign an element to a rack (via *Admin* > *Facilities* > *Rack Assignment*), you can now choose whether to assign it to the front or rear of the rack.

#### IDP API user configuration changes \[ID_30959\]

The IDP setup wizard has been modified so that the password from the currently configured API user is not loaded. In addition, the elements *DataMiner IDP*, *DataMiner IDP Rack Layout* *Manager*, *DataMiner IDP Discovery* and *DataMiner IDP Configuration* no longer allow the local configuration of the API credentials. Instead this configuration must be done through the setup wizard.

In the setup wizard, you now need to select if you want to edit the password of the currently configured API user. By default, the credentials remain the same, the password box is grayed out, and no user changes are sent to IDP. If you select to use a different user, you do need to configure a password to be able to move forward in the wizard.

On the *Extra Configurations* page of the wizard, the same behavior will apply when you open the *Configuration Manager* section. If credentials are already configured for the Configuration element, the credentials boxes are grayed out, but you can select to specify different credentials instead.

## Changes

### Enhancements

#### Support for long element names in rack view \[ID_30965\]

The rack view has been improved to support elements with long names. Previously, these could not be displayed correctly.

#### IDP Correlation rules moved to dedicated folder \[ID_30978\]

The Correlation rules *IDP_Element_Edit* and *IDP_Element_Delete* have been moved from the root folder of the Correlation module to a dedicated *DataMiner Solutions/IDP* subfolder.

#### Improved efficiency of Correlation rule detecting element name changes \[ID_30980\]

To detect whether an element name is changed by a user, DataMiner IDP uses a Correlation rule (*IDP_Element_Edit*) that is triggered based on information events. To improve the efficiency of this rule, it will now no longer be triggered when services or enhanced services are edited.

### Fixes

#### Configuration backup with a file path resulted in exception \[ID_30745\]

When a custom backup script was used that provided IDP with a file path, the *Update Progress* column reported an exception even though the file was actually successfully transferred to the configuration archive:

```txt
Configuration Backup has failed due to: The CancellationTokenSource has been disposed.
```

#### Setup wizard unable to import profile parameters and definitions \[ID_30785\]

When the setup wizard imported profile parameters and definitions, it could occur that this failed because the path to import these from was incorrect. This only affected first-time installations of IDP.

#### Information of first discovery still used when element is discovered again \[ID_30811\]

When an element was discovered again after having been discovered already previously, it could occur that IDP kept using the information from the first discovery result, even if this was not the same.

#### Exception during purge operation after storing configuration backup file \[ID_30842\]

If purging of the configuration archive was enabled, but a file path was too long, it could occur that IDP threw an exception when trying to carry out the purge operation after it stored a backup file in the configuration archive:

```txt
The specified path, file name, or both are too long. The fully qualified file name must be less than 260 characters, and the directory name must be less than 248 characters.
```

#### SNMPv3 devices not added to rack assignment section \[ID_30945\]

In some cases, it could occur that SNMPv3 devices were not added to the *Admin* > *Facilities* > *Rack Assignment* section, so that it was not possible to assign them to a rack position.
