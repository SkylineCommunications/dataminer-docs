---
uid: AddJobAttachmentV2 
---

# AddJobAttachmentV2

> [!NOTE]
> This method is solely intended for internal use by Skyline Communications employees.

Use this method to add an attachment to a job. Available from DataMiner 10.2.0 [CU9]/10.2.12 onwards.

> [!NOTE]
> From DataMiner 10.2.0 [CU9]/10.2.12 onwards, this method should be used instead of the [AddJobAttachment](xref:AddJobAttachment) method.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| jobID      | String | The ID of the job.                                   |
| fileName   | String | The name of the attachment file.                     |
| ID         | String | The ID retrieved through an UploadFile call (only available for Skyline employees). |

## Output

None.
