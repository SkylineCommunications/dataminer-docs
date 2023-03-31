---
uid: PTP_1.1.2_CU1
---

# PTP 1.1.2 CU1

## Enhancements

#### Support added for Ross Iggy AES16.16 connector \[ID_30304\]

The Ross Iggy AES16.16 connector is now supported as a "slave clock" PTP type. For this purpose, the mapping for the following parameters has been added: *Clock ID*, *Priority 1*, *Priority 2*, *PTP Domain*, *Slave Only*, *Lock Status*, *OffSet*, *Mean Path Delay*, *GM Clock ID*, *GM Clock Class*, *GM Clock Accuracy*, *GM Priority 1* and *GM Priority 2*.

#### Support added for directOut Montone.42 connector \[ID_30391\]

The directOut Montone.42 connector is now supported as a "slave clock" PTP type. For this purpose, the mapping for the following parameters has been added: *PTP Domain*, *Slave Only*, *Lock Status*, *Offset* and *GM Clock ID*.

#### No longer possible to assign role to PTP app elements \[ID_30459\]

In the setup wizard, it was possible to assign a role to the PTP app elements as well. However, as these are not PTP devices, this is now no longer possible.

#### Improved setup wizard messages \[ID_30501\]

The messages displayed by the setup wizard when you create a new app instance or configure an app instance have been improved. These messages will now contain the relevant domain name, to make it more clear which instance of the app is referred to.

#### Domain service created in same view as app instance \[ID_30502\]

Previously, when the domain of a PTP app instance was configured, the corresponding service was created in the root view. Now the service will be created in the same view as the app instance.

#### Improved support for long element names \[ID_30711\]

To improve support for long element names, several changes have been implemented.

- The role selection wizard now supports two lines for element names. In addition, column sizing has been improved throughout the script.
- On the *Summary* tab of the PTP app, the size of several sections has been adjusted. For the element name in the *Grandmaster* section, two lines are now supported. If the name is still too big to be fully displayed, an ellipsis will be added.
- On the *Nodes* tab of the PTP app, two lines are now supported for the element names in several places, and an ellipsis will be added in case a name is still too big to be fully displayed.

## Fixes

#### Problems when running setup wizard after installation \[ID_30489\]

Previously, when you ran the setup wizard again after PTP had already been installed, the wizard could not identify the current view used for the PTP app and therefore always asked to create a new view. In addition, it always mentioned that a new PTP app instance would be created, even if this was not the case.

#### Active grandmaster not correctly updated after switch \[ID_30569\]

After the active grandmaster was switched, it could occur that the PTP app did not show the correct active grandmaster and the count of the nodes reporting to the grandmaster was incorrect. This could also lead to incorrect values for the node synchronization status.

#### Incorrect error message when applying same name to domain \[ID_30720\]

When you applied the same name to a domain or ran the setup wizard for an existing domain, a failure message was displayed saying that the domain already existed.

#### Not possible to finish setup wizard \[ID_30737\]

When you ran the setup wizard from the *Admin* page of the PTP app, it could occur that no scroll bar was displayed in the last step of the wizard so that it was not possible to click the *Finish* button. This made it impossible to set up roles starting from the normal setup.

#### Empty domain name not shown correctly in setup wizard \[ID_30746\]

When the setup wizard was run from the *Admin* page of a PTP app instance that did not have a domain name set, the wizard incorrectly displayed the domain name as *N/A*.

#### Incorrect information for second analyzer on Nodes \> Analyzers tab \[ID_30759\]

When you compared two analyzers in the PTP app on the *Nodes* > *Analyzers* tab, it could occur that for the second analyzer information of the first analyzer was shown.
