---
uid: IDP_1.1.18
---

# IDP 1.1.18

## New features

#### Provisioning of connections for multiple elements \[ID_31638\]

Up to now, it was only possible to provision connections for one element at a time on the *Connectivity* > *Discovered* tab of the IDP app. In addition, if an unknown chassis ID was selected, the button to start provisioning was unavailable.

Now it will be possible to attempt to start a provisioning operation for any selection. The button to start the operation has also been renamed from *Provision All DCF* to *Provision DCF*.

Feedback on the provisioning operation will be provided per selected element. In case a request is made to provision connections for an unknown chassis ID, the following error message will be displayed:

```txt
There is no connectivity information. Try running a discovery for this element first.
```

However, note that when details of the connectivity of an element are viewed, multiple element selection is disabled.

#### Use of credentials from credentials library in CI Types \[ID_31677\]

For SNMP connections, you can now select to use credentials from the credentials library when you create or edit a CI Type. These will then be used to provision elements, or to reapply or reassign the CI Type.

To configure this in the wizard to create or edit a CI Type, select the *Use Credential Library* option and then select the desired credentials.

In Process Automation activities, the token can contain metadata that can replace these CI Type fields. For example, to enable the use of the credentials library for an SNMPv3 connection, you can specify this:

- Metadata name: *IDP\_$.Provisioning.Configuration.Ports\[0\].DMAElementSnmpV3PortInfo\[0\].UseCredentialsLibrary*
- Metadata value: "true"

To then specify the credentials from the library that are to be used for that same connection, you can use this:

- metadata name: *IDP\_$.Provisioning.Configuration.Ports\[0\].DMAElementSnmpV3PortInfo\[0\].Credential*
- metadata value: "f94c9750-61d5-4ab6-a74b-a624f4bf7ba4"

#### Separate script to restore default and to update configuration \[ID_31809\]

IDP now allows the user to select separate configuration update and restore default scripts.

For this purpose, on the *Admin* > *CI Types* > *Configuration Management* tab of the IDP app, the column *Default Update File* has been renamed to *Default Location*, and a new *Default Script* column has been added. On the *Admin* > *Settings* tab, the parameter *Default Script Folder* has been added.

When you upgrade to this release, the default value of the new *Default Script* column will be the script that is configured under *Update Script*, and the default value of the new *Default Script Folder* parameter is the script configured as the *Update Script Folder*. As such, you do not have to do any additional configuration to keep using the restore default operation.

#### Setup wizard no longer configures IDP API user \[ID_31873\] \[ID_31918\]

As the Provisioning API has become deprecated, the IDP setup wizard will now no longer configure the IDP API user. The ports for the various elements that previously made use of the API will also no longer be configured, so that these elements are not restarted by the setup wizard.

Up to now, the Configuration Manager used the IDP user for the working directories. This has been changed to be similar to the user for the DataMiner Configuration Archive. You can set up the user in the *Extra Configurations* section of the setup wizard.

In the IDP app itself, you will be able to find the working directories credentials under *Admin* > *Configuration*. A refresh button is available that allows you to check if the working directories can be reached with the specified credentials.

When IDP is deployed silently, the *UserAndGroupCreationScreen* property no longer needs to be specified when an instance of *SetupWizardInputData* is created. This property is now obsolete. For the configuration of the working directories user in the *Extra Configurations* section, a new property has been made available. If the user for the working directories is not specified, IDP will configure the credentials from the *UsersAndGroupCreationScreen* for the working directories. That way, existing silent installation scripts will continue to work.

Note that IDP will not remove the IDP API user and group. When this account is no longer used for other purposes (e.g. to have access to working directories, for third-party systems using the Provisioning API), these can be removed by an administrator in System Center.

#### New example script for configuration update activity \[ID_31886\]

A new example script, *IDP_Example_Custom_ConfigurationUpdate*, is now available for the configuration update activity.

## Changes

### Enhancements

#### Progress indication of DCF provisioning operation \[ID_31620\]

When the *Provision DCF* button has been clicked, in the *Connectivity* > *Discovered* tab of the IDP app, the *Progress* column will now display the current status of this provisioning operation.

#### HTTP Provisioning API deprecated and replaced with new method \[ID_31625\]

The HTTP Provisioning API is now considered deprecated. Instead, a new method to handle requests has been introduced in the IDP Provisioner, for which InterApp calls have been implemented.

#### Rack Layout Manager now uses InterApp calls \[ID_31786\]

The Rack Layout Manager has been updated to make use of InterApp calls for internal communication. This means that it no longer needs the Provisioning API, which has become deprecated.

#### Discovery connector now uses InterApp calls \[ID_31813\]

The Discovery connector has been updated to make use of InterApp calls for internal communication. This means that it no longer needs the Provisioning API, which has become deprecated.

#### IDP app now uses InterApp calls \[ID_31842\]

The IDP app has been updated to make use of InterApp calls for internal communication. This means that it no longer needs the Provisioning API, which has become deprecated.

#### Improved example script for restore default activity \[ID_31876\]

The example script for the restore default activity, *IDP_Example_Custom_ConfigurationDefault*, has been adjusted to be more user-friendly. Previously, this script was used for both the configuration update and restore default activity, but now it is only intended to be used for the latter.

Note that while the previous version of the example script remains usable, we do not recommend using its methods and constructors, as these are now considered obsolete.

#### Connectors updated to use virtual connection \[ID_31878\]

All connectors used by IDP now use a virtual connection.

#### Configuration update progress updated with error message in case of issue moving file to working directory \[ID_31929\]

Up to now, when there was an issue moving a file to the working directory during a configuration update, this was not indicated under *Update Progress*. Now the following information will be displayed, depending on the issue:

```txt
Working directory is not available.
```

or

```txt
Error moving the file to the working directory.
```

### Fixes

#### CI Type keyword replacement could not handle unescaped backslash \[ID_31646\]

If the replacement content for a CI Type keyword contained an unescaped backslash, the replacement failed to be parsed. This problem should no longer occur, so that the replacement now supports things like "C:\\\\Windows\\"

#### DataMiner 10.1.12 CU0 compatibility issue \[ID_31752\]

When IDP was used with DataMiner version 10.1.12 CU0, several scripts had compilation issues.

To prevent issues in case this DataMiner version is used, the IDP scripts and protocols have received an update of the class library, and the namespaces have been updated in some of the scripts.

#### Problem retrieving unmanaged elements \[ID_31947\]

In some cases, elements with corrupted properties could cause IDP to fail to load unmanaged elements. Now these elements will be shown with an exception value in the *Creation Time* column on the *Inventory* > *Unmanaged* tab.

#### Problem processing incoming Process Automation metadata \[ID_31957\]

When provisioning is done via Process Automation, the token can contain metadata that can replace the CI Type fields. For this to work, the name of the metadata must consist of the *IDP\_* prefix followed by the relevant JSON object from the CI Type. However, for the Process Automation activities Provision Element, Reapply CI Type and Reassign CI Type, this type of metadata could no longer be processed.

#### User credentials in input data of setup wizard not applied in silent mode \[ID_32065\]

When the setup wizard was run silently, and user credentials were provided in the input data, it could occur that these changes were not applied. This could happen both during initial IDP installation and during reconfiguration of an existing installation.

#### Reassign operation failed of Properties option was not selected \[ID_32084\]

Up to now, when you reassigned a CI Type without selecting the *Properties* option, the IDP and IDP CI Type properties were not updated as required, which could cause the reassign operation to fail. These properties will now always be updated during the reassigning process, regardless of whether the *Properties* option is selected.
