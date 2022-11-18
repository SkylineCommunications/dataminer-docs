---
uid: AddBookingAttachmentV2
---

# AddBookingAttachmentV2

> [!NOTE]
> This method is solely intended for internal use by Skyline Communications employees.

Use this method to add an attachment file to a booking. Available from DataMiner 10.2.0 [CU9]/10.2.12 onwards.

> [!NOTE]
> From DataMiner 10.2.0 [CU9]/10.2.12 onwards, this method should be used instead of the [AddBookingAttachment](xref:AddBookingAttachment) method.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| bookingID  | String | The booking ID.                                      |
| fileName   | String | The name of the attachment file.                     |
| ID         | String | The ID retrieved through an UploadFile call (only available for Skyline employees). |

## Output

None.
