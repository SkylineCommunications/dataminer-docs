---
uid: SwarmingElements
---

# Swarming elements

With DataMiner Swarming, you can swarm elements from one DataMiner Agent to another within a cluster. You can do so [in DataMiner Cube](#swarming-elements-in-dataminer-cube) or [via an Automation script](#swarming-elements-via-automation).

When you are swarming an element so it gets hosted on a different DataMiner Agent, a temporary transition occurs. The element will be stopped and then started again on a new host. While this happens, a message will be displayed to inform users that the element is currently swarming. The ability to open element cards or change the element configuration for the involved element will be temporarily suspended. Once the element migration is complete, it will become accessible again.

At present, Swarming is not yet supported for certain specific types of elements. Refer to [Upcoming features](xref:Swarming#upcoming-features) for information on which types of elements are supported already and which will supported in the future.

Because of the way Swarming functions, it is not possible to swarm smart-serial elements in server mode, elements polling localhost, and elements receiving SNMP traps in a DMS with trap distribution disabled on at least one DMA.

> [!NOTE]
> To be able to trigger swarming for an element, you need the [Swarming](xref:DataMiner_user_permissions#modules--swarming) user permission as well as config rights on the element. Users that have the [Import DELT](xref:DataMiner_user_permissions#general--elements--import-delt) and [Export DELT](xref:DataMiner_user_permissions#general--elements--import-delt) user permissions will automatically also get the *Swarming* user permission when DataMiner is upgraded from a version that does not support Swarming to a version that does support it.

## Swarming elements in DataMiner Cube

To swarm elements in DataMiner Cube:

1. Go to *System Center* > *Agents* > *Status* and click the *Swarm* button in the lower-right corner.

1. On the left, select the element(s) you want to swarm.

1. On the right, select the destination DMA.

   ![Swarming UI in Cube](~/dataminer/images/Swarming_Tutorial_Enable_Cube_Swarm.png)<br>*Swarming UI in DataMiner 10.5.3*

1. Click *Swarm*.

   From DataMiner 10.5.9/10.6.0 onwards<!--RN 43196-->, an information event will be generated when an element has been successfully swarmed. Example:

   `Swarmed from <DmaName> (<DmaId>) to <DmaName> (<DmaId>) by <UserName>`

   > [!NOTE]
   > When the source DMA is no longer available or unknown, the information event will be shortened to `Swarmed to <DmaName> (<DmaId>) by <UserName>`.

## Swarming elements via Automation

To swarm elements via an Automation script, call the SwarmingHelper.Create method and indicate the elements that need to be swarmed and the ID of the node they need to be swarmed to.

For example:

```csharp
Skyline.DataMiner.Net.Swarming.SwarmingResult[] swarmingResults = Skyline.DataMiner.Net.Swarming.Helper.SwarmingHelper.Create(engine.GetUserConnection())
           .SwarmElement(new ElementID(123, 456))
           .ToAgent(789);
```

For more detailed examples, refer to [Configuring a script to swarm elements](xref:SwarmingScriptElement).

## Blocking elements from being swarmed

From DataMiner 10.5.5/10.6.0 onwards<!--RN 42535 + 42536-->, it is possible to block specific elements from being swarmed.

To do so, when you create or edit an element in DataMiner Cube, expand the *Advanced element settings* section and select *Block Swarming*.

![Block Swarming in Cube](~/dataminer/images/Swarming_Element_BlockSwarming.png)

By default, this checkbox is not selected for new and existing elements.

If the checkbox is selected for an element and a user tries to swarm the element, this will result in the error message *Element is not allowed to swarm (blocked)*.
