---
uid: DocIntel_DocumentIntelligenceError_Reason
---

# DocumentIntelligenceError.Reason enum

## Definition

- Namespace: `Skyline.DataMiner.Net.Apps.DocumentIntelligence.Objects`
- Assembly: `SLNetTypes.dll`

Specifies the reason for a [DocumentIntelligenceError](xref:DocIntel_DocumentIntelligenceError).

Available from DataMiner 10.6.0/10.6.1 onwards.

## Fields

| Field | Description |
|-------|-------------|
| UnexpectedError | An unexpected server-side error occurred. Check the `Message` and `StackTrace` properties for details. |
| NotInitialized | The Document Intelligence service is not yet initialized. This can occur when the DataMiner Assistant DxM has just started or when its configuration is being applied. |
| FeatureNotAvailable | The Document Intelligence feature is not available in the current environment or license. |
| Timeout | The analysis request timed out before a result could be returned. |
