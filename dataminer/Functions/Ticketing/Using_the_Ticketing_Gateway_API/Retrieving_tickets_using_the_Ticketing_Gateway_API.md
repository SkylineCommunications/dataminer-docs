---
uid: Retrieving_tickets_using_the_Ticketing_Gateway_API
---

# Retrieving tickets using the Ticketing Gateway API

> [!IMPORTANT]
> The Ticketing Gateway API is obsolete. It is not supported with [STaaS](xref:STaaS) and is no longer available from DataMiner 10.6.0/10.6.3 onwards<!--RN 44417-->.

Tickets can be retrieved in a number of ways. See the following examples.

> [!NOTE]
> To filter tickets, you can pass a list of TicketLinks and a ticket filter.
> - If you pass a list of TicketLinks, you will receive all Tickets that have at least one matching TicketLink.
> - Ticket filters are FilterElements of type Ticket. They can be built using ANDFilterElement\<Ticket> or ORFilterElement\<Ticket>.
>
> To filter tickets quickly, do the following:
> - use one of the default TicketingExposers (DataminerID, TicketID, or ResolverID), or
> - use ReflectiveExposer to create a custom filter.

- Retrieving tickets by ticket field

    ```cs
    public Ticket RetrieveTicketByField()
    {
        var outputTickets = Helper.GetTickets(filter: ReflectiveExposer.DictField<Ticket, object>("CustomTicketFields","User").Equal("Jane"));
        if (outputTickets.Count() != 1) return null;
        return outputTickets.First();
    }
    ```

- Retrieving tickets by state

    ```cs
    public Ticket RetrieveTicketByState()
    {
        var outputTickets = Helper.GetTickets(filter: ReflectiveExposer.DictField<Ticket, object>("CustomTicketFields","State").Equal(0));
        //Alternatively:
        var alternative = Helper.GetTickets(filter: ReflectiveExposer.DictField<Ticket, object>("CustomTicketFields","State") .Equal(new GenericEnumEntry<int>() { Name = "Created", Value = 0 }));
        if (outputTickets.Count() != 1) return null;
        return outputTickets.First();
    }
    ```

- Retrieving tickets by link

    ```cs
    public Ticket RetrieveTicketByLink() {
        var outputTickets = Helper.GetTickets(new TicketLink[] { TicketLink.Create(new Skyline.DataMiner.Net.ElementID(123, 456)) });
        if (outputTickets.Count() != 1) return null;
        return outputTickets.First();
    }
    ```

- Retrieving tickets by ticket field resolver

    ```cs
    public Ticket[] RetrieveTicketByResolverID(TicketFieldResolver resolver) {
        var outputTickets = Helper.GetTickets(filter: TicketingExposers.ResolverID.Equal(resolver.ID));
        return outputTickets.ToArray();
    }
    ```

- Retrieving tickets page by page

    ```cs
    private static long PagingCookie = -1;
    private static int PageSize = 2;
    private static int totalTickets = 10;
    private IEnumerable<Ticket> RetrieveNextPage() {
        List<Ticket> result;
        //The maximum number of tickets retrieved by this method is pageSize * amount of DMAs in the DMS
        if (PagingCookie == -1)
        {
            result = Helper.NewPagingRequest(PageSize, out PagingCookie, out totalTickets, filter: TicketingExposers.DataMinerID.Equal(123)).ToList();
        }
        result = Helper.NextPagingRequest(PagingCookie).ToList();
        if (result.Count < PageSize) PagingCookie = -1;
        return result;
    }
    ```
