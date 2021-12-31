## Making an SLA generate tickets

On the *Ticket Creation* page of SLA elements, a parameter is provided that can be used to make DataMiner automatically generate tickets.

The parameter, *Generate Ticket*, can have five different values:

- Clear

- Create Ticket

- Create Ticket, second attempt

- Create Ticket, third attempt

- Unable to create ticket

To automatically generate tickets, this parameter must be used in conjunction with the Automation and Correlation modules in DataMiner.

### Example of usage

1. The SLA element detects an outage.

2. The *Generate Ticket* parameter is set to *Create Ticket* by an Automation rule that has been configured to do so when a particular outage occurs.

3. A Correlation rule, which has been configured to be triggered when the *Generate Ticket* parameter gets this value, activates a second Automation script.

4. The second Automation script requests a ticket number, posts the new ticket number value in the last column of the outage table, and sets the *Generate Ticket* parameter back to *Clear*.

> [!TIP]
> See also:
> -  [DMS Automation](../automation/automation.md#dms-automation) 
> -  [DMS Correlation](../correlation/correlation.md#dms-correlation) 
>
