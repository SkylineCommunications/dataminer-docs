---
uid: GetBooking
---

# GetBooking

Use this method to retrieve a booking.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| bookingID  | String | The booking ID.                                      |

## Output

| Item             | Format                        | Description            |
|------------------|-------------------------------|------------------------|
| GetBookingResult | [DMABooking](xref:DMABooking) | The specified booking. |
