---
uid: Overview_of_the_TicketingGatewayHelper_class
---

# Overview of the TicketingGatewayHelper class

> [!IMPORTANT]
> The Ticketing Gateway API is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.

Below, you can find an overview of all methods, properties and events of the *TicketingGatewayHelper* class.

## Methods

### DriverSync

Synchronizes the ticketing protocol with DataMiner.

```cs
IEnumerable<TicketingGatewayEventMessage> DriverSync(ElementID ElementID, DateTime TimeStamp, params Tuple<DateTime, Ticket>[] ChangedTickets)
```

Parameters:

- **ElementID**: The element ID of the element running the ticketing protocol.

- **TimeStamp**: The timestamp of the last polling cycle to the external ticketing system.

- **ChangedTickets**: The tickets that have changed since the last time this method was used, with *DateTime* being the timestamp of the last change to the ticket and *Ticket* being the changed ticket.

Returns:

- A collection of event messages containing all the verified and updated or deleted tickets.

### GetMaskedTicketFieldResolvers

Retrieves the masked resolvers corresponding to one or more filters.

```cs
IEnumerable<TicketFieldResolver> GetMaskedTicketFieldResolvers(params TicketFieldResolver[] filters);
```

Parameters:

- **filters**: A collection of filters. Each filter will be processed separately and the results will be added to the final response.

Returns:

- The requested ticket field resolvers.

Example:

- If the following is specified within a script, any resolvers that are masked will be retrieved and an information event will be generated with information about them:

    ```cs
    private void ShowMaskedResolvers(Engine engine)
    {
        var maskedTicketFieldResolvers = helper.GetMaskedTicketFieldResolvers();
        foreach (TicketFieldResolver maskedTicketFieldResolver in maskedTicketFieldResolvers)
        {
            engine.GenerateInformation(string.Format("Resolver \"{0}\", which is configured to be linked to \"{1}\", is masked.", maskedTicketFieldResolver.Name, maskedTicketFieldResolver.ElementUsingResolver.ToString()));
        }
    }
    ```

### GetTicketFieldResolvers

Retrieves the non-masked ticket field resolvers corresponding to one or more filters.

```cs
IEnumerable<TicketFieldResolver> GetTicketFieldResolvers(params TicketFieldResolver[] filters)
```

Parameters:

- **filters**: A collection of filters. Each filter will be processed separately and the results will be added to the final response.

Returns:

- The requested ticket field resolvers.

### GetTicketHistory

Retrieves the history for one or more tickets.

```cs
IEnumerable<TicketHistory> GetTicketHistory(params TicketID[] ticketIDs)
```

Parameters:

- **ticketIDs**: The ticket IDs of the tickets for which the history should be retrieved.

Returns:

- The requested collection of TicketHistory objects.

### GetTickets

Retrieves the tickets matching the given filter and links.

```cs
IEnumerable<Ticket> GetTickets(IEnumerable<TicketLink> links = null, FilterElement<Ticket> filter = null, bool CacheOnly = false)
```

Parameters:

- **links**: The links to be used when searching the tickets.

- **filter**: The filter to use when searching the tickets.

- **CacheOnly**: Indicates whether to only check the cache (true) or also the DB (false).

Returns:

- A collection of tickets matching the links and filter.

### NewPagingRequest

Use this method to retrieve tickets in a paged fashion. This method requests a new page.

```cs
IEnumerable<Ticket> NewPagingRequest(int pagesize, out long pagingCookie, out int totalTickets, int pageNumber = 0, IEnumerable<TicketLink> links = null, FilterElement<Ticket> filter = null, bool CacheOnly = false)
```

Parameters:

- **pagesize**: The number of tickets that should be retrieved on one page.

- **pagingCookie**: Output: The paging cookie to use in the NextPagingRequest method to request the next page. If output is 0, no cookie could be created.

- **totalTickets**: Output: The total number of tickets this request would result in if done as a regular request (GetTickets). If output is -1, no total number could be calculated.

- **pageNumber**: The page number you want to retrieve.

- **links**: The links to be used when searching the tickets.

- **filter**: The filter to use when searching the tickets.

- **CacheOnly**: Indicates whether to only check the cache (true) or also the database (false).

Returns:

- A collection of tickets with the indicated page size, matching the links and filter.

> [!NOTE]
> Instead of using the page number and calling a NewPagingRequest to retrieve the next page, we advise to use the NextPagingRequest method instead.

### NextPagingRequest

Request the next page of a previously requested set of pages (retrieved via NewPagingRequest).

```cs
IEnumerable<Ticket> NextPagingRequest(long pagingCookie)
```

Parameters:

- **pagingCookie**: The pagingCookie retrieved from NewPagingRequest.

Returns

- The next page of the set.

### RemoveTicketFieldResolvers

Removes one or more ticket field resolvers.

```cs
bool RemoveTicketFieldResolvers(out string error, params TicketFieldResolver[] resolvers)
```

Parameters:

- **error**: Output string with notifications and/or errors that occurred.

- **resolvers**: The ticket field resolvers that should be removed.

Returns

- *True* when removing the ticket field resolver(s) was successful, otherwise *False*.

### RemoveTickets

Removes one or more tickets.

```cs
bool RemoveTickets(out string error, params Ticket[] tickets)
```

Parameters:

- **error**: Output string with notifications and/or errors that occurred.

- **tickets**: The tickets that should be removed.

Returns

- *True* when removing the ticket(s), otherwise *False*.

### SetTicket

Adds or edits a ticket.

```cs
bool SetTicket(out string error, ref Ticket ticket)
```

Parameters:

- **error**: Output string with notifications and/or errors that occurred.

- **ticket**: The ticket you wish to add or edit.

Returns:

- *True* when adding/editing the ticket was successful, otherwise *False*.

Example: see[Creating tickets with the Ticketing Gateway API](xref:Creating_tickets_with_the_Ticketing_Gateway_API).

### SetTicketFieldResolver

Adds or edits a ticket field resolver.

```cs
bool SetTicketFieldResolver(out string error, ref TicketFieldResolver resolver)
```

Parameters:

- **error**: Output string with notifications and/or errors that occurred.

- **resolver**: The ticket field resolver you wish to add or edit.

Returns

- *True* when adding/editing the ticket field resolver was successful, otherwise *False*.

Example: see[Creating tickets with the Ticketing Gateway API](xref:Creating_tickets_with_the_Ticketing_Gateway_API).

### SetTicketFieldResolvers

Adds or edits multiple ticket field resolvers

```cs
bool SetTicketFieldResolvers(out string error, ref TicketFieldResolver[] resolvers)
```

Parameters:

- **error**: Output string with notifications and/or errors that occurred.

- **resolvers**: The ticket field resolvers you wish to add or edit.

Returns

- *True* when adding/editing the ticket field resolvers was successful, otherwise *False*.

### SetTickets

Adds or edits multiple tickets.

```cs
bool SetTickets(out string error, ref Ticket[] tickets)
```

Parameters:

- **error**: Output string with notifications and/or errors that occurred.

- **tickets**: The tickets you wish to add or edit.

Returns:

- *True* when adding/editing the tickets was successful, otherwise *False*.

## Properties

### IsLicensed

Checks with the server whether a valid Ticketing license is present.

```cs
bool IsLicensed
```

## Events

### RequestResponseEvent

Event that is called when the Helper wants to send a message to the server and expects a response.

```cs
event EventHandler<IManagerRequestResponseEventArgs> RequestResponseEvent
```
