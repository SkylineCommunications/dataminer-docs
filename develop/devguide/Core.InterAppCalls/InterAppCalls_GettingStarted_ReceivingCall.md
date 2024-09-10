---
uid: InterAppCalls_GettingStarted_ReceivingCall
---

# Receiving a call

You can create a QAction that triggers on parameter `interApp_receive`. This QAction will handle any incoming call. The code here will be easy as it uses a combination of the factory and command design patterns.

You get the raw value from the parameter and you use the `InterAppCallFactory` to turn it into an `IInterAppCall`. In addition the known types need to be added so that the factory can deduce which class it needs to deserialize to. More info about known types can be found here: [Known Types](xref:InterAppCalls_KnownTypes).

> [!IMPORTANT]
> It is not possible to receive both single messages and InterApp calls on the same parameter. We recommend just sticking to the InterApp call.

## Receiving a call without replying

```csharp
    public static void HandleIncomingMessages(SLProtocol protocol)
    {
        // Prepare necessary mappings
        List<Type> knownTypes = new List<Type> { typeof(MyMessage) };
        Dictionary<Type, Type> msgToExecutor = new Dictionary<Type, Type>
        {
            { typeof(MyMessage), typeof(MySimpleMessageExecutor) }
        };

        // Retrieve incoming message
        string raw = Convert.ToString(protocol.GetParameter(protocol.GetTriggerParameter()));
        IInterAppCall receivedCall = InterAppCallFactory.CreateFromRaw(raw, knownTypes);
        
        // Run the execute logic on each message
        foreach (var message in receivedCall.Messages)
        {
            message.TryExecute(protocol, protocol, msgToExecutor, out Message returnMessage);
        }
    }
```

## Receiving a call with replying

```csharp
    public static void HandleIncomingMessages(SLProtocol protocol)
    {
        // Prepare necessary mappings
        List<Type> knownTypes = new List<Type> { typeof(MyMessage), typeof(MyResponse) };
        Dictionary<Type, Type> msgToExecutor = new Dictionary<Type, Type>
        {
            { typeof(MyMessage), typeof(MySimpleMessageExecutor) }
        };

        // Retrieve incoming message
        string raw = Convert.ToString(protocol.GetParameter(protocol.GetTriggerParameter()));
        IInterAppCall receivedCall = InterAppCallFactory.CreateFromRaw(raw, knownTypes);
        
        // Run the execute logic on each message
        foreach (var message in receivedCall.Messages)
        {
            if (message.TryExecute(protocol, protocol, msgToExecutor, out Message returnMessage))
            {
                // Return the response using the Reply method
                message.Reply(protocol.SLNet.RawConnection, returnMessage, knownTypes);
            }
        }
    }
```
