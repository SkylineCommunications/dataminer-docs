---
uid: How_to_use_multiple_protocol_threads_to_split_communication_and_parsing
---

# How to use multiple protocol threads to split communication and parsing

Below, you can learn how to implement multithreading in a connector to split communication and parsing so these do not influence each other.

## User skills required

Basic knowledge of connectors.

## About 'Multiple protocol threads'

*Multiple protocol threads* is an option you can implement in a connector. Doing so allows you to execute groups in a separate thread, so that these do not influence the main thread. There is currently no hard limit on the number of threads you can create in a protocol. However, as a protocol thread does increase the load on the system, we advise to limit the number of extra threads.

## Use case

The use case described below concerns a data source requiring a fast response to acknowledge the received data. The acknowledgment is needed to keep the data source from sending retries. An acknowledgment must happen within 200 ms after the data was sent. Parsing all the received data packets can take up to 20 seconds.

![Graphic overview with multiple protocol threads](~/develop/images/HOWTO_WithMultipleProtocolThreads.svg)

![Graphic overview without multiple protocol threads](~/develop/images/HOWTO_WithoutMultipleProtocolThreads.svg)

The image below illustrates how this is implemented in the connector. The main thread is shown on the left and the second thread is shown on the right.

![Implementation in the connector](~/develop/images/HOWTO_MultiThreadedProtocolFlowChart.svg)

The element receives all the communication in parameter 1999. QAction 1999 is triggered when new data is received. The QAction reads the data, parses the header and makes the response. When the response is made, the correct parameters are set. After that, a checktrigger is executed to send the acknowledge. All the data packets in the response are added to the queue as a byte array.

QAction 1999 has 2 entry points. Alternatively, you can use an if or switch structure.

```csharp
public class QAction
{
    private readonly ConcurrentQueue<byte[]> queue = new ConcurrentQueue<byte[]>();
    public void ParseQueue(SLProtocol protocol)
    {
        try
        {
            byte[] firstInQueue;
            while (this.queue.TryDequeue(out firstInQueue))
            {
                ...
            }
        }
        catch (Exception ex)
        {
            ...
        }
    }
    public void ReadResponse(SLProtocol protocol)
    {
        try
        {
            var strNewResp = (object[])protocol.GetData("PARAMETER", 1999);
            ...
            queue.Enqueue(dataPackets.ToArray());
            ...
        }
        catch (Exception ex)
        {
            ...
        }
    }
}
```

The second thread is triggered by a timer. The timer will execute a group with attribute connection="1001" (the ID of the second thread).

The group will do a poll action. That action will do a run action on parameter 200, which will trigger QAction 1999, but on the other entry point.

The second entry point of the QAction will do a while loop. The loop will continue as long as the *tryDequeue* finds an item in the queue.

The QAction 1999 can have multiple instances running but in different threads. The main thread and extra threads can run QAction 1999 at the same time. The *ConcurrentQueue* will handle the locking between the instances that are running.

## How to

Steps:

1. Make an extra thread with an ID higher than 1000.
1. Put the attribute *connection* with the correct thread ID on the groups you want to run in the new thread.

```xml
    <Threads>
        <Thread connection="1001"/>
    </Threads>
    <Group id="200" connection="1001">
        <Name>triggerParseThread</Name>
        <Description>Trigger Parse Thread</Description>
        <Type>poll action</Type>
        <Content>
            <Action>200</Action>
        </Content>
    </Group>
```
