---
uid: Alarm_Cards
---

# Alarm cards

Alarm cards in the Monitoring app display the following information:

- *Current value*: The current value of the parameter in alarm. If it is a write parameter, you can click the wrench icon to modify the parameter value.

- *Details*: Detailed alarm information, such as the status of the alarm, the alarm owner, etc.

- *Properties*: The properties of the alarm and the element on which the alarm occurred.

- *Impact*: The elements, services and views affected by the alarm.

In the header of the card, two buttons are available:

- *Mask*: Allows you to mask or unmask the alarm or element. If you mask the alarm or element, a pop-up window will appear in which you need to indicate whether the alarm or element should be masked until it is unmasked, masked until the alarm is cleared, or masked for a limited period of time. Optionally, you can also specify a comment.

- *Ownership*: Allows you to take or release ownership of the alarm.

Alarm cards can be accessed from the Alarm Console, but you can also navigate directly to an alarm card by specifying the following URL:

- From DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 onwards<!--RN 41059-->: `https://<DMA IP>/monitoring/alarm/<DMA ID>/<element ID>/<root alarm ID>/<alarm ID>`

- Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12: `http(s)://<DMA IP>/monitoring/alarm/<DMA ID>/<root alarm ID>/<alarm ID>`

> [!NOTE]
> For both versions of the URL path, the alarm ID is optional and can be omitted.
