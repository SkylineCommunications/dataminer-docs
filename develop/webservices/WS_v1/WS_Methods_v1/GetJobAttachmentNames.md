---
uid: GetJobAttachmentNames
---

# GetJobAttachmentNames

Use this method to retrieve the names of all files attached to a specific job. Available from DataMiner 10.0.5 onwards.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| jobID      | String | The job ID.                                          |

## Output

| Item                         | Format          | Description                                        |
|------------------------------|-----------------|----------------------------------------------------|
| GetJobAttachmentNamesResult | Array of string | The names of the attachments of the specified job. |
