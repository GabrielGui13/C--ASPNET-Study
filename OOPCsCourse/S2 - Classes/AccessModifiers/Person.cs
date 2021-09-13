using System;

public class Person { //PaskoCase => for classes and methods
    private DateTime _birthdate; // _ + camelCase => good practices

    public void SetBirthdate(DateTime birthdate) {
        this._birthdate = birthdate;
    }

    public DateTime GetBirthdate() {
        return this._birthdate;
    }
}