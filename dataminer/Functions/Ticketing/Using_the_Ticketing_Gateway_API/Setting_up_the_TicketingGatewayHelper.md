---
uid: Setting_up_the_TicketingGatewayHelper
---

# Setting up the TicketingGatewayHelper

The TicketingGatewayHelper class allows you to communicate with the Ticketing Gateway running on a DataMiner Agent.

The following example shows how to set up the TicketingGatewayHelper.

```cs
class Script
{
    TicketingGatewayHelper Helper;
    Connection conn;
    Script()
    {
        // Connect to SLNet. Not needed for protocols and Automation scripts
        conn = ConnectionSettings.GetConnection("localhost");
        conn.Authenticate();
        //Construct TicketingGatewayHelper
        Helper = new TicketingGatewayHelper();
        Helper.HandleEventsAsync = false; //Most client applications will prefer blocking calls for event handling => false
        //Mandatory event to subscribe to for proper client-server communication
        Helper.RequestResponseEvent += Helper_RequestResponseEvent;
        //Other events on the Helper are optional.
        Helper.LoggingEvent += Helper_LoggingEvent;
        Helper.TicketChangedEvent += Helper_TicketChangedEvent;
        Helper.TicketFieldResolverChangedEvent += Helper_TicketFieldResolverChangedEvent;
    }
    private void Helper_RequestResponseEvent(object sender, Skyline.DataMiner.Net.IManager.Helper.IManagerRequestResponseEventArgs e)
    {
        e.responseMessage = conn.HandleSingleResponseMessage(e.requestMessage);
    }
    private void Helper_TicketFieldResolverChangedEvent(object sender, TicketFieldResolverChangedEventArgs e)
    {
        var changedResolver = e.ChangedResolver; //Resolver that changed
        bool isDelete = e.isDelete; //Delete or add/update?
    }
    private void Helper_TicketChangedEvent(object sender, TicketChangedEventArgs e)
    {
        var changedTicket = e.ChangedTicket; //The ticket that changed
        var changedHistory = e.ChangedHistory; //The history entry that changed
        bool isDelete = e.isDelete; //Delete or add/update?
    }
    private void Helper_LoggingEvent(object sender, Skyline.DataMiner.Net.IManager.Helper.IManagerErrorEventArgs e)
    {
        Console.WriteLine("Normal logging: " + e.NoException);
        Console.WriteLine("Exception logging: " + e.Exception.ToString());
    }
}
```

> [!NOTE]
> - Although a Ticketing Gateway caches all the open tickets, the TicketingGatewayHelper does not keep a cache of tickets or resolvers. If client-side caching is required, it must be implemented by the client.
> - Currently, tickets cannot be synchronized via the TicketingGatewayHelper.
>
