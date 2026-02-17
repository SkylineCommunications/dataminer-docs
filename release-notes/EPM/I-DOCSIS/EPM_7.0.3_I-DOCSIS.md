---
uid: EPM_7.0.3_I-DOCSIS
---

# EPM 7.0.3 I-DOCSIS

## New features

#### EPM_I_DOCSIS_AddNewCcapCmPair improvements [ID 39450]

Several improvements have been implemented in the EPM_I_DOCSIS_AddNewCcapCmPair script, which is used to create a new CCAP.

- Every page now includes a *Cancel* button, which you can use the terminate the script.
- If fields that must be filled in are still empty, the field validation will now prevent the user from proceeding.
- When the script has been fully executed, a final page is now displayed with important information regarding the element creation process. If a message labeled as "[ERROR]" is shown in this window, this means that the creation of a specific element could not be completed. If a message labeled as "[INFO]" is shown, this message contains important information regarding the creation of elements.

#### PNM threshold parameters now configurable for CM collectors via front end [ID 39603]

Up to now, to update the PNM threshold settings for all collectors, the Multiple Set feature had to be used. Now you can instead configure these via the front end, on the *Configuration* > *Thresholds Settings* > *PNM* page.

The following PNM parameters are available: Velocity Factor (VF) for Coax Cable, Non-Main-Tap Energy Ratio (NMTER) Threshold, Post-Main-Tap to Total Energy Ratio (Post-MTTER) Threshold, and Pre-Main-Tap to Total Energy Ratio (Pre-MTTER) Threshold.

To complete setting a parameter, click the *Apply* button. This will execute an automation script that will set the values to all CM collectors.

## Changes

### Enhancements

#### Boundaries updated for US/DS thresholds [ID 39507]

For the following parameters in the upstream and downstream threshold tables, the threshold boundaries were updated:

- For the upstream QAM channel for the CM collector, the Minimum Tx Power Level is now 25.0 dBmV.
- For the upstream QAM channel for the CCAP, the Maximum Timing Offset Level is now 10000 µs.
- For the downstream QAM channel for the CM collector, the Maximum Rx Power Level is now 20 dBmV.

#### Skyline EPM Platform information template adjusted to remove table name [ID 39508]

​The information template for the Skyline EPM Platform connector has been updated to remove the table name for the Percentage of US/DS Utilization parameters. Previously, in the topology, this was shown as "Percentage DS Utilization (DOCSIS DS Service Group: Percentage DS Utilization)", while now it is shown as "Percentage DS Utilization".

#### CCAP alarms now linked to EPM to allow navigation to EPM card from Alarm Console [ID 39539]

All alarms originating from the CCAP Core Overview table in any of the CCAP collectors are now linked to the EPM object, so that users can now navigate to the EPM object from the Alarm Console by right-clicking an alarm and selecting to open the EPM card.

#### Generic DOCSIS CM Collector: Improved performance [ID 39658]

The Generic DOCSIS CM Collector has been updated to improve performance. This enhancement should specifically reduce the load on the CPU.

### Fixes

#### Empty fiber nodes in dashboard because of separator issue in CSV files [ID 39552]

Because the CCAP Collector and CM Collector used both a comma and semicolon in files, and fiber node names could contain commas, this could cause incorrect parsing of subsequent columns, which could among others cause empty fiber nodes to be shown in the *Top 50 FN OFDMA Utilization* dashboard. To prevent this, a new method has been added to identify the separator in the CSV file to ensure correct data processing even when fiber node names contain special characters such as commas.
