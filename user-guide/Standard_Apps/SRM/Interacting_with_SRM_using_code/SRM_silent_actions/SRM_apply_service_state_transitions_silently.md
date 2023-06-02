---
uid: SRM_apply_service_state_transitions_silently
---

# Silently applying service state transitions

In an Automation script, you can apply service state transitions (Start, Stop, Pause, Standby, etc.) or force the same service state without user interaction by executing the *SRM_BookingAction* script with the following input arguments:

- Booking Manager Element Info : *{"Action":2,"Element":"\<booking_manager_elementname>",<br>"Reason":null,"ServiceId":null,"TableIndex":"\<reservation_guid>"}*

- Action: *{"Events":\["EXTERNAL"\],"ServiceStates":\["\<target service state>"\]}*
