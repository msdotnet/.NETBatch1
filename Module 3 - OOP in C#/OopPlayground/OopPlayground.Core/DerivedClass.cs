namespace OopPlayground.Core
{
   public class DerivedClass : BaseClass
   {
      public override string Property
      {
         get => "Specialized property available to DerivedClass instance";
      }
      public DerivedClass(string field) : base(field)
      {
      }
      public override string BaseAbstractMethod()
      {
         return "Returned from a abstract method implementation";
      }
      public string DerivedClassMethod()
      {
         return "Returned from Extended Derived method";
      }
      public new string GetFieldValue()
      {
         return $"{base.Field} value from DerivedClass";
      }
   }
   public class DerivedClass1 : BaseClass
   {
      public DerivedClass1(string field) : base(field)
      {
      }
      public override string BaseAbstractMethod()
      {
         return "Returned from a abstract method implementation from DerivedClass1";
      }
   }
}
