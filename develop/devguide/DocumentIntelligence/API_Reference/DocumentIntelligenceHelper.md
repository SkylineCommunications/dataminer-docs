---
uid: DocIntel_DocumentIntelligenceHelper
---

# DocumentIntelligenceHelper class

## Definition

- Namespace: `Skyline.DataMiner.Net.Apps.DocumentIntelligence`
- Assembly: `SLNetTypes.dll`

Provides helper methods to interact with the Document Intelligence feature of the [DataMiner Assistant DxM](xref:Assistant_DxM).

Available from DataMiner 10.6.0/10.6.1 onwards.

## Constructors

### DocumentIntelligenceHelper(Func\<DMSMessage[], DMSMessage[]\> sendSLNetMessages)

Initializes a new instance of the `DocumentIntelligenceHelper` class.

#### Parameters

- `Func<DMSMessage[], DMSMessage[]>` `sendSLNetMessages`: The SLNet communication function, typically provided by `engine.SendSLNetMessages`.

## Methods

### string AnalyzeDocuments(string instructions, IEnumerable\<Document\> documents)

Sends one or more documents to the Document Intelligence service for analysis and returns the result as a string.

#### Parameters

- `string` `instructions`: The instructions describing what to extract or analyze (i.e. the prompt).
- `IEnumerable<`[Document](xref:DocIntel_Document)`>` `documents`: The list of documents to analyze.

#### Returns

A `string` containing the analysis result produced by the LLM based on the uploaded documents and instructions.

> [!NOTE]
> To check for errors after the call, use [GetTraceDataLastCall](#tracedata-gettracedatalastcall).

### TraceData GetTraceDataLastCall()

Returns the `TraceData` from the most recent `AnalyzeDocuments` call. Use `HasSucceeded()` to check whether the call succeeded, and `GetErrorDataOfType<`[DocumentIntelligenceError](xref:DocIntel_DocumentIntelligenceError)`>()` to retrieve detailed error information.

#### Returns

A `TraceData` object containing success or error information for the last call.

#### Example

```csharp
var result = docIntelHelper.AnalyzeDocuments(instructions, documents);
var traceData = docIntelHelper.GetTraceDataLastCall();
if (!traceData.HasSucceeded())
{
    var errors = traceData.GetErrorDataOfType<DocumentIntelligenceError>();
    // Handle errors
}
```
