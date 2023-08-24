---
uid: Cube_Main_Release_10.3.0_CU4
---

# DataMiner Cube Main Release 10.3.0 CU4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Main Release 10.3.0 CU4](xref:General_Main_Release_10.3.0_CU4).

### Enhancements

#### Visual Overview - ListView component: Columns and options removed [ID_35530]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

The following columns have become obsolete. They can no longer be added to a ListView component:

| Source   | Columns |
|----------|---------|
| Elements | Contributing Service<br>ElementID<br>ReservationInstances<br>Service properties |
| Services | Booking properties<br>ReservationInstance<br>Resource state<br>UsedResources    |

Also, the following component options can no longer be used:

- DisableInUseItems
- EditMode
- Recursive

#### System Center: Overhaul of LDAP settings [ID_35782]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.6 -->

In *System Center > System settings > LDAP*, you can configure a number of LDAP settings. These settings have had an overhaul.

- In the *General* tab, from now on, you will only be able to set *Authentication type* to either "Anonymous" or "Simple".

  > [!NOTE]
  > When you set *Authentication type* to "Anonymous", the *User name* and *Password* fields will now be disabled. When both fields contain a value, *Authentication type* will by default be set to "Simple".

- In this section, it is now also possible to configure the *nonDomainLDAP* setting. Up to now, this setting could only be configured in the *DataMiner.xml* file.

- When you update LDAP settings, a warning will now appear to notify you that these settings will only be changed on the DataMiner Agent to which you are connected. Changes made to LDAP settings will not be synchronized among the agents in the cluster.

Also, a number of issues have been fixed. Up to now, the value entered in *Use fully qualified domain name (FQDN)* would not be saved to the *DataMiner.xml* file, an incorrect default value would be entered in the *User class name* field, and the value entered in the *Password* field would get lost when the LDAP settings were updated without changing the password.

#### Services app - Profiles tab: Profile instance selection box now sorted by name [ID_36332]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When, in the *Services* app, you configure a service profile instance in the *Profiles* tab, you can link the different nodes of the service profile to existing profile instances using a profile instance selection box. Up to now, the profile instances listed in this selection box were sorted the creation date. From now on, they will be sorted by name. Also, this selection box can now be filtered.

#### Resources app: Saving a resource property with an empty value [ID_36345]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

In the *Resources* app, it is now possible to save a resource property with an empty value.

### Fixes

#### Resources app: Problem when opening the element list in the 'device' tab [ID_36239]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When, in the *Resources* app, you created a resource and then opened the element list in the *device* tab in order to link a device to that newly created resource, in some cases, DataMiner Cube could become unresponsive, especially when the element list contained a large number of elements.

#### Automation app: C# editor would incorrectly jump to the first line of code when saving a script [ID_36321]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When, in the *Automation* app, you saved an Automation script after making changes to a C# code block, the C# editor would incorrectly jump to the first line of that code block. From now on, when you save an Automation script, the C# editor will jump to the last line of code that was changed.

#### Visual Overview: Problem when opening an EPM card [ID_36323]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you opened an EPM card by clicking a shape that was linked to the EPM object via the *SystemName* and *SystemType* properties, in some cases, the card would be missing certain pages.

#### Visual Overview: Dynamically positioned top-level shapes would lose their connections when a child shape had 'DisableConnectivity' set [ID_36340]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

When dynamically positioned shapes contained subshapes that disabled the connectivity, in some cases, no connections would be drawn.

From now on, connections will be drawn when a dynamically positioned shape has at least one subshape with connectivity.

When all subshapes have the `DisableConnectivity` option set, then no connections will be drawn.

#### Spectrum analysis: Trace would no longer be updated when you restarted a spectrum element while its card was open [ID_36347]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you restarted a spectrum element while its card was open, the trace would no longer be updated. For the trace to get updated, you had to close the card and open it again. From now on, the trace will be updated as soon as the element has finished restarting.

#### Visual Overview: Blinking shapes would affect other components [ID_36357]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

Up to now, setting a shape to blink in Visual Overview could unintentionally affect other components. For example, when the parameter table contained monitored parameters, the monitored cells would incorrectly blink along with the shape.

From now on, when a shape is set to blink, other components will no longer be affected.

#### Problem with 'Use credentials' selection box when creating or editing an element [ID_36362]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you selected the *Use credentials* option for an SNMPv1 or SNMPv2 connection while creating or updating an element, you would incorrectly not be required to select any predefined credentials. As a result, an error would occur when the element was created or the update was applied. From now on, when you select this option, the label will turn red and the *Create* or *Apply* button will be disabled as long as no credentials have been selected.

Also, when you edited an element for which credentials had been selected, the *Use credentials* selection box would be disabled and the *Get community string* and *Set community string* boxes would be enabled until you toggled the *Use credentials* option off and on again.

#### Reports and heatline of a monitored parameter of a DVE child element would incorrectly show "No monitoring" [ID_36384]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

When you opened the card of a DVE child element, drilled down to a monitored parameter and opened the *Details* tab, the reports would incorrectly show "No monitoring". Also, "No monitoring" would be shown when you viewed the heatline of the parameter in question.

#### Problem when opening the alarm template of a large matrix parameter [ID_36444]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, Cube could become unresponsive when you tried to open the alarm template of a large matrix parameter.

#### Problem when trying to export all elements to a CSV file [ID_36512]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In some cases, the following exception could be thrown when you tried to export all elements to a CSV file:

`Export failed: Object reference not set to an instance of an object`
