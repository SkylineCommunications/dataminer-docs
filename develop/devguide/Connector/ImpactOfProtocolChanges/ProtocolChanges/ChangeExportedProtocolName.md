---
uid: ChangeExportedProtocolName
---

# Change exported protocol name

Changing the name of an exported protocol is considered a major change.

DIS MCC

| Full ID | Error message | Description |
|---------|---------------|-------------|
| 1.10.1  | UpdatedValue | DVE Protocol with Name '{dveProtocolName}' for Table '{tableId}' was changed into '{newDveProtocolName}'. |
| 1.10.2  | RemovedItem  | DVE Protocol with Name '{dveProtocolName}' for Table '{tableId}' was removed. |
| 1.16.1  | AddedElementPrefix | ElementPrefix was added to DVE Protocol with Name '{dveProtocolName}' for Table '{tableId}'. |
| 1.16.2  | RemovedElementPrefix | ElementPrefix was removed from DVE Protocol with Name '{dveProtocolName}' for Table '{tableId}'. |

## Impact

When upgrading to a new version with the change exported protocol name, previous virtual protocols (and elements) cannot be removed and linking between main and DVE elements is broken.

The old virtual elements are still linked to the old version and name.

This should only be allowed in case direct problem of duplicate protocol name would arise.

## Actions to be taken

A manual removal of the previous protocol version is required.

In case it was undesired to change the name:

- Create new version with previous "correct version" and take this into production. Then the linking will be fixed again.

You can just manually remove the "bad" main protocol which will remove the corresponding "bad" virtual protocols.

> [!NOTE]
> The above actions only work if the incorrect protocol did NOT create new DVEs, but only worked with DVEs previously created.
> If you have a 'mixed' setup where some DVEs are running version A and some are running the previous version B, then it will not be possible to just upload a new protocol that resets the version to B. The DVEs running version A will stick.

## Note

SW to use placeholder for Protocol Mother Name. (customers who adapt existing protocols to have multiple versions as production).
