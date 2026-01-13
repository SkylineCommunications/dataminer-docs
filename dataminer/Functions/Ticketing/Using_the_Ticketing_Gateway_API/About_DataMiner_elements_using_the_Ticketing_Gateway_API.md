---
uid: About_DataMiner_elements_using_the_Ticketing_Gateway_API
---

# About DataMiner elements using the Ticketing Gateway API

> [!IMPORTANT]
> The Ticketing Gateway API is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.

In most cases, a dedicated DataMiner element will be linked to a ticket field resolver, and will control all communication with the third-party ticketing system. The protocol of that element will have to be specifically written for that purpose, using the Ticketing Gateway API described in this release note.

If the Ticketing Gateway is used by an element, that element can then also be configured to synchronize the tickets with the third-party ticketing system with which it communicates.

To implement ticket synchronization:

1. Add a parameter with ID 80000 to the element protocol. The Ticketing Gateway will then set this parameter to the amount of changes the element can receive at any given time.

1. Add logic to the element protocol that synchronizes the ticket updates, taking into account the value set in parameter 80000.

   Example of a synchronization routine:

   ```cs
   public class QAction
   {
       public static void Run(SLProtocol protocol)
       {
           //Assuming the tickets are saved in a table with paramid 1000
           var rows = protocol.GetKeys(1000).Select(oneKey => protocol.GetRow(1000, oneKey));
           TicketingDriverSyncMessage syncMsg = new TicketingDriverSyncMessage();
           syncMsg.ElementID = new Skyline.DataMiner.Net.ElementID(protocol.DataMinerID, protocol.ElementID);
           //The timestamp of the last polling cycle to the external ticketing system.
           syncMsg.TimeStamp = DateTime.UtcNow;
           syncMsg.ManagerObjects = new List<Tuple<DateTime, Ticket>>();

           foreach(var row in rows) {
               object[] cells = row as object[];
               string jsonTicket = cells[1] as string; //The ticket saved as a json string (see: Ticket.ToJson())
               string timestamp = cells[0] as string; //The timestamp of when this ticket was added/changed
               DateTime TimeStamp = DateTime.Parse(timestamp);
               Ticket t = Ticket.FromJson(jsonTicket);
               syncMsg.ManagerObjects.Add(Tuple.Create(TimeStamp, t));
           }

           //Send the sync request
           var responses = protocol.SLNet.SendMessage(syncMsg);
           foreach(var response in responses)
           {
               var evt = response as TicketingGatewayEventMessage;
               if (evt == null) continue;

               //Handle the eventmessage
           }
       }
   }
   ```

When an element requests a ticket synchronization, it is possible that some tickets polled by that element have been changed by both the third-party ticketing system and a DataMiner user. In that case, the SLNet process will try to establish which updates take precedence.

| If ... | then ... |
|--|--|
| DataMiner has a ticket that cannot be found in the third-party system, | the ticket is verified and sent to the element. |
| the third-party system has a ticket that cannot be found in DataMiner, | The ticket is verified, saved in the database, and sent to the element.|
| DataMiner has a ticket that is also found in the third-party system, | \-  If the tickets are an exact match, the ticket is verified and sent to the element.<br> -  If the tickets differ:<br> -  - First, the tickets are merged:<br> -  - - Fields marked “IsDataMinerMaster == true” will keep the value found in the DataMiner ticket.<br> -  - - Fields marked “IsThirdPartyMaster == true” will keep the value found in the third-party system.<br> -  - - Fields for which no master is defined will keep the value found in the most recent of the two tickets.<br> -  - Then, the merged ticket is sent to the element (without being verified). |

> [!NOTE]
> Tickets are not synchronized among the DataMiner Agents in a DataMiner System.
>
> - If a ticket is created using a ticket field resolver that is linked to an element, then that ticket is saved on the DataMiner Agent that hosts the element.
> - If a ticket is created using a ticket field resolver that is not linked to an element, then that ticket is saved on the DataMiner Agent on which it was created.
