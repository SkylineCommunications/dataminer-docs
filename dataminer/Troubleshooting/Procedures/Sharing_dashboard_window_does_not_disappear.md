---
uid: Sharing_dashboard_window_does_not_disappear
---

# 'Sharing dashboard' window does not disappear

When you try to share a dashboard, you should get a pop-up window that asks you to enter e.g., the email address of the person you want to share the dashboard with. If, instead, you see a loading window that keeps on saying *Sharing dashboard*, follow the actions detailed below, in the specified order:

1. [Exit the loading window and try sharing the dashboard again](#exit-the-loading-window-and-try-sharing-the-dashboard-again)
1. [Check the SSL configuration](#check-the-ssl-configuration)

## Exit the loading window and try sharing the dashboard again

The pop-up window might not have loaded properly.

1. Exit the *Sharing dashboard* window by clicking the **X** in the top-right corner.
1. Try sharing the dashboard again.

## Check the SSL configuration

If you are unable to share the dashboard, check the SSL configuration.

1. Open *Internet Information Services (IIS) Manager*.
1. In the *Connections* pane on the left, select the *localhost* and go to *Sites* > *Default Web Site*.
1. In the *Actions* pane on the right, click *Bindings...*
1. In the *Site Bindings* window, select the binding of type "https" and click *Edit...* If no such binding is present in the list, then create one first.
1. In the *Edit Site Binding* window showing the details of the https binding, check the SSL certificate.
 
   The name of the selected certificate should consist of the DMA name followed by ".skyline.local". If this is not the case, then open the selection box and select the correct certificate.

1. Close *Internet Information Services (IIS) Manager*.
1. Try sharing the dashboard again
