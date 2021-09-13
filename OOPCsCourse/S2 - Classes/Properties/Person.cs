using System;

public class Person {

    public DateTime Birthdate { get; private set; } //set acessible only in class
    public int Age {
        get {
            var timeSpan = DateTime.Today - Birthdate;
            var years = timeSpan.Days/365;

            return years;
        }
    }

    public Person(DateTime birthdate) {
        Birthdate = birthdate;
    }
}