---
uid: NT_DIAG
---

# NT_DIAG (226)

Obtains additional information about a DMA or DMS.

```csharp
string command = "QACTIONMETRICS_ELEMENT_346:125";

string[] result = (string[]) protocol.NotifyDataMiner (226 /*NT_DIAG*/ , command, null);
```

## Parameters

- command (string): The action that needs to be performed.
  - QACTIONMETRICS_ALL: Enables monitoring on all QActions of all elements of the DMA.
  - QACTIONMETRICS_ELEMENT_[DMA ID]:[element ID]: enables monitoring of all QActions of the specified element.
  - RESETQACTIONMETRICS_ELEMENT_[DMA ID]:[element ID]: Resets the QAction metrics of the specified element.<!-- RN 8345 -->
  - RESETQACTIONMETRICS_QACTION_[DMA ID]:[element ID]:[QAction ID]: Resets the QAction metrics of the specified QAction.<!-- RN 8345 -->
  - RESETQACTIONMETRICS_PROTOCOL_[protocol name]:[protocol version]: Resets the QAction metrics of elements running the specified version of the specified protocol.<!-- RN 8345 -->

  e.g., QACTIONMETRICS_ELEMENT_101:510984" (101 = DMA ID, 510984 = Element ID)

  > [!NOTE]
  > By default, the QAction metrics are disabled. To enable monitoring, you have to enable the feature. Open the SLNetClientTest tool and select *Advanced* > *Options* > *SLNet Options*. There you can add features using a comma-separated list for *ExtraSupportedFeatureKeys*. For more information, see [SLNetClientTest tool](xref:SLNetClientTest_tool).

## Return Value

- Depends on the command that has been sent. (E.g. for the response value of QACTIONMETRICS_ELEMENT_[DMA ID]:[element ID], refer to QAction metrics.)

## Remarks

- This method call is not commonly used in protocols. However, it can be useful to debug or monitor elements for support purposes.
