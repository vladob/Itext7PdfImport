using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfProcessingLibrary
{
    public class PasswordRequiredException(string message) : Exception(message)
    {
    }
}
