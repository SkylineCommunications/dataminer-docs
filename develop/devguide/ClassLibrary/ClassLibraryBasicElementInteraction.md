---
uid: ClassLibraryBasicInteraction
---

# Elements basic interaction

The [IDms](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDms) interface provides the following methods to retrieve elements from a DataMiner System:

- [GetElement](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDms.GetElement*)
- [GetElementReference](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDms.GetElementReference*)
- [GetElements](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDms.GetElements)

The GetElementReference can be used in cases where you know the element with the specified ID exists on the system.
This method avoids an additional SLNet call that is always executed when performing a GetElement call.

The [IDma](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDma) interface also provides methods to retrieve elements that are hosted on that Agent.
In general, it is recommended to use the method from the IDms interface unless you have a specific scenario where you need to retrieve elements from a specific agent.

- [GetElement](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDma.GetElement*)
- [GetElements](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDma.GetElements*)

To verify whether an element exists, both the IDms and IDma interface provide the following method:

- [ElementExists (IDms)](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDms.ElementExists*)
- [ElementExists (IDma)](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDma.ElementExists*)

Note that the ElementExists method of the IDma interface only returns true if the element is actually hosted on that Agent.

To update the state of an element, one of the following methods can be used:

- [Pause](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDmsElement.Pause)
- [Restart](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDmsElement.Restart)
- [Start](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDmsElement.Start)
- [Stop](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDmsElement.Stop)

To delete an element, call the [Delete](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDmsElement.Delete) method on the element object.

An element can be duplicated by calling the [Duplicate](xref:Skyline.DataMiner.Core.DataMinerSystem.Common.IDmsElement.Duplicate(System.String,Skyline.DataMiner.Core.DataMinerSystem.Common.IDma)) method on the element object.
