---
uid: LinkingTicketsToAssets
---

# Linking tickets to assets

## Overview

The DataMiner Ticketing solution supports linking tickets to assets through the Standard Data Model (SDM) Relationships layer.

This enables visibility of ticket information directly within the Asset Manager, allowing users to identify which assets are affected by tickets.

## SDM Relationships

Tickets are automatically linked to relevant DataMiner objects, including:

- Alarms
- Elements
- Services
- Assets

When a ticket is created from an alarm:

- The ticket is linked to the originating alarm.
- The associated element is linked automatically.
- If the element is linked to an asset, the asset is also linked to the ticket.

This behavior applies to both manual and automatic (using correlation) ticket creation.

## Asset Manager Integration

### Ticket Visibility

The Asset Manager uses the SDM Relationships layer to determine whether tickets are linked to an asset.

- Assets with linked tickets are indicated visually.
- Assets without linked tickets are shown without an active indicator.

### Accessing Tickets from an Asset

Tickets related to a specific asset can be accessed directly from the Asset Manager.

#### Procedure

1. Open the Asset Manager.
2. Locate the required asset.
3. Select the ticket indicator.

This opens the Ticketing application filtered for the selected asset.

### Behavior

When accessing tickets from the Asset Manager, only tickets linked to the selected asset are displayed.

If multiple tickets are created for alarms on the same element, and that element is linked to an asset, all those tickets will be visible when filtering by that asset.

## Use Cases

- View all tickets affecting a specific asset.
- Identify recurring issues on the same asset.
- Navigate from asset context to related tickets.
- Correlate alarms, elements, and tickets through shared asset relationships.

## Best Practices

- Ensure elements are correctly linked to assets in the Asset Manager.
- Use asset linking to enhance traceability between alarms and tickets.
- Monitor assets using ticket information for better operational awareness.
