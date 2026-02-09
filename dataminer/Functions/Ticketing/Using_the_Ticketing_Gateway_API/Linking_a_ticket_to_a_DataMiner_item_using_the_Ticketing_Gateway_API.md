---
uid: Linking_a_ticket_to_a_DataMiner_item_using_the_Ticketing_Gateway_API
---

# Linking a ticket to a DataMiner item using the Ticketing Gateway API

> [!IMPORTANT]
> The Ticketing Gateway API is obsolete. It is not supported with [STaaS](xref:STaaS) and is no longer available from DataMiner 10.5.0 [CU12]/10.6.3 onwards<!--RN 44417-->.

In the ticket creation example in the previous, the ticket is linked to a DataMiner element by means of a TicketLink object. See [Creating tickets with the Ticketing Gateway API](xref:Creating_tickets_with_the_Ticketing_Gateway_API).

Currently, a TicketLink object can be used to link a ticket to the following objects:

- Skyline.DataMiner.Net.ElementID

- ServiceID

- ViewID

- ProtocolID

- Messages.SLDataGateway.AlarmID

- Messages.SLDataGateway.ParameterID
