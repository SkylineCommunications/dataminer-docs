---
uid: Creating_tickets_with_the_Ticketing_Gateway_API
---

# Creating tickets with the Ticketing Gateway API

> [!IMPORTANT]
> The Ticketing Gateway API is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.

Before tickets can be created, there has to be at least one ticket field resolver, which will translate the third-party ticket fields into DataMiner ticket fields. The first time the Ticket Gateway starts up, a default resolver is automatically created. This default resolver contains a number of predefined fields. You can, however, also create a custom resolver.

> [!NOTE]
> Each ticket field resolver must have a unique name.

Example of how to create a default ticket field resolver:

```cs
private TicketFieldResolver CreateDefaultResolver()
{
    //Create a default resolver from the factory.
    var resolver = TicketFieldResolver.Factory.CreateDefaultResolver();
    string error;
    //Save the resolver.
    var success = Helper.SetTicketFieldResolver(out error, ref resolver);
    if (!success)
    {
        throw new Exception("Something went wrong when saving the TicketFieldResolver: " + error);
    }
    return resolver;
}
```

Example of how to create a custom ticket field resolver:

```cs
private TicketFieldResolver CreateCustomResolver()
{
    TicketFieldResolver resolver = TicketFieldResolver.Factory.CreateEmptyResolver("CustomResolver");
    //Choose the element which will use this resolver. Leave empty for no element
    resolver.ElementUsingResolver = new Skyline.DataMiner.Net.ElementID(123, 456);
    //The Empty resolver generated already contains a "State" field. Let's clear it and make our own.
    var fields = resolver.GetDataMinerFields2ThirdPartyFields();
    foreach (var field in fields)
    {
        resolver.RemoveDataMinerField(field.Key);
        resolver.RemoveThirdPartyField(field.Value);
    }
    resolver.StateResolver.Clear(); //Clear the custom states
    resolver.TicketLinkFields.Clear(); //Clear the link fields
    resolver.TicketLinkFields.Add("Links"); //Add a link field

    //Create a state field
    //First we create a StateEnum which contains the names and the integer values of the states.
    StateEnum DmaState = new StateEnum();
    DmaState.EnumName = "MyStates";
    DmaState.DynamicAdd("Created", 0);
    DmaState.DynamicAdd("Started", 1);
    DmaState.DynamicAdd("Paused", 2);
    DmaState.DynamicAdd("Stopped", 3);
    DmaState.DynamicAdd("Closed", 4);

    //We now link our custom ticket states to a DataMiner TicketState
    //I.e.: "Created" has value 0 and gets linked to TicketState.Open.
    resolver.StateResolver.Add(0, TicketState.Open); //Created
    resolver.StateResolver.Add(1, TicketState.Open); //Started
    resolver.StateResolver.Add(2, TicketState.Open); //Paused
    resolver.StateResolver.Add(3, TicketState.Closed); //Stopped
    resolver.StateResolver.Add(4, TicketState.Closed); //Closed

    //Now we add the state field
    resolver.AddOrUpdateNames(
        new TicketFieldDescriptor() //Here we add the descriptor for our "State" field
        {
            FieldDisplayName = "State”,
            FieldName = "State",
            FieldType = typeof(GenericEnumEntry<int>),
            IsThirdParty = false, //This is a DataMiner field
            IsDataMinerMaster = true, //When a clash of this field occurs, the value set by DataMiner is used
            Validator = new EnumValidator<int>(DmaState)
        },
        new TicketFieldDescriptor() //And we link the "State" to a third-party field "Status"
        {
            FieldDisplayName = "Status",
            FieldName = "Status",
            FieldType = typeof(string),
            IsThirdParty = true, //This is a third-party field
            IsDataMinerMaster = true,
            Validator = new TypeValidator<string>()
        });

    //Create a Username field.
    resolver.AddOrUpdateNames(
        new TicketFieldDescriptor()
        {
            FieldDisplayName = "User Name",
            FieldName = "User",
            FieldType = typeof(string),
            IsThirdParty = false, //This is a DataMiner field
            IsThirdPartyMaster = true,
            Validator = new UserValidator() //We know this is a user
        },
        new TicketFieldDescriptor()
        {
            FieldDisplayName = "Account Number",
            FieldName = "Accnr",
            FieldType = typeof(long),
            IsThirdParty = true, //This is a third party field
            IsThirdPartyMaster = true, //When a clash of this field occurs, the value set by the  element is used.
            Validator = new TypeValidator<long>() //The third-party system uses an account number instead of a user.
        });

    ...

    //Save the custom resolver.
    string error;
    if (!Helper.SetTicketFieldResolver(out error, ref resolver))
    {
        throw new Exception("Something went wrong when saving the TicketFieldResolver: " + error);
    }
    return resolver;
}
```

> [!NOTE]
>
> - If one of the TicketFieldDescriptors in a TicketFieldDescriptor pair mentions "*IsDataMinerMaster = true*" or "*IsThirdPartyMaster = true*", this line must also be mentioned for the other TicketFieldDescriptor. If either of these lines is set to false, this does not imply that the other case is true. As such, it is better to only specify one of these lines in case it is true, and otherwise to specify nothing. If neither of the lines is specified, and there are two conflicting ticket changes, the value of the field will be set to the most recent of the changes.
> - The *TicketFieldDescriptor* class has an *AlarmProperty* property, which can be used to link an alarm property to a ticket field.

Example of how to create a ticket:

```cs
private Ticket CreateTicket(TicketFieldResolver resolver)
{
    Ticket ticket = new Ticket();
    ticket.CustomFieldResolverID = resolver.ID;
    ticket.CustomTicketFields["Status"] = new GenericEnumEntry<int>(){Name = "Created", Value = 0};
    ticket.CustomTicketFields["User"] = "John";
    ticket.CustomTicketFields["Mail"] = "john@company.com";
    ...
    ticket.AddTicketLink("Links", TicketLink.Create(new Skyline.DataMiner.Net.ElementID(123, 456)) );
    string error;
    if(!Helper.SetTicket(out error, ref ticket))
        throw new Exception("Something went wrong while creating the ticket: " + error);
    return ticket;
}
```
