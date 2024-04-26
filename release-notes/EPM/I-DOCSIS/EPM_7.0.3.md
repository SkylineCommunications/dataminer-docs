---
uid: EPM_7.0.3_I-DOCSIS
---

# EPM 7.0.3 I-DOCSIS (preview)

> [!IMPORTANT]
> We are still working on this release. Release notes may still be added, modified, or moved to a later release. Check back soon for updates!

## New features

#### EPM_I_DOCSIS_AddNewCcapCmPair improvements [ID_39450]

Several improvements have been implemented in the EPM_I_DOCSIS_AddNewCcapCmPair script, which is used to create a new CCAP.

- Every page now includes a *Cancel* button, which you can use the terminate the script.
- If fields that must be filled in are still empty, the field validation will now prevent the user from proceeding.
- When the script has been fully executed, a final page is now displayed with important information regarding the element creation process. If a message labeled as "[ERROR]" is shown in this window, this means that the creation of a specific element could not be completed. If a message labeled as "[INFO]" is shown, this message contains important information regarding the creation of elements.

## Changes

### Enhancements

#### Boundaries updated for US/DS thresholds [ID_39507]

For the following parameters in the upstream and downstream threshold tables, the threshold boundaries were updated:

- For the upstream QAM channel for the collector, the Minimum Tx Power Level is now 25.0 dBmV.
- For the upstream QAM channel for the CCAP, the Maximum Timing Offset Level is now 10000 µs.
- For the downstream QAM channel for the collector, the Maximum Rx Power Level is now 20 dBmV.

#### Skyline EPM Platform information template adjusted to remove table name [ID_39508]

​The information template for the Skyline EPM Platform connector has been updated to remove the table name for the Percentage of US/DS Utilization parameters. Previously, in the topology, this was shown as "Percentage DS Utilization (DOCSIS DS Service Group: Percentage DS Utilization)", while now it is shown as "Percentage DS Utilization".
