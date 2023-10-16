---
uid: BPA_SRM_Framework_Configuration
---

# SRM Framework Configuration

This BPA test checks for bookings with invalid properties that have an end date in the future.

This test is currently not available yet but will soon be released as part of the SRM framework.<!-- RN 37417 -->

> [!NOTE]
> Depending on the number of bookings in the system, the BPA test can take some time to run.

## Metadata

- Name: SRM Framework Configuration
- Description: Detects invalid SRM configurations
- Author: Skyline Communications
- Default schedule: Daily

## Results

### Success

No inconsistencies have been detected in the system.

Result message: `No invalid bookings detected in the system.`

### Error

One or more issues have been found:

- The booking does not have properties with the name *Booking Manager*, *Booking Life Cycle*, *FriendlyReference*, *PreRoll*, *PostRoll*, *Service State*, *Start*, *End*, *VisualBackground*, and/or *VisualForeground*.
- The booking has an empty value for the properties *Booking Manager*, *Booking Life Cycle*, *FriendlyReference*, *PreRoll*, *PostRoll*, *Service State*, *Start*, *End*, *VisualBackground*, and/or *VisualForeground*".
- The properties *Start* and *End* are not in DateTime format.
- The properties *PreRoll* and *PostRoll* are not in TimeSpan format.
- The *Start* - *PreRoll* property value is different from *Reservation.Start*.
- The *End* + *PostRoll* property value is different from *Reservation.End* while the *End* property does not have the value *Not Applicable*.
- The *PostRoll* property value is different from TimeSpan.Zero while the *End* property has the value *Not Applicable*.
- The *Booking Manager* property value refers to an existing DataMiner element using the connector *Skyline Booking Manager* but that element is not active.
- The booking does not have the *Virtual Platform* property or does have this property but with a value that is different from the element's *Default Virtual Platform* parameter.

### Warning

This BPA does not generate warnings.

### Not Executed

If the test fails to execute, this message is displayed:

- `Resource Manager is not initialized.`

## Impact when issues detected

- Impact: Bookings may not execute correctly.
- Action: Please contact your system administrator for support.

## Limitations

- Requires the SRM framework.
- Requires an SRM license.
- The Resource Manager needs to be initialized.
