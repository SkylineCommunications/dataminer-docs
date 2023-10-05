---
uid: Cassandra_Java_updating
---

# Updating Java for Cassandra

By default, DataMiner installs Cassandra with its own Java 8 installation. This is typically located in *C:\Program Files\Cassandra\Java\bin*. DataMiner deploys Cassandra with **Java 1.8.0_91**. Cassandra depends on **Java 8**. We **do not recommend** deploying Java 11.

> [!TIP]
>
> - A PowerShell script to update the Java version is available at [Cassandra Hardening](https://github.com/SkylineCommunications/cassandra-hardening).
> - If you do not want the hassle of maintaining the DataMiner storage databases yourself, we recommend using [DataMiner Storage as a Service](xref:STaaS) instead.

To update the Java version:

1. Download the latest OpenJDK 8 JRE binaries from the official website.

   > [!NOTE]
   > You can download the latest OpenJDK 8 JRE binaries from [the OpenJDK Wiki](https://wiki.openjdk.java.net/display/jdk8u/Main). Make sure to download the **Windows x64** archive. For example: *OpenJDK8U-jre_x64_windows_8u322b06.zip*

1. Stop the DataMiner Agent.

1. Stop the *Cassandra* service.

1. Rename the *C:\Program Files\Cassandra\Java* folder to *C:\Program Files\Cassandra\Java_bak*.

1. Create a new *Java* folder in *C:\Program Files\Cassandra*.

1. Extract the OpenJDK archive you downloaded and copy the binaries to *C:\Program Files\Cassandra\Java*.

1. Start the *Cassandra* service.

1. Start the DataMiner Agent.
