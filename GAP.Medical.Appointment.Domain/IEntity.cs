﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GAP.Medical.Appointment.Domain
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
