namespace OopPlayground.Core
{
   public abstract class BaseClass
   {
      public readonly string Field;
      public virtual string Property{ 
         get => "Generic property available to all";
      }
      public BaseClass(string field)
      {
         this.Field = field;
      }
      public abstract string BaseAbstractMethod();
      public string GetFieldValue()
      {
         return $"{Field} value from BaseClass";
      }
   }
}
