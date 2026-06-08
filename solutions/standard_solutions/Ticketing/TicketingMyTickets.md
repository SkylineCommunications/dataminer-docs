# My Tickets Functionality

## Overview

The *My Tickets* functionality allows users to view tickets assigned to them within the DataMiner Ticketing application.

This functionality depends on the identical email relationship between:

- The **DataMiner user account**
- The **People & Organizations Contact or Team**

A correct configuration ensures that users can easily select and view their assigned tickets.

---

## User and Contact Mapping

### Principle

Ticket assignment is based on **People & Organizations contacts**, not on DataMiner user accounts.

To allow a user to see their assigned tickets:

- A corresponding contact must exist in the People & Organizations module.
- This contact must use the **same e-mail address** as the DataMiner user account.

![My Tickets](~/solutions/images/Ticketing_MyTickets.png)
---

## Configuration

### Required Setup

1. Identify the **DataMiner user account**.
2. Create or update a corresponding **contact** in People & Organizations.
3. Ensure that:
   - The **e-mail address matches** the DataMiner user account.
4. Assign tickets to this contact.

---

## Best Practices

- Maintain consistent e-mail addresses between DataMiner users and contacts.
- Ensure each user has a corresponding contact entry.
- Avoid duplicate contacts with the same e-mail address.
- Validate the configuration during onboarding of new users.

---