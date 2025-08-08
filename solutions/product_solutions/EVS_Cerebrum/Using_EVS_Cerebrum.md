---
uid: Using_EVS_Cerebrum
---

# Working with the EVS Cerebrum application

To access the application:

1. Go to `http(s)://[DMA name]/root`.

1. Select *EVS Cerebrum* to start using the application.

## The EVS Cerebrum user interface

The UI of the EVS Cerebrum app consists of five main components:

![Low-Code App buttons](~/dataminer/images/EVS_Cerebrum_UI.png)

**Levels** (1): All available levels for a selected destination, including the connected source, if applicable.

**Categories** (2): All existing categories applied to sources and destinations. Filtering of sources and destinations is based on the selected category.

**Sources** (3): All source mnemonics available in Cerebrum.

**Destinations** (4): All destination mnemonics available in Cerebrum. Each destination button indicates the connected source, if applicable.

**Route connection buttons** (5): Contains two buttons (*Take* and *All Level Take*) that allow you to start the route connection setup.

## Establishing a route connection

- To establish a route connection:

  1. Select a source, destination, and level.

  1. Click the *Take* button.

     Once the route is established, the connected source will be visible on the designated destination and level(s).

- To set up routes for all levels simultaneously, click the *All level Take* button.

- To access an overview of the established route connections, navigate to the *Routes* page.

  ![*Routes* page](~/dataminer/images/Routes_page.png)

  The *Routes* table lists each destination level along with its corresponding source level.

  > [!NOTE]
  > Hover the mouse pointer over the table to access easy filtering.
  >
  > ![Easy filtering](~/dataminer/images/Easy_Filtering.png)
