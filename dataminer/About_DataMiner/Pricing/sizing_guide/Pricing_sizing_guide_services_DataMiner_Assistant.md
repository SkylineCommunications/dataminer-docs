---
uid: Pricing_sizing_guide_services_DataMiner_Assistant
---

# Sizing guide: DataMiner Assistant

Document Intelligence is charged **per page processed**, not per document or per workflow run.

## Service volumes

| Category | Service | Metering unit | Calculation method |
|----------|---------|:-------------:|---------------------|
| DataMiner Assistant | Document Intelligence | Sum of processed document pages, priced per 100 | Count the total number of pages across all documents processed through the Document Intelligence tool in DataMiner Automation. Supported formats: PDF, Word, Excel, images. |

## Examples

- Processing 1,500 PDF documents with 2 pages each = **3,000** pages 

## What does not affect this estimate

- **Document file size**: Billing is per page, not per MB.
- **Number of workflows or scripts that call Document Intelligence**: Only the pages processed count, regardless of how many automation scripts trigger the processing.
