---
uid: SRM_rename_booking_silently
---

# Silently renaming a booking

The example below shows how a booking and the associated DataMiner service can be renamed without user interaction by means of an Automation script.

```csharp
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Library.Solutions.SRM.Model.ReservationAction;
using Skyline.DataMiner.Automation;

    public class Script
    {
        public static void Run(Engine engine)
        {
            // Replace with reservation guid
            var ReservationGuid = Guid.NewGuid();

            // Replace with Element Name of the Booking Manager 
            string BookingManagerElementName = "Booking Manager";

            var bookingManager = new BookingManager(engine,
                                   engine.FindElement(BookingManagerElementName));

            var sri = SrmManagers.ResourceManager.GetReservationInstance(ReservationGuid);

            var changeNameInputData = new Skyline.DataMiner.Library.Solutions.SRM.Model.ReservationAction.ChangeNameInputData();
            changeNameInputData.Name = "my new booking name";
        
        // to make it silent
        changeNameInputData.IsSilent = true;
        
            var result = bookingManager.TryChangeName(engine, ref sri, changeNameInputData);
            
        }
    }
```
