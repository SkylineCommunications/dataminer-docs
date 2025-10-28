---
uid: ChangeUnicode
---

# Change Unicode

Changing a protocol to Unicode or removing the Unicode option from a protocol is considered a major change.

DIS MCC

| Full ID | Error message  | Description                             |
|---------|----------------|-----------------------------------------|
| 1.9.6   | AddedUnicode   | Unicode option on protocol was added.   |
| 1.9.7   | RemovedUnicode | Unicode option on protocol was removed. |

## Impact

Element data and trending in the database need to be removed entirely.

Changing a protocol using MySQL (no longer supported as of DataMiner 10.4.x) is not compatible.
Cassandra and STaaS are compatible since DataMiner version 10.6.1, RN43929. Values in *elementdata* are stored by default as Unicode UTF-16 encoding and Windows code page encoding in columns vu and v, allowing to switch between Unicode or not. Values that were inserted in *elementdata* before DataMiner 10.6.1 and were not modified since then could show unexpected characters when switching to Unicode. Read [Code pages](xref:AdvancedCodePages) to have a better understanding of Unicode and the needed steps to take when implementing Unicode.

## Actions to be taken

Manual removal of database when using MySQL.
