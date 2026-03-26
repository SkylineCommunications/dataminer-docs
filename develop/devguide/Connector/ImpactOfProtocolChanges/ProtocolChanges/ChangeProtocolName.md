---
uid: ChangeProtocolName
---

# Change protocol name

Changing the name of a protocol is considered a major change.

DIS MCC

| Full ID | Error message | Description                                                         |
|---------|---------------|---------------------------------------------------------------------|
| 1.2.6   | UpdatedValue  | Protocol Name '{oldProtocolName}' changed into '{newProtocolName}'. |

## Impact

- Live updates will be broken.
- Elements will need to use the new protocol, and possible existing configurations may be broken (monitoring, reports, filters, automation scripts).
- Users with an *allowed protocols* license may need a license change.
