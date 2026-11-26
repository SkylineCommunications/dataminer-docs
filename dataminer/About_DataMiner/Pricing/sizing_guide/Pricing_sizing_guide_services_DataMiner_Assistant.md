---
uid: Pricing_sizing_guide_services_DataMiner_Intelligence
description: "Estimate Document Intelligence page volumes and monthly processing needs with this DataMiner Intelligence sizing guide."
---

# Sizing guide: DataMiner Intelligence

Document Intelligence is charged **per page processed**, not per document or per workflow run.

For information about the metering of the other DataMiner Intelligence capabilities, see [DataMiner Intelligence pricing](xref:Pricing_DataMiner_Intelligence).

## Service volumes

| Category | Service | Metering unit | Calculation method |
|----------|---------|:-------------:|---------------------|
| DataMiner Intelligence | Document Intelligence | Sum of processed document pages, priced per 100 | Count the total number of pages across all documents processed through the Document Intelligence tool in DataMiner Automation. Supported formats: PDF, Word, Excel, images. |

## Examples

- Processing 1,500 PDF documents with 2 pages each = **3,000** pages 

## What does not affect this estimate

- **Document file size**: Billing is per page, not per MB.
- **Number of workflows or scripts that call Document Intelligence**: Only the pages processed count, regardless of how many automation scripts trigger the processing.
