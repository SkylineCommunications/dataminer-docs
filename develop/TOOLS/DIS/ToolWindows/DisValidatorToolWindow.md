---
uid: DisValidatorToolWindow
---

# DIS Validator

If you click *Tool Windows > DIS Validator*, the *DIS Validator* window will appear.

This window lists the results of the latest protocol validation in a treegrid structure, grouped by severity and category.

At the top of the tool window, you can find the following buttons:

- Click *Validate* to launch a new protocol validation.
- Click *Export* to export the results of the latest validation to a CSV file.
- Click the ![Show/hide suppressed results](~/develop/images/DisValidatorToolWindowToggleResultsIcon.png) icon to toggle visualization of the results to only show the Active items or all items (i.e., Active, Suppressed and Postponed items).

> [!NOTE]
> As of DIS v2.41, when you open a main DVE protocol and click *Validate*, DIS will not only validate the main protocol but also all its exported child DVE protocols.

The validator results are listed in a treegrid which groups the validation results by their severity. The treegrid has the following columns:

- Description: Description: Description of the issue
- Information icon: This icon is shown in case more information is available about this validator check. Clicking the information icon will open a pop-up window which provided more details about the validator check.
- Autofix icon: If this icon is displayed, an auto-fix is available. To execute the fix, from the context menu, select either *Fix* > *This error* or *Fix* > *All errors of this type*
- State: Shows the state of this validation result (Active, Postponed or Suppressed). 
- Certainty: Specifies whether the validator is certain or uncertain about the validity of the detected issue.
- Fix Impact: Indicates whether fixing the issues results in a breaking change.
- Category: Displays the category of the check (e.g. Param or Protocol).
- Code: Displays the unique code of the validator check.
- Line: Specifies the line number where the detected issue.
- Column: Specifies the column number where the issue was detected.
- DVE: Displays the name of the DVE protocol in case this validation result belongs to a DVE protocol.

![DIS Validator tool window](~/develop/images/DisValidatorToolWindow.png)

## Suppressing or postponing a validation result

In case a validation result is not valid, it can be suppressed. To suppress a validation result, select the item from the list, right click to open the context menu and select *Suppress...* from the context menu. In the *Suppress Validator Result* window that appears, provide a reason why the result has been suppressed.

![DIS Validator tool window context menu](~/develop/images/DisValidatorToolWindowContextMenu.png)

This will now introduce an XML comment in the protocol XML which is taken into account by the validator when validating and generating results:

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

Alternatively, a validation result can be postponed to be tackled at a later point. To postpone a specific validation result or all validation results of a specific type, select *Postpone* > *This error...* or *Postpone* > *All errors of this type...* from the context menu, respectively.

In the popup window, provide the ID of the DCP task that was created to tackle this issue. And provide a description of why fixing this validation result is postponed.

## Navigating to the corresponding location

To navigate to the location where the issue was detected, either double-click on the row or , from the context menu, select *Navigate*.