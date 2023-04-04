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
  ```cSharp
  <partial name='_Notification'>
  ```
* If the partial view has to be used **in all the pages**, then use it in **_Layout.cshtml**
```cSharp
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

## 💡: Steps for adding a new Model in DOTNET CORE:
* Add a new model class add the prop with DataAnnotations
* Migrate using NuGet Package Console
	```powerShell
	add-migration AddModelToDb
	update-database
	```
* Update the repositories
	*   Update IXRepository
	*   Update XRepository
	*   Update IUnitOfWork for new XRepository
	*   Update UnitOfWork for new XRepository
 
 #### ⭐ Areas
 * To segregate the Views and Controllers into different section e.g. Admin and Non-Admin, use Areas. Areas have their own MVC i.e., Models, Views and Controllers
 * Areas is a folder structure that has Areas with separate subfolders for *Controllers, Data, Models and Views*. So, if scaffolding is not possible, then create this folder structure.
 * *_Layout, _ViewImports, _ViewStart* **should be present in each of the Views folders**
 * Below code changes are important. 1) TagHelper asp-area

```cSharp
// Inside _Layouts, asp-area shows in which subfolder, controller and action be looked at
<li class="nav-item">
     <a class="nav-link" asp-area="Customer" asp-controller="Home" asp-action="Index">Home</a>
</li>
```
```cSharp
// In Program.cs
app.MapControllerRoute(
    name: "default",
    //area is included here
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
```

  

