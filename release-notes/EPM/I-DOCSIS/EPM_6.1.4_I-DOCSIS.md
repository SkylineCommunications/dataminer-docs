---
uid: EPM_6.1.4_I-DOCSIS
---

# EPM 6.1.4 I-DOCSIS

## New features

#### Skyline EPM Platform: Automatic reset [ID_33767] [ID_33768]

To avoid inconsistencies such as empty service nodes, the reset logic in the Skyline EPM Platform connector will now be triggered automatically at regular intervals. These intervals are determined by the Reset Interval parameter. Its minimum value is 15 minutes, and its maximum value is 24 hours. The latter is also the default value.

This parameter is available in the EPM Platform visual overview under General, below the Perform Reset button.

## Changes

### Enhancements

#### CM QAM channel association [ID_33742]

The active channels used by the cable modem will now be retrieved in order to only poll the active channels for CMA QAM US and DS channels.

#### Backup of entities_config.json and relations_config.json [ID_33765]

A proper backup will now always be available for the entities_config.json and relations_config.json files.

The following failure scenarios will be taken into account:

- If it is possible to read from the permanent file or it is the first time the logic is executed, a backup is made of the file. After the backup has been successfully created, the file is copied to the permanent file.

- If it is not possible to read from the permanent file, the logic will check if a backup for the file is available and use it in the same way as the permanent file in the previous scenario.

- If it is not possible to read from the permanent file and no backup is available, the logic will be the same as when no config file is found, i.e. a reset will be done to assign new IDs.

#### Generic DOCSIS CM Collector: Export improvements [ID_33814]

A new export mechanism has been implemented in the Generic DOCSIS CM Collector connector, which will include the active QAM channels per CM. The files generated for each CCAP will be used by the CCAP elements to only poll the required channels per CM. In addition, logic was implemented to compress each exported file.

For debugging purposes, a button parameter has also been added that allows you to trigger the export mechanism.

### Fixes

#### Problem loading Skyline EPM Platform visual overview [ID_33785]

When a user went to the visual overview of one of the parents in the topology view (e.g. Hub) and then tried to go back to the visual overview of one of the children (e.g. CCAP core), it could occur that the Skyline EPM Platform visual overview did not load properly and did not display the correct values.

#### Generic DOCSIS CM Collector: Export directory not found [ID_33864]

An exception of type DirectoryNotFound could occur in the CCAP log files. To prevent this, the CM Collector connector will now check if a remote directory exists before it tries to copy files to it.

#### Decimal thresholds converted to integers [ID_33866]

In some cases, an incorrect status could be attributed to parameters such as US QAM TX Power Status, US QAM RX Power Status, etc. The cause of this was that decimal thresholds were converted to integers, so that decimals were compared against integers when the thresholds were validated. This issue has now been resolved.

#### Incorrect US QAM TX Power Status [ID_33867]

The US QAM TX Power Status could be reported incorrectly. To prevent this, DataMiner EPM will now discard any invalid (-1) power values before it checks whether all Tx power values are within the power thresholds range.
