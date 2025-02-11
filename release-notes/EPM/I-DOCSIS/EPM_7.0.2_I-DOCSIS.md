---
uid: EPM_7.0.2_I-DOCSIS
---

# EPM 7.0.2 I-DOCSIS

## New features

#### Harmonic CableOS: New PTP page [ID 39310]

A new PTP page has been added to the Harmonic CableOS connector. On this page, the following new parameters are available:

- CCAP PTP Clock State
- RPD Port PTP Status Table
- RPD PTP Clock Status Table

While these parameters are currently not shown on the topology chains, you can retrieve this information with a dashboard or low-code app, or in a visual overview.

#### New map dashboards added [ID 39319]

New dashboards titled *03. CPE MAP* have been added to the solution, which will show a map of the passive device information associated with the selected entity. These maps can be accessed from the Dashboard module or via a new dashboard link on the Overview page when the selected entity is opened from the Topology app.

The new maps are available for the following levels:

- Node segment
- Node
- Amplifier
- Tap

When you open the dashboard, the available layer information is shown for all associated child entities:

- Amplifiers: Icons will show the highest alarm severity affecting the entity.
- Taps: Icons will show the highest alarm severity affecting the entity.
- CPE devices:
  - Group Delay: All CPE devices affected by Group Delay Out of Spec (OOS).
  - Reflection: All CPE devices affected by Reflection OOS.
  - Group Delay and Reflection: All CPE devices affected by Group Delay or Reflection OOS.

#### New Ping and Tracert buttons on CCAP and CM overview pages [ID 39334]

On the overview page for a CCAP or CM, users can now click dedicated *Ping* and *Tracert* buttons to open a window with the outcome of the ping or traceroute operation for the relevant CCAP or CM. This will provide additional insight into the status and connectivity of the system's devices.

> [!NOTE]
> To make use of this functionality, [DITT](xref:Dataminer_IT_Tool_Overview) must be deployed in the DataMiner System.

#### CISCO CBR-8 CCAP Platform: New Service Group Naming Convention parameter to determine fiber node description [ID 39448]

On the *Debug* page of the CISCO CBR-8 CCAP Platform element, it is now possible to define which descriptor is used for the fiber node, using the new parameter *Service Group Naming Convention*. This parameter can have the following values:

- *Interface Alias*: The alias of the cable interface associated with the fiber node will be used. This is the previous default behavior.
- *Node MIB*: The *ccwbFiberNodeDescription* MIB table will be used to retrieve the description.

> [!NOTE]
> Only the administrator user can access this parameter directly. Other users can change its value using the multiple set feature.

## Changes

### Enhancements

#### Default dashboard template implemented [ID 39320]

All tables in dashboards used by the EPM I-DOCSIS Solution now have a default template, which will ensure that, regardless of how the user navigates, the columns have enough width to show all data, and no user input is required to display information.
