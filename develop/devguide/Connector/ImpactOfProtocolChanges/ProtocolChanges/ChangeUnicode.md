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

If MySQL is used (no longer supported as of DataMiner 10.4.x), adding or removing the Unicode option in an existing protocol is not supported.

From DataMiner 10.6.1 onwards (RN 43929), Cassandra and STaaS support switching to and from Unicode. Values in *elementdata* are stored by default as Unicode UTF-16 encoding and Windows code page encoding in columns vu and v, allowing a switch to or from Unicode. Values that were inserted in *elementdata* before DataMiner 10.6.1 and that have not been modified since then could show unexpected characters when switching to Unicode.

To gain a better understanding of Unicode and the needed steps to take when implementing Unicode, refer to [Code pages](xref:AdvancedCodePages).

## Actions to be taken

If MySQL is used, manual removal from database.
