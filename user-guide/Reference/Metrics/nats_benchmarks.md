---
uid: nats_benchmarks
---

# NATS benchmarks

## Specifications of the test servers

### Client

- Intel Core i7-8700 CPU @ 3.20GHz
- 32GB RAM
- Hosting all clients

### Servers

- All servers hosted on 1 VM host

    - Intel Xeon Silver 4210R CPU @ 2.40GHz
    
        - Split across 6 VMs

    - 200GB RAM

        - Split across 6 VMs

- 3x VM

## Benchmarks

| \# | Specification | Message Size | Messages/s processed per node | Total bandwidth per node (Mbps) | Average CPU usage per node |
| -- | -- | -- | -- | -- | -- |
| 1 | Publishing small messages as fast as possible, without handling them (see note) | 45 bytes | ~530.000 | ~300 | ~3% |
| 2 | Publishing large messages as fast as possible, without handling them (see note) | 1 MB | ~35 | ~300 | ~2% |

> [!NOTE]
> Tests were limited by the client machine, capping out the network interface at a constant 1 Gbps.
