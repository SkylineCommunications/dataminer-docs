---
uid: SLNetClientTest_Inspecting_the_stack_sizes_in_SLNet
description: "Inspect SLNet stack sizes in SLNetClientTest to assess delays, check the 250,000 default peak, and learn when a DMA restart is required."
---

# Inspecting the stack sizes in SLNet

To get an overview of all stack sizes in the SLNet process, go to *Diagnostics* > *SLNet* > *StackSizes*.

A large value means a delay of client actions can be noticed. The default stack peak is 250,000.

When the maximum peak is reached, all items will be finished and no new items will be added to the queue (even after all items are finished). A DMA restart will be needed.
