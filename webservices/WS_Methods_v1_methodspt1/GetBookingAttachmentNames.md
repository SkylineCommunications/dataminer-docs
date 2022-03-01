---
uid: GetBookingAttachmentNames
---

# GetBookingAttachmentNames

Use this method to retrieve the names of all files attached to a specific booking.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp) . |
| BookingID  | String | The booking ID.                                      |

## Output

| Item                             | Format          | Description                                            |
|----------------------------------|-----------------|--------------------------------------------------------|
| GetBookingAttachment­NamesResult | Array of string | The names of the attachments of the specified booking. |

