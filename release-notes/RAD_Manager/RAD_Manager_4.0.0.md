---
uid: RAD_Manager_4.0.0
---

# RAD Manager 4.0.0

> [!NOTE]
> This RAD Manager version requires that **DataMiner 10.5.12/10.6.0 or higher** is installed.

## New features

#### Historical anomalies panel [ID 43829]

A *Historical Anomalies* button is now available in the upper right corner of the RAD Manager app. It opens a pane listing all detected historical anomalies for the selected relational anomaly group. In addition, the number of historical anomalies detected per group or subgroup is now shown in the relational anomaly groups grid on the left-hand side of the main page.

#### Shared model groups [ID 44091]

RAD Manager now supports shared model groups, i.e. groups that include multiple subgroups that share the same detection model. These are ideal when monitoring many similar entities or when some subgroups suffer from insufficient healthy training data.

You can add a shared model group in the RAD Manager app using the *Add Shared Model Group* button. Adding a single group remains possible with the *Add Single Group* button.

Both single and shared model groups are displayed in the relational anomaly groups grid on the left-hand side of the main page. To view the subgroups of a shared model group, you can click the group tile.

#### Outlier groups and subgroup sorting [ID 44227]

If one of the subgroups of a shared model group behaves significantly differently from other subgroups, it will now be labeled as an "Outlier group" so that it can easily be detected. In addition, you can now sort the subgroups of a shared model group based on the outlier score.

## Changes

### Enhancements

#### Retraining configuration integrated in add/edit group dialog [ID 44138]

The training configuration for relational anomaly groups has now been integrated in the dialog used to add or edit groups (both shared model and single group)s. In this dialog, you can now specify from which time range and from which subgroups data will be used to (re-)train the model of a group.

If this is not specified in the dialog to add a group, the default configuration will be used (i.e. data from all subgroups and from the last two months). If it is not specified in the dialog to edit a group, the model will remain unchanged, provided that the number of parameters in the group does not change.

#### Anomaly scores no longer cached when DataMiner supports caching [ID 44182]

From DataMiner 10.6.0/10.6.1 onwards, DataMiner itself will cache anomaly scores for  relational anomaly groups, making the cache in the RAD Manager itself redundant. For this reason, the internal RAD Manager cache will now only be used with older DataMiner versions.

#### Redesigned main page [ID 43829]

A major redesign of the RAD Manager main page has been implemented to enhance usability, provide better insights into relational anomaly groups, and align better with existing visual guidelines.

#### Dialog layout updated [ID 44217]

The dialogs in the RAD Manager app have been reworked:

- In the dialogs to add or edit a single or shared model group, the group options and the training configuration buttons are now shorter.
- In all dialogs, the *OK*, *Apply*, and *Cancel* buttons are now smaller, and they are shown on the right-hand side.

#### Support for adding DVE child element parameters to relational anomaly groups [ID 44244]

When you add or edit a relational anomaly group using the RAD Manager, you can now also select parameters from DVE child elements.

### Fixes

#### Parameter validation issue when editing group if first element has no trended parameters [ID 44206]

If the element that is alphabetically first in the system did not have a trended parameter, and you edited an existing single group (not a shared model group), the dropdown under *Parameter* was incorrectly shown in red. Now this will only be shown in red if another element is selected or if you tried pressing *Add*.
