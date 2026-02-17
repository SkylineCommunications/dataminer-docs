---
uid: DisValidatorToolWindow
---

# DIS Validator

If you click *Tool Windows > DIS Validator*, the *DIS Validator* window will appear.

This window lists the results of the latest protocol validation in a tree grid structure, grouped by severity and category.

At the top of the tool window, you can find the following buttons:

| Button | Description |
|--|--|
| Validate | Launches  a new protocol validation.<br>When you open a main DVE protocol and click *Validate*, DIS will not only validate the main protocol but also all its exported child DVE protocols. |
| Export | Exports the results of the latest validation to a CSV file. |
| ![Show/hide suppressed results](~/develop/images/DisValidatorToolWindowToggleResultsIcon.png) | Switches between showing only the active items or all items (i.e., active, suppressed, and postponed items). |

The validator results are listed in a tree grid that groups the validation results by their severity. The tree grid has the following columns:

| Column | Description |
|--|--|
| Description | A description of the issue. |
| Code | Displays the unique code of the validator check.<br>Clicking this code will open the online validator documentation in a browser window and show you more information about the error in question.<!-- RN 42396 --> |
| Auto-fix icon | If this icon is displayed, an auto-fix is available. To execute the fix, from the context menu, select either *Fix* > *This error* or *Fix* > *All errors of this type*. |
| State | Shows the state of this validation result (*Active*, *Postponed*, or *Suppressed*). |
| Certainty | Specifies whether the validator is certain or uncertain about the validity of the detected issue. If a result is uncertain, we recommend that you check the result and either fix the issue or [suppress the result](#suppressing-or-postponing-a-validation-result). |
| Fix Impact | Indicates whether fixing the issues results in a breaking change. |
| Category | Displays the category of the check (e.g., *Param* or *Protocol*). |
| Line | Specifies the line number where the issue was detected. |
| Column | Specifies the column number where the issue was detected. |
| DVE | Displays the name of the DVE protocol in case this validation result belongs to a DVE protocol. |

![DIS Validator tool window](~/develop/images/DisValidatorToolWindow.png)

## Suppressing or postponing a validation result

In case a validation result is not valid, it can be suppressed. While it is possible to suppress any validation result, in principle this should only be done for checks that are marked as "Uncertain". For such checks, a double-check is required as the automated validation cannot be certain. If there is a result that is indicated as "Certain", and you have the impression that this should be suppressed, this usually means that the check should be improved. In that case, you should report the issue and postpone the validation result. You can use the *Send Feedback* option in the DIS menu to report the issue. Skyline users should use the *Report Issue* option in the DIS menu (which is not available to external users), and create a validator issue task.

To **suppress** a validation result, select the item in the list, right-click to open the context menu, and select *Suppress*. In the *Suppress Validator Result* window, provide a reason why the result has been suppressed.

![DIS Validator tool window context menu](~/develop/images/DisValidatorToolWindowContextMenu.png)

This will introduce an XML comment in the protocol XML, which will be taken into account by the validator when validating and generating results:

```xml
<!-- SuppressValidator 2.9.7 No unit applicable. -->
<Display>
   <RTDisplay>true</RTDisplay>
   <Positions>
      <Position>
         <Page>General</Page>
         <Column>0</Column>
         <Row>0</Row>
      </Position>
   </Positions>
</Display>
<!-- /SuppressValidator 2.9.7 -->
```

To **postpone** a specific validation result or all validation results of a specific type, select *Postpone* > *This error* or *Postpone* > *All errors of this type* from the context menu, respectively. In the pop-up window, provide the ID of the DCP task that was created to tackle this issue, and provide a description of why fixing this validation result is postponed.

## Navigating to the corresponding location

To navigate to the location where the issue was detected, either double-click the row or select *Navigate* in the context menu.
