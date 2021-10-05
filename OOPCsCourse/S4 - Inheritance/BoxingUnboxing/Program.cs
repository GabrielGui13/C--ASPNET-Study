using System;
using System.Collections;
using System.Collections.Generic;

namespace BoxingUnboxing
{
    class Program {
        public static void Main (string[] args) {
            var list = new ArrayList(); //problem with type safety
            //this arraylist accepts an object by parameter, so any value type we insert, will be boxed, and when we get it back using cast, unboxing will happen

            list.Add(1); //integer is value type, will be boxed
            list.Add("Gabriel"); //string is a reference, won't be boxed
            list.Add(DateTime.Today); //DateTime is a struct, a value type, will be boxed

            var number = (int) list[1]; //invalid cast exception, cast int to a string


            var anotherList = new List<int>(); //int as generic parameter
            anotherList.Add(1); //receives an argument of type integer, opposed to object
            //boxing will not happen, because the list store integers and not objects
        }
    }
}

/* 
	Stack: store all value/primitive types in memory, but temporarily
	Heap: store instance and reference types, with a longer lifetime
	Boxing: process of converting a value type instance to an object reference
	Unboxing: opposite, cast an object to a primitive type to store at stack
	Object: parent of all classes

	It's interesting to avoid boxing/unboxing due to extra object creation
 */