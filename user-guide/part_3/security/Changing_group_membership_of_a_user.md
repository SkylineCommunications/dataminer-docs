## Changing group membership of a user

1. In the *Users / Groups* section of the System Center module, go to the *users* tab and select the user in question.

    Alternatively, you can also open the user card for the user in question. See [Opening a user card](Opening_a_user_card.md).

2. Go to the *Group membership* tab.

3. If you are using a version of DataMiner prior to 9.5.4, click the *Edit* button in the lower right corner.

4. User the *ADD \>\>* and *\<\< REMOVE* buttons to move different groups to or from the *Available groups* and *Included in groups* columns.

5. Click the *Apply* button.

> [!NOTE]
> -  In DataMiner, you cannot add users to domain groups. Membership of domain groups is managed on the domain.
> -  To make it easier to manage permissions in complex systems, it can be useful to add users to more than one group. This way you can for example add an “Operator” group with basic permissions and access to the views that every operator should be able to see, and then add users to additional groups depending on the additional views and functionality they need to have access to.
>
