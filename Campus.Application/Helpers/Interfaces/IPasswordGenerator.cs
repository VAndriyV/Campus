using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Application.Helpers.Interfaces
{
    public interface IPasswordGenerator
    {
        string GetRandomAlphanumericString(int length = 8);
    }
}
