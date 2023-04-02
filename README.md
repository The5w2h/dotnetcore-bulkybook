# dotnetcore-bulkybook

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
  - :Exclamation: **Benefit**: Minimizes duplicate logic
  

