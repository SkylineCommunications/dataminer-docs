---
uid: Microbenchmarking
---

# Microbenchmarking

When code optimization is performed, measurements should be taken (microbenchmarking) in order to be able to confirm that the optimization is indeed improving performance and to get an estimation of the obtained performance gain. To perform measurements, the Stopwatch class (System.Diagnostics) can be used.

Some things to consider when microbenchmarking:

- During microbenchmarking, no other processes should be running (to avoid other processes impacting the microbenchmark).

- When measuring code that takes little time to execute, multiple iterations should be executed.

- The test could be optimized away by the language or JIT compiler (e.g., in Release mode).

- Often, the first measurement result is discarded, as this measurement can be influenced by startup costs.

- The measurement time overhead should be subtracted from the total measured time.
