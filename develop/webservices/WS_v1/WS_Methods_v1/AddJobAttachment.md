---
uid: AddJobAttachment
---

# AddJobAttachment

Obsolete. Use the [AddJobAttachmentV2](xref:AddJobAttachmentV2) method instead.

> [!NOTE]
> This method is solely intended for internal use by Skyline Communications employees.

> [!IMPORTANT]
>
> - The Jobs app is obsolete ([end of life as of DataMiner 10.5.x](xref:Software_support_life_cycles)). Starting from DataMiner 10.5.0 [CU20]/10.5.0 [CU8]/10.6.11<!-- 46170 -->, any related methods are no longer available.
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
