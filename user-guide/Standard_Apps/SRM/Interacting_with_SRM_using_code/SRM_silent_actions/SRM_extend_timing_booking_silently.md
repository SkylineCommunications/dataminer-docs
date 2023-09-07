---
uid: SRM_extend_timing_booking_silently
---

# Silently extending the timing of a booking

The example below shows how the timing of a booking can be extended without user interaction by means of an Automation script.<!-- RN 26212 -->

```csharp
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Automation;

namespace SRMSolution_SilentActions.Extend
{
    public class Script
    {
        public static void Run(Engine engine)
        {
            // Replace with reservation guid
            var ReservationGuid = Guid.NewGuid();

            // Replace with Element Name of the Booking Manager 
            string BookingManagerElementName = "Booking Manager";

            var sri = SrmManagers.ResourceManager.GetReservationInstance(ReservationGuid);

            var bookingManager = new BookingManager(engine,
                                    engine.FindElement(BookingManagerElementName));

            var extendBookingInputData = new Skyline.DataMiner.Library.Solutions.SRM.Model.ReservationAction.ExtendBookingInputData();
            extendBookingInputData.TimeToAdd = new TimeSpan(1, 0, 0);


            var result = bookingManager.TryExtend(engine, ref sri, extendBookingInputData);
            
        }
    }
}
```
