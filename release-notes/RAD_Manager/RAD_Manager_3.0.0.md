---
uid: RAD_Manager_3.0.0
---

# RAD Manager 3.0.0

> [!NOTE]
> This version of RAD Manager requires the [GQI DxM](https://aka.dataminer.services/gqi-dxm). Make sure the GQI DxM is installed and enabled before installing the RAD Manager, or use RAD Manager version 2.0.4.

## Changes

### Enhancements

#### Is Monitored column added in relational anomaly groups table [ID 42915]

An 'Is Monitored' column has been added to the relational anomaly groups table to indicate the monitoring status of each group. If there are issues, an error icon and red text are displayed; if everything is functioning correctly, the text remains black. When the error icon is clicked, a message appears referring the user to SLAnalytics logging for more details.

#### Removing multiple relational anomaly groups at once [ID 42915]

It is now possible to select multiple relational anomaly groups and remove them at once using the 'Remove group' button.

### Fixes

#### Groups only shown when users have access [ID 43324]

Starting from DataMiner version 10.5.9/10.6.0 <!--RN 43320-->, groups are hidden whenever a user does not have access to any of the parameters in those groups.

#### Correct default thresholds in RAD Manager [ID 43405]

The default settings for relational anomaly groups, as implemented in DataMiner version 10.5.9/10.6.0 <!--RN 43400-->, are now displayed correctly when creating new groups in the RAD Manager.

#### Improved dialogs for group actions [ID 43474]

The dialogs to add, edit, delete, or retrain relational anomaly groups now appear immediately after clicking the respective buttons. In previous versions, it could take up to 20 seconds before these dialogs were shown.
