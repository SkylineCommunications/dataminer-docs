---
uid: Protocol_threads
---

# Protocol threads

- Consider using separate protocol threads in cases where this could be beneficial, e.g., when multiple different types of functionality are implemented and can run independently of each other. However, make sure to verify that the implementation using multiple protocol threads actually performs better.
