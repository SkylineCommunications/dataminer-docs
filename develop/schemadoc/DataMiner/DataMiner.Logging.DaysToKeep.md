---
uid: DataMiner.Logging.DaysToKeep
---

# DaysToKeep element

Specifies how many days log files are kept in the `C:\Skyline DataMiner\Logging` folder.

## Content Type

integer

## Parents

[Logging](xref:DataMiner.Logging)

## Example

```xml
<DataMiner>
  ...
  <Logging>
  ...
  <DaysToKeep>30</DaysToKeep>
  </Logging>
  ...
</DataMiner>
```

## Remarks

If this tag is not specified or if its value is 0, log files will be kept for 100 days.
