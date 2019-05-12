using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCourse.Models.validator
{
    public interface IValidator<T>
    {
        IValidator<T> SetModel(T model);
        bool IsValid();
        String GetInformation();

    }
}
