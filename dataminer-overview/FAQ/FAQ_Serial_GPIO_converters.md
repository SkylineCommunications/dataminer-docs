---
uid: FAQ_Serial_GPIO_converters
---

# Does Skyline offer serial and GPIO converters?

## Devices in our portfolio

**RS-232** is the most common serial interface. It only allows for one transmitter and one receiver on each line (point to point only). RS-232 also supports the Full-Duplex transmission method (sending and receiving at the same time).

**RS-422** (EIA RS-422-A Standard) is the serial connection used on e.g. Apple computers. It provides a mechanism for transmitting data up to 10 Mbits/s. RS-422 sends each signal using two wires to increase the maximum baud rate and cable length. RS-422 is also specified for multi-drop (point to multipoint) applications where only one transmitter is connected, and it transmits on a bus of up to 10 receivers.

**RS-485** is a superset of RS-422 and expands on its capabilities. RS-485 was made to address the multi-drop limitation of RS-422, allowing up to 32 devices to communicate through the same data line. Any of the slave devices on an RS-485 bus can communicate with any other 32 slave devices without going through a master device. Since RS-422 is a subset of RS-485, all RS-422 devices may be controlled by RS-485.

Both RS-422 and RS-485 have multi-drop capability, but **RS-485** allows up to **32** devices and **RS-422** has a limit of **10**. For both communication protocols, you should provide your own termination. Evidently, this is used in a master/slave architecture. No slave is to send data unless it is requested to do so by the master (a.k.a. polling).

> [!NOTE]
> SLC can deliver such devices, but we recommend that our users purchase them locally. Please note that Skyline cannot be held responsible for the model the user selects. It is up to the user to look into the specifications of the elements that need such an add-on and to select the proper device.

## Product overview

| SLC Product Code | Brand     | Series    | Part Number      |
|------------------|-----------|-----------|------------------|
| DMS-IOGW-5000    | Advantech | ADAM-5000 | ADAM-5000/TCP-BE |
| DMS-IOGW-5013    | Advantech | ADAM-5000 | ADAM-5013-A1E    |
| DMS-IOGW-5017    | Advantech | ADAM-5000 | ADAM-5017-A1E    |
| DMS-IOGW-5050    | Advantech | ADAM-5000 | ADAM-5050-AE     |
| DMS-IOGW-5051-S  | Advantech | ADAM-5001 | ADAM-5051-AE     |
| DMS-IOGW-5052    | Advantech | ADAM-5000 | ADAM-5052-AE     |
| DMS-IOGW-5060    | Advantech | ADAM-5000 | ADAM-5060-AE     |
| DMS-IOGW-5068    | Advantech | ADAM-5000 | ADAM-5069-AE     |
| DMS-IOGW-6015    | Advantech | ADAM-6000 | ADAM-6015-BE     |
| DMS-IOGW-6017    | Advantech | ADAM-6000 | ADAM-6017-BE     |
| DMS-IOGW-6050    | Advantech | ADAM-6000 | ADAM-6050-BE     |
| DMS-IOGW-6052    | Advantech | ADAM-6000 | ADAM-6052-BE     |
| DMS-IOGW-6060    | Advantech | ADAM-6000 | ADAM-6060-BE     |
| DMS-IOGW-6066    | Advantech | ADAM-6000 | ADAM-6066-BE     |
| DMS-SGW-16       | Moxa      |           | NP-5650-16       |
| DMS-SGW-232-2    | Moxa      |           | NP-5210          |
| DMS-SGW-232-4    | Moxa      |           | NP-5410          |
| DMS-SGW-232-8    | Moxa      |           | NP-5610-8        |
| DMS-SGW-485-4    | Moxa      |           | NP-5430          |
| DMS-SGW-485-8    | Moxa      |           | NP-5630-8        |
| DMS-SGW-UNI-1    | Moxa      |           | NP-DE-311        |
