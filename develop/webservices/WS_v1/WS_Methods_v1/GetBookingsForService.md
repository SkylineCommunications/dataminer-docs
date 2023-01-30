---
uid: GetBookingsForService
---

# GetBookingsForService

Use this method to retrieve all bookings that make use of the specified service.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| serviceID | Integer | The service ID. |
| utcStartTime | Long integer | The start time of the timespan for which the bookings should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| utcEndTime | Long integer | The end time of the timespan for which the bookings should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |

## Output

| Item | Format | Description |
|--|--|--|
| GetBookingsForServiceResult | Array of [DMABooking](xref:DMABooking) | The bookings using the specified service. |
