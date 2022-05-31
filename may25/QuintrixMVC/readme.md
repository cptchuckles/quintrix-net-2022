# Quintrix MVC App, the second one

This app is a reboot of the project from 23 May

Features include:
 - Authentication: users can register and login/logout
 - Authorization: Certified **Gigachad**®™s are allowed to edit privileged tables.
 - Some CRUD entities:
   - `PiddlyThing`:
     - Public access: **view**
     - All Users: full control
   - `ValuableThing`:
     - Public access: **none**
     - All users: view
     - Authenticated `Gigachad`s: full control
