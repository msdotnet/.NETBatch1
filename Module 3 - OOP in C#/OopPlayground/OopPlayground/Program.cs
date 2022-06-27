// See https://aka.ms/new-console-template for more information
using OopPlayground.Core;


//BaseClass dc = new DerivedClass("Initializing readonly Filed");
////Console.WriteLine(dc.DerivedClassMethod());
//Console.WriteLine(dc.BaseAbstractMethod());
//Console.WriteLine(dc.Property);
//Console.WriteLine(dc.Field);
//Console.WriteLine(dc.GetFieldValue());


List<BaseClass> list = new List<BaseClass>()
{
   new DerivedClass("Initializing readonly Filed from DerivedClass"),
   new DerivedClass1("Initializing readonly Filed from DerivedClass1")
};

foreach(var obj in list){
   
   Console.WriteLine(obj.BaseAbstractMethod());
   Console.WriteLine(obj.Property);
   Console.WriteLine(obj.Field);
   Console.WriteLine(obj.GetFieldValue());
   Console.WriteLine("\n");
}



