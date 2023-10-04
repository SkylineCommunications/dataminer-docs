---
uid: EPM_1.0.4_VSAT
---

# EPM 1.0.4 VSAT

## New features

#### Backup mechanism added [ID_37035]

To prevent a potential issue where the entities config file gets corrupted, the entities config file will now automatically be backed up. This happens when the system is set up for the first time or when the file is read successfully. The backup is located on the front-end DMA. If a problem is detected when trying to read the entities config file, the backup will be used instead. If no backup is available for some reason, the same logic will be used as when no config file is used, which means new IDs will need to be assigned.

In addition, a daily backup functionality has been added. On the new *Admin* > *Backup* page in the Verizon VSAT Platform Manager visual overview, you can configure how often the backup should occur and where the backup file should be located.

#### Newtec Dialog Platform VSAT: HRC modem type integration [ID_37375]

The Newtec Dialog Platform VSAT connector has been updated to include dynamic return technologies so that HRC/MRC type modems can be processed and data can be collected from the right locations.

## Changes

### Enhancements

#### VSAT dashboards: Optimized default settings + improved total remote count calculation [ID_37116]

In all EPM VSAT dashboards, the default settings have been optimized:

- The default time period for all time range feeds has been set to the last 24 hours.
- All line charts now show the legend by default.
- The default line colors in line charts have been improved so that there is a more distinct color distribution for the lines.
- The min/max shading for line charts is now hidden by default.

In addition, to achieve more accurate percentages, the Carrier Performance dashboard now calculates the total remote count based on the iDirect Hub Return Carrier table instead of the Hub Return Overview table.

### Fixes

#### Verizon ETMS Platform: Message not displayed at top Activity Log [ID_37132]

If a ticket with power issues needed additional investigation, the message "Further Investigation Required" could incorrectly appear at the bottom of its Activity Log, instead of at the top.

#### Security issue related to BinaryFormatter [ID_37133]

A security issue related to the use of the BinaryFormatter type has been addressed in the following connectors:

- Newtec Dialog Platform VSAT
- Verizon iDirect Evolution Platform Collector
- Verizon WM DCAT
- Verizon WM Ticketing

#### No ticket created for circuit in alarm [ID_37215]

In some cases, it could occur that a ticket failed to be created for a circuit in alarm, because a remote event incorrectly cleared the alarm early, so that alarm hysteresis caused no alarm to be triggered in DataMiner.
