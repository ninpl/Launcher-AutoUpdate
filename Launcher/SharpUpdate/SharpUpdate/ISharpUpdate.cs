using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Reflection;

namespace SharpUpdate
{
    /// <summary>
    /// The interface that all applications need to implement in order to use SharpUpdate
    /// </summary>
    public interface ISharpUpdate
    {
        /// <summary>
        /// The name of your application as tou want it displayed on the update form
        /// </summary>
        string ApplicationName { get; }

        /// <summary>
        /// An identifier string to use to identify your application in the ipdate.xml
        /// Should be the same as your appId in the update.xml
        /// </summary>
        string ApplicationID { get; }

        /// <summary>
        /// The current assembly
        /// </summary>
        Assembly ApplicationAssembly { get; }

        /// <summary>
        /// The application´s icon to be displayed in the top left
        /// </summary>
        Icon ApplicationIcon { get; }

        /// <summary>
        /// The location of the update.xml on a server
        /// </summary>
        Uri UpdateXmlLocation { get; }

        /// <summary>
        /// The context of the program.
        /// For windows form applications, use "this".
        /// Console apps, reference System.Windows.Froms and return null.
        /// </summary>
        Form context { get; }
    }
}
