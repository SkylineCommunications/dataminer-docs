---
uid: AddBookingAttachment
---

# AddBookingAttachment

> [!NOTE]
> This method is solely intended for internal use by Skyline Communications employees.

Use this method to add an attachment file to a booking. Available from DataMiner 10.0.10 onwards.

> [!NOTE]
> From DataMiner 10.2.0 [CU9]/10.2.12 onwards, use the [AddBookingAttachmentV2](xref:AddBookingAttachmentV2) method instead.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| bookingID  | String | The booking ID.                                      |
| fileName   | String | The name of the attachment file.                     |
| path       | String | The file path of the attachment file.                |

## Output

None.
