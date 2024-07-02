---
uid: InterAppCalls_GettingStarted_SendingCall
---

# Sending a call

## Sending a call without expected return

```csharp
    public static void SendMessages(SLProtocol protocol, int dmaId, int elementId)
    {
        // Prepare necessary mappings
        List<Type> knownTypes = new List<Type> { typeof(MyMessage) };

        // Create new IInterAppCall
        IInterAppCall myCommands = InterAppCallFactory.CreateNew();

        // Create the message
        MyMessage message = new MyMessage { MyProperty = "myValue" };

        // Add the message to the InterApp call
        myCommands.Messages.Add(message);

        // Send the InterApp call to the destinationElement
        // Parameter 9000000 (9 million) is the default parameter for InterApp call messages
        myCommands.Send(protocol.SLNet.RawConnection, dmaId, elementId, 9000000, knownTypes);
    }
```

## Sending a call with expected return

```csharp
    public static void SendMessages(SLProtocol protocol, int dmaId, int elementId)
    {
        // Prepare necessary mappings
        List<Type> knownTypes = new List<Type> { typeof(MyMessage), typeof(MyResponse) };
        Dictionary<Type, Type> msgToExecutor = new Dictionary<Type, Type>
        {
            { typeof(MyMessage), typeof(MySimpleMessageExecutor) }
        };

        // Create new IInterAppCall
        IInterAppCall myCommands = InterAppCallFactory.CreateNew();

        // Specify the return address
        myCommands.ReturnAddress = new ReturnAddress(dmaId, elementId, 9000001);

        // Create the message
        MyMessage message = new MyMessage { MyProperty = "myValue" };

        // Add the message to the InterApp call
        myCommands.Messages.Add(message);

        // Send the InterApp call to the destinationElement
        // Parameter 9000000 (9 million) is the default parameter for InterApp call messages
        IEnumerable<Message> responses = myCommands.Send(protocol.SLNet.RawConnection, dmaId, elementId, 9000000, TimeSpan.FromMinutes(1), knownTypes);

        // Handle the responses
        foreach (Message returnedMsg in responses)
        {
            returnedMsg.TryExecute(protocol, protocol, msgToExecutor, out Message optionalReturn);
        }
    }
```

> [!IMPORTANT]
> The parameter selected with the *ReturnAddress* must not be on the source element (the parameter 9000001 on the destination element is recommended). If you use a parameter on the element you are sending from, you will cause deadlocks. This happens because the sending QAction waits on a response, but the response cannot be set to the parameter because there is a QAction running (i.e. the one waiting on the response).

> [!NOTE]
> When using InterApp on DataMiner version 10.3.12 or higher, the *ReturnAddress* is optional as it is not used unless SLNet subscriptions are forcefully used.
> See more info on the [release note](xref:Skyline_DataMiner_Core_InterAppCalls_Range_1.0#new-feature---enhanced-efficiency-on-interapp-reply-calls).

## See also

- [Creating an API with messages that define the data you want to share.](xref:InterAppCalls_GettingStarted_CreatingApi)
- [Creating executors that define how to process a message.](xref:InterAppCalls_GettingStarted_CreatingExecutor)
- [Receiving a call.](xref:InterAppCalls_GettingStarted_ReceivingCall)
