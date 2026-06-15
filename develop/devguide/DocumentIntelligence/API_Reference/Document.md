---
uid: DocIntel_Document
---

# Document class

## Definition

- Namespace: `Skyline.DataMiner.Net.Apps.DocumentIntelligence.Objects`
- Assembly: `SLNetTypes.dll`

Represents a document to be analyzed by the [DocumentIntelligenceHelper](xref:DocIntel_DocumentIntelligenceHelper).

Available from DataMiner 10.6.0/10.6.1 onwards.

## Properties

| Property | Type | Required | Description |
|----------|------|----------|-------------|
| Name | `string` | Yes | The file name of the document, including its extension (e.g. `"report.pdf"`). The extension is used to determine the document format. |
| Content | `byte[]` | Yes | The raw byte content of the document file. |

## Remarks

Any file format supported by the Azure Document Intelligence Service can be used. See [Processing documents](xref:docintel#processing-documents) for the list of supported formats and maximum file sizes.
