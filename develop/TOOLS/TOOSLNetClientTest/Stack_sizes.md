---
uid: Stack_sizes
---

# Stack sizes

To get an overview of all stack sizes in the SLNet process, go to *Diagnostics* > *SLNet* > *StackSizes*.

A large value means a delay of client actions can be noticed. The default stack peak is 250000. When the maximum peak is reached, all items will be finished and no new items will be added to the queue (even after all items are finished). A DMA restart is needed.

![](~/develop/images/StackSizes.png)<br>
*SLNetClientTest Stack Sizes window*
