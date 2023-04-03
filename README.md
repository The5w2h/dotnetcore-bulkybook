# dotnetcore-bulkybook
#### General
* Services are registered inside Program.cs
```
builder.Services.AddSomething<>();
```
#### Complete Dotnet Core Project for adding Books or Movies
* Partial Views:
  * **Do not** have a **page model**
  * Mostly used as **reusable** component in the Razor View
  * :bulb: Put in **Shared** folder
  * *Naming Convention* starts with **_**
  ```
  <partial name='_Notification'>
  ```
* If the partial view has to be used **in all the pages**, then use it in **_Layout.cshtml**
```
<div class="container">
        <main role="main" class="pb-3">
           <partial name="_Notification"/> <!--Used just before @RenderBody()-->
            @RenderBody()
        </main>
</div>
```
* #### Repository Pattern
* Domain Driven Design. Abstraction of data.
  **Benefit**: 
  - Minimizes duplicate logic.
  - Used to have independence from persistence framework, as Repository framework decouples app from persistence framework.
* Get(id), GetAll(param1, param2, ...., param n), GetFirstOrDefault(param1, ..., param n), Add(obj), Remove(obj)
  - ⚠️ **Update** method should be made separately, as update logic is *not common* for all obj. So, it should not be part of the common repository.

* Should NOT have methods like update or save, mimicking a DB.
* #### Unit of Work
  - Has single DB Context class and it coordinates with all the repositories
  - Has common DB context for all the repositories. ❓ *How is this beneficial?*
  - Controller ▶️ UNIT OF WORK ▶️ Entity Framework and DB
  - DBSet1 ... DBSetn, SaveChanges(). So, for multiple transactions are handled by a ❓ single SaveChanges() method.
  

