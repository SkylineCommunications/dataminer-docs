---
uid: GetBookingAttachmentNames
---

# GetBookingAttachmentNames

Use this method to retrieve the names of all files attached to a specific booking.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| bookingID  | String | The booking ID.                                      |

## Output

| Item                             | Format          | Description                                            |
|----------------------------------|-----------------|--------------------------------------------------------|
| GetBookingAttachmentNamesResult | Array of string | The names of the attachments of the specified booking. |
