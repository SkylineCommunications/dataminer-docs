# SRM Framework Configuration

This BPA test checks for Bookings with invalid Properties that have end date in the future.

> [!NOTE]
> The BPA can take some time to run, depending on the amount of bookings in the system.
## Metadata

* Name: SRM Framework Configuration
* Description: Detects with invalid SRM Solution configurations.
* Author: Skyline Communications
* Default schedule: Daily

## Results

### Success

* "No invalid Bookings detected in the system.*

No inconsistencies have been detected in the system.

### Error

* "Booking doesn't have Property with names: 'Booking Manager', 'Booking Life Cycle', 'FriendlyReference', 'PreRoll', 'PostRoll', 'Service State', 'Start', 'End', 'VisualBackground' and 'VisualForeground'"
* "Booking has an empty value for Property 'Booking Manager', 'Booking Life Cycle', 'FriendlyReference', 'PreRoll', 'PostRoll', 'Service State', 'Start', 'End', 'VisualBackground' and 'VisualForeground'"
* "Properties 'Start' and 'End' are not in DateTime format"
* "Properties 'PreRoll' and 'PostRoll' are not in TimeSpan format"
* "'Start' - 'PreRoll' Property values is different from Reservation.Start"
* "'End' + 'PostRoll' Property values is different from Reservation.End when 'End' Property different from 'Not Applicable'"
* "'PostRoll' Property value is different from TimeSpan.Zero when 'End' Property is equal to 'Not Applicable'"
* "'Booking Manager' Property value refers to an existing DataMiner element using connector 'Skyline Booking Manager' and that element is not Active"
* "Booking doesn't have 'Virtual Platform' Property or this has a value different from the Element 'Default Virtual Platform' parameter"

### Warning

This BPA does not generate warnings.

### Not Executed

* "Resource Manager is not initialized"

## Impact when issues detected

- Impact: "Bookings may not execute correctly."
- Action: "Please contact 'support.automation-orchestration@skyline.be' for support."

## Limitations

- Needs the SRM framework.
- Needs an SRM license.
- Resource Manager needs to be initialized.