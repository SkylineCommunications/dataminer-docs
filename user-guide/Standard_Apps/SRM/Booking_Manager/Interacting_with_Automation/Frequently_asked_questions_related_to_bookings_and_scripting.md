---
uid: Frequently_asked_questions_related_to_bookings_and_scripting
---

# Frequently asked questions related to bookings and scripting

### Can I update the content of the DataMiner service generated for each booking?

No, only the SRM framework is supposed to modify the content of the service, based on what has been booked/assigned. If a service does not reflect the content of the running booking at all times, this means there is an underlying problem.

### Can I use custom events to automatically update the booking (timing, resources)?

No, custom events cannot be used to modify the booking. This logic can instead be implemented as part of a custom element subscribing to bookings and triggering the update process when necessary.
