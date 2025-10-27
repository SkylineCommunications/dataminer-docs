---
uid: RAD_Manager_3.0.0
---

# RAD Manager 3.0.0

> [!NOTE]
> This version of RAD Manager requires the [GQI DxM](https://aka.dataminer.services/gqi-dxm). Make sure the GQI DxM is installed and enabled before installing the RAD Manager, or use RAD Manager version 2.0.4.

## Changes

### Enhancements

#### 'Is Monitored' column added to relational anomaly groups table [ID 42915]

An *Is Monitored* column has been added to the relational anomaly groups table to indicate the monitoring status of each group. If there are issues, an error icon and red text are displayed. If everything is functioning correctly, the text remains black. When the error icon is clicked, a message appears, referring the user to the SLAnalytics logging for more details. 

Note that this new column requires DataMiner 10.5.9/10.6.0 or higher to be able to display the monitoring status.

#### Removing multiple relational anomaly groups at once [ID 42915]

It is now possible to select multiple relational anomaly groups and remove them at once using the *Remove group* button.

#### Improved layout of 'Update model' column [ID 43692]

The *Update model* column in the relational anomaly groups table now shows *Yes* or *No* instead of a check mark or an empty cell.

#### Improved startup time on DataMiner 10.5.9/10.6.0 [ID 43736]

On DataMiner 10.5.9/10.6.0 <!--RN 43299--> or newer, RAD Manager now starts up faster in most cases.

### Fixes

#### Groups only shown when users have access [ID 43324]

Starting from DataMiner version 10.5.9/10.6.0 <!--RN 43320-->, groups are hidden whenever a user does not have access to any of the parameters in them.

#### Correct default thresholds in RAD Manager [ID 43405]

The default settings for relational anomaly groups introduced in DataMiner version 10.5.9/10.6.0 <!--RN 43400--> are now displayed correctly when new groups are created in RAD Manager.

#### Improved dialogs for group actions [ID 43474]

The dialogs to add, edit, delete, or retrain relational anomaly groups now appear immediately after the respective buttons are clicked. In previous versions, it could take up to 20 seconds before these dialogs were shown.

#### Incorrect red border around 'Display key filter' field fixed [ID 43691]

In some cases, the *Display key filter* field in the *Add group* and *Edit group* dialogs could be highlighted with a red border and display the tooltip *No matching instance found* even though matching instances were available. This issue has been resolved, and the red border will now only be shown when there is an actual issue with the input in this field.
