---
uid: DSIEmberPlus
description: Ember+ is a control protocol allowing communication between a data provider and a consumer, consisting of three parts, i.e., Glow, EmBER, and S101.
---

# Ember+

Ember+ is a control protocol defined by the Lawo Group, allowing communication between two endpoints: a data provider (typically a device exposing a set of controllable parameters) and a consumer (typically a monitoring system).

The Ember+ specification consists of three parts:

- Glow: The data schema defining the data types used to convey Ember+ information.

- EmBER: The encoding used to store instances of the Glow-defined types.

- S101: The framing protocol used to transmit EmBER encoded data.

![Ember+ layers ](~/develop/images/EmberPlusLayers.jpg)

The Ember+ specification is available in the following location: <https://github.com/Lawo/ember-plus/blob/master/documentation/Ember%2B%20Documentation.pdf>.

To obtain the latest release, refer to <https://github.com/Lawo/ember-plus/releases>.

The following sections provide a brief overview of the different parts of Ember+. For more detailed information, refer to the specification.

- [Glow](xref:Glow)

- [EmBER](xref:EmBER)

- [S101](xref:S101)

- [Usage](xref:Usage2#usage)

- [Library](xref:Library)

- [DMS protocol](xref:DMS_protocol)

- [Viewer](xref:Viewer)
