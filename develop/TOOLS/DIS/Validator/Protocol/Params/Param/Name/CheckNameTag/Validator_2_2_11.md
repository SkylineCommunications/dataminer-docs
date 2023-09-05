---  
uid: Validator_2_2_11  
---

# CheckNameTag

## RTDisplayExpectedOnQActionFeedback

### Description

RTDisplay(true) expected on Param '{qactionFeedbackPid}' used for QAction feedback.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.2.11      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Parameter with names ending with "\_QActionFeedback" are used to dynamically provide feedback from a QAction to (and only to) the user triggering the QAction.  
Example scenarios where such feature is used:  
\- Feedback from a QAction triggered by a table context menu.  
Such Param requires its RTDisplay tag to be set to true.
