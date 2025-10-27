---
uid: SRM_launching_booking_wizard_pages
---

# Launching specific pages of the standard Booking Wizard from a custom script

From a custom script, you can launch the standard Booking Wizard and show only specific pages of that wizard. This way, you can execute the actions of some of the pages silently, but still use user interaction for other pages.

To do so:

- Create a *WizardUserInteraction* object defining which pages will be presented to user, for example:<!-- RN 30376 -->

  ```csharp
  var wizardUserInteraction = new WizardUserInteraction
  {
      CreateNewBooking = false,
      AssignProfilesAndResources = true,
      ManageEvents = false,
      ManageProperties = false
  };
  ```

- Use the same code as is used to [silently create a booking](xref:SRM_creating_booking_silently), but use the overloaded *TryCreateNewBooking* or *TryEditBooking* method:

  ```csharp
  bookingManager.TryCreateNewBooking(Engine, wizardUserInteraction, bookingData, this.functions, null, bookingProperties, out reservation);
  ```

  ```csharp
  bookingManager.TryEditBooking(Engine, wizardUserInteraction, reservationId, bookingData, null, null, null, null);
  ```
