---
uid: ChangeUnicode
---

# Change Unicode

Changing a protocol to Unicode or removing Unicode from a protocol is considered a major change.

DIS MCC

| Full ID | Error message | Description |
|---------|---------------|-------------|
| 1.9.6   | AddedUnicode   | Unicode option on protocol was added.   |
| 1.9.7   | RemovedUnicode | Unicode option on protocol was removed. |

## Impact

Element Data and Trend database needs to be removed entirely.

For DMA versions prior to 10.4.x, changing a protocol using MySQL and Cassandra should be compatible (MySQL not supported as of 10.4.x). Values in *elementdata* are stored by default as Unicode and ASCII v and vu.

To be verified as from which DMA version it will be considered no longer an impacting change. Until clarified, we will still consider it an impacting change. See [task 106112](https://collaboration.dataminer.services/task/106112)

## Actions to be taken

Manual removal of database
