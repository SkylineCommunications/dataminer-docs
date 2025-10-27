---
uid: TicketingVersionDifferences
---

# Ticketing differences depending on the DataMiner version

In DataMiner 10.0.13, multiple important changes are introduced in the Ticketing app. The most important difference introduced by this DataMiner version is a switch to the use of the indexing database instead of the Cassandra database. In addition, this DataMiner version introduces several breaking changes.

> [!NOTE]
>
> - If you upgrade to DataMiner 10.0.13 and your DMS already uses an indexing database, all ticketing data is migrated automatically.
> - If you upgrade to DataMiner 10.0.13 and your DMS does not use an indexing database yet, the ticketing data will be migrated automatically as soon as you add an indexing database to your DataMiner System. However, as long as there is no indexing database, you will not be able to use the Ticketing app. A runtime error in the Alarm Console will indicate that Ticketing Manager could not be initialized because there is no indexing database.

> [!CAUTION]
>
> - The Ticketing app is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles) for more details. ![EOL](~/dataminer/images/EOL_Duo.png)
> - The Ticketing app is not supported on systems using [Storage as a Service (STaaS)](xref:STaaS).

## Ticketing with indexing vs. with Cassandra

The switch to the indexing database results in the following important functionality changes:

- With the indexing database, a ticket has a UID property of type GUID, which is always unique and which replaces the TicketID object used with Cassandra. This TicketID consists of a DataMiner ID and ticket ID. However, in the indexing database, the DataMiner ID is not needed. While tickets still have a unique ticket ID, new implementations from DataMiner 10.0.13 onwards should make use of the UID instead.
- With the indexing database, the TicketingHelper should be used to read, create, update and delete tickets, ticket field resolvers and ticket history in scripts, instead of the TicketingGatewayHelper. The TicketingGatewayHelper remains backwards compatible, but should not be used for new implementations or to update existing code. For an example, see TicketingHelper class.

## Breaking changes introduced in DataMiner 10.0.13

DataMiner 10.0.13 also introduces the following breaking changes:

- Total number of tickets when starting paging:

  When paging is started using TicketingGatewayHelper.NewPagingRequest(), the out parameter no longer returns the total number of tickets, but is always “-1”.

- Invalid paging size response:

  When an invalid page size or page number is used in a request (<0), an empty list is now returned, while previously the ticketing helper returned all tickets matching the filter.

- Initial bulk event when subscribing:

  Subscribing to TicketingGatewayEventMessage no longer returns an initial bulk. Instead tickets and ticket field resolvers should be retrieved via paging with the TicketingHelper.

- Filtering on active tickets:

  When the Cassandra database was used, all open tickets were stored in the cache as well as the database. It was therefore possible to use the CacheOnly boolean in requests to retrieve only open tickets. This cache is no longer used, so using the CacheOnly boolean no longer works when you use NewPagedTicketsWithFilterMessage. To resolve this, concatenate the filter with an open tickets filter, which you can retrieve using the method GetTicketStateFilter(TicketState ticketState) (see TicketFieldResolver.GetTicketStateFilter method). An exception is made for the GetTickets method of the TicketingGatewayHelper (see TicketingGatewayHelper.GetTickets method (FilterElement(Ticket)[])), which will still only return the open tickets.

- Null fields are not saved:

  "Null" values of ticket fields are no longer saved or returned.

- Ticket state is not defined by alarm TicketLink:

  The open state of a ticket can no longer be linked to the state of an alarm.

- GenericEnumEntry\<int> is returned as “long”:

  If GenericEnumEntry\<int> is used in VisualData on a TicketFieldResolver, this is now returned as a long integer instead of an integer.

- Tickets must now always contain a field for their state if the TicketFieldResolver defines a state TicketFieldDescriptor

  If the ticket field resolver defines a state TicketFieldDescriptor, tickets must now always contain a field indicating their state. When tickets are initially migrated to the indexing database, a state will automatically be defined for any tickets where this was not yet the case.
