using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
   
   public class NotFoundException : Exception
   {
      public string AdditionalMessage { get; set; }
      public NotFoundException() : base()
      {
      }
      public NotFoundException(string? message) : base(message)
      {
      }
      public NotFoundException(string? message, string additionalMessage) : base(message)
      {
         this.AdditionalMessage = additionalMessage;
      }
      public NotFoundException(string? message, Exception? innerException): base(message, innerException)
      {

      }
   }
}
