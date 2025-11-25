---
uid: AddJobAttachment
---

# AddJobAttachment

Obsolete. Use the [AddJobAttachmentV2](xref:AddJobAttachmentV2) method instead.

> [!NOTE]
> This method is solely intended for internal use by Skyline Communications employees.

> [!CAUTION]
>
> - The Jobs app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Jobs app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| jobID      | String | The ID of the job.                                   |
| fileName   | String | The name of the attachment file.                     |
| path       | String | The file path of the attachment file.                |

## Output

None.
