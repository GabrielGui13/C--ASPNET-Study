using System;

namespace Constructors
{
    public class Human {
        private string firstName;
        private string lastName;
        private string eyeColor;
        private int age;

        //default constructor
        public Human() {
            Console.WriteLine("Constructor called. Object created");
        }

        //no eye color constructor
        public Human(string firstName, string lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        //no age constructor
        public Human(string firstName, string lastName, string eyeColor) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
        }

        // parameterized constructor
        public Human(string firstName, string lastName, string eyeColor, int age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            this.age = age;
        }

        public void IntroduceMyself() {
            if (age == 0 && eyeColor == null) 
                Console.WriteLine($"Hi, my name is {firstName} {lastName}.");
            else if (age == 0) 
                Console.WriteLine($"Hi, my name is {firstName} {lastName}. My eye color is {eyeColor}");
            else 
                Console.WriteLine($"Hi, my name is {firstName} {lastName} and I'm {age} year(s) old. My eye color is {eyeColor}.");
        }

    }
}