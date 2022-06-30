using GenericComparator.Core.Generic;

namespace GenericComparator.Core
{
   public class Comparision: GenericComparision<int>
   {
      public bool CompareValues<TValue> (TValue firstValue, TValue secondValue)
      {
         if(firstValue == null || secondValue == null) { return false; }
         if(firstValue.Equals(secondValue))
         {
            return true;
         }
         return false;
      }
   }
}