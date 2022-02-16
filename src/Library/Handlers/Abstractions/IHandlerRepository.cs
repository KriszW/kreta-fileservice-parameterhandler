﻿using Kreta.FileService.ParameterHandler.Library.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.FileService.ParameterHandler.Library.Handlers.Abstractions
{
    public interface IHandlerRepository
    {
        IParameterHandlerCommand GetCommand(string queryName, string queryValue);
    }
}
