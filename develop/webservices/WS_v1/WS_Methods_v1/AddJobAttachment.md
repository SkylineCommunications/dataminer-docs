---
uid: AddJobAttachment
---

# AddJobAttachment

> [!NOTE]
> This method is solely intended for internal use by Skyline Communications employees.

Use this method to add an attachment to a job. Available from DataMiner 10.0.5 onwards.

> [!NOTE]
> From DataMiner 10.2.0 [CU9]/10.2.12 onwards, use the [AddJobAttachmentV2](xref:AddJobAttachmentV2) method instead.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| jobID      | String | The ID of the job.                                   |
| fileName   | String | The name of the attachment file.                     |
| path       | String | The file path of the attachment file.                |

## Output

None.
