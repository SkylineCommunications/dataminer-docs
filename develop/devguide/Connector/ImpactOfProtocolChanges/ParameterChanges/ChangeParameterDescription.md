---
uid: ChangeParameterDescription
---

# Change parameter description

Changing the parameter description is considered a major change.

## Impact

Changing the parameter description can impact the following (when used):

- Filters
- automation scripts
- Visio files
- Reports
- Dashboards
- Web API

Note that in the following cases, there is no actual impact and these types of changes can be done in the same range:

- Changes to capitalization of parameter descriptions
- Changes to descriptions of internal parameters (*RTDisplay* false)

*DIS MCC*

| Full ID | Error Message | Description                                                                                            |
|---------|---------------|--------------------------------------------------------------------------------------------------------|
| 2.14.1  | UpdatedValue  | Description tag on Param '{paramId}' was changed from '{previousDescription}' into '{newDescription}'. |
| 2.14.2  | RemovedItem   | Description tag with value '{descriptionValue}' on Param '{paramId}' was removed.                      |

## Workarounds

Changes to parameter descriptions will be approved in case one of the following conditions is met:

- The current parameter description is wrong.
- The current parameter description is not user-friendly (e.g. an abbreviation is used instead of writing the description in full).

All other parameter description changes will generally be rejected.

In case a user really insists that the description is changed, an information template can be created to change the description on the DMS of that user.
