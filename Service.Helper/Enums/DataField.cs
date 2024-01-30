using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper.Enums
{
    public enum DataField
    {
        STAGE,
        FAB,
        PLANT,
        PRODUCT_LOCATION
    }

    public struct DataFieldName
    {
        public const string Plant = "Plant";

        public const string Fab = "Fab";

        public const string Stage = "Stages";

        public const string ProductLocation = "prod-uint";
    }
}
