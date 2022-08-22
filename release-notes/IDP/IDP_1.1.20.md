---
uid: IDP_1.1.20
---

# IDP 1.1.20

## New features

#### Support for credentials from the Credentials Library in discovery profiles \[ID_32606\]

It is now possible to use credentials from the Credentials Library during a discovery. To do so, in a discovery profile for SNMPv1, SNMPV2 or SNMPv3, you can specify an ID that links to a set of credentials from the Credentials Library.

If a discovery template with invalid credentials is imported, IDP will display an error. This can be the case if the credentials no longer exist in the Credentials Library or if they are not applicable for the selected protocol type (e.g. Community credentials used in an SNMPv3 profile).

#### Adding/editing discovery profiles directly in IDP UI \[ID_32778\]

On the *Admin* > *Discovery* > *Discovery Profiles* page, you can now add and edit discovery profiles. Previously, the only way you could manage discovery profiles was by importing them as JSON files.

Two new buttons are available above the list of discovery profiles that allow you to add a new discovery profile and edit a selected discovery profile. These will open a wizard in which you can configure the discovery profile. You can add and delete actions, as well as configure specific options for the relevant protocol type. This includes the possibility to use credentials from the Credentials Library for SNMPv1, SNMPv2 and SNMPv3 protocol types.

#### New Admin \> Activities tab \[ID_32889\]

The activities configuration has now been moved to one consolidated location in the IDP app. i.e. the *Admin* > *Activities* tab, which has two pages:

- The *Overview* page, containing the configuration that was previously available under *Processes* > *Activities*.
- The *Default Behavior* page, containing the configuration that was available under *Admin* > *CI Types* > *Activity Management*.

#### File Transfer credentials clarified in IDP UI \[ID_32980\]

On the *Configuration* > *Admin* tab, the *Network Shares* page previously contained a set of credentials for the working directories. While these credentials were in fact used for all file transfers (including e.g. for a configuration backup), a user could easily get the impression that they were exclusively used for the configuration update operation. For this reason, the credentials are now displayed in a new *File Transfer Credentials* section on the same page. Similarly, in the Configuration Manager section of the setup wizard, they are now mentioned as “File Transfer Credentials”.

## Changes

### Enhancements

#### Obsolete Activity Scheduler feature removed \[ID_32619\]

The Activity Scheduler feature, which has been replaced with Process Automation, is now considered fully deprecated and has been removed from the IDP UI. It will also no longer be mentioned in the setup wizard. If you do not have Process Automation installed and you go to the *Processes* tab, a message will be displayed to indicate that Process Automation is required for this.

#### Minimum required DataMiner version changed to 10.1.0.0 - 11229 CU10 \[ID_32820\]

The minimum required DataMiner version for DataMiner IDP is now DataMiner 10.1.0.0 - 11229 CU10.

### Fixes

#### Exception during IDP installation \[ID_32644\]

When IDP was initially installed, it could occur that the *Solution Components* table of the IDP app was not fully filled in yet, which caused the following exception to be included in the information event logging:

```txt
GetInfoFromConfigurationElement: Could not parse dmaeid. (Script 'IDP_SetupWizardFrontEnd')
```

Now a retry mechanism has been implemented to prevent this issue, and clearer error messages have been implemented in case the retry fails.

#### Unable to create booking with process definition created by IDP_ProcessAutomationWizard \[ID_32675\]

It could occur that it was not possible to create a booking with a process definition created by *IDP_ProcessAutomationWizard*.

#### Exception in case IDP activity had Element Selection Type set to Element Property \[ID_32692\]

If a Process Automation activity for IDP had "Element" as input, and the Element Selection Type of the profile instance was set to "Element Property", a null reference exception could be thrown.

#### \[DNSName\] keyword not resolved in proposed element name \[ID_32802\]

When the *\[DNSName\]* keyword was used in the element name of a CI Type, it could occur that this was not resolved in the *Proposed Element Name* column of the *Discovered Elements* table (on the *Inventory* > *Discovered* tab).

#### SET buttons not working on Admin \> Facilities tab \[ID_32820\]

On the *Admin* > *Facilities* tab of the IDP app, it could occur that the *SET* buttons no longer worked.

#### Configuration Types and Working Directories tables empty after new installation \[ID_32881\]

After a new installation of DataMiner IDP, no credentials are configured in the Skyline Configuration Manager. This could cause exceptions that made it impossible to fill in the *Configuration Types* and *Working Directories* tables. If these exceptions now occur, they will be logged, but this will no longer affect the functionality of the tables.
