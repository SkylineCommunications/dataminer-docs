---
uid: CreatingTickets
---

# Ticket creation

Tickets can be created in several ways:

- Directly from the Ticketing application.
- From a Cube alarm using the right-click menu.
- From an automation script triggered by a correlation rule.

When a ticket is created from a Cube alarm using the right-click menu:

- An automation script is launched to collect additional details.
- The Ticketing API Helper is used to create the ticket.
- The alarm and the element on which the alarm occurred are automatically linked to the ticket.

If the element is linked to an asset in the Asset Manager, that asset is also linked to the ticket.
