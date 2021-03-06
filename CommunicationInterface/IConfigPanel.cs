﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Communication.Interface
{
    public delegate void OnConfigChangeEvent(IConfigPanel ConfigPanel);
    
    /// <summary>
    /// Interface configure panel defination
    /// </summary>
    public interface IConfigPanel
    {
        /// <summary>
        /// return connection generated by config panel
        /// </summary>
        /// <returns></returns>
        string GetConnectionString();

        /// <summary>
        /// trigger when configuration changed
        /// </summary>
        event OnConfigChangeEvent OnConfigChange;
    }
}
