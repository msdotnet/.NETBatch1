using System;

namespace TemperatureConverter
{
   internal class Program
   {
      static void Main(string[] args)
      {
         var instanceClass = new Child();
         var name = instanceClass.ReturnName("Chulbul");
         Console.WriteLine($"Name: {name}");
         var age = 28;
         var increment = 5;

         Console.WriteLine($"Age: {Child.ReturnAge(age: ref age, increment:increment)}");
         Console.WriteLine($"Age: {age}");

         Console.WriteLine($"Parent Name: {instanceClass.ReturnParentName("Big Boss")}");

         Console.WriteLine($"Family Tree: {instanceClass.ReturnFamilyTree("Father", "Gandfather")}");

         var family = new Family { Age = 29, Name = "Chulbul Family" };
         Console.WriteLine($"Passed Name: {family.Name}");

         var familyReturned = instanceClass.ReturnAgeAndName(family);
         Console.WriteLine($"Name: {familyReturned.Name}, Age: {familyReturned.Age}");

         var familyReturnedAsTupple = instanceClass.ReturnAgeAndNameWithTupple(family);
         Console.WriteLine($"Name: {familyReturnedAsTupple.Name}, Age: {familyReturnedAsTupple.Age}");
         
         Console.WriteLine($"Passed Name: {family.Name}");
      }
   }
   class Child : Parent
   {
      internal string ReturnName(string name)
      {
         return $"{name} Pandey";
      }
      internal static int ReturnAge(ref int age, int ageHike = 1, int increment = 0)
      {
         age = age + increment + ageHike;
         return age;
      }
      internal override string ReturnParentName(string name)
      {
         return $"{name} Overridden Pandey";
      }
      internal Family ReturnAgeAndName(Family family)
      {
         family.Name = $"{family.Name} Pandey";
         return family;
      }

      internal (string Name, int Age) ReturnAgeAndNameWithTupple(Family family)
      {
         family.Name = $"{family.Name} Pandey";
         family.Age = 30;
         return (family.Name, family.Age);
      }

      internal string ReturnFamilyTree(params string[] name)
      {
         return $"{name[0]}, {name[1]} Pandey";
      }
   }
   class Parent
   {
      internal virtual string ReturnParentName(string name)
      {
         return $"{name} Pandey";
      }

   }
   class Family
   {
      public int Age; // Field
      public string Name { get; set; } // Prop
   }
}
