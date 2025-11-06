using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.utils
{
    public class InconPath
    {
        public static string GetRoomIconPath(string roomType, bool isAvailable, string projectPath)
        {
            string iconFileName = "";

            if (roomType.ToLower() == "single")
            {
                iconFileName = isAvailable ? "single_bed_available.png" : "single_bed_unavailble.png";
            }
            else if (roomType.ToLower() == "twin")
            {
                iconFileName = isAvailable ? "twin_bed_available.png" : "twin_bed_unavailable.png";
            }

            return Path.Combine(projectPath, "Resources", "icon", iconFileName);
        }

    }
}
