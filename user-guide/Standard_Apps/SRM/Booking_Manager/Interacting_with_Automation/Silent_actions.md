---
uid: Silent_actions
---

# Silent actions

Multiple "silent actions" are possible in scripts, allowing the scripts to interact with bookings without any user interaction. The section below lists the most common use cases. Adjusting bookings in ways that are not described below is not supported and could have a severe impact on the stability of SRM. However, if a specific feature you need is not described here, you can submit a feature request to Skyline to evaluate whether this could be added.

- [Finding the reference of an object](#finding-the-reference-of-an-object)

- [Creating a booking](#creating-a-booking)

- [Assigning resource, profile and parameter values](#assigning-resource-profile-and-parameter-values)

- [Adding properties to an existing booking](#adding-properties-to-an-existing-booking)

- [Applying booking life cycle transitions](#applying-booking-life-cycle-transitions)

- [Applying service state transitions](#applying-service-state-transitions)

- [Updating the timing of a booking](#updating-the-timing-of-a-booking)

## Finding the reference of an object

To configure custom Automation scripts so that they can manipulate SRM objects such as service definitions, resources, profiles, etc., you need to know their object reference.

You can find this using the SLNetClientTest tool.

> [!WARNING]
> Always be extremely careful when using SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

To do so:

1. Open the tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

2. Connect to the DMA. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

3. Go to *Advanced* > *App* > *SRM Surveyor* to open the SRM Surveyor.

4. Select the object type and click *Select Object Type*.

    For example:

    - A service definition GUID

        ![](~/user-guide/images/ServiceDefinitionGUID.png)

    - A node ID

        ![](~/user-guide/images/NodeID.png)

    - A resource GUID

        ![](~/user-guide/images/ResourceGUID.png)

    - A profile definition GUID

        ![](~/user-guide/images/ProfileDefinitionGUID.png)

    - A profile instance GUID

        ![](~/user-guide/images/ProfileInstanceGUID.png)

## Creating a booking

The example below shows how a booking can be created without user interaction by means of an Automation script.

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Library.Solutions.SRM.Model;
using Skyline.DataMiner.Net.ResourceManager.Objects;
using CustomEvent = Skyline.DataMiner.Library.Solutions.SRM.Model.Events.Event;
using Property = Skyline.DataMiner.Library.Solutions.SRM.Model.Properties.Property;

public class Script
{
 public static void Run(Engine engine)
 {
 // Update with relevant data
 string bookingManagerElementName = "Booking Manager";
 int bookingDurationSeconds = 3600;
 string bookingDescription = $"Booking {DateTime.Now.ToString("yyyyMMdd HHmmss")}";
 Guid serviceDefinitionId = Guid.Parse("c2583ca4-a55e-483f-a50e-7d5e0a6b357f");
 DateTime start = DateTime.Now.AddSeconds(20);
 DateTime end = start.AddSeconds(bookingDurationSeconds);

 var bookingManager = new BookingManager(engine,
 engine.FindElement(bookingManagerElementName));

 // Configuring booking main info - PLEASE USE VISUAL STUDIO TO SEE ALL OPTIONS
 var bookingData = new Booking
 {
 Description = bookingDescription,
 Recurrence = new Recurrence
 {
 StartDate = DateTime.SpecifyKind(start, DateTimeKind.Local),
 EndDate = DateTime.SpecifyKind(end, DateTimeKind.Local),
 },
 ServiceDefinition = serviceDefinitionId.ToString()
 };

 var functions = new Function[]
 {
 // Configuring node(s) - PLEASE USE VISUAL STUDIO TO SEE ALL OPTIONS
 new Function
 {
 Id = 1,
 //ShouldAutoSelectResource = true,
 SelectedResource = "0e7a1e0c-6b14-484f-ae13-46e71a522d7a",
 ProfileInstance = "73697f60-789f-4b9b-a1b0-4f7d5776a0e9"
 },
 new Function
 {
 Id = 2,
 //ShouldAutoSelectResource = true,
 SelectedResource = "77a391a1-d5a2-46e3-a6b6-e7b80d4cd139",
 ProfileInstance = "4e7941ab-ed99-4adc-bda3-ebe48b1b2602"
 }
 };

 // Selecting properties - PLEASE USE VISUAL STUDIO TO SEE ALL OPTIONS
 var properties = new List<Property>();
 var property = bookingManager.Properties.FirstOrDefault(x =>
 string.Equals(x.Name, "test property", StringComparison.InvariantCultureIgnoreCase));

 if (property != null)
 {
 property.Value = "test value";
 property.IsChecked = true;
 properties.Add(property);
 }

 // Selecting custom events - PLEASE USE VISUAL STUDIO TO SEE ALL OPTIONS
 var customEvents = new List<CustomEvent>();
 var customEvent = bookingManager.Events.FirstOrDefault(x =>
 string.Equals(x.Name, "test event", StringComparison.InvariantCultureIgnoreCase));

 if (customEvent != null)
 {
 customEvent.IsChecked = true;
 customEvents.Add(customEvent);
 }

 // Safe method, won't throw exceptions, though in case of error cannot be seen
 var success = bookingManager.TryCreateNewBooking(engine, bookingData,
 functions, customEvents, properties, null, out ReservationInstance reservation);

 // Not safe, this method will throw exceptions in case of failure, a try catch is necessary
 try
 {
 reservation = bookingManager.CreateNewBooking(engine, bookingData, functions, customEvents, properties);
 }
 catch (Exception e)
 {
 engine.GenerateInformation($"Failed to create booking {bookingData.Description} due to: {e}");
 }
 }
}
```

## Assigning resource, profile and parameter values

The example below shows how resource, profile and parameter values can be assigned to a booking without user interaction by means of an Automation script.

> [!NOTE]
> In case the booking is already running, you must force the service state to transition again so that LSO and Profile-Load Scripts will be executed to apply new settings or to configure the new resource.

```cs
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Library.Solutions.SRM.Model.AssignProfilesAndResources;
using Skyline.DataMiner.Library.Solutions.SRM.Model;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.ResourceManager.Objects;

public class Script
{
 public static void Run(Engine engine)
 {
 // Replace with reservation guid
 var reservationId = Guid.NewGuid();

 var reservationInstance = SrmManagers.ResourceManager.GetReservationInstance(reservationId) as ServiceReservationInstance;

 var requests = new[]
 {
 // Assign a resource (update with relevant data)
 new AssignResourceRequest
 {
 TargetNodeLabel = "DEC1",
 NewResourceId = Guid.Parse("4d4c6525-8fbc-419c-9250-7e8b59dd2fcb")

 },
 // Unassign a resource (update with relevant data)
 new AssignResourceRequest
 {
 TargetNodeLabel = "DEC2",
 NewResourceId = Guid.Empty

 },
 // Assign a profile instance (update with relevant data)
 new AssignResourceRequest
 {
 TargetNodeLabel = "DEC3",
 ProfileInstanceId = Guid.Parse("c4130041-21c5-4693-bbe5-ef1efe78ff04"),
 ByReference = false

 },
 };
 reservationInstance.AssignResources(engine, requests);

 // Assign a profile parameter value (update with relevant data)
 var request = new AssignResourceRequest
 {
 TargetNodeLabel = "DEC3",
 ProfileInstanceId = Guid.Parse("c4130041-21c5-4693-bbe5-ef1efe78ff04"),
 ByReference = false
 };
 var param = new Parameter
 {
 Id = Guid.Parse("7f8bd260-0d26-46c1-9093-08b16a5f7dcf"),
 Value = "abc"
 };
 request.OverriddenParameters.Add(param);
 reservationInstance.AssignResources(engine, request);

 // PLEASE USE VISUAL STUDIO TO SEE ALL OPTIONS ON AssignResourceRequest,
 // including manipulating parameters and instance on interface level
 }
}
```

## Adding properties to an existing booking

The example below shows how properties can be added to an existing booking without user interaction by means of an Automation script.

```cs
using System;
using System.Collections.Generic;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Library.Reservation;
using Skyline.DataMiner.Library.Solutions.SRM;

public class Script
{
 public static void Run(Engine engine)
 {
 // Replace with reservation guid
 var reservationId = Guid.NewGuid();

 var properties = new Dictionary<string, object> { { "testproperty", "testvalue" } };

 var reservationInstance = SrmManagers.ResourceManager.GetReservationInstance(reservationId);
 reservationInstance.UpdateServiceReservationProperties(properties);
 }
}
```

## Applying booking life cycle transitions

The example below shows how booking life cycle transitions (Finish, On-Hold, Confirm, Cancel or Delete) can be applied to an existing booking without user interaction by means of an Automation script.

> [!NOTE]
> Using the *TryChangeStateToConfirmed* call as illustrated below will also trigger any Created Booking custom script.

```cs
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Automation;

public class Script
{
 public static void Run(Engine engine)
 {
 // Replace with reservation guid
 var reservationId = Guid.NewGuid();

 // Replace with Element Name of the Booking Manager
 var bookingManagerElementName = "Booking Manager";

 var reservationInstance = SrmManagers.ResourceManager.GetReservationInstance(reservationId);

 var bookingManager = new BookingManager(engine,
 engine.FindElement(bookingManagerElementName));

 var result = bookingManager.TryChangeStateToConfirmed(engine, ref reservationInstance);
 //var result = bookingManager.TryFinish(engine, ref reservationInstance);
 //var result = bookingManager.TryChangeStateToOnHold(engine, ref reservationInstance);
 //var result = bookingManager.TryCancel(engine, ref reservationInstance);
 //var result = bookingManager.TryDelete(engine, reservationInstance);
 }
}
```

## Applying service state transitions

Applying service state transitions (Start, Stop, Pause, Standby, etc.) or forcing the same service state can be done by executing the *SRM_BookingAction* script with following input arguments:

- Booking Manager Element Info : *{"Action":2,"Element":"\<booking_manager_elementname>",<br>"Reason":null,"ServiceId":null,"TableIndex":"\<reservation_guid>"}*

- Action: *{"Events":\["EXTERNAL"\],"ServiceStates":\["\<target service state>"\]}*

## Updating the timing of a booking

The example below shows how the timing of a booking can be changed without user interaction by means of an Automation script.

> [!NOTE]
> The timing of events that have already been executed cannot be changed.

```cs
using System;
using Skyline.DataMiner.Library.Solutions.SRM;
using Skyline.DataMiner.Library.Solutions.SRM.Model.ReservationAction;
using Skyline.DataMiner.Automation;

public class Script
{
 public static void Run(Engine engine)
 {
 // Replace with reservation guid
 var reservationId = Guid.NewGuid();

 // Replace with Element Name of the Booking Manager
 string bookingManagerElementName = "Booking Manager";

 // Replace with expected timing
 DateTime start = DateTime.UtcNow.AddHours(2);
 DateTime end = start.AddHours(4);
 TimeSpan preRoll = TimeSpan.FromMinutes(5);
 TimeSpan postRoll = TimeSpan.FromMinutes(5);

 var reservationInstance = SrmManagers.ResourceManager.GetReservationInstance(reservationId);

 var bookingManager = new BookingManager(engine,
 engine.FindElement(bookingManagerElementName));

 var newTiming = new ChangeTimeInputData
 {
 StartDate = start,
 EndDate = end,
 PreRoll = preRoll,
 PostRoll = postRoll,
 IsSilent = true
 };

 var result = bookingManager.TryChangeTime(engine, ref reservationInstance, newTiming);
 }
}
```
