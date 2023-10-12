---
uid: SRM_removing_resource_and_node_silently
---

# Silently removing a resource and node from a booking and potentially creating a new service definition

<!-- RN 30812 -->

When a resource has to be removed from a booking and the service definition with the associated node also has to be removed, you can use the *TryRemoveAndNode* method.

In case there is no matching service definition that can cope with the updated list of resources in the booking, DataMiner SRM will try to identify another service definition or create a new one.

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
            
            bookingManager.TryRemoveResourceAndNode(engine, ref instance, Guid.Parse(engine.GetScriptParam("ResourceGuid").Value), Convert.ToInt32(engine.GetScriptParam("NodeId").Value));
            
        }
```

> [!NOTE]
>
> - In case a service definition needs to be created, it will not be a template.
> - A non-template service definition will not be cleaned up.
