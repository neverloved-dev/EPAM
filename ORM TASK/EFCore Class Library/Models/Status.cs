using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Class_Library.Models
{
    public enum Status
    {
        NOT_STARTED,
        LOADING,
        ARRIVED,
        IN_PROGRES,
        UNLOADING,
        CANCELLED,
        DONE
    }
}
