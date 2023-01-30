---
uid: Making_an_SLA_generate_tickets
---

# Making an SLA generate tickets

On the *Ticket Creation* page of SLA elements, a parameter is provided that can be used to make DataMiner automatically generate tickets.

The parameter, *Generate Ticket*, can have five different values:

- Clear

- Create Ticket

- Create Ticket, second attempt

- Create Ticket, third attempt

- Unable to create ticket

To automatically generate tickets, this parameter must be used in conjunction with the Automation and Correlation modules in DataMiner.

## Example of usage

1. The SLA element detects an outage.

1. The *Generate Ticket* parameter is set to *Create Ticket*.

1. A Correlation rule, which has been configured to be triggered when the *Generate Ticket* parameter has this value, activates an Automation script.

1. The Automation script requests a ticket number, posts the new ticket number value in the last column of the outage table, and sets the *Generate Ticket* parameter back to *Clear*.

> [!TIP]
> See also:
>
> - [Automation](xref:automation)
> - [Correlation](xref:correlation)

> [!NOTE]
> You can also have a ticket generated using the "Create ticket" Correlation rule action, but this feature is currently still in preview. See [Creating a ticket](xref:Creating_a_ticket).
