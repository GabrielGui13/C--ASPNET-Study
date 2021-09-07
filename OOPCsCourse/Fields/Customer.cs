using System;
using System.Collections.Generic;

public class Customer {
    public int Id;
    public string Name;
    public readonly List<Order> Orders = new List<Order>(); //no matter which constructor is called, the list is always initialized

    public Customer(int id) {
        this.Id = id;
    }

    public Customer(int id, string name) : this(id) {
        this.Name = name;
    }

    public void Promote() {
        // ...
        //Orders = new List<Order>(); //it would restart the list and lose data
        //readonly is responsible to allow initialization only once (at constructor or variable)
    }
}