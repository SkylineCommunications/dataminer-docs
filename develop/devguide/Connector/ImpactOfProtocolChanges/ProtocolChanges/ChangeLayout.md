---
uid: ChangeLayout
---

# Change layout

Changing the layout of a protocol is considered a major change and as such a major change is required in the version numbering.

This includes changing the page ordering and/or parameter positioning.

## Impact

A user that was used to work with a certain layout may no longer be able to work with the new layout.

*DIS MCC*

| Full ID | Error message | Description |
|---------|---------------|-------------|
| 2.22.1  | RemovedFromPage | Param '{paramPid}' was removed from page '{pageName}'. |

## Workarounds

Changes to page ordering and/or parameter positioning will be approved in case:

- The current layout is wrong (for example a parameter should have been placed in the general page instead, or the page that contains overall status KPIs is not the first one).

All other positioning layout changes will generally be rejected.
