---
uid: GetBookingsForService
---

# GetBookingsForService

Use this method to retrieve all bookings that make use of the specified service.

## Input

| Item         | Format       | Description                                                                                                                                 |
|--------------|--------------|---------------------------------------------------------------------------------------------------------------------------------------------|
| Connection   | String       | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                        |
| DmaID        | Integer      | The DataMiner Agent ID.                                                                                                                     |
| ServiceID    | Integer      | The service ID.                                                                                                                             |
| UtcStartTime | Long integer | The start time of the timespan for which the bookings should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| UtcEndTime   | Long integer | The end time of the timespan for which the bookings should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT).   |

## Output

| Item                         | Format                                                                         | Description                               |
|------------------------------|--------------------------------------------------------------------------------|-------------------------------------------|
| GetBookingsforService­Result | Array of DMABooking (see [DMABooking](xref:DMABooking)) | The bookings using the specified service. |

