/*! \mainpage Main Page
 * 
 * \section intro_sec Introduction
 * 
 * Technical Specification for the main Program Class<br>
 * PROJECT  :   SQ1 - EMS1<br>
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation;

namespace SQI_EMSI
{
    /*!
    * NAME     : Program<br>
    * PURPOSE  : The Program class is used to call the MainMenu of the UIMenu. It acts as the start point to the SQI-EMSI program.
    */
    class Program
    {
        static void Main(string[] args)
        {
            UIMenu.MainMenu();
        }
    }
}
