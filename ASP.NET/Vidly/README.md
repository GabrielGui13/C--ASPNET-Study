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