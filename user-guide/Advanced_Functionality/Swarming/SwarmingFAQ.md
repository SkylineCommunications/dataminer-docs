---
uid: SwarmingFAQ
---

# Frequently Asked Questions

## Can I swarm X/Y/Z?

Swarming will gradually become available for more and more functionality in DataMiner.
As of DataMiner 10.5.1, only basic elements are supported.

On the main [Swarming](xref:Swarming#upcoming-features) page, you can see a list of upcoming features.

## Does the ID of an element change when it is swarmed?

No, the identifier (DataMinerID/ElementID) of the element stays the same.

Each element also stores where it is hosted, that field is updated when swarmed.

More info in the next question below.

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

## Can I block an element from swarming?

Not in the initial release but is expected to be available in DataMiner 10.5.5/10.6.0.

## What happens with my Elements folder on disk?

The configuration of an element used to be stored in an [XML file on disk](xref:Elements1).

In order for Swarming to work, every agent needs to be able to access all data of an element, including its configuration.
For that reason the configuration has been moved to the shared database instead.
This data migration happens automatically during DataMiner startup.

Note that this only happens if you enable Swarming, otherwise nothing is changed.

## How does the element license work?

Licensing is unchanged for elements.

There is still a limit in play per agent and you cannot swarm elements to go over it.
Once you swarm an element over and the limit is reached, it will move over, but not start up.

This is the same behavior as if you would have created a new element instead.

Note that the Swarming request will return as a failure if this happens.

## How do I know why my element is not Swarmable?

This is currently not visible anywhere in DataMiner Cube.
The only way right now is to swarm that element and look at the error message.

## How does an agent know which elements to host when it starts up?

This info is stored in database together with the element.
Each element has a field storing its current host.
When an element swarms to another agent, this field is updated.
