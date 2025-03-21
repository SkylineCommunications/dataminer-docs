---
uid: SwarmingFAQ
---

# Frequently asked questions

## Can I swarm X/Y/Z?

Swarming will gradually become available for more and more functionality in DataMiner.

As of DataMiner 10.5.1, only basic elements are supported.

For a list of upcoming features, see [Upcoming features](xref:Swarming#upcoming-features).

## Does the ID of an element change when it is swarmed?

No, the identifier (DataMiner ID/element ID) of an element that is swarmed stays the same.

Each element also stores where it is hosted, and that "Host ID" field is updated when the element is swarmed.

## What does the **DataMinerID** mean of an element that swarmed?

The meaning of a **DataMinerID** has slightly changed in a DMS with Swarming.

It used to be that every element has an **ElementID** that uniquely identifies it on a DataMiner agent.
However, once clusters of agents were created, these were no longer unique in the whole DMS, so the **DataMinerID** was added to the element identifier, which now consists of 2 number often shown as **DataMinerID/ElementID**.

You can see this identifier when you right click your element and open *properties*.

![What does the DataMinerID of an element mean](~/user-guide/images/Swarming_FAQ_DataMinerID.png)

To find the agent that was hosting the element, that same **DataMinerID** was used.
However this no longer works when swarming the element.
To keep the identifier unique in the DMS this **DataMinerID** cannot change.

To see the agent hosting the element in DataMiner Cube, you can click a parent view and scroll to the right until you see the **HOST ID** and **DATAMINER** column for the element.

Example below (with columns reordered for convenience):

![Hosting Agent in Cube](~/user-guide/images/Swarming_FAQ_HostingAgentCube.png)

To figure out the agent hosting the element in code, you can use the **HostingAgentID** property instead.

## Can I block an element from being swarmed?

Not in the initial release but is expected to be available in DataMiner 10.5.5/10.6.0.

## What happens with my Elements folder on disk?

When swarming is not enabled, the configuration of an element is stored in an [XML file on the DataMiner server](xref:Elements1).

In order for Swarming to work, every Agent needs to be able to access all data of an element, including its configuration. For this reason, the configuration is moved to the shared database instead. This data migration happens automatically during DataMiner startup after you enable Swarming.

## How does the element license work?

Enabling Swarming does not affect the licensing for elements.

There is still a limit in play per agent and you cannot swarm elements to go over it.
Once you swarm an element over and the limit is reached, it will move over, but not start up.

This is the same behavior as if you would have created a new element instead.

Note that the Swarming request will return as a failure if this happens.

## How do I know why my element is not swarmable?

The only way to see this in the UI at present is to attempt to swarm the element and look at the error message.

## How does an Agent know which elements to host when it starts up?

This info is stored in the database together with the element. Each element has a field storing its current host. When an element swarms to another Agent, this field is updated.
