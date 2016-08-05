using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CalculateException:Exception
    {
          public CalculateException(): base() {
          }

          public CalculateException(String message) : base(message) {
          }

          public CalculateException(String message, Exception innerException): base(message, innerException) {
          }

          protected CalculateException(SerializationInfo info, StreamingContext context): base(info, context) {
          }
    }
}
