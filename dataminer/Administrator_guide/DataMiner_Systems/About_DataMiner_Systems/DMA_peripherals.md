---
uid: DMA_peripherals
description: "Learn how, in some setups, special third-party interfacing hardware called 'DMA peripherals' is used to connect a DMA to third-party devices."
---

# DMA peripherals

In some network setups, special third-party interfacing hardware called "DMA peripherals" is used to connect a DMA to third-party devices. Typically, the intelligence is embedded in the DMA, while the peripherals are used for medium interfacing and conversion.

Frequently used peripherals include:

- Serial Gateway (RS232 and/or RS485 ports)
- IO Gateway (analog and digital IOs)
- HMS Gateway (RF ports, HMS compliant)
- GPIB Gateway (IEEE-488 ports)
- ...

> [!NOTE]
> When interfacing with IO gateways through DataMiner connectors, the following guidelines should be taken into account.
>
> - All analog and digital IOs must be listed in a normalized way so that they reflect the actual voltage/status.
> - Create a virtual protocol that contains the parameters to be included in the virtual element.
> - Specify the necessary multiplication and offset factors in order to deal with parameter units (e.g., 0.1 V/oC)
> - Virtual protocol design is independent of the IO Gateway being used.
