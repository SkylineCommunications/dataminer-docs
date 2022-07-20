---
uid: Making_Cassandra_nodetool_accessible_remotely
---

# Making Cassandra nodetool accessible remotely

To run one of the commands of the [Standalone Cassandra Backup Tool](xref:Standalone_Cassandra_Backup_Tool) against a Cassandra cluster or a remote single-node Cassandra database, the Cassandra nodetool has to be accessible remotely.

The procedures below specify how you can make the Cassandra nodetool accessible remotely on a Windows server and on a Linux server.

## Windows

1. Open Regedit and go to the following key:

    ```txt
    Computer\HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Apache Software Foundation\Procrun 2.0\cassandra\Parameters\Java
    ```

1. Open the options key and add the following options:

    ```txt
    -Dcassandra.jmx.remote.port=7199
    -Dcom.sun.management.jmxremote.rmi.port=7199
    -Djava.rmi.server.hostname=10.11.1.44 (a publicly accessibly IP address to which the rmi server will listen)
    ```

1. On the host, add an inbound firewall rule to expose port 7199.

1. Restart Cassandra.

## Linux

1. In `/etc/Cassandra/cassandra-env.sh`, comment out the following lines by placing # in front of each line:

    ```txt
    #if [ "x$LOCAL_JMX" = "x" ]; then
    # LOCAL_JMX=yes
    #fi
    ```

1. In the same file, add the following lines:

    ```txt
    -Dcassandra.jmx.remote.port=7199
    -Dcom.sun.management.jmxremote.rmi.port=7199
    -Djava.rmi.server.hostname=10.11.1.44 (a publicly accessibly IP address to which the rmi server will listen)
    ```

1. On the host, add an inbound firewall rule to expose port 7199.

1. Restart Cassandra using **systemctl** (not service).

    ```txt
    sudo systemctl stop cassandra
    sudo systemctl start cassandra
    ```
