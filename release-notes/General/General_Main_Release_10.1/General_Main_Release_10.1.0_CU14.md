---
uid: General_Main_Release_10.1.0_CU14
---

# General Main Release 10.1.0 CU14

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_32954\] \[ID_32992\] \[ID_33052\]

A number of security enhancements have been made.

#### Enhanced setup of serial connections with SSL/TLS enabled \[ID_32969\]

A number of enhancements have been made with regard to the setup of serial connections with SSL/TLS enabled.

### Fixes

#### Alarm templates: Miscellaneous fixes \[ID_32462\]

A number of issues have been fixed with regard to alarm templates.

- When you updated an alarm template that contained a table parameter with at least two filters, only the last of those filters was calculated.

- When, in an alarm template, you disabled the smart baselines for a table parameter with a filter and then re-enable it, the smart baselines for that table parameter would no longer be calculated.

Also, a number of enhancements have been made with regard to the calculation of smart baselines.

#### Service & Resource Management: GetEligibleResources would ignore the time range passed to it \[ID_32763\]

Up to now, when GetEligibleResources was called, the eligible resources would incorrectly be calculated based on the time range of the ReservationInstance to be ignored. From now on, when the context passed to GetEligibleResources includes a time range, the time range of the ReservationInstance will be ignored.

#### DataMiner Cube: Problem when opening the Ticketing app \[ID_32775\]

Up to now, in some cases, the Cube UI could become unresponsive when you opened the Ticketing app.

#### DataMiner Cube - Visual Overview: SET command linked to a shape would not be executed when the page was displayed in a VdxPage window of type 'Popup' \[ID_32780\]

When a page that was displayed in a VdxPage window of type “Popup” contained a shape linked to a SET command, clicking that shape would incorrectly not execute the SET command.

#### DataMiner Cube - Resources app: No resources or resource pools would be loaded when opening the Resources app \[ID_32790\]

When you opened the Resources app, in some cases, no resources or resource pools would be loaded.

#### Processes would not get registered correctly when a DataMiner upgrade included a reboot \[ID_32818\]

When a DataMiner upgrade included a reboot (either explicitly requested, or e.g. after installing Microsoft .NET 4.8), in some cases, services would not get registered correctly, especially when the new DataMiner version included services that did not previously exist.

#### Problem with SLDMS hosting agent cache \[ID_32827\]

In some rare cases, the SLDMS hosting agent cache could get corrupted. As a result, it would no longer contain the correct data when processing element updates.

#### NAS: Incorrect default settings in nas.config file \[ID_32840\]

The default settings in the nas.config file would be incorrect.

#### Memory leak in SLElement \[ID_32885\]

In some cases, a problem with subscriptions on views with remote data would cause SLElement to leak memory, which could eventually lead to run-time errors in the parameter thread.

#### Filtered tables could incorrectly receive updates for rows that did not match the applied filter \[ID_32915\]

In some cases, a filtered table could incorrectly receive updates for rows that did not match the applied filter. On EPM setups, this would cause performance issues and run-time errors.

#### Online SLA window would not get properly closed \[ID_32946\]

In some cases, an online SLA window would not get properly closed.

#### DataMiner Cube: No longer possible to move DVE elements to another view \[ID_32984\]

In some cases, it would incorrectly no longer be possible to move DVE elements to another view.

#### Problem with SLLog when a log file was closed \[ID_33191\]

In some cases, an error could occur in the SLLog process when a log file was closed.
