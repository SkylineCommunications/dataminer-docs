---
uid: LogicActionReadFile
---

# read file

This action must be executed on protocol.

This action reads the specified file contents.

## Attributes

### Type@id

The ID of the parameter containing the directory in which the file can be found.

### Type@nr

(optional): The ID of the parameter containing the number of bytes to read. Defaults to reading the entire file.

### Type@returnValue

The ID of the parameter in which to store the retrieved file content.

### Type@startoffset

(optional): The ID of the parameter containing the start offset (i.e., the number of bytes to skip before starting to read the file). Defaults to a start offset of 0.

## Remarks

This action can also be executed from within a QAction.

## Examples

The following action will read a number of bytes (found in parameter 3) from the file (located in the directory found in parameter 1), and will store those bytes in parameter 2. In the file, it will start reading after having skipped the number of bytes found in parameter 4:

```xml
<Action id="1">
  <On>protocol</On>
  <Type id="1" returnValue="2" nr="3" startoffset="4">read file</Type>
</Action>
```
