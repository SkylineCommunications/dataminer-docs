---
uid: DMATicket
---

# DMATicket

| Item | Format | Description |
|------|--------|-------------|
| Fields         | Array   | An array containing an entry for each field with its value. |
| DataMinerID    | Integer | The DMA ID of the Agent where the ticket was created. |
| ID             | Integer | The ID of the ticket. |
| UID            | String  | This property is added from DataMiner 10.0.13 onwards. It contains the unique GUID identifier of the ticket. While in earlier DataMiner versions, a ticket was identified by DataMiner ID and ticket ID, the DataMiner ID has become irrelevant from this version onwards. While tickets will still have a unique ticket ID, new implementations should make use of this UID instead. |
| TicketTypeID   | GUID    | The GUID of the ticket type. |
| TimeCreatedUTC | Long Integer | The time when the ticket was created, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| LinkFields     | Array of DMATicketLinkField | Array containing the linked DataMiner resources. For every DataMiner Object field, it contains a DMATicketLinkField entry with a DMATicketLinkValue array with its linked DataMiner resources.<br>See also:<br>- [DMATicketLinkField](xref:DMATicketLinkField)<br>- [DMATicketLinkValue](xref:DMATicketLinkValue) |
| StateColor     | String  | The color corresponding with the ticket state. |
| IsClosed       | Boolean | Indicates whether the ticket is closed. |
