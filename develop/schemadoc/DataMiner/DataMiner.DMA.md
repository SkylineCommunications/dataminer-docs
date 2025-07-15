---
uid: DataMiner.DMA
---

# DMA element

Specifies information for this DataMiner Agent.

## Parents

[DataMiner](xref:DataMiner)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [publicDNS](xref:DataMiner.DMA-publicDNS) | string |  | When a DNS name is specified in this attribute, it will be used instead of the DataMiner IP address for links to the DataMiner user interface in notification emails. |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| Sequence |  |  |
| &#160;&#160;[DMAName](xref:DataMiner.DMA.DMAName) | [0, 1] | Specifies the name of this DataMiner Agent.<br>See [Changing the name of a DMA](xref:Changing_the_name_of_a_DMA). |
| &#160;&#160;[Location1](xref:DataMiner.DMA.Location1) | [0, 1] | Specifies location information for this DataMiner Agent.<br>See [Specifying your company data](xref:Specifying_your_company_data). |
| &#160;&#160;[Location2](xref:DataMiner.DMA.Location2) | [0, 1] | Specifies location information for this DataMiner Agent.<br>See [Specifying your company data](xref:Specifying_your_company_data). |
| &#160;&#160;[Location3](xref:DataMiner.DMA.Location3) | [0, 1] | Specifies location information for this DataMiner Agent.<br>See [Specifying your company data](xref:Specifying_your_company_data). |
