---
uid: GetBookings
---

# GetBookings

Use this method to retrieve all bookings matching a filter.

## Input

| Item       | Format  | Description                                                          |
|------------|---------|----------------------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp).                 |
| filter     | String  | The filter that the bookings must match.                             |
| amount     | Integer | The number of bookings matching the filter that should be retrieved. |

## Output

| Item | Format | Description |
|--|--|--|
| GetBookingsResult | Array of [DMABooking](xref:DMABooking) | The bookings matching the filter. |
