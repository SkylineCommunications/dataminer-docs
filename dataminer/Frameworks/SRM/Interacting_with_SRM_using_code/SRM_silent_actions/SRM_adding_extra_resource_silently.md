---
uid: SRM_adding_extra_resource_silently
---

# Silently adding an extra resource and potentially creating a new service definition

If you want assign an extra resource to a booking, regardless of whether it is already running or not, this may not be possible in [the usual way](xref:SRM_assigning_resource_profile_parameter_value_silently) if the selected service definition does not have any free nodes.

In that case, you can use the *AddResource* and *TryAddResource* methods to add the resource anyway. With these methods, DataMiner SRM will first try to find a compatible free node in the service definition. If no such node is found, it will search for a compatible service definition and update the booking accordingly. If no compatible service definitions are found, it will create a new service definition and assign it to the booking.

The methods use the node label to identify a node in the service definition.

Here is a code sample:

```csharp
public void Run(Engine engine)
    {
        engine.SetFlag(RunTimeFlags.NoKeyCaching);
    
        try
        {
            
            Guid myReservationGuid = Guid.Parse(engine.GetScriptParam("ReservationGuid").Value);
            
            var bookingManager = new BookingManager(engine, engine.FindElement(BookingManagerElementName));

            var instance = SrmManagers.ResourceManager.GetReservationInstance(myReservationGuid);
            
            bookingManager.TryAddResource(engine,ref instance,Guid.Parse(engine.GetScriptParam("ResourceGuid").Value), engine.GetScriptParam("Label").Value);
            
        }
```

> [!NOTE]
><!-- RN 30350 -->
> - In case a service definition needs to be created, it will not be a template.
> - In case no label is provided, SRM will try to identify a free node based on function type.
> - In case a free and compatible node is found, but it has a non-matching label, that node will be picked.
> - In case no label is provided and a new service definition needs to be created, the function name will be used as the label.
