---
uid: NT_ELEMENT_STARTUP_COMPLETE
---

# NT_ELEMENT_STARTUP_COMPLETE (377)

Checks if element startup is completed.

```csharp
uint dmaID = 346;
uint elementID = 806;
uint[] ids = new uint[] { dmaID, elementID };
object result = protocol.NotifyDataMiner(377/*NT_ELEMENT_STARTUP_COMPLETE*/, ids, null);

if (result != null)
{
   bool hasStartupCompleted = Convert.ToBoolean(result);
}
```

## Parameters

- ids (uint[]):
  - ids[0]: DataMiner Agent ID
  - ids[1]: Element ID

## Return Value

- If the element is stopped, a null reference is returned.
  
  If an element is starting, this call will block. If the element is started, the boolean value true is returned.

## Remarks

- There are two flows in DataMiner that are relevant to element readiness. One is the element creation and starting up in SLProtocol/SLElement, the other is the publication of this element's existence within the DataMiner System.

  For example, when a DVE is created, this is added to a queue in SLDataMiner, which then adds it to a queue in SLDMS, which is then queued in SLNet so the element is eventually known in the SLNet process.

  However, next to this flow, there is the virtual element being loaded up in SLElement. Depending on system load and element size, these two flows do not finish at the same time (the order of which flow finishes first is also not fixed).

  To summarize, NT_ELEMENT_STARTUP_COMPLETE is a check answered by SLDataMiner and returns true when it is ready in SLElement and SLDataMiner (and coincidentally in SLProtocol). However, this does not mean the SLNet process knows about the existence of this element when this call returns. In order to know if the element is known in SLNet, either:

  - Perform a GetElementByIDMessage (which will throw an exception if the element is not yet known), or
  - Subscribe to LiteElementInfoEvent (preferably with filters specifying the element(s) of interest).

- The corresponding flag in ElementStateEventMessage is IsElementStartupComplete, which indicates when SLNet has processed all incoming data on element startup.
