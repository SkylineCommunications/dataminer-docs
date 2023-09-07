---
uid: SRM_apply_service_state_transitions_silently
---

# Silently applying service state transitions

The example below shows how you can apply service state transitions (Start, Stop, Pause, Standby, etc.) or force the same service state without user interaction by means of an Automation script.

```csharp
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Net.ResourceManager.Objects;
using Skyline.DataMiner.Automation;

    public class Script
    {
        public static void Run(Engine engine)
        {
            // Replace with reservation guid
            var ReservationGuid = Guid.NewGuid();

            // Replace with Element Name of the Booking Manager 
            string BookingManagerElementName = "Booking Manager";

            var sri = SrmManagers.ResourceManager.GetReservationInstance(ReservationGuid) as ServiceReservationInstance;
            

            var bookingManager = new BookingManager(engine,
                                    engine.FindElement(BookingManagerElementName));

            bookingManager.ApplyServiceState(engine, sri, "STANDBY");
        }
    }
```

> [!NOTE]
> This call will run asynchronously. An overloaded method can be used to run it synchronously.<!-- RN 30454 -->
