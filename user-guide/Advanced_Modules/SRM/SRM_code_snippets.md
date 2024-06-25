---
uid: SRM_code_snippets
---

# SRM code snippets

Much of the functionality of the Service & Resource Management module makes use of Automation scripts.

This section contains a number of code snippets illustrating how such scripts can be made:

- [Creating, retrieving, updating and deleting a resource](#creating-retrieving-updating-and-deleting-a-resource)

- [Creating, retrieving, updating and deleting a resource pool](#creating-retrieving-updating-and-deleting-a-resource-pool)

- [Creating, retrieving, updating and deleting a booking instance](#creating-retrieving-updating-and-deleting-a-booking-instance)

- [Creating, retrieving, updating and deleting a booking definition](#creating-retrieving-updating-and-deleting-a-booking-definition)

- [Creating a service booking definition with children](#creating-a-service-booking-definition-with-children)

- [Creating, retrieving, updating and deleting a profile parameter](#creating-retrieving-updating-and-deleting-a-profile-parameter)

- [Creating, retrieving, updating and deleting a profile definition](#creating-retrieving-updating-and-deleting-a-profile-definition)

- [Creating, retrieving, updating and deleting a profile instance](#creating-retrieving-updating-and-deleting-a-profile-instance)

- [Managing virtual function definitions](#managing-virtual-function-definitions)

#### Creating, retrieving, updating and deleting a resource

```cs
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using System;
using System.Linq;

namespace SRM.SRM_Resource_CRUD
{
 public class Script
 {
 // The ResourceManagerHelper object we will be using to communicate with the ResourceManager Module. This is our API.
 private ResourceManagerHelper _helper;

 public void Run(Engine engine)
 {
 // Initialize the ResourceManagerHelper
 _helper = new ResourceManagerHelper();

 // Handling the RequestResponseEvent gives the ResourceManagerHelper connection with SLNet.
 // Any server call the Helper makes behind the scenes calls this method.
 _helper.RequestResponseEvent += (sender, args) =>
 args.responseMessage = engine.SendSLNetSingleResponseMessage(args.requestMessage);

 var created = CreateResource();
 var retrieved = RetrieveResource(created.ID);
 var updated = UpdateResource(retrieved);
 DeleteResource(updated);
 }

 private Resource CreateResource()
 {
 var resource = new Resource("MyResource")
 {
 MaxConcurrency = 6 // Resource can be used by 6 ReservationInstances simultaneously
 };

 return _helper.AddOrUpdateResources(resource).FirstOrDefault();
 }

 private Resource RetrieveResource(Guid id)
 {
 var filter = ResourceExposers.ID.Equal(id);
 return _helper.GetResources(filter).FirstOrDefault();
 }

 private Resource UpdateResource(Resource resource)
 {
 // Let's assign an element to the resource
 resource.DmaID = 123;
 resource.ElementID = 456;

 // Reduce the maximum concurrency
 resource.MaxConcurrency = 2;

 return _helper.AddOrUpdateResources(resource).FirstOrDefault();
 }

 private void DeleteResource(Resource resource)
 {
 _helper.RemoveResources(resource);
 }
 }
}
```

#### Creating, retrieving, updating and deleting a resource pool

```cs
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SRM.SRM_ResourcePool_CRUD
{
 public class Script
 {
 // The ResourceManagerHelper object we will be using to communicate with the ResourceManager Module. This is our API.
 private ResourceManagerHelper _helper;

 public void Run(Engine engine)
 {
 // Initialize the ResourceManagerHelper
 _helper = new ResourceManagerHelper();

 // Handling the RequestResponseEvent gives the ResourceManagerHelper connection with SLNet.
 // Any server call the Helper makes behind the scenes calls this method.
 _helper.RequestResponseEvent += (sender, args) =>
 args.responseMessage = engine.SendSLNetSingleResponseMessage(args.requestMessage);

 var created = CreatePool();
 var retrieved = RetrievePool(created.ID);
 var updated = UpdatePool(retrieved);
 DeletePool(updated);
 }

 private ResourcePool CreatePool()
 {
 var resourcePool = new ResourcePool()
 {
 Description = "MyDescription",
 Name = "MyPool"
 };

 resourcePool.Properties.Add(new ResourceManagerProperty("PropName", "PropValue"));

 return _helper.AddOrUpdateResourcePools(resourcePool).FirstOrDefault();
 }

 private ResourcePool RetrievePool(Guid id)
 {
 return _helper.GetResourcePools(new ResourcePool(id)).FirstOrDefault();
 }

 private ResourcePool UpdatePool(ResourcePool resourcePool)
 {
 // Make a Resource in the given ResourcePool
 CreateResourceInPool(resourcePool.ID);

 // Add a property
 var property = new ResourceManagerProperty("SecondProp", "SecondValue");
 resourcePool.Properties.Add(property);

 return _helper.AddOrUpdateResourcePools(resourcePool).FirstOrDefault();
 }

 private void DeletePool(ResourcePool pool)
 {
 _helper.RemoveResourcePools(pool);
 }

 private void CreateResourceInPool(Guid resourcePoolId)
 {
 var resource = new Resource("MyResource")
 {
 PoolGUIDs = new List<Guid> { resourcePoolId }
 };

 _helper.AddOrUpdateResources(resource);
 }
 }
}
```

#### Creating, retrieving, updating and deleting a booking instance

```cs
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.ResourceManager.Objects;
using Skyline.DataMiner.Net.Time;
using System;
using System.Linq;

namespace SRM.SRM_BookingInstance_CRUD
{
 public class Script
 {
 // The ResourceManagerHelper object we will be using to communicate with the ResourceManager Module. This is our API.
 private ResourceManagerHelper _helper;

 public void Run(Engine engine)
 {
 // Initialize the ResourceManagerHelper
 _helper = new ResourceManagerHelper();

 // Handling the RequestResponseEvent gives the ResourceManagerHelper connection with SLNet.
 // Any server call the Helper makes behind the scenes calls this method.
 _helper.RequestResponseEvent += (sender, args) =>
 args.responseMessage = engine.SendSLNetSingleResponseMessage(args.requestMessage);

 var created = CreateReservationInstance();
 var retrievedById = RetrieveReservationInstance(created.ID);
 var retrieveByTiming = RetrieveReservationInstance(created.Start, created.End);
 var updated = UpdateReservationInstance(retrievedById);
 DeleteReservationInstance(updated);
 }

 private ReservationInstance CreateReservationInstance()
 {
 // Determine the time slot in which we want the instance to run.
 // It should start in 5 minutes, be active for 2 hours after that and we specify
 // that the timezone of the DateTime object is in local time.
 var timeRange = new TimeRangeUtc(DateTime.Now.AddMinutes(5), TimeSpan.FromHours(2), TimeZoneInfo.Local);
 var instance = new ReservationInstance(timeRange)
 {
 Name = "MyInstance",

 // Status on 'Confirmed' => it will be scheduled and events will be triggered
 // Status on 'Pending' => it will be scheduled, but no events will be triggered
 Status = ReservationStatus.Confirmed
 };

 return _helper.AddOrUpdateReservationInstances(instance).FirstOrDefault();
 }

 private ReservationInstance RetrieveReservationInstance(Guid id)
 {
 // Retrieve the ReservationInstance using its ID
 var filter = ReservationInstanceExposers.ID.Equal(id);
 return _helper.GetReservationInstances(filter).FirstOrDefault();
 }

 private ReservationInstance RetrieveReservationInstance(DateTime start, DateTime end)
 {
 // Retrieve the ReservationInstance using a time slot
 // We can merge filters by using the AND operator
 var filter = ReservationInstanceExposers.End.GreaterThan(start)
 .AND(ReservationInstanceExposers.Start.LessThan(end));

 return _helper.GetReservationInstances(filter).FirstOrDefault();
 }

 private ReservationInstance UpdateReservationInstance(ReservationInstance instance)
 {
 // Determine a new time range for the instance
 var timeRange = new TimeRangeUtc(DateTime.Now.AddHours(1), TimeSpan.FromHours(1), TimeZoneInfo.Local);
 var updated = instance.NewTimeRange(timeRange);

 return _helper.AddOrUpdateReservationInstances(updated).FirstOrDefault();
 }

 private void DeleteReservationInstance(ReservationInstance instance)
 {
 _helper.RemoveReservationInstances(instance);
 }
 }
}
```

#### Creating, retrieving, updating and deleting a booking definition

```cs
using Skyline.DataMiner.Net.Messages;
using System;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.ResourceManager.Objects;
using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Time;
using Skyline.DataMiner.Net.Messages.SLDataGateway;

namespace SRM.SRM_BookingDefinition_CRUD
{
 public class Script
 {
 // The ResourceManagerHelper object we will be using to communicate with the ResourceManager Module. This is our API.
 private ResourceManagerHelper _helper;

 public void Run(Engine engine)
 {
 // Initialize the ResourceManagerHelper
 _helper = new ResourceManagerHelper();

 // Handling the RequestResponseEvent gives the ResourceManagerHelper connection with SLNet.
 // Any server call the Helper makes behind the scenes calls this method.
 _helper.RequestResponseEvent += (sender, args) =>
 args.responseMessage = engine.SendSLNetSingleResponseMessage(args.requestMessage);

 var created = CreateReservationDefinition();
 var retrieved = RetrieveReservationDefinition(created.ID);
 var updated = UpdateReservationDefinition(retrieved);
 DeleteReservationDefinition(updated);
 }

 private ReservationDefinition CreateReservationDefinition()
 {
 // First we determine the recurrences.
 // Every day from 8h -> 9h
 var daily = new DailyRecurrence(TimeSpan.FromHours(8), TimeSpan.FromHours(1));

 // Every Saturday and Sunday, from 18h -> 20h
 var weekly = new WeeklyRecurrence(TimeSpan.FromHours(18), TimeSpan.FromHours(2), new[] { DayOfWeek.Saturday, DayOfWeek.Sunday });

 // Every first day of the month, from 10h -> 13h
 var monthly = new MonthlyRecurrence(TimeSpan.FromHours(10), TimeSpan.FromHours(3));
 monthly.AddDay(1);

 var recurrences = new RecurrenceBase[] { daily, weekly, monthly };

 // The ReservationDefinition starts tomorrow, and lasts for a year.
 var now = DateTime.Now;
 var timing = new RecurrenceTiming(now.Date.AddDays(1), now.Date.AddYears(1), recurrences, TimeZoneInfo.Local);

 // Create the ReservationDefinition with the configured RecurrenceTiming.
 var definition = new ReservationDefinition(timing)
 {
 Name = "MyDefinition",
 Description = "A definition containing daily, weekly and monthly recurrence",
 Status = ReservationStatus.Confirmed
 };

 return _helper.AddOrUpdateReservationDefinitions(definition).FirstOrDefault();
 }

 private ReservationDefinition RetrieveReservationDefinition(Guid id)
 {
 var filter = ReservationDefinitionExposers.ID.Equal(id);
 return _helper.GetReservationDefinitions(filter).FirstOrDefault();
 }

 private ReservationDefinition UpdateReservationDefinition(ReservationDefinition definition)
 {
 // Let's simplify the scheduling and only do the daily.
 var daily = new DailyRecurrence(TimeSpan.FromHours(8), TimeSpan.FromHours(1));
 var recurrences = new RecurrenceBase[] { daily };
 var now = DateTime.Now;

 // The ReservationDefinition starts tomorrow, and lasts for a year.
 var timing = new RecurrenceTiming(now.Date.AddDays(1), now.Date.AddYears(1), recurrences, TimeZoneInfo.Local);
 var updated = definition.NewTiming(timing);

 return _helper.AddOrUpdateReservationDefinitions(updated).FirstOrDefault();
 }

 private void DeleteReservationDefinition(ReservationDefinition definition)
 {
 _helper.RemoveReservationDefinitions(definition);
 }
 }
}
```

#### Creating a service booking definition with children

```cs
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.ResourceManager.Objects;
using Skyline.DataMiner.Net.Time;
using System;
using System.Collections.Generic;

namespace SRM.SRM_BookingDefinitionWithChildren_Create
{
 public class Script
 {
 // The ResourceManagerHelper object we will be using to communicate with the ResourceManager Module. This is our API.
 private ResourceManagerHelper _helper;
 private DateTime _utcNow;

 public void Run(Engine engine)
 {
 // Save the current time to calculate all other timings using the DT & T helper methods
 _utcNow = DateTime.UtcNow;

 // Initialize the ResourceManagerHelper
 _helper = new ResourceManagerHelper();

 // Handling the RequestResponseEvent gives the ResourceManagerHelper connection with SLNet.
 // Any server call the Helper makes behind the scenes calls this method.
 _helper.RequestResponseEvent += (sender, args) =>
 args.responseMessage = engine.SendSLNetSingleResponseMessage(args.requestMessage);

 CreateReservationDefinitionWithChildren();
 }

 /*
 * Reservations:
 * └─ Main (1)
 * ├─ ChildOne (2)
 * └─ ChildTwo (3)
 * └─ SubChild (4)
 *
 * ╔══════════════════════════════════════╗
 * ║ TIMELINE ║
 * ╠══════════════════════════════════════╣
 * ║ 0s 50s 100s 150s ║
 * ║ └────┴────┴────┴────┴────┴────┴────┘ ║
 * ║ 1_________11_________11_________1 ║
 * ║ 2__2 2__2 2__2 ║
 * ║ 3___3 3___3 3___3 ║
 * ║ 4_4 4_4 4_4 ║
 * ╚══════════════════════════════════════╝
 */
 private void CreateReservationDefinitionWithChildren()
 {
 // Main - 5 seconds -> 200 seconds
 var recurrences = new List<RecurrenceBase>()
 {
 new CustomRecurrence(new TimeRangeUtc(DT(1), DT(11), TimeZoneInfo.Local)), // 5 seconds - 55 seconds
 new CustomRecurrence(new TimeRangeUtc(DT(12), DT(22), TimeZoneInfo.Local)), // 60 seconds - 110 seconds
 new CustomRecurrence(new TimeRangeUtc(DT(23), DT(33), TimeZoneInfo.Local)), // 115 seconds - 165 seconds
 };

 var mainTiming = new RecurrenceTiming(DT(1), DT(40), recurrences, TimeZoneInfo.Local);
 var main = new ServiceReservationDefinition(mainTiming)
 {
 ID = Guid.NewGuid(),
 Status = ReservationStatus.Confirmed,
 Name = "Root"
 };

 // ChildOne - 5 seconds after start of parent (Main), duration of 15 seconds
 var childOneTiming = new RelativeTiming(T(3), T(1), EventExecutionTimeInfo.Marker.AfterStart);
 var childOne = new ServiceReservationDefinition(childOneTiming)
 {
 Status = ReservationStatus.Confirmed,
 Name = "Child1"
 };
 main.AddSubReservationDefinition(childOne);

 // ChildTwo - 25 seconds before end of parent (Main), duration of 20 seconds
 var childTwoTiming = new RelativeTiming(T(4), T(5), EventExecutionTimeInfo.Marker.BeforeEnd);
 var childTwo = new ServiceReservationDefinition(childTwoTiming)
 {
 Status = ReservationStatus.Confirmed,
 Name = "Child2"
 };
 main.AddSubReservationDefinition(childTwo);

 // SubChild - 5 seconds after start of parent (ChildTwo), duration of 10 seconds
 var subChildTiming = new RelativeTiming(T(2), T(1), EventExecutionTimeInfo.Marker.AfterStart);
 var subChild = new ServiceReservationDefinition(subChildTiming)
 {
 Status = ReservationStatus.Confirmed,
 Name = "Child2_1"
 };
 childTwo.AddSubReservationDefinition(subChild);

 // Save the main ReservationDefinition, this saves all the children as well
 _helper.AddOrUpdateReservationDefinitions(main);
 }

 private DateTime DT(int number, int stepSize = 5)
 {
 return _utcNow.AddSeconds(number * stepSize);
 }

 private TimeSpan T(int number, int stepsize = 5)
 {
 return TimeSpan.FromSeconds(number * stepsize);
 }
 }
}
```

#### Creating, retrieving, updating and deleting a profile parameter

```cs
using System;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Profiles;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Parameter = Skyline.DataMiner.Net.Profiles.Parameter;
using System.Linq;

namespace SRM.SRM_ProfileParameter_CRUD
{
 public class Script
 {
 // We use the ProfileHelper object to communicate with the ProfileManager Module. This is our API.
 private ProfileHelper _helper;

 public void Run(Engine engine)
 {
 // Initialize the ProfileHelper
 _helper = new ProfileHelper(engine.SendSLNetMessages);

 var created = CreateParameter();
 var retrieved = RetrieveParameter(created.ID);
 var updated = UpdateParameter(retrieved);
 DeleteParameter(updated);
 }

 private Parameter CreateParameter()
 {
 var parameter = new Parameter
 {
 Decimals = 5,
 DefaultValue = new ParameterValue()
 {
 Type = ParameterValue.ValueType.Double,
 DoubleValue = 12345
 },
 IsOptional = true,
 Name = "Amount of Apples",

 // Parameter can be linked to multiple protocols, each defined parameter shows an amount of apples
 ParameterReferences = new[]
 {
 new ProtocolParameterReference()
 {
 ParameterId = 201,
 ProtocolName = "Apple Farm",
 ProtocolVersion = "1.0.0.12"
 },
 new ProtocolParameterReference()
 {
 ParameterId = 101,
 ProtocolName = "Orchard Protocol",
 ProtocolVersion = "1.0.0.1",
 TableIndex = "Apple Counter" // Table index in case the ParameterId is a column parameter
 },
 new ProtocolParameterReference()
 {
 ParameterId = 1001,
 ProtocolName = "Forest Watch",
 ProtocolVersion = "5.4.0.14",
 TableIndex = "Harvested: Apples" // Table index in case the ParameterId is a column parameter
 }
 },
 RangeMax = 99999,
 RangeMin = 0,
 Remarks = "The amount of apples in the Orchard",
 Stepsize = 1,
 Type = Parameter.ParameterType.Number,
 Units = "Apples"
 };

 return _helper.ProfileParameters.Create(parameter);
 }

 private Parameter RetrieveParameter(Guid id)
 {
 var filter = ParameterExposers.ID.Equal(id);
 return _helper.ProfileParameters.Read(filter).FirstOrDefault();
 }

 private Parameter UpdateParameter(Parameter parameter)
 {
 parameter.Decimals = 6;
 parameter.Remarks = "Everybody likes apples";

 return _helper.ProfileParameters.Update(parameter);
 }

 private void DeleteParameter(Parameter parameter)
 {
 _helper.ProfileParameters.Delete(parameter);
 }
 }
}
```

#### Creating, retrieving, updating and deleting a profile definition

```cs
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Profiles;
using System;
using System.Linq;

namespace SRM.SRM_ProfileDefinition_CRUD
{
 public class Script
 {
 // We use the ProfileHelper object to communicate with the ProfileManager Module. This is our API.
 private ProfileHelper _helper;

 public void Run(Engine engine)
 {
 // Initialize the ProfileHelper
 _helper = new ProfileHelper(engine.SendSLNetMessages);

 var created = CreateProfileDefinition();
 var retrieved = RetrieveProfileDefinition(created.ID);
 var updated = UpdateProfileDefinition(retrieved);
 DeleteProfileDefinition(updated);
 }

 private ProfileDefinition CreateProfileDefinition()
 {
 var def = new ProfileDefinition
 {
 Description = "Description",
 Name = "Name",
 Scripts = new[]
 {
 new ScriptEntry()
 {
 Description = "Script Description",
 Name = "Script Name",
 Script = "Script:ScriptToRun|||||"
 }
 }
 };

 // ProfileDefinition can be based upon another ProfileDefinition (inheritance)
 // def.BasedOn.Add(...)

 // Create a new parameter linked to the ProfileDefinition (same method as in Profile Parameter code sample)
 def.Parameters.Add(CreateParameter());

 return _helper.ProfileDefinitions.Create(def);
 }

 private ProfileDefinition RetrieveProfileDefinition(Guid id)
 {
 var filter = ProfileDefinitionExposers.ID.Equal(id);
 return _helper.ProfileDefinitions.Read(filter).FirstOrDefault();
 }

 private ProfileDefinition UpdateProfileDefinition(ProfileDefinition profileDefinition)
 {
 profileDefinition.Description = "Another Description";

 // Create a new parameter linked to the ProfileDefinition (same method as in Profile Parameter code sample)
 profileDefinition.Parameters.Add(CreateParameter());

 return _helper.ProfileDefinitions.Update(profileDefinition);
 }

 private void DeleteProfileDefinition(ProfileDefinition profileDefinition)
 {
 _helper.ProfileDefinitions.Delete(profileDefinition);
 }
 }
}
```

#### Creating, retrieving, updating and deleting a profile instance

```cs
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Profiles;
using System;
using System.Linq;

namespace SRM.SRM_ProfileInstance_CRUD
{
 public class Script
 {
 // We use the ProfileHelper object to communicate with the ProfileManager Module. This is our API.
 private ProfileHelper _helper;

 public void Run(Engine engine)
 {
 // Initialize the ProfileHelper
 _helper = new ProfileHelper(engine.SendSLNetMessages);

 var created = CreateProfileInstance();
 var retrieved = RetrieveProfileInstance(created.ID);
 var updated = UpdateProfileInstance(retrieved);
 DeleteProfileInstance(updated);
 }

 private ProfileInstance CreateProfileInstance()
 {
 var instance = new ProfileInstance
 {
 // Create a ProfileDefinition (same method as in ProfileDefinition CRUD)
 AppliesTo = CreateProfileDefinition(),
 Description = "A description",
 Name = "A Name",
 Values = new[]
 {
 new ProfileParameterEntry()
 {
 // Create a new parameter linked to the ProfileDefinition (same method as in Profile Parameter code sample)
 Parameter = CreateParameter(),
 Remarks = "This is a thing",
 Value = new ParameterValue()
 {
 DoubleValue = 12345,
 Type = ParameterValue.ValueType.Double
 }
 }
 },
 };

 // ProfileInstance can be based upon another ProfileInstance (inheritance)
 // pi.BasedOn.Add(...);

 return _helper.ProfileInstances.Create(instance);
 }

 private ProfileInstance UpdateProfileInstance(ProfileInstance instance)
 {
 instance.Name = "Another Name";
 instance.Description = "Another Description";

 return _helper.ProfileInstances.Update(instance);
 }

 private ProfileInstance RetrieveProfileInstance(Guid id)
 {
 var filter = ProfileInstanceExposers.ID.Equal(id);
 return _helper.ProfileInstances.Read(filter).FirstOrDefault();
 }

 private void DeleteProfileInstance(ProfileInstance profileInstance)
 {
 _helper.ProfileInstances.Delete(profileInstance);
 }
 }
}
```

#### Managing virtual function definitions

A ProtocolFunctionHelper class is available that facilitates the creation of Automation scripts dealing with virtual function definitions.

The example below illustrates the use of the various methods in this class.

##### [From DataMiner 10.4.6/10.5.0 onwards](#tab/tabid-1)

<!--RN 39362-->

```cs
using System;
using System.Collections.Generic;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.ServiceManager.Objects;

namespace SRM.SRM_FunctionDefinitions
{
    public class Script
    {
        private ProtocolFunctionHelper _helper;

        public void Run(Engine engine)
        {
            // Initialize the ProtocolFunctionHelper
            _helper = new ProtocolFunctionHelper();

            // Handling the RequestResponseEvent gives the ProtocolFunctionHelper connection with SLNet.
            // Any server call the Helper makes behind the scenes calls this method.
            _helper.RequestResponseEvent += (sender, args) =>
                args.responseMessage = engine.SendSLNetSingleResponseMessage(args.requestMessage);

            // Retrieve the ProtocolFunction configuration
            var config = _helper.GetProtocolFunctionConfig();

            // Update the function hysteresis value to 12 days
            config.FunctionHysteresis = TimeSpan.FromDays(12);
            _helper.SetProtocolFunctionConfig(config);

            // Add a function
            var protocolName = "STA_DCF_DEVICE";
            var newVersion = "1.1.0.0";
            var functionDefinition = AddFunctionToFunctionsXml(protocolName, newVersion);

            // Set the current functions XML to the new version
            _helper.SetCurrentFunctionsXml(protocolName, newVersion);
            // Get the EntryPoints of the specified function and element
            _helper.GetFunctionEntryPoints(functionDefinition.GUID, 1337, 360);
            
            // Delete the functions XML
            _helper.DeleteFunctionsXml(protocolName, newVersion);

            // You can also force delete the functions XML by setting the third 'force' attribute to true
            _helper.DeleteFunctionsXml(protocolName, newVersion, true);

            // Retrieve all protocol functions
            var functions = _helper.GetProtocolFunctions(protocolName);

            // If a function definition is already present on the system, you can get it by passing the FunctionDefinitionID to GetFunctionDefinition:
            var sysFunctionDefinition = _helper.GetFunctionDefinition(new FunctionDefinitionID(Guid.Parse("da1f3250-0e32-4584-bc4d-7595fb7a3fad")));
            // Or if you need multiple function definitions, pass a list of FunctionDefinitionIDs to GetFunctionDefinitions:
            var functionDefinitionIds = new List<FunctionDefinitionID>()
            {
                new FunctionDefinitionID(Guid.Parse("521a23f6-eb31-4e7b-b06b-3c730ee91c47")),
                new FunctionDefinitionID(Guid.Parse("4f724aa3-b205-4d3b-a251-e9fc4eab1842"))
            };
            var functionDefinitions = _helper.GetFunctionDefinitions(functionDefinitionIds);
        }

        private FunctionDefinition AddFunctionToFunctionsXml(string protocolName, string newVersion)
        {
            var functionDefinition = new FunctionDefinition
            {
                GUID = Guid.NewGuid(),
                Name = "Decoder",
                MaxInstances = 2,

                // Define the input only interfaces
                InputInterfaces = new[]
                {
                    new FunctionInterface()
                    {
                        Name = "SD IN", InterfaceType = InterfaceType.In, ParameterGroupLink = 500, Id = 100
                    }
                },

                // Define the input/output interfaces
                InputOutputInterfaces = new[]
                {
                    new FunctionInterface()
                    {
                        Name = "SD IN/OUT",
                        InterfaceType = InterfaceType.InOut,
                        ParameterGroupLink = 502,
                        Id = 101
                    }
                },

                // Define the output only interfaces
                OutputInterfaces = new[]
                {
                    new FunctionInterface()
                    {
                        Name = "SD OUT", InterfaceType = InterfaceType.Out, ParameterGroupLink = 501, Id = 102
                    }
                },

                // Define the FunctionParameters
                Parameters = new[] {new FunctionParameter(500), new FunctionParameter(5), new FunctionParameter(6),},

                // Define the entry points
                EntryPoints = new[] {new FunctionEntryPointDefinition {ParameterId = 500}},
            };

            // Wrap the FunctionDefinition in a ProtocolFunctionVersion
            // and add it to the functions XML of a protocol
            var protocolFunctionVersion = new ProtocolFunctionVersion
            {
                Version = newVersion,
                ProtocolName = protocolName,
                FunctionDefinitions = new List<FunctionDefinition> {functionDefinition}
            };

            _helper.AddFunctionsToFunctionsXml(protocolName, protocolFunctionVersion);
            return functionDefinition;
        }
    }
}
```

##### [Prior to DataMiner 10.4.6/10.5.0](#tab/tabid-2)

```cs
using System;
using System.Collections.Generic;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.ServiceManager.Objects;

namespace SRM.SRM_FunctionDefinitions
{
 public class Script
 {
 private ProtocolFunctionHelper _helper;

 public void Run(Engine engine)
 {
 // Initialize the ProtocolFunctionHelper
 _helper = new ProtocolFunctionHelper();

 // Handling the RequestResponseEvent gives the ProtocolFunctionHelper connection with SLNet.
 // Any server call the Helper makes behind the scenes calls this method.
 _helper.RequestResponseEvent += (sender, args) =>
 args.responseMessage = engine.SendSLNetSingleResponseMessage(args.requestMessage);

 // Retrieve the ProtocolFunction configuration
 var config = _helper.GetProtocolFunctionConfig();

 // Update the function hysteresis value to 12 days
 config.FunctionHysteresis = TimeSpan.FromDays(12);
 _helper.SetProtocolFunctionConfig(config);

 // Add a function
 var protocolName = "STA_DCF_DEVICE";
 var newVersion = "1.1.0.0";
 var functionDefinition = AddFunctionToFunctionsXml(protocolName, newVersion);

 // Set the current functions XML to the new version
 _helper.SetCurrentFunctionsXml(protocolName, newVersion);

 // Get the EntryPoints of the specified function and element
 _helper.GetFunctionEntryPoints(functionDefinition.GUID, 1337, 360);

 // Delete the functions XML
 _helper.DeleteFunctionsXml(protocolName, newVersion);

 // You can also force delete the functions XML by setting the third 'force' attribute to true
 _helper.DeleteFunctionsXml(protocolName, newVersion, true);

 // Retrieve all protocol functions
 var functions = _helper.GetProtocolFunctions(protocolName);
 }

 private FunctionDefinition AddFunctionToFunctionsXml(string protocolName, string newVersion)
 {
 var functionDefinition = new FunctionDefinition
 {
 GUID = Guid.NewGuid(),
 Name = "Decoder",
 MaxInstances = 2,

 // Define the input only interfaces
 InputInterfaces = new[]
 {
 new FunctionInterface()
 {
 Name = "SD IN",
 InterfaceType = InterfaceType.In,
 ParameterGroupLink = 500,
 Id = 100
 }
 },

 // Define the input/output interfaces
 InputOutputInterfaces = new[]
 {
 new FunctionInterface()
 {
 Name = "SD IN/OUT",
 InterfaceType = InterfaceType.InOut,
 ParameterGroupLink = 502,
 Id = 101
 }
 },

 // Define the output only interfaces
 OutputInterfaces = new[]
 {
 new FunctionInterface()
 {
 Name = "SD OUT",
 InterfaceType = InterfaceType.Out,
 ParameterGroupLink = 501,
 Id = 102
 }
 },

 // Define the FunctionParameters
 Parameters = new []
 {
 new FunctionParameter(500),
 new FunctionParameter(5),
 new FunctionParameter(6),
 },

 // Define the entry points
 EntryPoints = new[]
 {
 new FunctionEntryPointDefinition
 {
 ParameterId = 500
 }
 },
 };

 // Wrap the FunctionDefinition in a ProtocolFunctionVersion
 // and add it to the functions XML of a protocol
 var protocolFunctionVersion = new ProtocolFunctionVersion
 {
 Version = newVersion,
 ProtocolName = protocolName,
 FunctionDefinitions = new List<FunctionDefinition> { functionDefinition }
 };

 _helper.AddFunctionsToFunctionsXml(protocolName, protocolFunctionVersion);
 return functionDefinition;
 }
 }
}
```

***
