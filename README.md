#### To change archives
<kbd>CTRL</kbd>+<kbd>TAB</kbd>

```csharp
    cw => Console.WriteLine("");
    ctor => public ClassName (parameters) {}
    prop => public int PropName { get; set; }
    try => 
        try { } 
        catch (System.Exception) {
            throw;
        }
    tryf =>
        try { }
        finally { }
    propfull => 
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
    for =>
        for (int i = 0; i < length; i++) { }
    forr => 
        for (int i = length - 1; i >= 0 ; i--) { }
    foreach => 
        foreach (var item in collection) { }
    while => 
        while (true) { }
    do =>
        do { } while (true)
    interface =>
        interface IName { }
```

