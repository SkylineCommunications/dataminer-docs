---
uid: DocIntel_DocumentIntelligenceError
---

# DocumentIntelligenceError class

## Definition

- Namespace: `Skyline.DataMiner.Net.Apps.DocumentIntelligence.Objects`
- Assembly: `SLNetTypes.dll`

Represents an error that occurred during a Document Intelligence analysis. Instances of this class are returned via `TraceData.GetErrorDataOfType<DocumentIntelligenceError>()` after a failed [AnalyzeDocuments](xref:DocIntel_DocumentIntelligenceHelper) call.

Available from DataMiner 10.6.0/10.6.1 onwards.<!-- RN 44016 -->

## Properties

| Property | Type | Description |
|----------|------|-------------|
| ErrorReason | [DocumentIntelligenceError.Reason](xref:DocIntel_DocumentIntelligenceError_Reason) | Indicates the category of the error. |
| Message | `string` | A human-readable description of the error. |
| StackTrace | `string` | The server-side stack trace, if available. |

## Example

```csharp
var traceData = docIntelHelper.GetTraceDataLastCall();
if (!traceData.HasSucceeded())
{
    var errors = traceData.GetErrorDataOfType<DocumentIntelligenceError>();
    foreach (var error in errors)
    {
        engine.GenerateInformation($"Error ({error.ErrorReason}): {error.Message}");
    }
}
```
