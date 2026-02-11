---
uid: Cube_Feature_Release_10.4.3
---

# DataMiner Cube Feature Release 10.4.3

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.3](xref:General_Feature_Release_10.4.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.3](xref:Web_apps_Feature_Release_10.4.3).

## New features

#### Logging: Viewing the logging of enhanced services [ID 38623]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

In Cube, you can now view the logging of an enhanced service by doing one of the following:

- Open the card of an enhanced service, open its hamburger menu, and choose *View > Log*.
- In the Surveyor, right-click an enhanced service, and choose *View > Log*.

## Changes

### Enhancements

#### System Center: Database setting "CloudStorage" renamed to "STaaS" [ID 38325]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

In the *Database* section of *System Center*, up to now, when a DataMiner Agent was configured to use Storage as a Service (STaaS), the *Database* setting was set to "CloudStorage". This "CloudStorage" value has now been renamed to "STaaS".

Also, when *Database* is set to "STaaS", the *Configuration* and *Maintenance* sections will no longer be visible in both the *General* and *Offload* tabs, and the *Cassandra preparation/migration* button will be hidden.

#### Enhanced operator support when constructing filters for numeric columns of partial tables [ID 38367]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

From now on, the following operators are supported in filters for numeric columns of partial tables:

```txt
<
<=
>
>=
==
!=
```

#### Incident alarms and correlation alarms will now be processed separately [ID 38389]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

In order to enhance overall performance, incident alarms and correlation alarms will now be processed separately.

#### Property names identical to names of existing properties except for leading or trailing whitespace characters will no longer be allowed [ID 38424]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When creating a new property, from now on, it will no longer be allowed to use a name that is identical to the name of an existing property except for a number of leading and/or trailing whitespace characters. For example, the name "myproperty " (with a trailing whitespace character) will no longer be accepted when there is a property named "myproperty" (without whitespace characters).

> [!NOTE]
> Property names will now be trimmed before being saved.

#### Service templates: Enhanced performance when reapplying a service template [ID 38463]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

Because of a number of enhancements, overall performance has increased when reapplying a service template.

#### CubeConnection entry will now be added to the SLClient.txt log file each time a Cube client has fully connected to a DMA [ID 38574]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

Each time a Cube client has fully connected to a DataMiner Agent, a *CubeConnection* entry will now be added to the *SLClient.txt* log file of the DataMiner Agent in question.

This entry will contain the following information:

- The DataMiner Cube version
- The name of the client computer that is running DataMiner Cube
- The creation time of the connection (in ISO 8601 format)
- The ID of the connection
- The type of the current connection: "Auto", "Remoting", "WebServices" or "Grpc"
- The type of the last disconnect: "AbnormalClose", "Logout", "NoActivity", "Close", "FailedConnection", "NewConnection" or "Refresh"
- The reason of the last disconnect (depending on the type of the last disconnect)
- The hostname of the non-resolved connection URL
- The connected hostname
- The raw text of the client connection (includes connection property data such as *AmountCallsIn*, *AmountCallsOut*, *AmountInitiatedConnectionChecks*, *AmountCallsInProgress*, *AmountCallsWaiting*, etc.)

#### DataMiner Cube - Visual Overview: Page loading times are now logged in SLClient.txt [ID 38636] [ID 38694]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 [CU0] -->

The time it takes to load a visual overview will now be logged in the *SLClient.txt* log file.

The load time will be the time between page initialization and (a) the time at which the page is fully loaded or (b) the time at which the user closes the card.

Page loads will time out after 2 minutes.

Note that these *SLClient.txt* entries will also include the name of the page that was loaded.

### Fixes

#### User menu: Problem when logging out immediately after logging in [ID 38178]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When you logged out of Cube immediately after logging in, in some cases, a blank home screen would appear instead of the login screen.

From now on, the *Sign out* button will only be enabled once the login screen has been loaded.

#### No longer allowed to create properties with a name that consists of whitespace characters only [ID 38209]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

Up to now, DataMiner Cube would incorrectly allow you to create properties of which the name consisted of whitespace characters only. From now on, this is no longer allowed.

#### DataMiner Cube was not able to reconnect to the server after a disconnect using gRPC [ID 38261]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

Up to now, when using a gRPC connection, Cube was not able to verify whether the server endpoint was available. As a result, it would fail to reconnect to the server when the connection had been lost and would display a `Waiting for the connection to become available...` message indefinitely.

#### Correlation: Apply button would not be enabled when a correlation rule had been modified [ID 38351]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When changes had been made to a correlation rule, in some cases, the Apply button would incorrectly not be enabled.

Also, the *Limit the base alarms* option will now be properly validated.

#### Problem when opening a service card [ID 38354]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When you opened a service card, in some rare cases, an `InvalidOperationException` could be thrown.

#### Problem when opening a service card of which the default page was set to 'Reports' [ID 38380]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When you opened a service card of which the default page was set to *Reports*, an error could occur, causing DataMiner Cube to become unresponsive.

#### Alarm Console: Reports view button would not be shown [ID 38398]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

On undocked alarm cards or alarm consoles that were embedded in e.g. elements cards, in some cases, the reports view button would incorrectly not be shown.

#### Visual Overview: Parsing problem when using a custom separator inside a [param:] placeholder [ID 38405]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When a custom separator was used inside a [param:] placeholder referring to a table parameter value, the retrieved value would not be parsed correctly.

#### Automation: Problem when selecting 'User interaction' in the 'Add action' box [ID 38406]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When, while creating or editing an automation script, you opened the *Add action* selection box and selected "User interaction", in some cases, an exception could be thrown.

#### Protocols & templates: Problem when creating alarm templates or trend templates due to casing issue [ID 38456]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

In DataMiner Cube, you can create a new alarm template or trend template from within an element card by clicking the hamburger menu and selecting *Protocols & Templates > Assign alarm template > \<New alarm template\>* or *Protocols & Templates > Assign trend template > \<New trend template\>*.

Up to now, when the protocol name or protocol version of the element had a casing that was different from that of the protocol itself, in some cases, the protocol would incorrectly not be found.

From now on, protocol comparisons will be performed case-insensitively.

#### Settings: Description of 'Filter the alarms before they enter Cube' setting did not fit the screen [ID 38493]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

In the *Settings* windows, the description of the *Filter the alarms before they enter Cube* setting did not fit the screen. The text would be wrapped incorrectly.

#### Redundancy groups: Problem with imported elements [ID 38505]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When a redundancy group included a primary or backup element that had been imported by means of a DELT package, in some cases, another element would incorrectly be displayed instead of the imported element.

#### Correlation: Not possible to enable or disable any of the options for the 'Set parameter' action [ID 38616]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When editing a correlation rule in which a *Set Parameter* action had previously been configured, up to now, enabling or disabling any of the options for that action (e.g. *Execute on base alarm updates*) would incorrectly not enable the *Apply* button. As a result, it would not be possible to save the correlation rule after enabling or disabling some of those options.

#### Sidebar would not contain any buttons [ID 38652]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

In some rare cases, the DataMiner Cube sidebar would not contain any buttons.

#### Visual Overview: Problem with placeholders referring to datetime and timespan values [ID 38750]

<!-- MR 10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 [CU0] -->

On SRM systems, the following placeholders would not resolve correctly when a format was specified:

- [Start time:format=...]
- [End time:format=...]
- [Elapsed time:format=...]
- [Remaining time:format=...]
