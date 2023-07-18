Points to take into consideration:

1- The permissions are not important for performing CRUD operations in the system (User Sales). 
They are there solely for testing purposes to explore how a permission system could be based on user claims and modules.

2- Todo: At this point, I don't know what happens to the claims stored in the cookie for the currently logged-in user when the user updates their own claims.

3- To "update" a claim first you have to delete it in the database and then and it with the new value.
