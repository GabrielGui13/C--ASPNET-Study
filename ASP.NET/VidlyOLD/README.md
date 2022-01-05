## To create a project
* New project
* Aplicativo Web ASP.NET (.NET Framework) / Web Application ASP.NET (.NET Framework)

#### Keyboard Shortcuts
* Ctrl + F5 = Compile the application
* Ctrl + Shift + B = Build the application
* Alt + G + P = Open Package Manager Console (Needs to be created in Options/Keyboard)

#### Code Snippets
* mvcaction4 => public ActionResult Action() { return View(); }
* 

#### Razor Syntax
* @Html.ActionLink() => To redirect to another action in a controller
* @Html.DisplayNameFor(m => m.*) => To show a model attribute's name
* @Html.DisplayFor(m => m.*) => To show a model attribute's value
* @Html.BeginForm() => initializes a "<form>" tag, it's used with a @using (Html.BeginForm()) {} to close the tag calling Dispose
* @Html.LabelFor(m => m.*) => Almost the same as DisplayNameFor, but semantically is used as a form input label
* @Html.TextBoxFor(m => m.*) => Initializes a "type=text" input
* @Html.CheckBoxFor(m => m.*) => Initializes a "type=checkbox" input
* @Html.DropDownListFor(m => m.modelId, new SelectList(modelList, "ValueAttr", "TextAttr"), "First element text", htmlAttributes ) => to create a dropdown list (<select> <option>)
* @Html.HiddenFor(m => m.*) => hidden input usually used for id
* @Html.ValidationMessageFor(m => m.*) => used to display a message in the form, to turn red, a custom css class called 'field-validation-error' ('input-validation-error' for input) needs to be created, also the display message can be changed in model data annotations
* @Html.ValidationSummary(true, "Custom message") => used to display all validation errors in a list, when true is passed by parameter, a custom message can be set to show only once above the form
* @Html.AntiForgeryToken() => used to prevent CSRF attacks, by maintaining data in cookies, to enable it, this attribute needs to be inside the form tag and [ValidateAntiForgeryToken] needs to be used in form target action
* @section scripts { @Scripts.Render("~/bundles/jqueryval") } => used to enable bundles, in this case its enabling jquery validation in client-side

#### Packages
* Install-Package Microsoft.AspNet.WebApi.Core -Version 5.2.7 => Enable https requests
* Install-Package Microsoft.AspNet.WebApi.WebHost => Enable https requests
* Install-Package Microsoft.EntityFramework => Enable database ORM


## Autenticação
* https://stackoverflow.com/questions/31960433/adding-asp-net-mvc5-identity-authentication-to-an-existing-project

#### Instalacao de Pacotes
* Install-Package Microsoft.AspNet.Identity.Owin 
* Install-Package Microsoft.AspNet.Identity.EntityFramework
* Install-Package Microsoft.Owin.Host.SystemWeb

