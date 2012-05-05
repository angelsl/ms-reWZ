﻿// This file is part of reWZ.
// 
// reWZ is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// reWZ is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with reWZ. If not, see <http://www.gnu.org/licenses/>.
// 
// Linking this library statically or dynamically with other modules
// is making a combined work based on this library. Thus, the terms and
// conditions of the GNU General Public License cover the whole combination.
// 
// As a special exception, the copyright holders of this library give you
// permission to link this library with independent modules to produce an
// executable, regardless of the license terms of these independent modules,
// and to copy and distribute the resulting executable under terms of your
// choice, provided that you also meet, for each linked independent module,
// the terms and conditions of the license of that module. An independent
// module is a module which is not derived from or based on this library.
// If you modify this library, you may extend this exception to your version
// of the library, but you are not obligated to do so. If you do not wish to
// do so, delete this exception statement from your version.

using System.Globalization;

namespace reWZ.WZProperties
{
    /// <summary>
    /// A directory in a WZ image. This cannot be located outside an image.
    /// </summary>
    public class WZSubProperty : WZProperty<WZNothing>
    {
        internal WZSubProperty(string name, WZObject parent, WZBinaryReader r, WZImage container) : base(name, parent, default(WZNothing), container, true)
        {
            WZExtendedParser.ParsePropertyList(r, this, Image, Image._encrypted).ForEach(Add);
        }
    }

    /// <summary>
    /// A "Convex" property, containing multiple nameless WZ properties.
    /// </summary>
    public class WZConvexProperty : WZProperty<WZNothing>
    {
        internal WZConvexProperty(string name, WZObject parent, WZBinaryReader r, WZImage container)
            : base(name, parent, default(WZNothing), container, true)
        {
            int count = r.ReadWZInt();
            for (int i = 0; i < count; ++i)
                Add(WZExtendedParser.ParseExtendedProperty(i.ToString(CultureInfo.InvariantCulture), r, this, Image, Image._encrypted));
        }
    }
}