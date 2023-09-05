---  
uid: MajorChangeChecker_2_25_1  
---

# CheckIdxAttribute

## UpdatedIdxValue

### Description

Column with PID '{columnPid}' had its SLProtocol position changed from '{oldSLProtocolPosition}' into '{newSLProtocolPosition}'. Table PID '{tablePid}'.

### Properties

| Name         | Value              |
| ------------ | ------------------ |
| Category     | Param              |
| Full Id      | 2.25.1             |
| Severity     | Major              |
| Certainty    | Certain            |
| Source       | MajorChangeChecker |
| Fix Impact   | Breaking           |
| Has Code Fix | False              |

### Details

The SLProtocol position is based on the idx of the columns and will typically match with it.  
However, note that columns with type\="displaykey" are not known to SLProtocol.  
This means that even though the SLProtocol position is based on idx value, it will not alway match with it.
