---
uid: Thread_Sleep
---

# Thread.Sleep

- When Thread.Sleep is used, the time to sleep should be at least 15 ms and it should be a multiple of 15 ms. This is considered best practice because the default System Timer Resolution (15 ms) will force values below 15 ms to use 15 ms instead. Actual values will always be a multiple of 15 ms. E.g. Sleep 16 will actually be 30 ms; Sleep 5 ms will be 15 ms. The default timer resolution can be changed by multimedia applications (e.g., Cube) up to 1 ms, which then influences any defined Thread.Sleep. A value of 3 ms can then actually be 3 ms, which means that the actual measured impact on a platform may change in comparison with the default timer resolution of 15 ms.

- Using Thread.Sleep in a protocol should be exceptional. A good reason must be present to introduce a Sleep. Verify therefore the usefulness and that it does not e.g., introduce long execution times.
