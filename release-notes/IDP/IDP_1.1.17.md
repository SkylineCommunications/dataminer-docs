---
uid: IDP_1.1.17
---

# IDP 1.1.17

## New features

#### Reapplying/reassigning a CI Type now allows update of element properties \[ID_31128\]

In the wizard to reapply or reassign a CI Type, a new *Properties* option is now available, so that you can now update the element properties with a reapply/reassign action. The *Show Details* button allows you to check the end result for each property.

#### Discovered Connections table improvements \[ID_31597\]

In the IDP app, the following improvements have been implemented to the *Discovered Connections* table (on the *Connectivity* tab):

- Source and destination element names have been added.
- A pending connection is now displayed with the following information: the *Source Element Name*, *Source Port ID*, *Source DCF ID*, *Destination Element Name*, *Destination Port ID* and *Destination DCF ID*.

## Changes

### Enhancements

#### Support for elements migrated/imported using DELT \[ID_31091\]

IDP is now able to handle elements that have been migrated across DMAs or imported from another DMA using DELT. Up to now, these could not be managed with IDP. It was also impossible to move them to a rack or to set a baseline alarm for them.

#### \[IDP_DR\_\*\] keywords no longer case sensitive \[ID_31098\]

When \[IDP_DR\_\*\] keywords are used in CI Types, these no longer need to have the same casing as the discovery actions.

#### Delete button now longer shown in wizard when creating new CI Type or duplicating a CI Type \[ID_31259\]

The CI Type configuration wizard will now only show a *Delete* button when you edit a CI Type. Previously, this was also shown when you created a new CI Type or duplicated a CI Type.

#### Leading/trailing spaces removed from name new CI Type \[ID_31321\]

When you create a new CI Type or import one from a file, any leading or trailing spaces are now removed from the CI Type name.

#### Support for GZIP responses during HTTP discoveries \[ID_31372\]

During an HTTP discovery, GZIP responses will now be automatically unzipped so they can be processed. Previously, these responses were not supported.

#### Improved status information in case of provisioning issues \[ID_31405\]

When something goes wrong during provisioning, more detailed information will now be available in the IDP app, under *Inventory* > *Discovery* > *Discovered Elements*, in the *Provisioning Status* column. The following status messages can be displayed

- When a CI Type is provisioned of which the name is null or whitespace: "The name of the specified CI Type is null or whitespace."
- When an element is provisioned while the CMDB element is not available, is stopped or does not exist: "The CMDB element is not available."
- When an element is provisioned, but not all keywords can be resolved: "Not all discovery responses are available, please run discovery again."
- When an element is provisioned, but the CI Type is not configured to allow provisioning: "The specified CI type is not configured for provisioning."
- When an element is provisioned, but the JSON cannot be deserialized to a *CreateElement* object (for example because an incorrect keyword is provided): "Could not deserialize JSON to CreateElement object.";
- When an element is provisioned and a generic error occurs other than the issues mentioned above: "Unexpected exception creating element state based on CI Type: {CI Type name}"

#### DCF connections now made on both elements in case unilateral connection exists \[ID_31556\]

To prevent situations where a DCF connection only exists on one element, IDP will now always create a connection on both elements during provisioning. For example, if an element A has a connection to an element B, but element B has no connection to element A, DataMiner IDP will now create both connections.

### Fixes

#### Problem with Process Automation after process information was generated with invalid element ID \[ID_31102\]

In some cases, service definitions could generate process information with an invalid element ID (-1/-1), which could in turn cause an issue with the subsequent processes, stopping the normal Process Automation flow.

#### Problem with credentials configuration in setup wizard \[ID_31385\]

If the DMA was not part of a domain, it could occur that existing credentials specified in the setup wizard could not be validated. In addition, it could occur that the password boxes in the setup wizard were disabled when the IDP user account did not exist yet in the system and you tried to create it.

#### Process Automation: Not possible to create process if process with same activities was created earlier \[ID_31471\]

If a process had already been created with certain activities, it could occur that it was not possible to create another process with these activities.

An exception similar to the following would be thrown:

```txt
Script Failure (IDP_ProcessAutomationWizard): EXIT: "(Code: 0x80131500) Skyline.DataMiner.Automation.ScriptAbortException: failed creating new booking: Skyline.DataMiner.Library.Exceptions.ResourceManagerException: Node Token is mandatory in service definition Recurring Configuration Back-up, but does not contain a valid configuration
```

#### Exceptions because provisioning did not wait for element creation to be completed \[ID_31530\]

Up to now, the provisioning activity expected element creation to be completed immediately, which could cause generic exceptions to be thrown in case element creation took longer. Now a retry mechanism of five seconds has been implemented to prevent this.

#### Activities disabled after saving/editing CI Type \[ID_31533\]

In some cases, when a CI Type was saved or edited, it could occur that activities on the *Process* > *Activities* tab were set to *Disabled* even when this should not have been the case:

- When a CI Type was saved that had *Software Update* or *Software Compliancy* enabled on the *Process* > *Activities* tab, the toggle buttons for these activities were set to *Disabled* for all CI Types, even if no changes had been done for those CI Types.
- When a CI Type's provisioning information was edited, the activities *Rack Assignment* and *Connectivity Discovery* in the *Process* > *Activities* tab were alway set to *Disabled* for all CI Types.

Now activities will only be set to *Disabled* if the relevant completeness percentage is no longer 100%.
