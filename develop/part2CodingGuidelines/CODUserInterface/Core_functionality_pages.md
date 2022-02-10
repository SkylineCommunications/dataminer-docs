---
uid: Core_functionality_pages
---

# Core functionality pages

- A protocol is typically developed for a specific device (e.g. demodulator, integrated receiver/decoder (IRD), etc.). A protocol must reflect the functionality of the device by including a page for each functional block of the device. For example, a protocol for an integrated receiver/decoder should include a page for the receiver and a page for the decoder.

    These pages must contain the core parameters of the device, which should be a combination of status parameters and important configuration parameters. The order of these parameters should reflect the internal workflow of the device (e.g. in case of a decoder, first configure the frequency, then the modulation, etc.).
